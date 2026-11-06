using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyChoThueVanPhong.Data;

namespace QuanLyChoThueVanPhong.Services
{
    /// <summary>Tầng, phòng, bảng giá thuê, dịch vụ và khách hàng thuê.</summary>
    public class DanhMucService
    {
        public DataTable LayTang()
        {
            return Db.Query("SELECT MaTang, SoTang, DoCao FROM Tang ORDER BY SoTang");
        }

        public DataTable LayPhong()
        {
            return Db.Query(@"SELECT p.MaPhong, t.SoTang, p.Huong, p.DienTich, p.TinhTrang,
                                     (SELECT TOP 1 g.DonGiaThang FROM BangGiaThue g
                                      WHERE g.MaPhong = p.MaPhong
                                        AND g.NgayHieuLuc <= CAST(GETDATE() AS date)
                                      ORDER BY g.NgayHieuLuc DESC) AS DonGiaHienHanh
                              FROM Phong p JOIN Tang t ON p.MaTang = t.MaTang
                              ORDER BY t.SoTang, p.MaPhong");
        }

        public DataTable LayPhongTrongCombo()
        {
            return Db.Query(@"SELECT MaPhong, (MaPhong + N' - ' +
                                     CONVERT(nvarchar(20), DienTich) + N' m2') AS MoTa
                              FROM Phong WHERE TinhTrang = 'TRONG' ORDER BY MaPhong");
        }

        public DataTable LayBangGia(string maPhong)
        {
            return Db.Query(@"SELECT MaGia, MaPhong, NgayHieuLuc, DonGiaThang
                              FROM BangGiaThue
                              WHERE (@p = N'' OR MaPhong = @p)
                              ORDER BY MaPhong, NgayHieuLuc DESC",
                new SqlParameter("@p", (object)maPhong ?? ""));
        }

        public DataTable LayDichVu()
        {
            return Db.Query("SELECT MaDV, TenDV, DonViTinh, DonGia FROM DichVu ORDER BY TenDV");
        }

        public DataTable LayDichVuCombo()
        {
            return Db.Query(@"SELECT MaDV, (TenDV + N' (' + DonViTinh + N')') AS MoTa
                              FROM DichVu ORDER BY TenDV");
        }

        public DataTable LayKhachHang()
        {
            return Db.Query(@"SELECT MaKH, TenCongTy, MaSoThue, DiaChi, DienThoai, NguoiDaiDien
                              FROM KhachHang ORDER BY TenCongTy");
        }

        public DataTable LayKhachHangCombo()
        {
            return Db.Query("SELECT MaKH, TenCongTy FROM KhachHang ORDER BY TenCongTy");
        }

        public KetQuaXuLy ThemTang(string ma, int soTang, decimal doCao)
        {
            if (string.IsNullOrWhiteSpace(ma)) return KetQuaXuLy.Fail("Chưa nhập mã tầng.");
            if (doCao <= 0) return KetQuaXuLy.Fail("Độ cao phải lớn hơn 0.");
            try
            {
                Db.Execute("INSERT INTO Tang(MaTang, SoTang, DoCao) VALUES(@m, @s, @d)",
                    new SqlParameter("@m", ma), new SqlParameter("@s", soTang),
                    new SqlParameter("@d", doCao));
                return KetQuaXuLy.Ok("Đã thêm tầng " + soTang + ".");
            }
            catch (Exception ex) { return KetQuaXuLy.Fail(ex.Message); }
        }

        public KetQuaXuLy ThemPhong(string ma, string maTang, string huong, decimal dienTich)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(maTang) ||
                string.IsNullOrWhiteSpace(huong))
                return KetQuaXuLy.Fail("Chưa nhập đủ thông tin phòng.");
            if (dienTich <= 0) return KetQuaXuLy.Fail("Diện tích phải lớn hơn 0.");
            try
            {
                Db.Execute(@"INSERT INTO Phong(MaPhong, MaTang, Huong, DienTich, TinhTrang)
                             VALUES(@m, @t, @h, @d, 'TRONG')",
                    new SqlParameter("@m", ma), new SqlParameter("@t", maTang),
                    new SqlParameter("@h", huong), new SqlParameter("@d", dienTich));
                return KetQuaXuLy.Ok("Đã thêm phòng " + ma + ".");
            }
            catch (Exception ex) { return KetQuaXuLy.Fail(ex.Message); }
        }

        public KetQuaXuLy ThemGia(string maGia, string maPhong, DateTime hieuLuc, decimal donGia)
        {
            if (string.IsNullOrWhiteSpace(maGia) || string.IsNullOrWhiteSpace(maPhong))
                return KetQuaXuLy.Fail("Chưa nhập mã giá hoặc chưa chọn phòng.");
            if (donGia < 0) return KetQuaXuLy.Fail("Đơn giá không được âm.");
            try
            {
                Db.Execute(@"INSERT INTO BangGiaThue(MaGia, MaPhong, NgayHieuLuc, DonGiaThang)
                             VALUES(@m, @p, @ng, @g)",
                    new SqlParameter("@m", maGia), new SqlParameter("@p", maPhong),
                    new SqlParameter("@ng", hieuLuc.Date), new SqlParameter("@g", donGia));
                return KetQuaXuLy.Ok("Đã thêm mức giá cho phòng " + maPhong + ".");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail("Mỗi phòng chỉ một mức giá cho một ngày hiệu lực. " + ex.Message);
            }
        }

        public KetQuaXuLy ThemDichVu(string ma, string ten, string donVi, decimal donGia)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten) ||
                string.IsNullOrWhiteSpace(donVi))
                return KetQuaXuLy.Fail("Chưa nhập đủ thông tin dịch vụ.");
            if (donGia < 0) return KetQuaXuLy.Fail("Đơn giá không được âm.");
            try
            {
                Db.Execute(@"INSERT INTO DichVu(MaDV, TenDV, DonViTinh, DonGia)
                             VALUES(@m, @t, @d, @g)",
                    new SqlParameter("@m", ma), new SqlParameter("@t", ten),
                    new SqlParameter("@d", donVi), new SqlParameter("@g", donGia));
                return KetQuaXuLy.Ok("Đã thêm dịch vụ " + ten + ".");
            }
            catch (Exception ex) { return KetQuaXuLy.Fail(ex.Message); }
        }

        public KetQuaXuLy ThemKhachHang(string ma, string tenCongTy, string maSoThue,
                                        string diaChi, string dienThoai, string nguoiDaiDien)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(tenCongTy) ||
                string.IsNullOrWhiteSpace(diaChi) || string.IsNullOrWhiteSpace(dienThoai) ||
                string.IsNullOrWhiteSpace(nguoiDaiDien))
                return KetQuaXuLy.Fail("Chưa nhập đủ thông tin khách hàng.");
            try
            {
                Db.Execute(@"INSERT INTO KhachHang(MaKH, TenCongTy, MaSoThue, DiaChi,
                                                   DienThoai, NguoiDaiDien)
                             VALUES(@m, @t, @mst, @dc, @dt, @nd)",
                    new SqlParameter("@m", ma), new SqlParameter("@t", tenCongTy),
                    new SqlParameter("@mst", (object)maSoThue ?? DBNull.Value),
                    new SqlParameter("@dc", diaChi), new SqlParameter("@dt", dienThoai),
                    new SqlParameter("@nd", nguoiDaiDien));
                return KetQuaXuLy.Ok("Đã thêm khách hàng " + tenCongTy + ".");
            }
            catch (Exception ex) { return KetQuaXuLy.Fail(ex.Message); }
        }
    }
}
