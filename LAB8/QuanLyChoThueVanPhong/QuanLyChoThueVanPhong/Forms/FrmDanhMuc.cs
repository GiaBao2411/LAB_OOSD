using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyChoThueVanPhong.Common;
using QuanLyChoThueVanPhong.Services;

namespace QuanLyChoThueVanPhong.Forms
{
    public partial class FrmDanhMuc : Form
    {
        readonly DanhMucService s = new DanhMucService();

        DataGridView gTang, gPhong, gGia, gDV, gKH;
        TextBox txTangMa, txPhongMa, txHuong, txGiaMa, txDVMa, txDVTen, txDVDonVi;
        TextBox txKHMa, txKHTen, txKHMST, txKHDiaChi, txKHDienThoai, txKHNguoi;
        NumericUpDown numSoTang, numDoCao, numDienTich, numDonGia, numDVGia;
        ComboBox cbTang, cbPhongGia;
        DateTimePicker dtHieuLuc;

        public FrmDanhMuc()
        {
            InitializeComponent();
            BuildUI();
            Tai();
        }

        void BuildUI()
        {
            Ui.ChuanHoa(this, "Danh mục tầng, phòng, bảng giá, dịch vụ và khách hàng", 1000, 600);

            var tab = new TabControl { Dock = DockStyle.Fill };
            this.Controls.Add(tab);

            var tp1 = Ui.Trang("Tầng");
            gTang = Ui.Luoi(DockStyle.Fill, 0);
            txTangMa = Ui.Tx(90);
            numSoTang = Ui.Num(70, 100, 0);
            numDoCao = Ui.Num(90, 100, 2);
            tp1.Controls.Add(gTang);
            tp1.Controls.Add(Ui.Hang(Ui.Lb("Mã tầng"), txTangMa, Ui.Lb("Số tầng"), numSoTang,
                Ui.Lb("Độ cao (m)"), numDoCao, Ui.Bt("Thêm tầng", ThemTang)));
            tp1.Controls.Add(Ui.Tieu("Danh sách tầng của cao ốc"));
            tab.TabPages.Add(tp1);

            var tp2 = Ui.Trang("Phòng");
            gPhong = Ui.Luoi(DockStyle.Fill, 0);
            txPhongMa = Ui.Tx(90); txHuong = Ui.Tx(120);
            cbTang = Ui.Cb(120);
            numDienTich = Ui.Num(90, 100000, 2);
            tp2.Controls.Add(gPhong);
            tp2.Controls.Add(Ui.Hang(Ui.Lb("Mã phòng"), txPhongMa, Ui.Lb("Tầng"), cbTang,
                Ui.Lb("Hướng"), txHuong, Ui.Lb("Diện tích (m2)"), numDienTich,
                Ui.Bt("Thêm phòng", ThemPhong)));
            tp2.Controls.Add(Ui.Tieu("Phòng cho thuê và đơn giá hiện hành"));
            tab.TabPages.Add(tp2);

            var tp3 = Ui.Trang("Bảng giá thuê");
            gGia = Ui.Luoi(DockStyle.Fill, 0);
            txGiaMa = Ui.Tx(110);
            cbPhongGia = Ui.Cb(200);
            dtHieuLuc = Ui.Dt(110);
            numDonGia = Ui.Num(130, 1000000000, 0);
            tp3.Controls.Add(gGia);
            tp3.Controls.Add(Ui.Hang(Ui.Lb("Mã giá"), txGiaMa, Ui.Lb("Phòng"), cbPhongGia,
                Ui.Lb("Ngày hiệu lực"), dtHieuLuc, Ui.Lb("Đơn giá/tháng"), numDonGia,
                Ui.Bt("Thêm mức giá", ThemGia), Ui.Bt("Xem tất cả", (o, e) => NapGia(""))));
            tp3.Controls.Add(Ui.Tieu("Mỗi phòng một mức giá cho một ngày hiệu lực"));
            tab.TabPages.Add(tp3);

            var tp4 = Ui.Trang("Dịch vụ");
            gDV = Ui.Luoi(DockStyle.Fill, 0);
            txDVMa = Ui.Tx(90); txDVTen = Ui.Tx(200); txDVDonVi = Ui.Tx(100);
            numDVGia = Ui.Num(120, 1000000000, 0);
            tp4.Controls.Add(gDV);
            tp4.Controls.Add(Ui.Hang(Ui.Lb("Mã dịch vụ"), txDVMa, Ui.Lb("Tên dịch vụ"), txDVTen,
                Ui.Lb("Đơn vị tính"), txDVDonVi, Ui.Lb("Đơn giá"), numDVGia,
                Ui.Bt("Thêm dịch vụ", ThemDichVu)));
            tp4.Controls.Add(Ui.Tieu("Giá thuê không bao gồm dịch vụ, dịch vụ tính riêng"));
            tab.TabPages.Add(tp4);

            var tp5 = Ui.Trang("Khách hàng");
            gKH = Ui.Luoi(DockStyle.Fill, 0);
            txKHMa = Ui.Tx(90); txKHTen = Ui.Tx(200); txKHMST = Ui.Tx(120);
            txKHDiaChi = Ui.Tx(200); txKHDienThoai = Ui.Tx(110); txKHNguoi = Ui.Tx(160);
            tp5.Controls.Add(gKH);
            tp5.Controls.Add(Ui.Hang(Ui.Lb("Mã KH"), txKHMa, Ui.Lb("Tên công ty"), txKHTen,
                Ui.Lb("Mã số thuế"), txKHMST, Ui.Lb("Địa chỉ"), txKHDiaChi,
                Ui.Lb("Điện thoại"), txKHDienThoai, Ui.Lb("Người đại diện"), txKHNguoi,
                Ui.Bt("Thêm khách hàng", ThemKhachHang)));
            tp5.Controls.Add(Ui.Tieu("Công ty thuê văn phòng"));
            tab.TabPages.Add(tp5);
        }

