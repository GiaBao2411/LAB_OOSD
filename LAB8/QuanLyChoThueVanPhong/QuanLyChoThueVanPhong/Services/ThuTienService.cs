using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyChoThueVanPhong.Data;

namespace QuanLyChoThueVanPhong.Services
{
    /// <summary>
    /// Thu tiền thuê theo kỳ, thu tiền dịch vụ theo hóa đơn và thu tiền phạt.
    /// Mỗi phiếu thu chỉ gắn với đúng một chứng từ tương ứng loại thu.
    /// </summary>
    public class ThuTienService
    {
        public DataTable LayKhoanThu(string maCT)
        {
            return Db.Query(@"SELECT k.MaKhoanThu, k.MaCT, c.MaPhong, k.LoaiKy, k.KySo,
                                     k.TuNgay, k.DenNgay, k.HanThanhToan, k.SoTien,
                                     ISNULL((SELECT SUM(p.SoTien) FROM PhieuThu p
                                             WHERE p.MaKhoanThu = k.MaKhoanThu), 0) AS DaThu
                              FROM KhoanThuTienThue k
                              JOIN ChiTietHopDong c ON k.MaCT = c.MaCT
                              WHERE (@ct = N'' OR k.MaCT = @ct)
                              ORDER BY k.HanThanhToan",
                new SqlParameter("@ct", (object)maCT ?? ""));
        }

        public DataTable LayPhieuThu()
        {
            return Db.Query(@"SELECT SoPT, NgayThu, LoaiThu, MaKhoanThu, MaHDDV, SoQD,
                                     SoTien, HinhThuc
                              FROM PhieuThu ORDER BY NgayThu DESC");
        }

        public KetQuaXuLy ThuTienThue(string maKhoanThu, decimal soTien, string hinhThuc)
        {
            if (string.IsNullOrWhiteSpace(maKhoanThu) || soTien <= 0)
                return KetQuaXuLy.Fail("Thông tin thu tiền thuê không hợp lệ.");

            using (var cn = Db.OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var q = new SqlCommand(
                        "SELECT SoTien FROM KhoanThuTienThue WHERE MaKhoanThu = @m", cn, tx);
                    q.Parameters.AddWithValue("@m", maKhoanThu);
                    object o = q.ExecuteScalar();
                    if (o == null) return KetQuaXuLy.Fail("Không tìm thấy kỳ thu.");
                    decimal phaiThu = Convert.ToDecimal(o);

                    var d = new SqlCommand(
                        @"SELECT ISNULL(SUM(SoTien), 0) FROM PhieuThu
                          WHERE MaKhoanThu = @m", cn, tx);
                    d.Parameters.AddWithValue("@m", maKhoanThu);
                    decimal daThu = Convert.ToDecimal(d.ExecuteScalar());

                    if (daThu >= phaiThu)
                        return KetQuaXuLy.Fail("Kỳ thu này đã được thanh toán đủ.");
                    if (daThu + soTien > phaiThu)
                        return KetQuaXuLy.Fail("Số tiền vượt phần còn phải thu (" +
                                               (phaiThu - daThu).ToString("#,##0") + ").");

                    var i = new SqlCommand(
                        @"INSERT INTO PhieuThu(SoPT, NgayThu, LoaiThu, MaKhoanThu, MaHDDV,
                                               SoQD, SoTien, HinhThuc)
                          VALUES(@so, SYSDATETIME(), 'TIEN_THUE', @m, NULL, NULL, @t, @ht)",
                        cn, tx);
                    i.Parameters.AddWithValue("@so", Db.SinhMa("PT"));
                    i.Parameters.AddWithValue("@m", maKhoanThu);
                    i.Parameters.AddWithValue("@t", soTien);
                    i.Parameters.AddWithValue("@ht", hinhThuc);
                    i.ExecuteNonQuery();

                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã thu tiền thuê " + soTien.ToString("#,##0") + " đồng.");
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }
                    return KetQuaXuLy.Fail(ex.Message);
                }
            }
        }

        public KetQuaXuLy ThuDichVu(string maHDDV, decimal soTien, string hinhThuc)
        {
            if (string.IsNullOrWhiteSpace(maHDDV) || soTien <= 0)
                return KetQuaXuLy.Fail("Thông tin thu tiền dịch vụ không hợp lệ.");

            using (var cn = Db.OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var q = new SqlCommand(
                        "SELECT TongTien FROM HoaDonDichVu WHERE MaHDDV = @m", cn, tx);
                    q.Parameters.AddWithValue("@m", maHDDV);
                    object o = q.ExecuteScalar();
                    if (o == null) return KetQuaXuLy.Fail("Không tìm thấy hóa đơn dịch vụ.");
                    decimal tong = Convert.ToDecimal(o);

                    var d = new SqlCommand(
                        "SELECT ISNULL(SUM(SoTien), 0) FROM PhieuThu WHERE MaHDDV = @m", cn, tx);
                    d.Parameters.AddWithValue("@m", maHDDV);
                    decimal daThu = Convert.ToDecimal(d.ExecuteScalar());

                    if (daThu + soTien > tong)
                        return KetQuaXuLy.Fail("Số tiền vượt phần còn phải thu của hóa đơn (" +
                                               (tong - daThu).ToString("#,##0") + ").");

                    var i = new SqlCommand(
                        @"INSERT INTO PhieuThu(SoPT, NgayThu, LoaiThu, MaKhoanThu, MaHDDV,
                                               SoQD, SoTien, HinhThuc)
                          VALUES(@so, SYSDATETIME(), 'DICH_VU', NULL, @m, NULL, @t, @ht)", cn, tx);
                    i.Parameters.AddWithValue("@so", Db.SinhMa("PT"));
                    i.Parameters.AddWithValue("@m", maHDDV);
                    i.Parameters.AddWithValue("@t", soTien);
                    i.Parameters.AddWithValue("@ht", hinhThuc);
                    i.ExecuteNonQuery();

                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã thu tiền dịch vụ " + soTien.ToString("#,##0") + " đồng.");
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }
                    return KetQuaXuLy.Fail(ex.Message);
                }
            }
        }

        public KetQuaXuLy ThuPhat(string soQD, decimal soTien, string hinhThuc)
        {
            if (string.IsNullOrWhiteSpace(soQD) || soTien <= 0)
                return KetQuaXuLy.Fail("Thông tin thu tiền phạt không hợp lệ.");
            try
            {
                Db.Execute(@"INSERT INTO PhieuThu(SoPT, NgayThu, LoaiThu, MaKhoanThu, MaHDDV,
                                                  SoQD, SoTien, HinhThuc)
                             VALUES(@so, SYSDATETIME(), 'PHAT', NULL, NULL, @qd, @t, @ht)",
                    new SqlParameter("@so", Db.SinhMa("PT")), new SqlParameter("@qd", soQD),
                    new SqlParameter("@t", soTien), new SqlParameter("@ht", hinhThuc));
                return KetQuaXuLy.Ok("Đã thu tiền phạt.");
            }
            catch (Exception ex) { return KetQuaXuLy.Fail(ex.Message); }
        }
    }
}
