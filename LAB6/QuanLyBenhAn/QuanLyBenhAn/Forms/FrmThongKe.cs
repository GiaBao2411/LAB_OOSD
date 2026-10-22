using System;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmThongKe : Form
    {
        private readonly ThongKeService svc = new ThongKeService();

        public FrmThongKe() { InitializeComponent(); }

        private void FrmThongKe_Load(object sender, EventArgs e)
        {
            dtTu.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtDen.Value = DateTime.Today;
            btnTK_Click(null, null);
            btnXemHan_Click(null, null);
            btnXemPU_Click(null, null);
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            if (dtTu.Value.Date > dtDen.Value.Date)
            {
                MessageBox.Show("Từ ngày không được sau đến ngày.", "Không thực hiện được", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dgvBS.DataSource = svc.TheoBacSi(dtTu.Value, dtDen.Value);
        }

        private void btnXemHan_Click(object sender, EventArgs e) { dgvHan.DataSource = svc.SapHetHan((int)numNgay.Value); }
        private void btnXemPU_Click(object sender, EventArgs e) { dgvPU.DataSource = svc.PhanUngPhu(); }
        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
