using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyChoThueVanPhong.Common;
using QuanLyChoThueVanPhong.Services;

namespace QuanLyChoThueVanPhong.Forms
{
    /// <summary>Ký hợp đồng thuê nhiều phòng và gia hạn hợp đồng.</summary>
    public partial class FrmHopDong : Form
    {
        readonly HopDongService s = new HopDongService();
        readonly DanhMucService dm = new DanhMucService();

        readonly List<PhongThueItem> gioPhong = new List<PhongThueItem>();

        DataGridView gHD, gCT, gChon, gGH;
        TextBox txSoHD, txDieuKhoan, txNguoiLap;
        ComboBox cbKH, cbPhong, cbHD;
        DateTimePicker dtNgayKy, dtBatDau;
        NumericUpDown numSoThang, numGiaHan;

        public FrmHopDong()
        {
            InitializeComponent();
            BuildUI();
            Tai();
        }

        void BuildUI()
        {
            Ui.ChuanHoa(this, "Hợp đồng thuê và gia hạn", 1020, 640);

            var tab = new TabControl { Dock = DockStyle.Fill };
            this.Controls.Add(tab);

            var tp1 = Ui.Trang("Ký hợp đồng");
            txSoHD = Ui.Tx(110); txDieuKhoan = Ui.Tx(240);
            cbKH = Ui.Cb(220); cbPhong = Ui.Cb(200);
            dtNgayKy = Ui.Dt(110); dtBatDau = Ui.Dt(110);
            numSoThang = Ui.Num(70, 120, 0);
            numSoThang.Minimum = 6;
            numSoThang.Value = 12;
            gChon = Ui.Luoi(DockStyle.Fill, 0);

            tp1.Controls.Add(gChon);
            tp1.Controls.Add(Ui.Hang(Ui.Bt("Thêm phòng vào hợp đồng", ThemVaoGio),
                Ui.Bt("Bỏ phòng đang chọn", BoKhoiGio),
                Ui.Bt("Ký hợp đồng", KyHopDong)));
            tp1.Controls.Add(Ui.Hang(Ui.Lb("Phòng còn trống"), cbPhong));
            tp1.Controls.Add(Ui.Hang(Ui.Lb("Số HĐ"), txSoHD, Ui.Lb("Khách hàng"), cbKH,
                Ui.Lb("Ngày ký"), dtNgayKy, Ui.Lb("Ngày bắt đầu"), dtBatDau,
                Ui.Lb("Số tháng thuê"), numSoThang, Ui.Lb("Điều khoản"), txDieuKhoan));
            tp1.Controls.Add(Ui.Tieu("Đợt thuê tối thiểu sáu tháng, trả trước sáu tháng đầu"));
            tab.TabPages.Add(tp1);

            var tp2 = Ui.Trang("Hợp đồng và phòng thuê");
            gCT = Ui.Luoi(DockStyle.Fill, 0);
            gHD = Ui.Luoi(DockStyle.Top, 230);
            gHD.SelectionChanged += (o, e) => NapChiTiet();
            tp2.Controls.Add(gCT);
            tp2.Controls.Add(Ui.Tieu("Phòng của hợp đồng đang chọn"));
            tp2.Controls.Add(gHD);
            tp2.Controls.Add(Ui.Tieu("Danh sách hợp đồng"));
            tab.TabPages.Add(tp2);

            var tp3 = Ui.Trang("Gia hạn");
            cbHD = Ui.Cb(260); numGiaHan = Ui.Num(70, 120, 0); txNguoiLap = Ui.Tx(160);
            numGiaHan.Minimum = 1; numGiaHan.Value = 6;
            gGH = Ui.Luoi(DockStyle.Fill, 0);
            tp3.Controls.Add(gGH);
            tp3.Controls.Add(Ui.Hang(Ui.Lb("Hợp đồng"), cbHD, Ui.Lb("Số tháng gia hạn"), numGiaHan,
                Ui.Lb("Người lập"), txNguoiLap,
                Ui.Bt("Gia hạn phòng đang chọn ở tab bên", GiaHan)));
            tp3.Controls.Add(Ui.Tieu("Chỉ gia hạn khi phòng không còn nợ, thêm không quá một nửa thời gian thuê"));
            tab.TabPages.Add(tp3);
        }

        void Tai()
        {
            gHD.DataSource = s.LayHopDong();
            gGH.DataSource = s.LayPhieuGiaHan();
            Ui.NapCombo(cbKH, dm.LayKhachHangCombo(), "TenCongTy", "MaKH");
            Ui.NapCombo(cbPhong, dm.LayPhongTrongCombo(), "MoTa", "MaPhong");
            Ui.NapCombo(cbHD, s.LayHopDongCombo(), "MoTa", "SoHD");
            NapChiTiet();
            VeGio();
        }

        void NapChiTiet()
        {
            string soHD = Ui.ChuoiChon(gHD, "SoHD");
            gCT.DataSource = s.LayChiTiet(soHD == null ? "" : soHD);
        }

        void VeGio()
        {
            var dt = new DataTable();
            dt.Columns.Add("MaPhong");
            foreach (var x in gioPhong) dt.Rows.Add(x.MaPhong);
            gChon.DataSource = dt;
        }

        void ThemVaoGio(object sender, EventArgs e)
        {
            string maPhong = Ui.GiaTri(cbPhong);
            if (string.IsNullOrWhiteSpace(maPhong)) { Ui.Loi("Chưa chọn phòng."); return; }
            foreach (var x in gioPhong)
            {
                if (x.MaPhong == maPhong) { Ui.Loi("Phòng này đã có trong hợp đồng."); return; }
            }
            gioPhong.Add(new PhongThueItem { MaPhong = maPhong, DonGiaThang = 0 });
            VeGio();
        }

        void BoKhoiGio(object sender, EventArgs e)
        {
            string maPhong = Ui.ChuoiChon(gChon, "MaPhong");
            if (maPhong == null) { Ui.Loi("Chưa chọn dòng cần bỏ."); return; }
            for (int i = 0; i < gioPhong.Count; i++)
            {
                if (gioPhong[i].MaPhong == maPhong) { gioPhong.RemoveAt(i); break; }
            }
            VeGio();
        }

        void KyHopDong(object sender, EventArgs e)
        {
            var kq = s.KyHopDong(txSoHD.Text.Trim(), Ui.GiaTri(cbKH), dtNgayKy.Value,
                dtBatDau.Value, (int)numSoThang.Value, txDieuKhoan.Text.Trim(), gioPhong);
            Ui.Bao(kq);
            if (kq.ThanhCong) { gioPhong.Clear(); txSoHD.Clear(); Tai(); }
        }

        void GiaHan(object sender, EventArgs e)
        {
            string maCT = Ui.ChuoiChon(gCT, "MaCT");
            if (maCT == null)
            {
                Ui.Loi("Hãy mở tab Hợp đồng và phòng thuê rồi chọn phòng cần gia hạn.");
                return;
            }
            var kq = s.GiaHan(Ui.GiaTri(cbHD), maCT, (int)numGiaHan.Value, txNguoiLap.Text.Trim());
            Ui.Bao(kq);
            if (kq.ThanhCong) Tai();
        }
    }
}
