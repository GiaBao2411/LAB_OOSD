using System;
using System.Data;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    /// <summary>Lịch hẹn khám sức khỏe định kỳ theo quý (phòng chăm sóc khách hàng).</summary>
    public class LichHenService
    {
        public DataTable Lay(string maHoSo)
        {
            return Db.Query(@"SELECT l.MaLH, l.MaHoSo, n.HoTen, l.NgayGioHen,
                                     CASE l.TrangThai WHEN 'DAHEN' THEN N'Đã hẹn' WHEN 'DAKHAM' THEN N'Đã khám' ELSE N'Đã hủy' END AS TrangThai,
                                     l.GhiChu
                              FROM LichHen l
                              JOIN HoSoBenhAn h ON h.MaHoSo = l.MaHoSo
                              JOIN BenhNhan n ON n.MaBN = h.MaBN
                              WHERE (@h IS NULL OR l.MaHoSo = @h)
                              ORDER BY l.NgayGioHen DESC", Db.P("@h", maHoSo));
        }

        public KetQuaXuLy Dat(string maHoSo, DateTime ngayGio, string ghiChu)
        {
            if (string.IsNullOrWhiteSpace(maHoSo)) return KetQuaXuLy.Fail("Chưa chọn hồ sơ bệnh án.");
            if (ngayGio <= DateTime.Now) return KetQuaXuLy.Fail("Ngày giờ hẹn phải sau thời điểm hiện tại.");
            if (ngayGio.DayOfWeek == DayOfWeek.Sunday) return KetQuaXuLy.Fail("Bệnh viện không nhận lịch khám định kỳ vào Chủ nhật.");
            if (ngayGio.TimeOfDay < QuyDinh.GioMoCua || ngayGio.TimeOfDay > QuyDinh.GioDongCua)
                return KetQuaXuLy.Fail("Giờ hẹn phải nằm trong giờ làm việc 07:00 - 17:00.");
            try
            {
                object o = Db.Scalar("SELECT NgayHetHan FROM HoSoBenhAn WHERE MaHoSo = @h", Db.P("@h", maHoSo));
                if (o == null) return KetQuaXuLy.Fail("Hồ sơ không tồn tại.");
                if (ngayGio.Date > Convert.ToDateTime(o).Date)
                    return KetQuaXuLy.Fail("Hồ sơ hết hạn lệ phí trước ngày hẹn. Hãy gia hạn hồ sơ trước.");

                int quy = QuyDinh.Quy(ngayGio);
                object daHen = Db.Scalar(@"SELECT 1 FROM LichHen WHERE MaHoSo = @h AND TrangThai IN ('DAHEN', 'DAKHAM')
                                           AND YEAR(NgayGioHen) = @y AND DATEPART(QUARTER, NgayGioHen) = @q",
                    Db.P("@h", maHoSo), Db.P("@y", ngayGio.Year), Db.P("@q", quy));
                if (daHen != null) return KetQuaXuLy.Fail("Quý " + quy + "/" + ngayGio.Year + " bệnh nhân đã có lịch hẹn khám định kỳ (mỗi quý một lần).");
                object daKham = Db.Scalar(@"SELECT 1 FROM PhieuKham WHERE MaHoSo = @h AND LoaiKham = 'DINHKY'
                                            AND YEAR(NgayGioKham) = @y AND DATEPART(QUARTER, NgayGioKham) = @q",
                    Db.P("@h", maHoSo), Db.P("@y", ngayGio.Year), Db.P("@q", quy));
                if (daKham != null) return KetQuaXuLy.Fail("Quý " + quy + "/" + ngayGio.Year + " bệnh nhân đã khám định kỳ rồi.");

                Db.Execute("INSERT INTO LichHen(MaHoSo, NgayGioHen, TrangThai, GhiChu) VALUES(@h, @n, 'DAHEN', @g)",
                    Db.P("@h", maHoSo), Db.P("@n", ngayGio), Db.P("@g", ghiChu));
                return KetQuaXuLy.Ok("Đã đặt lịch khám định kỳ lúc " + ngayGio.ToString("HH:mm dd/MM/yyyy") + ".");
            }
            catch (Exception ex) { return KetQuaXuLy.TuLoi(ex); }
        }

        public KetQuaXuLy Huy(int maLH)
        {
            try
            {
                object o = Db.Scalar("SELECT TrangThai FROM LichHen WHERE MaLH = @m", Db.P("@m", maLH));
                if (o == null) return KetQuaXuLy.Fail("Lịch hẹn không tồn tại.");
                if (Convert.ToString(o) != QuyDinh.DaHen) return KetQuaXuLy.Fail("Chỉ hủy được lịch hẹn đang ở trạng thái Đã hẹn.");
                Db.Execute("UPDATE LichHen SET TrangThai = 'HUY' WHERE MaLH = @m", Db.P("@m", maLH));
                return KetQuaXuLy.Ok("Đã hủy lịch hẹn.");
            }
            catch (Exception ex) { return KetQuaXuLy.TuLoi(ex); }
        }
    }
}
