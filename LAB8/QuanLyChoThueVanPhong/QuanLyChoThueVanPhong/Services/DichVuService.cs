using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyChoThueVanPhong.Data;

namespace QuanLyChoThueVanPhong.Services
{
    /// <summary>
    /// Ghi nhận sử dụng điện, nước, internet theo kỳ tháng và lập hóa đơn dịch vụ cuối tháng.
    /// Giá thuê không bao gồm dịch vụ nên hóa đơn dịch vụ được lập riêng.
    /// </summary>
    public class DichVuService
    {
        public DataTable LaySuDung(string maCT)
        {
            return Db.Query(@"SELECT s.MaSD, s.MaCT, d.TenDV, s.KyThang, s.SoLuong,
                                     s.DonGia, (s.SoLuong * s.DonGia) AS ThanhTien, s.DaChot
                              FROM SuDungDichVu s JOIN DichVu d ON s.MaDV = d.MaDV
                              WHERE (@ct = N'' OR s.MaCT = @ct)
                              ORDER BY s.KyThang DESC, d.TenDV",
                new SqlParameter("@ct", (object)maCT ?? ""));
        }

        public DataTable LayHoaDon()
        {
            return Db.Query(@"SELECT h.MaHDDV, h.MaCT, c.MaPhong, h.KyThang, h.NgayLap,
                                     h.HanThanhToan, h.TongTien,
                                     ISNULL((SELECT SUM(p.SoTien) FROM PhieuThu p
                                             WHERE p.MaHDDV = h.MaHDDV), 0) AS DaThu
                              FROM HoaDonDichVu h
                              JOIN ChiTietHopDong c ON h.MaCT = c.MaCT
                              ORDER BY h.KyThang DESC");
        }

        public DataTable LayChiTietHoaDon(string maHDDV)
        {
            return Db.Query(@"SELECT c.MaSD, d.TenDV, s.SoLuong, s.DonGia, c.ThanhTien
                              FROM ChiTietHoaDonDichVu c
                              JOIN SuDungDichVu s ON c.MaSD = s.MaSD
                              JOIN DichVu d ON s.MaDV = d.MaDV
                              WHERE c.MaHDDV = @m ORDER BY d.TenDV",
                new SqlParameter("@m", (object)maHDDV ?? ""));
        }

        public KetQuaXuLy GhiSuDung(string maCT, string maDV, DateTime kyThang, decimal soLuong)
        {
            if (string.IsNullOrWhiteSpace(maCT) || string.IsNullOrWhiteSpace(maDV))
                return KetQuaXuLy.Fail("Chưa chọn phòng thuê hoặc dịch vụ.");
            if (soLuong < 0) return KetQuaXuLy.Fail("Số lượng không được âm.");
            try
            {
                object o = Db.Scalar("SELECT DonGia FROM DichVu WHERE MaDV = @d",
                    new SqlParameter("@d", maDV));
                if (o == null) return KetQuaXuLy.Fail("Không tìm thấy dịch vụ.");

                DateTime ky = new DateTime(kyThang.Year, kyThang.Month, 1);
                Db.Execute(@"INSERT INTO SuDungDichVu(MaSD, MaCT, MaDV, KyThang, SoLuong,
                                                      DonGia, DaChot)
                             VALUES(@m, @ct, @d, @ky, @sl, @g, 0)",
                    new SqlParameter("@m", Db.SinhMa("SD")), new SqlParameter("@ct", maCT),
                    new SqlParameter("@d", maDV), new SqlParameter("@ky", ky),
                    new SqlParameter("@sl", soLuong), new SqlParameter("@g", Convert.ToDecimal(o)));
                return KetQuaXuLy.Ok("Đã ghi nhận mức sử dụng dịch vụ.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail("Mỗi dịch vụ chỉ một dòng trong một kỳ tháng. " + ex.Message);
            }
        }

        /// <summary>
        /// Lập hóa đơn dịch vụ cuối tháng: ghi đầu hóa đơn, đưa các dòng sử dụng chưa chốt vào
        /// hóa đơn, đánh dấu đã chốt và cập nhật tổng tiền. Tất cả trong một transaction.
        /// </summary>
        public KetQuaXuLy LapHoaDon(string maCT, DateTime kyThang, int soNgayHanThanhToan)
        {
            if (string.IsNullOrWhiteSpace(maCT))
                return KetQuaXuLy.Fail("Chưa chọn phòng thuê.");

            DateTime ky = new DateTime(kyThang.Year, kyThang.Month, 1);
            DateTime cuoiKy = ky.AddMonths(1).AddDays(-1);

            using (var cn = Db.OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var q = new SqlCommand(
                        @"SELECT COUNT(*) FROM SuDungDichVu
                          WHERE MaCT = @ct AND KyThang = @ky AND DaChot = 0", cn, tx);
                    q.Parameters.AddWithValue("@ct", maCT);
                    q.Parameters.AddWithValue("@ky", ky);
                    if (Convert.ToInt32(q.ExecuteScalar()) == 0)
                        return KetQuaXuLy.Fail("Kỳ này chưa có mức sử dụng dịch vụ nào chưa chốt.");

                    string maHDDV = Db.SinhMa("HD");
                    var i = new SqlCommand(
                        @"INSERT INTO HoaDonDichVu(MaHDDV, MaCT, KyThang, NgayLap,
                                                   HanThanhToan, TongTien)
                          VALUES(@m, @ct, @ky, @lap, @han, 0)", cn, tx);
                    i.Parameters.AddWithValue("@m", maHDDV);
                    i.Parameters.AddWithValue("@ct", maCT);
                    i.Parameters.AddWithValue("@ky", ky);
                    i.Parameters.AddWithValue("@lap", cuoiKy);
                    i.Parameters.AddWithValue("@han", cuoiKy.AddDays(soNgayHanThanhToan));
                    i.ExecuteNonQuery();

                    var c = new SqlCommand(
                        @"INSERT INTO ChiTietHoaDonDichVu(MaHDDV, MaSD, ThanhTien)
                          SELECT @m, MaSD, CONVERT(decimal(18,2), SoLuong * DonGia)
                          FROM SuDungDichVu
                          WHERE MaCT = @ct AND KyThang = @ky AND DaChot = 0", cn, tx);
                    c.Parameters.AddWithValue("@m", maHDDV);
                    c.Parameters.AddWithValue("@ct", maCT);
                    c.Parameters.AddWithValue("@ky", ky);
                    c.ExecuteNonQuery();

                    var u = new SqlCommand(
                        @"UPDATE SuDungDichVu SET DaChot = 1
                          WHERE MaCT = @ct AND KyThang = @ky AND DaChot = 0", cn, tx);
                    u.Parameters.AddWithValue("@ct", maCT);
                    u.Parameters.AddWithValue("@ky", ky);
                    u.ExecuteNonQuery();

                    var t = new SqlCommand(
                        @"UPDATE HoaDonDichVu
                          SET TongTien = (SELECT ISNULL(SUM(ThanhTien), 0)
                                          FROM ChiTietHoaDonDichVu WHERE MaHDDV = @m)
                          WHERE MaHDDV = @m", cn, tx);
                    t.Parameters.AddWithValue("@m", maHDDV);
                    t.ExecuteNonQuery();

                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã lập hóa đơn dịch vụ " + maHDDV + " cho kỳ " +
                                         ky.ToString("MM/yyyy") + ".");
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }
                    return KetQuaXuLy.Fail("Mỗi phòng thuê chỉ một hóa đơn dịch vụ mỗi tháng. " + ex.Message);
                }
            }
        }
    }
}
