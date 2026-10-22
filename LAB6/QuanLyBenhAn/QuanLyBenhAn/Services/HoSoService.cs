using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    /// <summary>Phiếu đăng ký, hồ sơ bệnh án, lệ phí hằng năm.</summary>
    public class HoSoService
    {
        public DataTable Tim(string tuKhoa)
        {
            string k = "%" + (tuKhoa ?? "").Trim() + "%";
            return Db.Query(@"SELECT h.MaHoSo, b.MaBN, b.HoTen, b.NgaySinh, b.DienThoai, b.DiaChi, h.NgayCap, h.NgayHetHan,
                                     CASE WHEN h.NgayHetHan >= CAST(GETDATE() AS date) THEN N'Còn hạn' ELSE N'Hết hạn' END AS TrangThai
                              FROM HoSoBenhAn h JOIN BenhNhan b ON b.MaBN = h.MaBN
                              WHERE h.MaHoSo LIKE @k OR b.MaBN LIKE @k OR b.HoTen LIKE @k OR b.DienThoai LIKE @k
                              ORDER BY h.MaHoSo", new SqlParameter("@k", k));
        }

        public DataTable LayDanhSachCombo()
        {
            return Db.Query(@"SELECT h.MaHoSo, h.MaHoSo + N' - ' + b.HoTen AS HienThi
                              FROM HoSoBenhAn h JOIN BenhNhan b ON b.MaBN = h.MaBN ORDER BY h.MaHoSo");
        }

        public byte[] LayAnh(string maBN)
        {
            object o = Db.Scalar("SELECT Anh FROM BenhNhan WHERE MaBN = @m", Db.P("@m", maBN));
            return o as byte[];
        }

        public string LayHanHienThi(string maHoSo)
        {
            if (string.IsNullOrEmpty(maHoSo)) return "";
            object o = Db.Scalar("SELECT NgayHetHan FROM HoSoBenhAn WHERE MaHoSo = @h", Db.P("@h", maHoSo));
            if (o == null) return "";
            DateTime han = Convert.ToDateTime(o);
            return han.ToString("dd/MM/yyyy") + (han.Date >= DateTime.Today ? " (còn hạn)" : " (đã hết hạn)");
        }

        public KetQuaXuLy DangKyMoi(string maBN, string hoTen, string diaChi, DateTime ngaySinh, string dienThoai,
                                    byte[] anh, string maHoSo, decimal lePhi)
        {
            if (string.IsNullOrWhiteSpace(maBN) || string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(diaChi)
                || string.IsNullOrWhiteSpace(dienThoai) || string.IsNullOrWhiteSpace(maHoSo))
                return KetQuaXuLy.Fail("Phiếu đăng ký phải có mã bệnh nhân, mã hồ sơ, họ tên, địa chỉ, ngày sinh và điện thoại.");
            if (ngaySinh.Date >= DateTime.Today) return KetQuaXuLy.Fail("Ngày sinh phải trước ngày hôm nay.");
            if (!Regex.IsMatch(dienThoai.Trim(), @"^\d{9,11}$")) return KetQuaXuLy.Fail("Điện thoại chỉ gồm 9 đến 11 chữ số.");
            if (lePhi <= 0) return KetQuaXuLy.Fail("Phải đóng lệ phí năm (lớn hơn 0) mới được cấp hồ sơ bệnh án.");
            try
            {
                if (Db.Scalar("SELECT 1 FROM BenhNhan WHERE MaBN = @m", Db.P("@m", maBN)) != null)
                    return KetQuaXuLy.Fail("Mã bệnh nhân đã tồn tại. Nếu bệnh nhân đã có hồ sơ, hãy chọn hồ sơ trên lưới và dùng Gia hạn.");
                if (Db.Scalar("SELECT 1 FROM HoSoBenhAn WHERE MaHoSo = @m", Db.P("@m", maHoSo)) != null)
                    return KetQuaXuLy.Fail("Mã hồ sơ đã tồn tại.");

                DateTime ngayCap = DateTime.Today, hetHan = ngayCap.AddYears(1);
                var pAnh = new SqlParameter("@anh", SqlDbType.VarBinary, -1);
                pAnh.Value = (object)anh ?? DBNull.Value;
                using (var cn = Db.OpenConnection())
                using (var tr = cn.BeginTransaction())
                {
                    try
                    {
                        Db.Exec(cn, tr, "INSERT INTO BenhNhan(MaBN, HoTen, DiaChi, NgaySinh, DienThoai, Anh) VALUES(@m, @t, @d, @ns, @p, @anh)",
                            Db.P("@m", maBN), Db.P("@t", hoTen), Db.P("@d", diaChi), Db.P("@ns", ngaySinh.Date), Db.P("@p", dienThoai), pAnh);
                        Db.Exec(cn, tr, "INSERT INTO HoSoBenhAn(MaHoSo, MaBN, NgayCap, NgayHetHan) VALUES(@h, @m, @c, @x)",
                            Db.P("@h", maHoSo), Db.P("@m", maBN), Db.P("@c", ngayCap), Db.P("@x", hetHan));
                        Db.Exec(cn, tr, @"INSERT INTO PhieuDangKy(MaBN, MaHoSo, NgayDangKy, LePhi, TuNgay, DenNgay, LoaiDK)
                                          VALUES(@m, @h, @c, @lp, @c, @x, 'MOI')",
                            Db.P("@m", maBN), Db.P("@h", maHoSo), Db.P("@c", ngayCap), Db.P("@lp", lePhi), Db.P("@x", hetHan));
                        tr.Commit();
                        return KetQuaXuLy.Ok("Đã cấp hồ sơ " + maHoSo + ", có hiệu lực đến " + hetHan.ToString("dd/MM/yyyy") + ".");
                    }
                    catch (Exception ex) { try { tr.Rollback(); } catch { } return KetQuaXuLy.TuLoi(ex); }
                }
            }
            catch (Exception ex) { return KetQuaXuLy.TuLoi(ex); }
        }

        public KetQuaXuLy GiaHan(string maHoSo, decimal lePhi)
        {
            if (string.IsNullOrWhiteSpace(maHoSo)) return KetQuaXuLy.Fail("Chưa chọn hồ sơ cần gia hạn.");
            if (lePhi <= 0) return KetQuaXuLy.Fail("Lệ phí năm phải lớn hơn 0.");
            try
            {
                DataTable dt = Db.Query("SELECT MaBN, NgayHetHan FROM HoSoBenhAn WHERE MaHoSo = @h", Db.P("@h", maHoSo));
                if (dt.Rows.Count == 0) return KetQuaXuLy.Fail("Hồ sơ không tồn tại.");
                string maBN = Convert.ToString(dt.Rows[0]["MaBN"]);
                DateTime han = Convert.ToDateTime(dt.Rows[0]["NgayHetHan"]).Date;
                DateTime tu = han >= DateTime.Today ? han : DateTime.Today;   // còn hạn: cộng dồn; hết hạn: tính từ hôm nay
                DateTime den = tu.AddYears(1);
                using (var cn = Db.OpenConnection())
                using (var tr = cn.BeginTransaction())
                {
                    try
                    {
                        Db.Exec(cn, tr, "UPDATE HoSoBenhAn SET NgayHetHan = @x WHERE MaHoSo = @h", Db.P("@x", den), Db.P("@h", maHoSo));
                        Db.Exec(cn, tr, @"INSERT INTO PhieuDangKy(MaBN, MaHoSo, NgayDangKy, LePhi, TuNgay, DenNgay, LoaiDK)
                                          VALUES(@m, @h, @c, @lp, @t, @x, 'GIAHAN')",
                            Db.P("@m", maBN), Db.P("@h", maHoSo), Db.P("@c", DateTime.Today), Db.P("@lp", lePhi), Db.P("@t", tu), Db.P("@x", den));
                        tr.Commit();
                        return KetQuaXuLy.Ok("Đã gia hạn hồ sơ " + maHoSo + " đến " + den.ToString("dd/MM/yyyy") + ".");
                    }
                    catch (Exception ex) { try { tr.Rollback(); } catch { } return KetQuaXuLy.TuLoi(ex); }
                }
            }
            catch (Exception ex) { return KetQuaXuLy.TuLoi(ex); }
        }
    }
}
