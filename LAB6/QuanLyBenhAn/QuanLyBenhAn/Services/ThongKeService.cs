using System;
using System.Data;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    /// <summary>Thống kê phục vụ theo dõi điều trị và trách nhiệm bác sĩ.</summary>
    public class ThongKeService
    {
        public DataTable TheoBacSi(DateTime tu, DateTime den)
        {
            return Db.Query(@"SELECT b.MaBS, b.HoTen, k.TenKhoa,
                                     COUNT(p.MaPK) AS SoPhieu,
                                     ISNULL(SUM(CASE WHEN p.LoaiKham = 'DIEUTRI' THEN 1 ELSE 0 END), 0) AS DieuTri,
                                     ISNULL(SUM(CASE WHEN p.LoaiKham = 'DINHKY' THEN 1 ELSE 0 END), 0) AS DinhKy,
                                     ISNULL(SUM(p.VienPhi), 0) AS TongVienPhi
                              FROM BacSi b
                              JOIN Khoa k ON k.MaKhoa = b.MaKhoa
                              LEFT JOIN PhieuKham p ON p.MaBS = b.MaBS
                                   AND p.NgayGioKham >= @tu AND p.NgayGioKham < DATEADD(DAY, 1, @den)
                              GROUP BY b.MaBS, b.HoTen, k.TenKhoa
                              ORDER BY SoPhieu DESC, b.HoTen",
                Db.P("@tu", tu.Date), Db.P("@den", den.Date));
        }

        public DataTable SapHetHan(int soNgay)
        {
            return Db.Query(@"SELECT h.MaHoSo, n.HoTen, n.DienThoai, h.NgayHetHan,
                                     DATEDIFF(DAY, CAST(GETDATE() AS date), h.NgayHetHan) AS ConLaiNgay
                              FROM HoSoBenhAn h JOIN BenhNhan n ON n.MaBN = h.MaBN
                              WHERE h.NgayHetHan <= DATEADD(DAY, @n, CAST(GETDATE() AS date))
                              ORDER BY h.NgayHetHan", Db.P("@n", soNgay));
        }

        public DataTable PhanUngPhu()
        {
            return Db.Query(@"SELECT th.TenThuoc, t.MaToa, t.MaPK, n.HoTen, c.PhanUngPhu
                              FROM ChiTietToa c
                              JOIN ToaThuoc t ON t.MaToa = c.MaToa
                              JOIN Thuoc th ON th.MaThuoc = c.MaThuoc
                              JOIN PhieuKham p ON p.MaPK = t.MaPK
                              JOIN HoSoBenhAn h ON h.MaHoSo = p.MaHoSo
                              JOIN BenhNhan n ON n.MaBN = h.MaBN
                              WHERE c.PhanUngPhu IS NOT NULL
                              ORDER BY th.TenThuoc, t.MaToa");
        }
    }
}
