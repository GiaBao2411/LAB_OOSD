using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyChoThueVanPhong.Common;
using QuanLyChoThueVanPhong.Services;

namespace QuanLyChoThueVanPhong.Forms
{
    /// <summary>Thu tiền thuê theo kỳ, thu tiền dịch vụ theo hóa đơn và thu tiền phạt.</summary>
    public partial class FrmThuTien : Form
    {
        readonly ThuTienService s = new ThuTienService();
        readonly DichVuService dv = new DichVuService();
        readonly HopDongService hd = new HopDongService();
        readonly KiemTraService kt = new KiemTraService();

        DataGridView gKhoanThu, gHoaDon, gPhat, gPhieuThu;
        ComboBox cbPhongThue;
        NumericUpDown numTien, numTienDV, numTienPhat;
        ComboBox cbHinhThuc, cbHinhThucDV, cbHinhThucPhat;

        public FrmThuTien()
        {
            InitializeComponent();
            BuildUI();
            Tai();
        }

        ComboBox TaoHinhThuc()
        {
            var cb = Ui.Cb(140);
            cb.Items.Add("Tiền mặt");
            cb.Items.Add("Chuyển khoản");
            cb.SelectedIndex = 0;
            return cb;
        }

        void BuildUI()
        {
            Ui.ChuanHoa(this, "Thu tiền thuê, tiền dịch vụ và tiền phạt", 1020, 640);

            var tab = new TabControl { Dock = DockStyle.Fill };
            this.Controls.Add(tab);

            var tp1 = Ui.Trang("Tiền thuê");
            gKhoanThu = Ui.Luoi(DockStyle.Fill, 0);
            cbPhongThue = Ui.Cb(280);
            numTien = Ui.Num(140, 1000000000, 0);
            cbHinhThuc = TaoHinhThuc();
            tp1.Controls.Add(gKhoanThu);
            tp1.Controls.Add(Ui.Hang(Ui.Lb("Phòng thuê"), cbPhongThue,
                Ui.Bt("Xem kỳ thu", XemKhoanThu), Ui.Lb("Số tiền"), numTien,
                Ui.Lb("Hình thức"), cbHinhThuc, Ui.Bt("Thu kỳ đang chọn", ThuTienThue)));
            tp1.Controls.Add(Ui.Tieu("Sáu tháng đầu trả trước, từ tháng thứ bảy trả đầu mỗi tháng"));
            tab.TabPages.Add(tp1);

            var tp2 = Ui.Trang("Tiền dịch vụ");
            gHoaDon = Ui.Luoi(DockStyle.Fill, 0);
            numTienDV = Ui.Num(140, 1000000000, 0);
            cbHinhThucDV = TaoHinhThuc();
            tp2.Controls.Add(gHoaDon);
            tp2.Controls.Add(Ui.Hang(Ui.Lb("Số tiền"), numTienDV, Ui.Lb("Hình thức"), cbHinhThucDV,
                Ui.Bt("Thu hóa đơn đang chọn", ThuDichVu)));
            tp2.Controls.Add(Ui.Tieu("Hóa đơn dịch vụ và số đã thu"));
            tab.TabPages.Add(tp2);

            var tp3 = Ui.Trang("Tiền phạt");
            gPhat = Ui.Luoi(DockStyle.Fill, 0);
            numTienPhat = Ui.Num(140, 1000000000, 0);
            cbHinhThucPhat = TaoHinhThuc();
            tp3.Controls.Add(gPhat);
            tp3.Controls.Add(Ui.Hang(Ui.Lb("Số tiền"), numTienPhat,
                Ui.Lb("Hình thức"), cbHinhThucPhat,
                Ui.Bt("Thu quyết định đang chọn", ThuPhat)));
            tp3.Controls.Add(Ui.Tieu("Quyết định xử phạt và số đã thu"));
            tab.TabPages.Add(tp3);

            var tp4 = Ui.Trang("Phiếu thu");
            gPhieuThu = Ui.Luoi(DockStyle.Fill, 0);
            tp4.Controls.Add(gPhieuThu);
            tp4.Controls.Add(Ui.Tieu("Toàn bộ phiếu thu đã lập"));
            tab.TabPages.Add(tp4);
        }

        void Tai()
        {
            Ui.NapCombo(cbPhongThue, hd.LayPhongThueCombo(), "MoTa", "MaCT");
            gKhoanThu.DataSource = s.LayKhoanThu("");
            gHoaDon.DataSource = dv.LayHoaDon();
            gPhat.DataSource = kt.LayXuPhat();
            gPhieuThu.DataSource = s.LayPhieuThu();
        }

        void XemKhoanThu(object sender, EventArgs e)
        {
            string maCT = Ui.GiaTri(cbPhongThue);
            gKhoanThu.DataSource = s.LayKhoanThu(maCT == null ? "" : maCT);
        }

        void ThuTienThue(object sender, EventArgs e)
        {
            string ma = Ui.ChuoiChon(gKhoanThu, "MaKhoanThu");
            if (ma == null) { Ui.Loi("Chưa chọn kỳ thu."); return; }
            var kq = s.ThuTienThue(ma, numTien.Value, Convert.ToString(cbHinhThuc.SelectedItem));
            Ui.Bao(kq);
            if (kq.ThanhCong) Tai();
        }

        void ThuDichVu(object sender, EventArgs e)
        {
            string ma = Ui.ChuoiChon(gHoaDon, "MaHDDV");
            if (ma == null) { Ui.Loi("Chưa chọn hóa đơn dịch vụ."); return; }
            var kq = s.ThuDichVu(ma, numTienDV.Value,
                Convert.ToString(cbHinhThucDV.SelectedItem));
            Ui.Bao(kq);
            if (kq.ThanhCong) Tai();
        }

        void ThuPhat(object sender, EventArgs e)
        {
            string ma = Ui.ChuoiChon(gPhat, "SoQD");
            if (ma == null) { Ui.Loi("Chưa chọn quyết định xử phạt."); return; }
            var kq = s.ThuPhat(ma, numTienPhat.Value,
                Convert.ToString(cbHinhThucPhat.SelectedItem));
            Ui.Bao(kq);
            if (kq.ThanhCong) Tai();
        }
    }
}
