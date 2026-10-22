using System;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmLichHen : Form
    {
        private readonly HoSoService hs = new HoSoService();
        private readonly LichHenService svc = new LichHenService();

        public FrmLichHen() { InitializeComponent(); }

        private void FrmLichHen_Load(object sender, EventArgs e)
        {
            FormHelper.Nap(cboHoSo, hs.LayDanhSachCombo(), "HienThi", "MaHoSo");
            DateTime ngay = DateTime.Today.AddDays(1);
            dtHen.Value = new DateTime(ngay.Year, ngay.Month, ngay.Day, 9, 0, 0);
        }

        private void Tai() { dgv.DataSource = svc.Lay(FormHelper.Gia(cboHoSo)); }

        private void cboHoSo_SelectedIndexChanged(object sender, EventArgs e) { Tai(); }

        private void btnDat_Click(object sender, EventArgs e)
        {
            if (FormHelper.Bao(svc.Dat(FormHelper.Gia(cboHoSo), dtHen.Value, txtGhiChu.Text))) { txtGhiChu.Clear(); Tai(); }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            int ma;
            if (!int.TryParse(FormHelper.O(dgv, "MaLH"), out ma))
            {
                MessageBox.Show("Hãy chọn lịch hẹn trên lưới trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (FormHelper.Bao(svc.Huy(ma))) Tai();
        }

        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
