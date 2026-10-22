using System;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmDanhMuc : Form
    {
        private readonly DanhMucService svc = new DanhMucService();

        public FrmDanhMuc() { InitializeComponent(); }

        private void FrmDanhMuc_Load(object sender, EventArgs e) { TaiTatCa(); }

        private void TaiTatCa()
        {
            dgvKhoa.DataSource = svc.LayKhoa();
            FormHelper.Nap(cboBSKhoa, svc.LayKhoa(), "TenKhoa", "MaKhoa");
            dgvBS.DataSource = svc.LayBacSi();
            dgvThuoc.DataSource = svc.LayThuoc();
            dgvXN.DataSource = svc.LayXetNghiem();
        }

        private void btnThemKhoa_Click(object sender, EventArgs e)
        {
            if (FormHelper.Bao(svc.ThemKhoa(txtKhoaMa.Text, txtKhoaTen.Text))) { txtKhoaMa.Clear(); txtKhoaTen.Clear(); TaiTatCa(); }
        }

        private void btnThemBS_Click(object sender, EventArgs e)
        {
            if (FormHelper.Bao(svc.ThemBacSi(txtBSMa.Text, txtBSTen.Text, FormHelper.Gia(cboBSKhoa), txtBSDT.Text, txtBSChuyenMon.Text)))
            { txtBSMa.Clear(); txtBSTen.Clear(); txtBSDT.Clear(); txtBSChuyenMon.Clear(); TaiTatCa(); }
        }

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            if (FormHelper.Bao(svc.ThemThuoc(txtThuocMa.Text, txtThuocTen.Text, txtThuocDV.Text, txtThuocCCD.Text)))
            { txtThuocMa.Clear(); txtThuocTen.Clear(); txtThuocDV.Clear(); txtThuocCCD.Clear(); TaiTatCa(); }
        }

        private void btnThemXN_Click(object sender, EventArgs e)
        {
            if (FormHelper.Bao(svc.ThemXetNghiem(txtXNMa.Text, txtXNTen.Text, numXNGia.Value)))
            { txtXNMa.Clear(); txtXNTen.Clear(); numXNGia.Value = 0; TaiTatCa(); }
        }

        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