        void Tai()
        {
            gTang.DataSource = s.LayTang();
            gPhong.DataSource = s.LayPhong();
            gDV.DataSource = s.LayDichVu();
            gKH.DataSource = s.LayKhachHang();
            Ui.NapCombo(cbTang, s.LayTang(), "SoTang", "MaTang");
            Ui.NapCombo(cbPhongGia, s.LayPhong(), "MaPhong", "MaPhong");
            NapGia("");
        }

        void NapGia(string maPhong)
        {
            gGia.DataSource = s.LayBangGia(maPhong);
        }

        void ThemTang(object sender, EventArgs e)
        {
            var kq = s.ThemTang(txTangMa.Text.Trim(), (int)numSoTang.Value, numDoCao.Value);
            Ui.Bao(kq);
            if (kq.ThanhCong) Tai();
        }

        void ThemPhong(object sender, EventArgs e)
        {
            var kq = s.ThemPhong(txPhongMa.Text.Trim(), Ui.GiaTri(cbTang), txHuong.Text.Trim(),
                numDienTich.Value);
            Ui.Bao(kq);
            if (kq.ThanhCong) Tai();
        }

        void ThemGia(object sender, EventArgs e)
        {
            var kq = s.ThemGia(txGiaMa.Text.Trim(), Ui.GiaTri(cbPhongGia), dtHieuLuc.Value,
                numDonGia.Value);
            Ui.Bao(kq);
            if (kq.ThanhCong) Tai();
        }

        void ThemDichVu(object sender, EventArgs e)
        {
            var kq = s.ThemDichVu(txDVMa.Text.Trim(), txDVTen.Text.Trim(), txDVDonVi.Text.Trim(),
                numDVGia.Value);
            Ui.Bao(kq);
            if (kq.ThanhCong) Tai();
        }

        void ThemKhachHang(object sender, EventArgs e)
        {
            var kq = s.ThemKhachHang(txKHMa.Text.Trim(), txKHTen.Text.Trim(), txKHMST.Text.Trim(),
                txKHDiaChi.Text.Trim(), txKHDienThoai.Text.Trim(), txKHNguoi.Text.Trim());
            Ui.Bao(kq);
            if (kq.ThanhCong) Tai();
        }
    }
}
