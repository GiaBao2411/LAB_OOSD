using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyChoThueVanPhong.Data;

namespace QuanLyChoThueVanPhong.Services
{
    /// <summary>
    /// Ký hợp đồng thuê và gia hạn. Thời gian một đợt thuê ít nhất sáu tháng,
    /// khách trả trước tiền thuê sáu tháng đầu, từ tháng thứ bảy trả vào đầu mỗi tháng.
    /// </summary>
    public class HopDongService
    {
        public DataTable LayHopDong()
        {
            return Db.Query(@"SELECT h.SoHD, k.TenCongTy, h.NgayKy, h.NgayBatDau,
                                     h.SoThangThue, h.TrangThai,
                                     (SELECT COUNT(*) FROM ChiTietHopDong c
                                      WHERE c.SoHD = h.SoHD) AS SoPhong
                              FROM HopDongThue h JOIN KhachHang k ON h.MaKH = k.MaKH
                              ORDER BY h.NgayKy DESC");
        }

        public DataTable LayChiTiet(string soHD)
        {
            return Db.Query(@"SELECT c.MaCT, c.MaPhong, c.DonGiaThang, c.NgayKetThucGoc,
                                     c.NgayKetThucHienTai
                              FROM ChiTietHopDong c
                              WHERE (@h = N'' OR c.SoHD = @h)
                              ORDER BY c.MaPhong",
                new SqlParameter("@h", (object)soHD ?? ""));
        }

        /// <summary>Danh sách phòng đang thuê, dùng cho ComboBox của các Form dịch vụ và thu tiền.</summary>
        public DataTable LayPhongThueCombo()
        {
            return Db.Query(@"SELECT c.MaCT, (c.MaPhong + N' - ' + k.TenCongTy +
                                     N' - HĐ ' + c.SoHD) AS MoTa
                              FROM ChiTietHopDong c
                              JOIN HopDongThue h ON c.SoHD = h.SoHD
                              JOIN KhachHang k ON h.MaKH = k.MaKH
                              WHERE h.TrangThai = 'HIEU_LUC'
                              ORDER BY c.MaPhong");
        }

        public DataTable LayHopDongCombo()
        {
            return Db.Query(@"SELECT h.SoHD, (h.SoHD + N' - ' + k.TenCongTy) AS MoTa
                              FROM HopDongThue h JOIN KhachHang k ON h.MaKH = k.MaKH
                              WHERE h.TrangThai = 'HIEU_LUC' ORDER BY h.SoHD");
        }

        public DataTable LayPhieuGiaHan()
        {
            return Db.Query(@"SELECT p.SoPGH, p.SoHD, p.NgayLap, p.NguoiLap,
                                     (SELECT COUNT(*) FROM ChiTietGiaHan c
                                      WHERE c.SoPGH = p.SoPGH) AS SoPhong
                              FROM PhieuGiaHan p ORDER BY p.NgayLap DESC");
        }

        /// <summary>
        /// Ký hợp đồng: ghi hợp đồng, từng phòng với đơn giá đã chốt, đánh dấu phòng đã thuê
        /// và lập kỳ thu trả trước sáu tháng đầu. Tất cả trong một transaction.
        /// </summary>
        public KetQuaXuLy KyHopDong(string soHD, string maKH, DateTime ngayKy,
                                    DateTime ngayBatDau, int soThangThue, string dieuKhoan,
                                    List<PhongThueItem> dsPhong)
        {
            if (string.IsNullOrWhiteSpace(soHD) || string.IsNullOrWhiteSpace(maKH) ||
                dsPhong == null || dsPhong.Count == 0)
                return KetQuaXuLy.Fail("Hợp đồng phải có khách hàng và ít nhất một phòng.");
            if (soThangThue < 6)
                return KetQuaXuLy.Fail("Thời gian của đợt thuê phải ít nhất sáu tháng.");
            if (ngayBatDau.Date < ngayKy.Date)
                return KetQuaXuLy.Fail("Ngày bắt đầu không được trước ngày ký.");

            using (var cn = Db.OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var i = new SqlCommand(
                        @"INSERT INTO HopDongThue(SoHD, MaKH, NgayKy, NgayBatDau, SoThangThue,
                                                  DieuKhoan, TrangThai)
                          VALUES(@so, @kh, @nk, @bd, @st, @dk, 'HIEU_LUC')", cn, tx);
                    i.Parameters.AddWithValue("@so", soHD);
                    i.Parameters.AddWithValue("@kh", maKH);
                    i.Parameters.AddWithValue("@nk", ngayKy.Date);
                    i.Parameters.AddWithValue("@bd", ngayBatDau.Date);
                    i.Parameters.AddWithValue("@st", soThangThue);
                    i.Parameters.AddWithValue("@dk", (object)dieuKhoan ?? DBNull.Value);
                    i.ExecuteNonQuery();

                    DateTime ketThuc = ngayBatDau.Date.AddMonths(soThangThue).AddDays(-1);
                    int stt = 0;

                    foreach (var x in dsPhong)
                    {
                        stt = stt + 1;
                        var kt = new SqlCommand(
                            "SELECT TinhTrang FROM Phong WHERE MaPhong = @p", cn, tx);
                        kt.Parameters.AddWithValue("@p", x.MaPhong);
                        object o = kt.ExecuteScalar();
                        if (o == null) return KetQuaXuLy.Fail("Không tìm thấy phòng " + x.MaPhong + ".");
                        if (Convert.ToString(o) != "TRONG")
                            return KetQuaXuLy.Fail("Phòng " + x.MaPhong +
                                                   " đang được thuê hoặc đang tu sửa.");

                        var g = new SqlCommand(
                            @"SELECT TOP 1 MaGia, DonGiaThang FROM BangGiaThue
                              WHERE MaPhong = @p AND NgayHieuLuc <= @bd
                              ORDER BY NgayHieuLuc DESC", cn, tx);
                        g.Parameters.AddWithValue("@p", x.MaPhong);
                        g.Parameters.AddWithValue("@bd", ngayBatDau.Date);
                        string maGia = null; decimal donGia = 0;
                        using (var rd = g.ExecuteReader())
                        {
                            if (!rd.Read())
                                return KetQuaXuLy.Fail("Phòng " + x.MaPhong + " chưa có bảng giá thuê.");
                            maGia = Convert.ToString(rd[0]);
                            donGia = Convert.ToDecimal(rd[1]);
                        }

                        string maCT = "CT" + DateTime.Now.ToString("yyMMddHHmmss") + stt.ToString("00");
                        var c = new SqlCommand(
                            @"INSERT INTO ChiTietHopDong(MaCT, SoHD, MaPhong, MaGia, DonGiaThang,
                                                         NgayKetThucGoc, NgayKetThucHienTai)
                              VALUES(@ct, @so, @p, @mg, @dg, @kt, @kt)", cn, tx);
                        c.Parameters.AddWithValue("@ct", maCT);
                        c.Parameters.AddWithValue("@so", soHD);
                        c.Parameters.AddWithValue("@p", x.MaPhong);
                        c.Parameters.AddWithValue("@mg", maGia);
                        c.Parameters.AddWithValue("@dg", donGia);
                        c.Parameters.AddWithValue("@kt", ketThuc);
                        c.ExecuteNonQuery();

                        var u = new SqlCommand(
                            "UPDATE Phong SET TinhTrang = 'DA_THUE' WHERE MaPhong = @p", cn, tx);
                        u.Parameters.AddWithValue("@p", x.MaPhong);
                        u.ExecuteNonQuery();

                        var k = new SqlCommand(
                            @"INSERT INTO KhoanThuTienThue(MaKhoanThu, MaCT, LoaiKy, KySo,
                                    TuNgay, DenNgay, HanThanhToan, SoTien)
                              VALUES(@mk, @ct, 'TRA_TRUOC', 1, @tu, @den, @han, @tien)", cn, tx);
                        k.Parameters.AddWithValue("@mk", "KT" + maCT.Substring(2) + "00");
                        k.Parameters.AddWithValue("@ct", maCT);
                        k.Parameters.AddWithValue("@tu", ngayBatDau.Date);
                        k.Parameters.AddWithValue("@den",
                            ngayBatDau.Date.AddMonths(6).AddDays(-1));
                        k.Parameters.AddWithValue("@han", ngayBatDau.Date);
                        k.Parameters.AddWithValue("@tien", donGia * 6);
                        k.ExecuteNonQuery();

                        // từ tháng thứ bảy trả vào đầu mỗi tháng
                        for (int thang = 7; thang <= soThangThue; thang++)
                        {
                            DateTime tu = ngayBatDau.Date.AddMonths(thang - 1);
                            var k2 = new SqlCommand(
                                @"INSERT INTO KhoanThuTienThue(MaKhoanThu, MaCT, LoaiKy, KySo,
                                        TuNgay, DenNgay, HanThanhToan, SoTien)
                                  VALUES(@mk, @ct, 'THANG', @ky, @tu, @den, @han, @tien)", cn, tx);
                            k2.Parameters.AddWithValue("@mk", "KT" + maCT.Substring(2) + thang.ToString("00"));
                            k2.Parameters.AddWithValue("@ct", maCT);
                            k2.Parameters.AddWithValue("@ky", thang);
                            k2.Parameters.AddWithValue("@tu", tu);
                            k2.Parameters.AddWithValue("@den", tu.AddMonths(1).AddDays(-1));
                            k2.Parameters.AddWithValue("@han", tu);
                            k2.Parameters.AddWithValue("@tien", donGia);
                            k2.ExecuteNonQuery();
                        }
                    }

                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã ký hợp đồng " + soHD + " cho " + dsPhong.Count +
                        " phòng, đã lập kỳ trả trước sáu tháng đầu.");
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }
                    return KetQuaXuLy.Fail(ex.Message);
                }
            }
        }

        /// <summary>
        /// Gia hạn: chỉ gia hạn khi phòng không còn nợ tiền thuê và tiền dịch vụ,
        /// thời gian thêm không quá một nửa thời gian thuê.
        /// </summary>
        public KetQuaXuLy GiaHan(string soHD, string maCT, int soThangGiaHan, string nguoiLap)
        {
            if (string.IsNullOrWhiteSpace(soHD) || string.IsNullOrWhiteSpace(maCT) ||
                string.IsNullOrWhiteSpace(nguoiLap))
                return KetQuaXuLy.Fail("Chưa đủ thông tin gia hạn.");
            if (soThangGiaHan <= 0)
                return KetQuaXuLy.Fail("Số tháng gia hạn phải lớn hơn 0.");

            using (var cn = Db.OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var q = new SqlCommand(
                        @"SELECT h.SoThangThue, c.DonGiaThang, c.NgayKetThucHienTai
                          FROM ChiTietHopDong c JOIN HopDongThue h ON c.SoHD = h.SoHD
                          WHERE c.MaCT = @ct AND h.SoHD = @so", cn, tx);
                    q.Parameters.AddWithValue("@ct", maCT);
                    q.Parameters.AddWithValue("@so", soHD);
                    int soThangThue = 0; decimal donGia = 0; DateTime ketThuc = DateTime.Today;
                    using (var rd = q.ExecuteReader())
                    {
                        if (!rd.Read()) return KetQuaXuLy.Fail("Không tìm thấy phòng của hợp đồng.");
                        soThangThue = Convert.ToInt32(rd[0]);
                        donGia = Convert.ToDecimal(rd[1]);
                        ketThuc = Convert.ToDateTime(rd[2]);
                    }

                    if (soThangGiaHan * 2 > soThangThue)
                        return KetQuaXuLy.Fail("Thời gian gia hạn không được quá một nửa thời gian thuê (" +
                                               (soThangThue / 2) + " tháng).");

                    var no1 = new SqlCommand(
                        @"SELECT ISNULL(SUM(k.SoTien), 0) -
                                 ISNULL((SELECT SUM(p.SoTien) FROM PhieuThu p
                                         WHERE p.MaKhoanThu IN (SELECT MaKhoanThu
                                                                FROM KhoanThuTienThue
                                                                WHERE MaCT = @ct)), 0)
                          FROM KhoanThuTienThue k
                          WHERE k.MaCT = @ct AND k.HanThanhToan <= CAST(GETDATE() AS date)", cn, tx);
                    no1.Parameters.AddWithValue("@ct", maCT);
                    decimal noThue = Convert.ToDecimal(no1.ExecuteScalar());

                    var no2 = new SqlCommand(
                        @"SELECT ISNULL(SUM(h.TongTien), 0) -
                                 ISNULL((SELECT SUM(p.SoTien) FROM PhieuThu p
                                         WHERE p.MaHDDV IN (SELECT MaHDDV FROM HoaDonDichVu
                                                            WHERE MaCT = @ct)), 0)
                          FROM HoaDonDichVu h WHERE h.MaCT = @ct", cn, tx);
                    no2.Parameters.AddWithValue("@ct", maCT);
                    decimal noDichVu = Convert.ToDecimal(no2.ExecuteScalar());

                    if (noThue > 0 || noDichVu > 0)
                        return KetQuaXuLy.Fail("Phòng còn nợ tiền thuê hoặc tiền dịch vụ, chưa gia hạn được.");

                    string soPGH = Db.SinhMa("GH");
                    var i = new SqlCommand(
                        @"INSERT INTO PhieuGiaHan(SoPGH, SoHD, NgayLap, NguoiLap)
                          VALUES(@so, @hd, CAST(GETDATE() AS date), @nl)", cn, tx);
                    i.Parameters.AddWithValue("@so", soPGH);
                    i.Parameters.AddWithValue("@hd", soHD);
                    i.Parameters.AddWithValue("@nl", nguoiLap);
                    i.ExecuteNonQuery();

                    DateTime batDauGH = ketThuc.AddDays(1);
                    DateTime ketThucGH = batDauGH.AddMonths(soThangGiaHan).AddDays(-1);

                    var c = new SqlCommand(
                        @"INSERT INTO ChiTietGiaHan(SoPGH, MaCT, SoThangGiaHan,
                                                    NgayBatDauGH, NgayKetThucGH)
                          VALUES(@so, @ct, @st, @bd, @kt)", cn, tx);
                    c.Parameters.AddWithValue("@so", soPGH);
                    c.Parameters.AddWithValue("@ct", maCT);
                    c.Parameters.AddWithValue("@st", soThangGiaHan);
                    c.Parameters.AddWithValue("@bd", batDauGH);
                    c.Parameters.AddWithValue("@kt", ketThucGH);
                    c.ExecuteNonQuery();

                    var u = new SqlCommand(
                        @"UPDATE ChiTietHopDong SET NgayKetThucHienTai = @kt WHERE MaCT = @ct",
                        cn, tx);
                    u.Parameters.AddWithValue("@kt", ketThucGH);
                    u.Parameters.AddWithValue("@ct", maCT);
                    u.ExecuteNonQuery();

                    var max = new SqlCommand(
                        "SELECT ISNULL(MAX(KySo), 0) FROM KhoanThuTienThue WHERE MaCT = @ct", cn, tx);
                    max.Parameters.AddWithValue("@ct", maCT);
                    int kySo = Convert.ToInt32(max.ExecuteScalar());

                    for (int thang = 1; thang <= soThangGiaHan; thang++)
                    {
                        DateTime tu = batDauGH.AddMonths(thang - 1);
                        kySo = kySo + 1;
                        var k = new SqlCommand(
                            @"INSERT INTO KhoanThuTienThue(MaKhoanThu, MaCT, LoaiKy, KySo,
                                    TuNgay, DenNgay, HanThanhToan, SoTien)
                              VALUES(@mk, @ct, 'THANG', @ky, @tu, @den, @han, @tien)", cn, tx);
                        k.Parameters.AddWithValue("@mk", "KG" + DateTime.Now.ToString("yyMMddHHmm") + kySo.ToString("000"));
                        k.Parameters.AddWithValue("@ct", maCT);
                        k.Parameters.AddWithValue("@ky", kySo);
                        k.Parameters.AddWithValue("@tu", tu);
                        k.Parameters.AddWithValue("@den", tu.AddMonths(1).AddDays(-1));
                        k.Parameters.AddWithValue("@han", tu);
                        k.Parameters.AddWithValue("@tien", donGia);
                        k.ExecuteNonQuery();
                    }

                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã gia hạn thêm " + soThangGiaHan +
                        " tháng, đến ngày " + ketThucGH.ToString("dd/MM/yyyy") + ".");
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }
                    return KetQuaXuLy.Fail(ex.Message);
                }
            }
        }
    }
}
