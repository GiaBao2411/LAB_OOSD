using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyChoThueVanPhong.Data;

namespace QuanLyChoThueVanPhong.Services
{
    /// <summary>
    /// Kiểm tra tình trạng phòng hằng năm, lập biên bản, kế hoạch tu sửa và
    /// quyết định xử phạt khi khách tự ý thay đổi kết cấu văn phòng.
    /// </summary>
    public class KiemTraService
    {
        public DataTable LayBienBan()
        {
            return Db.Query(@"SELECT SoBB, MaPhong, NgayKiemTra, NguoiKiemTra, HienTrang,
                                     TuYSuaKetCau, KetLuan
                              FROM BienBanKiemTra ORDER BY NgayKiemTra DESC");
        }

        public DataTable LayKeHoach()
        {
            return Db.Query(@"SELECT k.MaKeHoach, k.SoBB, b.MaPhong, k.NoiDung, k.NgayBatDau,
                                     k.NgayKetThuc, k.ChiPhiDuKien, k.TrangThai
                              FROM KeHoachTuSua k JOIN BienBanKiemTra b ON k.SoBB = b.SoBB
                              ORDER BY k.NgayBatDau DESC");
        }

        public DataTable LayXuPhat()
        {
            return Db.Query(@"SELECT q.SoQD, q.SoBB, q.MaCT, q.NgayLap, q.QuyDinhApDung,
                                     q.LyDo, q.SoTienPhat,
                                     ISNULL((SELECT SUM(p.SoTien) FROM PhieuThu p
                                             WHERE p.SoQD = q.SoQD), 0) AS DaThu
                              FROM QuyetDinhXuPhat q ORDER BY q.NgayLap DESC");
        }

        /// <summary>
        /// Lập biên bản kiểm tra; nếu có tự ý sửa kết cấu thì lập quyết định xử phạt,
        /// nếu cần tu sửa thì lập kế hoạch và chuyển phòng sang trạng thái tu sửa.
        /// </summary>
        public KetQuaXuLy LapBienBan(string soBB, string maPhong, DateTime ngayKiemTra,
                string nguoiKiemTra, string hienTrang, bool tuYSuaKetCau, string minhChung,
                string ketLuan, string maCT, decimal soTienPhat, string quyDinhApDung,
                bool lapKeHoachTuSua, string noiDungTuSua, DateTime batDau, DateTime ketThuc,
                decimal chiPhiDuKien)
        {
            if (string.IsNullOrWhiteSpace(soBB) || string.IsNullOrWhiteSpace(maPhong) ||
                string.IsNullOrWhiteSpace(nguoiKiemTra) || string.IsNullOrWhiteSpace(hienTrang) ||
                string.IsNullOrWhiteSpace(ketLuan))
                return KetQuaXuLy.Fail("Chưa nhập đủ thông tin biên bản.");
            if (tuYSuaKetCau && (string.IsNullOrWhiteSpace(maCT) || soTienPhat <= 0))
                return KetQuaXuLy.Fail("Trường hợp tự ý sửa kết cấu phải chọn phòng thuê và nhập số tiền phạt.");

            using (var cn = Db.OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var i = new SqlCommand(
                        @"INSERT INTO BienBanKiemTra(SoBB, MaPhong, NgayKiemTra, NguoiKiemTra,
                                HienTrang, TuYSuaKetCau, MinhChung, KetLuan)
                          VALUES(@so, @p, @ng, @nkt, @ht, @ty, @mc, @kl)", cn, tx);
                    i.Parameters.AddWithValue("@so", soBB);
                    i.Parameters.AddWithValue("@p", maPhong);
                    i.Parameters.AddWithValue("@ng", ngayKiemTra.Date);
                    i.Parameters.AddWithValue("@nkt", nguoiKiemTra);
                    i.Parameters.AddWithValue("@ht", hienTrang);
                    i.Parameters.AddWithValue("@ty", tuYSuaKetCau);
                    i.Parameters.AddWithValue("@mc", (object)minhChung ?? DBNull.Value);
                    i.Parameters.AddWithValue("@kl", ketLuan);
                    i.ExecuteNonQuery();

                    if (tuYSuaKetCau)
                    {
                        var q = new SqlCommand(
                            @"INSERT INTO QuyetDinhXuPhat(SoQD, SoBB, MaCT, NgayLap,
                                    QuyDinhApDung, LyDo, SoTienPhat)
                              VALUES(@so, @bb, @ct, @ng, @qd, @ld, @t)", cn, tx);
                        q.Parameters.AddWithValue("@so", Db.SinhMa("QD"));
                        q.Parameters.AddWithValue("@bb", soBB);
                        q.Parameters.AddWithValue("@ct", maCT);
                        q.Parameters.AddWithValue("@ng", ngayKiemTra.Date);
                        q.Parameters.AddWithValue("@qd",
                            string.IsNullOrWhiteSpace(quyDinhApDung)
                                ? "Quy định của cao ốc về thay đổi kết cấu" : quyDinhApDung);
                        q.Parameters.AddWithValue("@ld", ketLuan);
                        q.Parameters.AddWithValue("@t", soTienPhat);
                        q.ExecuteNonQuery();
                    }

                    if (lapKeHoachTuSua)
                    {
                        if (ketThuc.Date < batDau.Date)
                            return KetQuaXuLy.Fail("Ngày kết thúc tu sửa không được trước ngày bắt đầu.");

                        var k = new SqlCommand(
                            @"INSERT INTO KeHoachTuSua(MaKeHoach, SoBB, NoiDung, NgayBatDau,
                                    NgayKetThuc, ChiPhiDuKien, TrangThai)
                              VALUES(@m, @bb, @nd, @bd, @kt, @cp, 'KE_HOACH')", cn, tx);
                        k.Parameters.AddWithValue("@m", Db.SinhMa("KH"));
                        k.Parameters.AddWithValue("@bb", soBB);
                        k.Parameters.AddWithValue("@nd",
                            string.IsNullOrWhiteSpace(noiDungTuSua) ? ketLuan : noiDungTuSua);
                        k.Parameters.AddWithValue("@bd", batDau.Date);
                        k.Parameters.AddWithValue("@kt", ketThuc.Date);
                        k.Parameters.AddWithValue("@cp", chiPhiDuKien);
                        k.ExecuteNonQuery();

                        var u = new SqlCommand(
                            @"UPDATE Phong SET TinhTrang = 'TU_SUA'
                              WHERE MaPhong = @p AND TinhTrang = 'TRONG'", cn, tx);
                        u.Parameters.AddWithValue("@p", maPhong);
                        u.ExecuteNonQuery();
                    }

                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã lập biên bản kiểm tra " + soBB +
                        (tuYSuaKetCau ? " kèm quyết định xử phạt" : "") +
                        (lapKeHoachTuSua ? " và kế hoạch tu sửa" : "") + ".");
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }
                    return KetQuaXuLy.Fail("Mỗi phòng chỉ một biên bản trong một ngày kiểm tra. " + ex.Message);
                }
            }
        }
    }
}
