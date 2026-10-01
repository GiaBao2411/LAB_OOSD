using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThuVien.Services;

namespace QuanLyThuVien.Forms
{
    public partial class FrmDocGia : Form
    {
        // Khai báo service từ file hướng dẫn
        private readonly DocGiaService service = new DocGiaService();

        public FrmDocGia()
        {
            InitializeComponent();

            // Ép Form chạy hàm Load để tự động hiển thị dữ liệu ngay khi mở
            this.Load += FrmDocGia_Load;
        }

        private void FrmDocGia_Load(object sender, EventArgs e)
        {
            cboPhai.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            if (cboPhai.Items.Count > 0) cboPhai.SelectedIndex = 0;

            dtNgayCap.Value = DateTime.Today;
            dtHan.Value = DateTime.Today.AddYears(1);

            TaiDuLieu();
            LamMoi();
        }

        // ==========================================
        // CÁC HÀM HỖ TRỢ DỮ LIỆU
        // ==========================================
        private void TaiDuLieu()
        {
            dgvDocGia.DataSource = null; // Xóa bộ nhớ đệm giúp bảng hiển thị dữ liệu mới liền
            dgvDocGia.DataSource = service.LayDanhSach();
            dgvDocGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private DocGia LayForm()
        {
            return new DocGia
            {
                MaDocGia = txtMa.Text.Trim(),
                Ho = txtHo.Text.Trim(),
                Ten = txtTen.Text.Trim(),
                NgaySinh = dtNgaySinh.Value.Date,
                Phai = Convert.ToString(cboPhai.SelectedItem),
                SoDienThoai = txtSDT.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Anh3x4 = txtAnh.Text.Trim()
            };
        }

        private void ShowResult(KetQuaXuLy kq)
        {
            MessageBox.Show(kq.ThongBao, kq.ThanhCong ? "Thông báo" : "Lỗi",
                MessageBoxButtons.OK, kq.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (kq.ThanhCong)
            {
                TaiDuLieu();
                LamMoi();
            }
        }

        private void LamMoi()
        {
            txtMa.Clear();
            txtHo.Clear();
            txtTen.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtAnh.Clear();

            dtNgaySinh.Value = DateTime.Today.AddYears(-18);
            dtNgayCap.Value = DateTime.Today;
            dtHan.Value = DateTime.Today.AddYears(1);
            chkLePhi.Checked = true;

            txtMa.ReadOnly = false;
            btnThem.Enabled = true;
            btnCapNhat.Enabled = false;
            txtMa.Focus();
        }

        // ==========================================
        // SỰ KIỆN NÚT BẤM VÀ DATAGRIDVIEW
        // ==========================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            ShowResult(service.Luu(LayForm(), false));
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            ShowResult(service.Luu(LayForm(), true));
        }

        private void btnCapThe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text))
            {
                MessageBox.Show("Vui lòng chọn độc giả.");
                return;
            }
            ShowResult(service.CapThe(txtMa.Text.Trim(), dtNgayCap.Value, dtHan.Value, chkLePhi.Checked));
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtMa.Text))
            {
                MessageBox.Show("Vui lòng chọn độc giả.");
                return;
            }
            ShowResult(service.GiaHanThe(txtMa.Text.Trim(), dtHan.Value, chkLePhi.Checked));
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvDocGia_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDocGia.CurrentRow == null || dgvDocGia.CurrentRow.DataBoundItem == null) return;

            DataRowView r = dgvDocGia.CurrentRow.DataBoundItem as DataRowView;
            if (r == null) return;

            txtMa.Text = Convert.ToString(r["MaDocGia"]);
            txtHo.Text = Convert.ToString(r["Ho"]);
            txtTen.Text = Convert.ToString(r["Ten"]);

            if (r["NgaySinh"] != DBNull.Value) dtNgaySinh.Value = Convert.ToDateTime(r["NgaySinh"]);
            cboPhai.SelectedItem = Convert.ToString(r["Phai"]);
            txtSDT.Text = Convert.ToString(r["SoDienThoai"]);
            txtDiaChi.Text = Convert.ToString(r["DiaChi"]);

            txtEmail.Text = Convert.ToString(r["Email"]);
            txtAnh.Text = Convert.ToString(r["Anh3x4"]);

            if (r["NgayCap"] != DBNull.Value) dtNgayCap.Value = Convert.ToDateTime(r["NgayCap"]);
            if (r["HanSuDung"] != DBNull.Value) dtHan.Value = Convert.ToDateTime(r["HanSuDung"]);

            chkLePhi.Checked = r["DaDongLePhi"] != DBNull.Value && Convert.ToBoolean(r["DaDongLePhi"]);

            txtMa.ReadOnly = true;
            btnThem.Enabled = false;
            btnCapNhat.Enabled = true;
        }

        // ==========================================
        // HÀM LỠ TẠO NHẦM (ĐỂ TRỐNG ĐỂ TRÁNH LỖI)
        // ==========================================
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
        }
    }
}