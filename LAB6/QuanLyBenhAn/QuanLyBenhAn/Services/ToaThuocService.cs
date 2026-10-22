using System;
using System.Collections.Generic;
using System.Data;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    /// <summary>Lập toa thuốc, ghi nhận phản ứng phụ.</summary>
    public class ToaThuocService
    {
        /// <summary>Các phiếu khám chưa có toa thuốc.</summary>
        public DataTable LayPhieuChuaCoToa()
        {
            return Db.Query(@"SELECT p.MaPK,
                                     p.MaPK + N' - ' + n.HoTen + N' (' + CONVERT(nvarchar(16), p.NgayGioKham, 120) + N')' AS HienThi,
                                     p.TrieuChung
                              FROM PhieuKham p
                              JOIN HoSoBenhAn h ON h.MaHoSo = p.MaHoSo
                              JOIN BenhNhan n ON n.MaBN = h.MaBN
                              WHERE NOT EXISTS (SELECT 1 FROM ToaThuoc t WHERE t.MaPK = p.MaPK)
                              ORDER BY p.NgayGioKham DESC");
        }

        public DataTable LayDongToa()
        {
            return Db.Query(@"SELECT TOP 500 t.MaToa, t.MaPK, n.HoTen, c.MaThuoc, th.TenThuoc, c.SoLuong, c.LieuDung, c.PhanUngPhu
                              FROM ChiTietToa c
                              JOIN ToaThuoc t ON t.MaToa = c.MaToa
                              JOIN Thuoc th ON th.MaThuoc = c.MaThuoc
                              JOIN PhieuKham p ON p.MaPK = t.MaPK
                              JOIN HoSoBenhAn h ON h.MaHoSo = p.MaHoSo
                              JOIN BenhNhan n ON n.MaBN = h.MaBN
                              ORDER BY t.NgayLap DESC, t.MaToa, th.TenThuoc");
        }

        public DataTable LayToaTheoPhieu(string maPK)
        {
            return Db.Query(@"SELECT t.MaToa, th.TenThuoc, c.SoLuong, c.LieuDung, c.PhanUngPhu
                              FROM ToaThuoc t
                              JOIN ChiTietToa c ON c.MaToa = t.MaToa
                              JOIN Thuoc th ON th.MaThuoc = c.MaThuoc
                              WHERE t.MaPK = @p ORDER BY th.TenThuoc", Db.P("@p", maPK));
        }

        public KetQuaXuLy LapToa(string maToa, string maPK, DateTime ngayLap, string ghiChu, List<DongToaItem> dong)
        {
            if (string.IsNullOrWhiteSpace(maToa)) return KetQuaXuLy.Fail("Mã toa không được để trống.");
            if (string.IsNullOrWhiteSpace(maPK)) return KetQuaXuLy.Fail("Chưa chọn phiếu khám cần lập toa.");
            if (dong == null || dong.Count == 0) return KetQuaXuLy.Fail("Toa thuốc phải có ít nhất một loại thuốc.");
            var da = new HashSet<string>();
            foreach (var d in dong)
            {
                if (d.SoLuong <= 0) return KetQuaXuLy.Fail("Số lượng thuốc phải lớn hơn 0.");
                if (string.IsNullOrWhiteSpace(d.LieuDung)) return KetQuaXuLy.Fail("Mỗi thuốc phải có liều dùng.");
                if (!da.Add(d.MaThuoc)) return KetQuaXuLy.Fail("Một thuốc không được xuất hiện hai lần trong cùng toa.");
            }
            try
            {
                object o = Db.Scalar("SELECT NgayGioKham FROM PhieuKham WHERE MaPK = @p", Db.P("@p", maPK));
                if (o == null) return KetQuaXuLy.Fail("Phiếu khám không tồn tại.");
                if (ngayLap < Convert.ToDateTime(o)) return KetQuaXuLy.Fail("Toa thuốc không được lập trước thời điểm khám.");
                if (Db.Scalar("SELECT 1 FROM ToaThuoc WHERE MaPK = @p", Db.P("@p", maPK)) != null)
                    return KetQuaXuLy.Fail("Phiếu khám này đã có toa thuốc.");

                using (var cn = Db.OpenConnection())
                using (var tr = cn.BeginTransaction())
                {
                    try
                    {
                        Db.Exec(cn, tr, "INSERT INTO ToaThuoc(MaToa, MaPK, NgayLap, GhiChu) VALUES(@t, @p, @n, @g)",
                            Db.P("@t", maToa), Db.P("@p", maPK), Db.P("@n", ngayLap), Db.P("@g", ghiChu));
                        foreach (var d in dong)
                            Db.Exec(cn, tr, "INSERT INTO ChiTietToa(MaToa, MaThuoc, SoLuong, LieuDung) VALUES(@t, @m, @sl, @ld)",
                                Db.P("@t", maToa), Db.P("@m", d.MaThuoc), Db.P("@sl", d.SoLuong), Db.P("@ld", d.LieuDung));
                        tr.Commit();
                        return KetQuaXuLy.Ok("Đã lập toa " + maToa + " gồm " + dong.Count + " loại thuốc.");
                    }
                    catch (Exception ex) { try { tr.Rollback(); } catch { } return KetQuaXuLy.TuLoi(ex); }
                }
            }
            catch (Exception ex) { return KetQuaXuLy.TuLoi(ex); }
        }

        public KetQuaXuLy GhiPhanUng(string maToa, string maThuoc, string noiDung)
        {
            if (string.IsNullOrWhiteSpace(maToa) || string.IsNullOrWhiteSpace(maThuoc)) return KetQuaXuLy.Fail("Chưa chọn dòng thuốc trên lưới.");
            if (string.IsNullOrWhiteSpace(noiDung)) return KetQuaXuLy.Fail("Nội dung phản ứng phụ không được để trống.");
            try
            {
                int n = Db.Execute("UPDATE ChiTietToa SET PhanUngPhu = @n WHERE MaToa = @t AND MaThuoc = @m",
                    Db.P("@n", noiDung), Db.P("@t", maToa), Db.P("@m", maThuoc));
                return n > 0 ? KetQuaXuLy.Ok("Đã ghi nhận phản ứng phụ của thuốc.") : KetQuaXuLy.Fail("Không tìm thấy dòng thuốc.");
            }
            catch (Exception ex) { return KetQuaXuLy.TuLoi(ex); }
        }
    }
}
