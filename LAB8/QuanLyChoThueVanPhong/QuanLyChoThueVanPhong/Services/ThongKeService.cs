using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyChoThueVanPhong.Data;

namespace QuanLyChoThueVanPhong.Services
{
    /// <summary>Báo cáo tình trạng phòng, doanh thu và công nợ tiền thuê, dịch vụ, tiền phạt.</summary>
    public class ThongKeService
    {
        public DataTable TongHop()
        {
            return Db.Query(@"SELECT
                (SELECT COUNT(*) FROM Phong) AS TongSoPhong,
                (SELECT COUNT(*) FROM Phong WHERE TinhTrang = 'TRONG') AS PhongTrong,
                (SELECT COUNT(*) FROM Phong WHERE TinhTrang = 'DA_THUE') AS PhongDaThue,
                (SELECT COUNT(*) FROM Phong WHERE TinhTrang = 'TU_SUA') AS PhongTuSua,
                (SELECT COUNT(*) FROM HopDongThue WHERE TrangThai = 'HIEU_LUC') AS HopDongHieuLuc,
                (SELECT ISNULL(SUM(SoTien), 0) FROM PhieuThu
                 WHERE LoaiThu = 'TIEN_THUE') AS DaThuTienThue,
                (SELECT ISNULL(SUM(SoTien), 0) FROM PhieuThu
                 WHERE LoaiThu = 'DICH_VU') AS DaThuDichVu,
                (SELECT ISNULL(SUM(SoTien), 0) FROM PhieuThu
                 WHERE LoaiThu = 'PHAT') AS DaThuPhat");
        }

        public DataTable CongNo()
        {
            return Db.Query(@"SELECT k.TenCongTy, c.MaPhong,
                                     ISNULL(t.PhaiThu, 0) - ISNULL(t.DaThu, 0) AS NoTienThue,
                                     ISNULL(d.PhaiThu, 0) - ISNULL(d.DaThu, 0) AS NoDichVu,
                                     ISNULL(f.PhaiThu, 0) - ISNULL(f.DaThu, 0) AS NoTienPhat
                              FROM ChiTietHopDong c
                              JOIN HopDongThue h ON c.SoHD = h.SoHD
                              JOIN KhachHang k ON h.MaKH = k.MaKH
                              OUTER APPLY (
                                  SELECT SUM(x.SoTien) AS PhaiThu,
                                         (SELECT ISNULL(SUM(p.SoTien), 0) FROM PhieuThu p
                                          WHERE p.MaKhoanThu IN
                                                (SELECT MaKhoanThu FROM KhoanThuTienThue
                                                 WHERE MaCT = c.MaCT)) AS DaThu
                                  FROM KhoanThuTienThue x
                                  WHERE x.MaCT = c.MaCT
                                    AND x.HanThanhToan <= CAST(GETDATE() AS date)) t
                              OUTER APPLY (
                                  SELECT SUM(y.TongTien) AS PhaiThu,
                                         (SELECT ISNULL(SUM(p.SoTien), 0) FROM PhieuThu p
                                          WHERE p.MaHDDV IN
                                                (SELECT MaHDDV FROM HoaDonDichVu
                                                 WHERE MaCT = c.MaCT)) AS DaThu
                                  FROM HoaDonDichVu y WHERE y.MaCT = c.MaCT) d
                              OUTER APPLY (
                                  SELECT SUM(z.SoTienPhat) AS PhaiThu,
                                         (SELECT ISNULL(SUM(p.SoTien), 0) FROM PhieuThu p
                                          WHERE p.SoQD IN
                                                (SELECT SoQD FROM QuyetDinhXuPhat
                                                 WHERE MaCT = c.MaCT)) AS DaThu
                                  FROM QuyetDinhXuPhat z WHERE z.MaCT = c.MaCT) f
                              ORDER BY k.TenCongTy, c.MaPhong");
        }
    }
}
