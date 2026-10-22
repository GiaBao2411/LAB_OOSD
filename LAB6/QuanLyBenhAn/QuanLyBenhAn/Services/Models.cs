using System;
using System.Data.SqlClient;

namespace QuanLyBenhAn.Services
{
    /// <summary>Kết quả của mọi thao tác nghiệp vụ; Form chỉ đọc ThanhCong và ThongBao.</summary>
    public class KetQuaXuLy
    {
        public bool ThanhCong { get; private set; }
        public string ThongBao { get; private set; }
        public static KetQuaXuLy Ok(string thongBao) { return new KetQuaXuLy { ThanhCong = true, ThongBao = thongBao }; }
        public static KetQuaXuLy Fail(string thongBao) { return new KetQuaXuLy { ThanhCong = false, ThongBao = thongBao }; }

        /// <summary>Đổi lỗi SQL thành thông báo dễ hiểu.</summary>
        public static KetQuaXuLy TuLoi(Exception ex)
        {
            var sql = ex as SqlException;
            if (sql != null)
            {
                if (sql.Number == 2627 || sql.Number == 2601) return Fail("Mã đã tồn tại, vui lòng nhập mã khác.");
                if (sql.Number == 547) return Fail("Dữ liệu vi phạm ràng buộc (khóa ngoại hoặc giá trị không hợp lệ).");
            }
            return Fail(ex.Message);
        }
    }

    /// <summary>Một dòng thuốc trong toa.</summary>
    public class DongToaItem
    {
        public string MaThuoc { get; set; }
        public int SoLuong { get; set; }
        public string LieuDung { get; set; }
    }

    /// <summary>Hằng số nghiệp vụ.</summary>
    public static class QuyDinh
    {
        public const string DieuTri = "DIEUTRI";
        public const string DinhKy = "DINHKY";
        public const string DaHen = "DAHEN";
        public const string DaKham = "DAKHAM";
        public const string DaHuy = "HUY";
        public static readonly TimeSpan GioMoCua = new TimeSpan(7, 0, 0);
        public static readonly TimeSpan GioDongCua = new TimeSpan(17, 0, 0);

        public static int Quy(DateTime d) { return (d.Month - 1) / 3 + 1; }
    }
}
