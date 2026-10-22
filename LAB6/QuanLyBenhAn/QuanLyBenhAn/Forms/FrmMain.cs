using System;
using System.Windows.Forms;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain() { InitializeComponent(); }

        private void Mo(Form f) { using (f) f.ShowDialog(this); }

        private void btnDanhMuc_Click(object sender, EventArgs e) { Mo(new FrmDanhMuc()); }
        private void btnDangKyHoSo_Click(object sender, EventArgs e) { Mo(new FrmDangKyHoSo()); }
        private void btnTraCuu_Click(object sender, EventArgs e) { Mo(new FrmTraCuuHoSo()); }
        private void btnPhieuKham_Click(object sender, EventArgs e) { Mo(new FrmPhieuKham()); }
        private void btnToaThuoc_Click(object sender, EventArgs e) { Mo(new FrmToaThuoc()); }
        private void btnLichHen_Click(object sender, EventArgs e) { Mo(new FrmLichHen()); }
        private void btnThongKe_Click(object sender, EventArgs e) { Mo(new FrmThongKe()); }
        private void btnThoat_Click(object sender, EventArgs e) { Close(); }
    }
}
