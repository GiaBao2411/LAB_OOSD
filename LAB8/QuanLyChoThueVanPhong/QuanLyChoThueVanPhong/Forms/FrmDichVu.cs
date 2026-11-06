using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyChoThueVanPhong.Common;
using QuanLyChoThueVanPhong.Services;

namespace QuanLyChoThueVanPhong.Forms
{
    /// <summary>Ghi nhận mức sử dụng dịch vụ theo tháng và lập hóa đơn dịch vụ cuối tháng.</summary>
    public partial class FrmDichVu : Form
    {
        readonly DichVuService s = new DichVuService();
        readonly DanhMucService dm = new DanhMucService();
        readonly HopDongService hd = new HopDongService();

        DataGridView gSD, gHoaDon, gChiTiet;
        ComboBox cbPhongThue, cbDichVu, cbPhongHD;
        DateTimePicker dtKy, dtKyHD;
        NumericUpDown numSoLuong, numHan;

        public FrmDichVu()
        {
            InitializeComponent();
            BuildUI();
            Tai();
        }

        void BuildUI()
        {
            Ui.ChuanHoa(this, "Dịch vụ và hóa đơn dịch vụ", 1020, 620);

            var tab = new TabControl { Dock = DockStyle.Fill };
            this.Controls.Add(tab);

            var tp1 = Ui.Trang("Ghi nhận sử dụng");
            gSD = Ui.Luoi(DockStyle.Fill, 0);
            cbPhongThue = Ui.Cb(280); cbDichVu = Ui.Cb(200);
            dtKy = Ui.Dt(110);
            numSoLuong = Ui.Num(100, 1000000, 3);
            tp1.Controls.Add(gSD);
            tp1.Controls.Add(Ui.Hang(Ui.Lb("Phòng thuê"), cbPhongThue, Ui.Lb("Dịch vụ"), cbDichVu,
                Ui.Lb("Kỳ tháng"), dtKy, Ui.Lb("Số lượng"), numSoLuong,
                Ui.Bt("Ghi nhận", GhiSuDung), Ui.Bt("Xem theo phòng", XemTheoPhong)));
            tp1.Controls.Add(Ui.Tieu("Điện, nước, internet được ghi theo từng kỳ tháng"));
            tab.TabPages.Add(tp1);

            var tp2 = Ui.Trang("Hóa đơn dịch vụ");
            gChiTiet = Ui.Luoi(DockStyle.Fill, 0);
            gHoaDon = Ui.Luoi(DockStyle.Top, 230);
            gHoaDon.SelectionChanged += (o, e) => NapChiTiet();
            cbPhongHD = Ui.Cb(280); dtKyHD = Ui.Dt(110);
            numHan = Ui.Num(70, 60, 0); numHan.Value = 7;
            tp2.Controls.Add(gChiTiet);
            tp2.Controls.Add(Ui.Tieu("Chi tiết hóa đơn đang chọn"));
            tp2.Controls.Add(gHoaDon);
            tp2.Controls.Add(Ui.Hang(Ui.Lb("Phòng thuê"), cbPhongHD, Ui.Lb("Kỳ tháng"), dtKyHD,
                Ui.Lb("Hạn thanh toán sau (ngày)"), numHan,
                Ui.Bt("Lập hóa đơn cuối tháng", LapHoaDon)));
            tp2.Controls.Add(Ui.Tieu("Mỗi phòng thuê chỉ một hóa đơn dịch vụ mỗi tháng"));
            tab.TabPages.Add(tp2);
        }

        void Tai()
        {
            DataTable dsPhong = hd.LayPhongThueCombo();
            Ui.NapCombo(cbPhongThue, dsPhong, "MoTa", "MaCT");
            Ui.NapCombo(cbPhongHD, hd.LayPhongThueCombo(), "MoTa", "MaCT");
            Ui.NapCombo(cbDichVu, dm.LayDichVuCombo(), "MoTa", "MaDV");
            gSD.DataSource = s.LaySuDung("");
            gHoaDon.DataSource = s.LayHoaDon();
            NapChiTiet();
        }

        void NapChiTiet()
        {
            string ma = Ui.ChuoiChon(gHoaDon, "MaHDDV");
            gChiTiet.DataSource = s.LayChiTietHoaDon(ma == null ? "" : ma);
        }

        void XemTheoPhong(object sender, EventArgs e)
        {
            string maCT = Ui.GiaTri(cbPhongThue);
            gSD.DataSource = s.LaySuDung(maCT == null ? "" : maCT);
        }

        void GhiSuDung(object sender, EventArgs e)
        {
            var kq = s.GhiSuDung(Ui.GiaTri(cbPhongThue), Ui.GiaTri(cbDichVu), dtKy.Value,
                numSoLuong.Value);
            Ui.Bao(kq);
            if (kq.ThanhCong) Tai();
        }

        void LapHoaDon(object sender, EventArgs e)
        {
            var kq = s.LapHoaDon(Ui.GiaTri(cbPhongHD), dtKyHD.Value, (int)numHan.Value);
            Ui.Bao(kq);
            if (kq.ThanhCong) Tai();
        }
    }
}
