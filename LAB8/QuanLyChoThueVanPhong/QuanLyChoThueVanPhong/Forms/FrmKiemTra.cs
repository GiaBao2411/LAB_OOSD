using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyChoThueVanPhong.Common;
using QuanLyChoThueVanPhong.Services;

namespace QuanLyChoThueVanPhong.Forms
{
    /// <summary>
    /// Kiểm tra phòng hằng năm: lập biên bản, xử phạt khi tự ý sửa kết cấu
    /// và lập kế hoạch tu sửa.
    /// </summary>
    public partial class FrmKiemTra : Form
    {
        readonly KiemTraService s = new KiemTraService();
        readonly DanhMucService dm = new DanhMucService();
        readonly HopDongService hd = new HopDongService();

        DataGridView gBB, gKH, gQD;
        TextBox txSoBB, txNguoiKiemTra, txHienTrang, txMinhChung, txKetLuan;
        TextBox txQuyDinh, txNoiDungTuSua;
        ComboBox cbPhong, cbPhongThue;
        DateTimePicker dtKiemTra, dtBatDau, dtKetThuc;
        CheckBox chkTuY, chkTuSua;
        NumericUpDown numPhat, numChiPhi;

        public FrmKiemTra()
        {
            InitializeComponent();
            BuildUI();
            Tai();
        }

        void BuildUI()
        {
            Ui.ChuanHoa(this, "Kiểm tra phòng, xử phạt và tu sửa", 1020, 660);

            var tab = new TabControl { Dock = DockStyle.Fill };
            this.Controls.Add(tab);

            var tp1 = Ui.Trang("Lập biên bản");
            gBB = Ui.Luoi(DockStyle.Fill, 0);
            txSoBB = Ui.Tx(110); txNguoiKiemTra = Ui.Tx(160); txHienTrang = Ui.Tx(240);
            txMinhChung = Ui.Tx(180); txKetLuan = Ui.Tx(240);
            txQuyDinh = Ui.Tx(220); txNoiDungTuSua = Ui.Tx(220);
            cbPhong = Ui.Cb(150); cbPhongThue = Ui.Cb(260);
            dtKiemTra = Ui.Dt(110); dtBatDau = Ui.Dt(110); dtKetThuc = Ui.Dt(110);
            chkTuY = Ui.Chk("Tự ý sửa kết cấu (lập quyết định xử phạt)");
            chkTuSua = Ui.Chk("Lập kế hoạch tu sửa");
            numPhat = Ui.Num(140, 1000000000, 0);
            numChiPhi = Ui.Num(140, 1000000000, 0);

            tp1.Controls.Add(gBB);
            tp1.Controls.Add(Ui.Hang(Ui.Bt("Lập biên bản kiểm tra", LapBienBan)));
            tp1.Controls.Add(Ui.Hang(chkTuSua, Ui.Lb("Nội dung tu sửa"), txNoiDungTuSua,
                Ui.Lb("Từ ngày"), dtBatDau, Ui.Lb("Đến ngày"), dtKetThuc,
                Ui.Lb("Chi phí dự kiến"), numChiPhi));
            tp1.Controls.Add(Ui.Hang(chkTuY, Ui.Lb("Phòng thuê bị phạt"), cbPhongThue,
                Ui.Lb("Quy định áp dụng"), txQuyDinh, Ui.Lb("Số tiền phạt"), numPhat));
            tp1.Controls.Add(Ui.Hang(Ui.Lb("Số BB"), txSoBB, Ui.Lb("Phòng"), cbPhong,
                Ui.Lb("Ngày kiểm tra"), dtKiemTra, Ui.Lb("Người kiểm tra"), txNguoiKiemTra,
                Ui.Lb("Hiện trạng"), txHienTrang, Ui.Lb("Kết luận"), txKetLuan,
                Ui.Lb("Minh chứng"), txMinhChung));
            tp1.Controls.Add(Ui.Tieu("Mỗi phòng chỉ một biên bản trong một ngày kiểm tra"));
            tab.TabPages.Add(tp1);

            var tp2 = Ui.Trang("Kế hoạch tu sửa");
            gKH = Ui.Luoi(DockStyle.Fill, 0);
            tp2.Controls.Add(gKH);
            tp2.Controls.Add(Ui.Tieu("Kế hoạch tu sửa phát sinh từ biên bản kiểm tra"));
            tab.TabPages.Add(tp2);

            var tp3 = Ui.Trang("Quyết định xử phạt");
            gQD = Ui.Luoi(DockStyle.Fill, 0);
            tp3.Controls.Add(gQD);
            tp3.Controls.Add(Ui.Tieu("Quyết định xử phạt và số tiền đã thu"));
            tab.TabPages.Add(tp3);
        }

        void Tai()
        {
            gBB.DataSource = s.LayBienBan();
            gKH.DataSource = s.LayKeHoach();
            gQD.DataSource = s.LayXuPhat();
            Ui.NapCombo(cbPhong, dm.LayPhong(), "MaPhong", "MaPhong");
            Ui.NapCombo(cbPhongThue, hd.LayPhongThueCombo(), "MoTa", "MaCT");
        }

        void LapBienBan(object sender, EventArgs e)
        {
            var kq = s.LapBienBan(txSoBB.Text.Trim(), Ui.GiaTri(cbPhong), dtKiemTra.Value,
                txNguoiKiemTra.Text.Trim(), txHienTrang.Text.Trim(), chkTuY.Checked,
                txMinhChung.Text.Trim(), txKetLuan.Text.Trim(),
                chkTuY.Checked ? Ui.GiaTri(cbPhongThue) : null,
                chkTuY.Checked ? numPhat.Value : 0, txQuyDinh.Text.Trim(),
                chkTuSua.Checked, txNoiDungTuSua.Text.Trim(), dtBatDau.Value, dtKetThuc.Value,
                numChiPhi.Value);
            Ui.Bao(kq);
            if (kq.ThanhCong) Tai();
        }
    }
}
