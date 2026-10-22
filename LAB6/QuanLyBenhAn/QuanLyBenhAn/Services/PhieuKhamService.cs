using System;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    /// <summary>Phiếu khám bệnh và xét nghiệm.</summary>
    public class PhieuKhamService
    {
        public DataTable LayPhieuTheoHoSo(string maHoSo)
        {
            return Db.Query(@"SELECT p.MaPK, p.NgayGioKham,
                                     CASE p.LoaiKham WHEN 'DIEUTRI' THEN N'Điều trị' ELSE N'Khám định kỳ' END AS LoaiKham,
                                     b.HoTen AS TenBS, k.TenKhoa, p.TrieuChung, p.NhietDo, p.HuyetAp, p.KetLuan, p.VienPhi
                              FROM PhieuKham p
                              JOIN BacSi b ON b.MaBS = p.MaBS
                              JOIN Khoa k ON k.MaKhoa = p.MaKhoa
                              WHERE p.MaHoSo = @h ORDER BY p.NgayGioKham DESC", Db.P("@h", maHoSo));
        }

        public DataTable LayXetNghiem(string maPK)
        {
            return Db.Query(@"SELECT x.MaXN, x.TenXN, px.KetQua
                              FROM PhieuKham_XetNghiem px JOIN XetNghiem x ON x.MaXN = px.MaXN
                              WHERE px.MaPK = @p ORDER BY x.TenXN", Db.P("@p", maPK));
        }

        public KetQuaXuLy GhiNhan(string maPK, string maHoSo, DateTime ngayGio, string maBS, string maKhoa, string loai,
                                  string trieuChung, string nhietDoText, string huyetAp, string ketLuan,
                                  decimal vienPhi, bool daThanhToan)
        {
            if (string.IsNullOrWhiteSpace(maPK) || string.IsNullOrWhiteSpace(maHoSo) || string.IsNullOrWhiteSpace(maBS)
                || string.IsNullOrWhiteSpace(maKhoa) || string.IsNullOrWhiteSpace(trieuChung))
                return KetQuaXuLy.Fail("Phiếu khám phải có mã phiếu, hồ sơ, khoa, bác sĩ và triệu chứng.");
            if (ngayGio > DateTime.Now) return KetQuaXuLy.Fail("Ngày giờ khám không được ở tương lai.");
            if (vienPhi < 0) return KetQuaXuLy.Fail("Viện phí không được âm.");

            decimal? nhiet = null;
            if (!string.IsNullOrWhiteSpace(nhietDoText))
            {
                decimal t;
                if (!decimal.TryParse(nhietDoText.Trim().Replace(',', '.'), NumberStyles.Number, CultureInfo.InvariantCulture, out t) || t < 30 || t > 45)
                    return KetQuaXuLy.Fail("Thân nhiệt phải là số trong khoảng 30 đến 45 độ C.");
                nhiet = t;
            }
            if (!string.IsNullOrWhiteSpace(huyetAp) && !Regex.IsMatch(huyetAp.Trim(), @"^\d{2,3}/\d{2,3}$"))
                return KetQuaXuLy.Fail("Huyết áp nhập theo dạng tâm thu/tâm trương, ví dụ 120/80.");

            try
            {
                DataTable hs = Db.Query("SELECT NgayCap, NgayHetHan FROM HoSoBenhAn WHERE MaHoSo = @h", Db.P("@h", maHoSo));
                if (hs.Rows.Count == 0) return KetQuaXuLy.Fail("Hồ sơ bệnh án không tồn tại.");
                DateTime ngayCap = Convert.ToDateTime(hs.Rows[0]["NgayCap"]).Date;
                DateTime hetHan = Convert.ToDateTime(hs.Rows[0]["NgayHetHan"]).Date;
                if (ngayGio.Date < ngayCap) return KetQuaXuLy.Fail("Ngày khám không được trước ngày cấp hồ sơ (" + ngayCap.ToString("dd/MM/yyyy") + ").");
                if (Db.Scalar("SELECT 1 FROM BacSi WHERE MaBS = @b AND MaKhoa = @k", Db.P("@b", maBS), Db.P("@k", maKhoa)) == null)
                    return KetQuaXuLy.Fail("Bác sĩ được chọn không thuộc khoa điều trị đã chọn.");

                bool dinhKy = loai == QuyDinh.DinhKy;
                if (dinhKy)
                {
                    if (ngayGio.Date > hetHan) return KetQuaXuLy.Fail("Hồ sơ đã hết hạn lệ phí năm, không được khám định kỳ miễn phí. Hãy gia hạn hồ sơ.");
                    if (vienPhi != 0) return KetQuaXuLy.Fail("Khám sức khỏe định kỳ theo quý là miễn phí, viện phí phải bằng 0.");
                    object trung = Db.Scalar(@"SELECT 1 FROM PhieuKham WHERE MaHoSo = @h AND LoaiKham = 'DINHKY'
                                               AND YEAR(NgayGioKham) = @y AND DATEPART(QUARTER, NgayGioKham) = @q",
                        Db.P("@h", maHoSo), Db.P("@y", ngayGio.Year), Db.P("@q", QuyDinh.Quy(ngayGio)));
                    if (trung != null) return KetQuaXuLy.Fail("Quý " + QuyDinh.Quy(ngayGio) + "/" + ngayGio.Year + " bệnh nhân đã khám định kỳ rồi (mỗi quý một lần).");
                    daThanhToan = true;
                }
                else if (!daThanhToan)
                    return KetQuaXuLy.Fail("Chỉ ghi nhận phiếu khám sau khi bệnh nhân làm thủ tục xuất viện và thanh toán viện phí.");

                using (var cn = Db.OpenConnection())
                using (var tr = cn.BeginTransaction())
                {
                    try
                    {
                        Db.Exec(cn, tr, @"INSERT INTO PhieuKham(MaPK, MaHoSo, NgayGioKham, MaBS, MaKhoa, LoaiKham, TrieuChung, NhietDo, HuyetAp, KetLuan, VienPhi, DaThanhToan)
                                          VALUES(@p, @h, @ng, @bs, @k, @l, @tc, @nd, @ha, @kl, @vp, @tt)",
                            Db.P("@p", maPK), Db.P("@h", maHoSo), Db.P("@ng", ngayGio), Db.P("@bs", maBS), Db.P("@k", maKhoa), Db.P("@l", loai),
                            Db.P("@tc", trieuChung), Db.P("@nd", nhiet), Db.P("@ha", huyetAp), Db.P("@kl", ketLuan), Db.P("@vp", vienPhi), Db.P("@tt", daThanhToan));
                        if (dinhKy)   // đánh dấu lịch hẹn định kỳ của quý này là đã khám
                            Db.Exec(cn, tr, @"UPDATE LichHen SET TrangThai = 'DAKHAM'
                                              WHERE MaLH = (SELECT TOP 1 MaLH FROM LichHen
                                                            WHERE MaHoSo = @h AND TrangThai = 'DAHEN'
                                                              AND YEAR(NgayGioHen) = @y AND DATEPART(QUARTER, NgayGioHen) = @q
                                                            ORDER BY NgayGioHen)",
                                Db.P("@h", maHoSo), Db.P("@y", ngayGio.Year), Db.P("@q", QuyDinh.Quy(ngayGio)));
                        tr.Commit();
                        return KetQuaXuLy.Ok("Đã ghi nhận phiếu khám " + maPK + (dinhKy ? " (khám định kỳ miễn phí)." : "."));
                    }
                    catch (Exception ex) { try { tr.Rollback(); } catch { } return KetQuaXuLy.TuLoi(ex); }
                }
            }
            catch (Exception ex) { return KetQuaXuLy.TuLoi(ex); }
        }

        public KetQuaXuLy ThemXetNghiem(string maPK, string maXN, string ketQua)
        {
            if (string.IsNullOrWhiteSpace(maPK)) return KetQuaXuLy.Fail("Chưa chọn phiếu khám trên lưới.");
            if (string.IsNullOrWhiteSpace(maXN)) return KetQuaXuLy.Fail("Chưa chọn xét nghiệm.");
            try
            {
                if (Db.Scalar("SELECT 1 FROM PhieuKham WHERE MaPK = @p", Db.P("@p", maPK)) == null) return KetQuaXuLy.Fail("Phiếu khám không tồn tại.");
                if (Db.Scalar("SELECT 1 FROM PhieuKham_XetNghiem WHERE MaPK = @p AND MaXN = @x", Db.P("@p", maPK), Db.P("@x", maXN)) != null)
                    return KetQuaXuLy.Fail("Phiếu khám này đã có xét nghiệm đó.");
                Db.Execute("INSERT INTO PhieuKham_XetNghiem(MaPK, MaXN, KetQua) VALUES(@p, @x, @k)", Db.P("@p", maPK), Db.P("@x", maXN), Db.P("@k", ketQua));
                return KetQuaXuLy.Ok("Đã thêm xét nghiệm vào phiếu " + maPK + ".");
            }
            catch (Exception ex) { return KetQuaXuLy.TuLoi(ex); }
        }
    }
}
