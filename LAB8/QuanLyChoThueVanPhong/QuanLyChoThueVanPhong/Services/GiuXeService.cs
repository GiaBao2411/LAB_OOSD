using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyChoThueVanPhong.Data;

namespace QuanLyChoThueVanPhong.Services
{
    /// <summary>
    /// Quản lý nhân viên của công ty thuê, xe và thẻ giữ xe.
    /// Mỗi xe chỉ có một thẻ còn hiệu lực tại một thời điểm.
    /// </summary>
    public class GiuXeService
    {
        public DataTable LayNhanVien()
        {
            return Db.Query(@"SELECT n.MaNV, k.TenCongTy, n.HoTen, n.ChucVu, n.MaPhong,
                                     t.SoTang, n.TrangThai, n.NgayNghi
                              FROM NhanVienCongTy n
                              JOIN KhachHang k ON n.MaKH = k.MaKH
                              JOIN Phong p ON n.MaPhong = p.MaPhong
                              JOIN Tang t ON p.MaTang = t.MaTang
                              ORDER BY k.TenCongTy, n.HoTen");
        }

        public DataTable LayNhanVienCombo()
        {
            return Db.Query(@"SELECT MaNV, (HoTen + N' - ' + MaPhong) AS MoTa
                              FROM NhanVienCongTy WHERE TrangThai = 'DANG_LAM'
                              ORDER BY HoTen");
        }

        public DataTable LayXe()
        {
            return Db.Query(@"SELECT x.MaXe, x.BienSo, x.LoaiXe, x.NhanHieu, x.MauXe,
                                     n.HoTen AS NhanVien
                              FROM Xe x JOIN NhanVienCongTy n ON x.MaNV = n.MaNV
                              ORDER BY x.BienSo");
        }

        public DataTable LayXeCombo()
        {
            return Db.Query(@"SELECT MaXe, (BienSo + N' - ' + LoaiXe) AS MoTa
                              FROM Xe ORDER BY BienSo");
        }

        public DataTable LayThe()
        {
            return Db.Query(@"SELECT t.MaThe, x.BienSo, n.HoTen, t.NgayCap, t.TrangThai,
                                     t.NgayThuHoi
                              FROM TheGiuXe t
                              JOIN Xe x ON t.MaXe = x.MaXe
                              JOIN NhanVienCongTy n ON x.MaNV = n.MaNV
                              ORDER BY t.NgayCap DESC");
        }

        public KetQuaXuLy ThemNhanVien(string maNV, string maKH, string maPhong, string hoTen,
                                       string chucVu, string hinhAnh)
        {
            if (string.IsNullOrWhiteSpace(maNV) || string.IsNullOrWhiteSpace(maKH) ||
                string.IsNullOrWhiteSpace(maPhong) || string.IsNullOrWhiteSpace(hoTen) ||
                string.IsNullOrWhiteSpace(chucVu))
                return KetQuaXuLy.Fail("Chưa nhập đủ thông tin nhân viên.");
            try
            {
                Db.Execute(@"INSERT INTO NhanVienCongTy(MaNV, MaKH, MaPhong, HoTen, HinhAnh,
                                                        ChucVu, TrangThai)
                             VALUES(@m, @kh, @p, @h, @a, @cv, 'DANG_LAM')",
                    new SqlParameter("@m", maNV), new SqlParameter("@kh", maKH),
                    new SqlParameter("@p", maPhong), new SqlParameter("@h", hoTen),
                    new SqlParameter("@a", (object)hinhAnh ?? DBNull.Value),
                    new SqlParameter("@cv", chucVu));
                return KetQuaXuLy.Ok("Đã cập nhật hồ sơ nhân viên " + hoTen + ".");
            }
            catch (Exception ex) { return KetQuaXuLy.Fail(ex.Message); }
        }

        public KetQuaXuLy ThemXe(string maXe, string maNV, string bienSo, string loaiXe,
                                 string nhanHieu, string mauXe)
        {
            if (string.IsNullOrWhiteSpace(maXe) || string.IsNullOrWhiteSpace(maNV) ||
                string.IsNullOrWhiteSpace(bienSo) || string.IsNullOrWhiteSpace(loaiXe))
                return KetQuaXuLy.Fail("Chưa nhập đủ thông tin xe.");
            try
            {
                Db.Execute(@"INSERT INTO Xe(MaXe, MaNV, BienSo, LoaiXe, NhanHieu, MauXe)
                             VALUES(@m, @nv, @bs, @l, @nh, @mx)",
                    new SqlParameter("@m", maXe), new SqlParameter("@nv", maNV),
                    new SqlParameter("@bs", bienSo), new SqlParameter("@l", loaiXe),
                    new SqlParameter("@nh", (object)nhanHieu ?? DBNull.Value),
                    new SqlParameter("@mx", (object)mauXe ?? DBNull.Value));
                return KetQuaXuLy.Ok("Đã đăng ký xe " + bienSo + ".");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail("Biển số xe không được trùng. " + ex.Message);
            }
        }

        /// <summary>Cấp thẻ giữ xe: thu hồi thẻ cũ rồi cấp thẻ mới trong một transaction.</summary>
        public KetQuaXuLy CapThe(string maXe)
        {
            if (string.IsNullOrWhiteSpace(maXe)) return KetQuaXuLy.Fail("Chưa chọn xe.");

            using (var cn = Db.OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var u = new SqlCommand(
                        @"UPDATE TheGiuXe
                          SET TrangThai = 'THU_HOI', NgayThuHoi = CAST(GETDATE() AS date)
                          WHERE MaXe = @x AND TrangThai = 'HIEU_LUC'", cn, tx);
                    u.Parameters.AddWithValue("@x", maXe);
                    u.ExecuteNonQuery();

                    var i = new SqlCommand(
                        @"INSERT INTO TheGiuXe(MaThe, MaXe, NgayCap, TrangThai)
                          VALUES(@m, @x, CAST(GETDATE() AS date), 'HIEU_LUC')", cn, tx);
                    i.Parameters.AddWithValue("@m", Db.SinhMa("THE"));
                    i.Parameters.AddWithValue("@x", maXe);
                    i.ExecuteNonQuery();

                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã cấp thẻ giữ xe mới và thu hồi thẻ cũ nếu có.");
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
