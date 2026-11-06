using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyChoThueVanPhong.Common;
using QuanLyChoThueVanPhong.Services;

namespace QuanLyChoThueVanPhong.Forms
{
    /// <summary>Hồ sơ nhân viên của công ty thuê, xe và thẻ giữ xe.</summary>
    public partial class FrmGiuXe : Form
    {
        readonly GiuXeService s = new GiuXeService();
        readonly DanhMucService dm = new DanhMucService();

        DataGridView gNV, gXe, gThe;
        TextBox txNVMa, txHoTen, txChucVu, txHinhAnh;
        TextBox txXeMa, txBienSo, txLoaiXe, txNhanHieu, txMauXe;
        ComboBox cbKH, cbPhong, cbNhanVien, cbXe;

        public FrmGiuXe()
        {
            InitializeComponent();
            BuildUI();
            Tai();
        }

        void BuildUI()
        {
            Ui.ChuanHoa(this, "Nhân viên, xe và thẻ giữ xe", 1020, 620);

            var tab = new TabControl { Dock = DockStyle.Fill };
            this.Controls.Add(tab);

            var tp1 = Ui.Trang("Nhân viên công ty thuê");
            gNV = Ui.Luoi(DockStyle.Fill, 0);
            txNVMa = Ui.Tx(100); txHoTen = Ui.Tx(180); txChucVu = Ui.Tx(150);
            txHinhAnh = Ui.Tx(180);
            cbKH = Ui.Cb(220); cbPhong = Ui.Cb(150);
            tp1.Controls.Add(gNV);
            tp1.Controls.Add(Ui.Hang(Ui.Lb("Mã NV"), txNVMa, Ui.Lb("Công ty"), cbKH,
                Ui.Lb("Phòng làm việc"), cbPhong, Ui.Lb("Họ tên"), txHoTen,
                Ui.Lb("Chức vụ"), txChucVu, Ui.Lb("Hình ảnh"), txHinhAnh,
                Ui.Bt("Lưu hồ sơ", ThemNhanVien)));
            tp1.Controls.Add(Ui.Tieu("Mỗi công ty gửi danh sách nhân viên kèm hình ảnh"));
            tab.TabPages.Add(tp1);

            var tp2 = Ui.Trang("Xe");
            gXe = Ui.Luoi(DockStyle.Fill, 0);
            txXeMa = Ui.Tx(100); txBienSo = Ui.Tx(130); txLoaiXe = Ui.Tx(110);
            txNhanHieu = Ui.Tx(130); txMauXe = Ui.Tx(100);
            cbNhanVien = Ui.Cb(220);
            tp2.Controls.Add(gXe);
            tp2.Controls.Add(Ui.Hang(Ui.Lb("Mã xe"), txXeMa, Ui.Lb("Nhân viên"), cbNhanVien,
                Ui.Lb("Biển số"), txBienSo, Ui.Lb("Loại xe"), txLoaiXe,
                Ui.Lb("Nhãn hiệu"), txNhanHieu, Ui.Lb("Màu xe"), txMauXe,
                Ui.Bt("Đăng ký xe", ThemXe)));
            tp2.Controls.Add(Ui.Tieu("Biển số xe không được trùng"));
            tab.TabPages.Add(tp2);

            var tp3 = Ui.Trang("Thẻ giữ xe");
            gThe = Ui.Luoi(DockStyle.Fill, 0);
            cbXe = Ui.Cb(220);
            tp3.Controls.Add(gThe);
            tp3.Controls.Add(Ui.Hang(Ui.Lb("Xe"), cbXe, Ui.Bt("Cấp thẻ giữ xe", CapThe)));
            tp3.Controls.Add(Ui.Tieu("Mỗi xe chỉ một thẻ còn hiệu lực, cấp thẻ mới sẽ thu hồi thẻ cũ"));
            tab.TabPages.Add(tp3);
        }

        void Tai()
        {
            gNV.DataSource = s.LayNhanVien();
            gXe.DataSource = s.LayXe();
            gThe.DataSource = s.LayThe();
            Ui.NapCombo(cbKH, dm.LayKhachHangCombo(), "TenCongTy", "MaKH");
            Ui.NapCombo(cbPhong, dm.LayPhong(), "MaPhong", "MaPhong");
            Ui.NapCombo(cbNhanVien, s.LayNhanVienCombo(), "MoTa", "MaNV");
            Ui.NapCombo(cbXe, s.LayXeCombo(), "MoTa", "MaXe");
        }

        void ThemNhanVien(object sender, EventArgs e)
        {
            var kq = s.ThemNhanVien(txNVMa.Text.Trim(), Ui.GiaTri(cbKH), Ui.GiaTri(cbPhong),
                txHoTen.Text.Trim(), txChucVu.Text.Trim(), txHinhAnh.Text.Trim());
            Ui.Bao(kq);
            if (kq.ThanhCong) Tai();
        }

        void ThemXe(object sender, EventArgs e)
        {
            var kq = s.ThemXe(txXeMa.Text.Trim(), Ui.GiaTri(cbNhanVien), txBienSo.Text.Trim(),
                txLoaiXe.Text.Trim(), txNhanHieu.Text.Trim(), txMauXe.Text.Trim());
            Ui.Bao(kq);
            if (kq.ThanhCong) Tai();
        }

        void CapThe(object sender, EventArgs e)
        {
            var kq = s.CapThe(Ui.GiaTri(cbXe));
            Ui.Bao(kq);
            if (kq.ThanhCong) Tai();
        }
    }
}
