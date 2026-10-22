using System;
using System.Data;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    public class DanhMucService
    {
        public DataTable LayKhoa() { return Db.Query("SELECT MaKhoa, TenKhoa FROM Khoa ORDER BY TenKhoa"); }

        public DataTable LayBacSi()
        {
            return Db.Query(@"SELECT b.MaBS, b.HoTen, k.TenKhoa, b.DienThoai, b.ChuyenMon
                              FROM BacSi b JOIN Khoa k ON k.MaKhoa = b.MaKhoa ORDER BY b.HoTen");
        }

        public DataTable LayBacSiTheoKhoa(string maKhoa)
        {
            return Db.Query("SELECT MaBS, HoTen FROM BacSi WHERE MaKhoa = @k ORDER BY HoTen", Db.P("@k", maKhoa));
        }

        public DataTable LayThuoc() { return Db.Query("SELECT MaThuoc, TenThuoc, DonViTinh, ChongChiDinh FROM Thuoc ORDER BY TenThuoc"); }
        public DataTable LayXetNghiem() { return Db.Query("SELECT MaXN, TenXN, DonGia FROM XetNghiem ORDER BY TenXN"); }

        public KetQuaXuLy ThemKhoa(string ma, string ten)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten)) return KetQuaXuLy.Fail("Mã khoa và tên khoa không được để trống.");
            return Chay("INSERT INTO Khoa(MaKhoa, TenKhoa) VALUES(@m, @t)", "Đã thêm khoa.", Db.P("@m", ma), Db.P("@t", ten));
        }

        public KetQuaXuLy ThemBacSi(string ma, string ten, string maKhoa, string dienThoai, string chuyenMon)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten) || string.IsNullOrWhiteSpace(maKhoa))
                return KetQuaXuLy.Fail("Mã, họ tên và khoa của bác sĩ không được để trống.");
            return Chay("INSERT INTO BacSi(MaBS, HoTen, MaKhoa, DienThoai, ChuyenMon) VALUES(@m, @t, @k, @d, @c)", "Đã thêm bác sĩ.",
                Db.P("@m", ma), Db.P("@t", ten), Db.P("@k", maKhoa), Db.P("@d", dienThoai), Db.P("@c", chuyenMon));
        }

        public KetQuaXuLy ThemThuoc(string ma, string ten, string donVi, string chongChiDinh)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten) || string.IsNullOrWhiteSpace(donVi))
                return KetQuaXuLy.Fail("Mã, tên và đơn vị tính của thuốc không được để trống.");
            return Chay("INSERT INTO Thuoc(MaThuoc, TenThuoc, DonViTinh, ChongChiDinh) VALUES(@m, @t, @d, @c)", "Đã thêm thuốc.",
                Db.P("@m", ma), Db.P("@t", ten), Db.P("@d", donVi), Db.P("@c", chongChiDinh));
        }

        public KetQuaXuLy ThemXetNghiem(string ma, string ten, decimal donGia)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten)) return KetQuaXuLy.Fail("Mã và tên xét nghiệm không được để trống.");
            if (donGia < 0) return KetQuaXuLy.Fail("Đơn giá không được âm.");
            return Chay("INSERT INTO XetNghiem(MaXN, TenXN, DonGia) VALUES(@m, @t, @g)", "Đã thêm xét nghiệm.",
                Db.P("@m", ma), Db.P("@t", ten), Db.P("@g", donGia));
        }

        private static KetQuaXuLy Chay(string sql, string thongBao, params System.Data.SqlClient.SqlParameter[] ps)
        {
            try { Db.Execute(sql, ps); return KetQuaXuLy.Ok(thongBao); }
            catch (Exception ex) { return KetQuaXuLy.TuLoi(ex); }
        }
    }
}
