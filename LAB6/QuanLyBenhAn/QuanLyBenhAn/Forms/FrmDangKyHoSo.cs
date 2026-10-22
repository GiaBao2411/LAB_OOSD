using System;
using System.IO;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmDangKyHoSo : Form
    {
        private readonly HoSoService svc = new HoSoService();
        private byte[] anh;

        public FrmDangKyHoSo() { InitializeComponent(); }

        private void FrmDangKyHoSo_Load(object sender, EventArgs e)
        {
            dtNgaySinh.Value = new DateTime(1990, 1, 1);
            Tai();
        }

        private void Tai() { dgv.DataSource = svc.Tim(txtTim.Text); }

        private void LamMoi()
        {
            txtMaBN.Clear(); txtHoTen.Clear(); txtDiaChi.Clear(); txtDT.Clear(); txtMaHoSo.Clear();
            dtNgaySinh.Value = new DateTime(1990, 1, 1);
            numLePhi.Value = 500000;
            anh = null;
            if (picAnh.Image != null) { picAnh.Image.Dispose(); picAnh.Image = null; }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                if (dlg.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    byte[] b = File.ReadAllBytes(dlg.FileName);
                    if (b.Length > 2 * 1024 * 1024) { MessageBox.Show("Ảnh quá lớn (tối đa 2 MB).", "Không thực hiện được", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    var img = FormHelper.DocAnh(b);
                    if (img == null) { MessageBox.Show("File không phải ảnh hợp lệ.", "Không thực hiện được", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    anh = b;
                    if (picAnh.Image != null) picAnh.Image.Dispose();
                    picAnh.Image = img;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Không đọc được ảnh", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            var kq = svc.DangKyMoi(txtMaBN.Text, txtHoTen.Text, txtDiaChi.Text, dtNgaySinh.Value, txtDT.Text, anh, txtMaHoSo.Text, numLePhi.Value);
            if (FormHelper.Bao(kq)) { LamMoi(); Tai(); }
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            string ma = FormHelper.O(dgv, "MaHoSo");
            if (ma == "") { MessageBox.Show("Hãy chọn hồ sơ trên lưới trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (MessageBox.Show("Gia hạn hồ sơ " + ma + " thêm 1 năm với lệ phí " + numLePhi.Value.ToString("N0") + " đ?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            if (FormHelper.Bao(svc.GiaHan(ma, numLePhi.Value))) Tai();
        }

        private void btnLamMoi_Click(object sender, EventArgs e) { LamMoi(); }
        private void btnTim_Click(object sender, EventArgs e) { Tai(); }
        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
