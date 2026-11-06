using System.Collections.Generic;

namespace QuanLyChoThueVanPhong
{
    /// <summary>
    /// Kết quả trả về chuẩn cho mọi thao tác nghiệp vụ (Service) gọi từ Form.
    /// Form chỉ cần hiển thị ThongBao, không cần biết chi tiết xử lý.
    /// </summary>
    public class KetQuaXuLy
    {
        public bool ThanhCong { get; set; }
        public string ThongBao { get; set; }

        public static KetQuaXuLy Ok(string thongBao)
        {
            return new KetQuaXuLy { ThanhCong = true, ThongBao = thongBao };
        }

        public static KetQuaXuLy Fail(string thongBao)
        {
            return new KetQuaXuLy { ThanhCong = false, ThongBao = thongBao };
        }
    }

    /// <summary>Một phòng được chọn khi ký hợp đồng thuê (FrmHopDong).</summary>
    public class PhongThueItem
    {
        public string MaPhong { get; set; }
        public decimal DonGiaThang { get; set; }
    }
}
