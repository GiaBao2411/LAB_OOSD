using System;
using System.Windows.Forms;

namespace QuanLyThuVien.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) { using (FrmDanhMuc f = new FrmDanhMuc()) f.ShowDialog(this); }
        private void button2_Click(object sender, EventArgs e) { using (FrmSach f = new FrmSach()) f.ShowDialog(this); }
        private void button3_Click(object sender, EventArgs e) { using (FrmDocGia f = new FrmDocGia()) f.ShowDialog(this); }
        private void button4_Click(object sender, EventArgs e) { using (FrmMuonTra f = new FrmMuonTra()) f.ShowDialog(this); }
        private void button5_Click(object sender, EventArgs e) { using (FrmThongKe f = new FrmThongKe()) f.ShowDialog(this); }
        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát chương trình?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Close();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}