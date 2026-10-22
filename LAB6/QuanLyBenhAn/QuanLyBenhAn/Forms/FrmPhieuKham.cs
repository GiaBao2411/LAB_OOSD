using System;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmPhieuKham : Form
    {
        private readonly HoSoService hs = new HoSoService();
        private readonly DanhMucService dm = new DanhMucService();
        private readonly PhieuKhamService svc = new PhieuKhamService();

        public FrmPhieuKham() { InitializeComponent(); }

        private void FrmPhieuKham_Load(object sender, EventArgs e)
        {
            cboLoai.Items.AddRange(new object[] { "Điều trị", "Khám định kỳ" });
            FormHelper.Nap(cboHoSo, hs.LayDanhSachCombo(), "HienThi", "MaHoSo");
            FormHelper.Nap(cboKhoa, dm.LayKhoa(), "TenKhoa", "MaKhoa");
            FormHelper.Nap(cboXN, dm.LayXetNghiem(), "TenXN", "MaXN");
            cboLoai.SelectedIndex = 0;
            dtKham.Value = DateTime.Now;
        }

        private void cboHoSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ma = FormHelper.Gia(cboHoSo);
            lblHanHS.Text = hs.LayHanHienThi(ma);
            dgvPhieu.DataSource = svc.LayPhieuTheoHoSo(ma);
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormHelper.Nap(cboBS, dm.LayBacSiTheoKhoa(FormHelper.Gia(cboKhoa)), "HoTen", "MaBS");
        }

        private void cboLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool dinhKy = cboLoai.SelectedIndex == 1;
            if (dinhKy) { numVienPhi.Value = 0; chkTT.Checked = true; }
            numVienPhi.Enabled = !dinhKy;
            chkTT.Enabled = !dinhKy;
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            string loai = cboLoai.SelectedIndex == 1 ? QuyDinh.DinhKy : QuyDinh.DieuTri;
            var kq = svc.GhiNhan(txtMaPK.Text, FormHelper.Gia(cboHoSo), dtKham.Value, FormHelper.Gia(cboBS), FormHelper.Gia(cboKhoa), loai,
                txtTrieuChung.Text, txtNhiet.Text, txtHuyetAp.Text, txtKetLuan.Text, numVienPhi.Value, chkTT.Checked);
            if (FormHelper.Bao(kq))
            {
                dgvPhieu.DataSource = svc.LayPhieuTheoHoSo(FormHelper.Gia(cboHoSo));
                LamMoiPhieu();
            }
        }

        private void LamMoiPhieu()
        {
            txtMaPK.Clear(); txtTrieuChung.Clear(); txtNhiet.Clear(); txtHuyetAp.Clear(); txtKetLuan.Clear();
            if (cboLoai.SelectedIndex == 0) { numVienPhi.Value = 0; chkTT.Checked = false; }
            dtKham.Value = DateTime.Now;
        }

        private void btnLamMoi_Click(object sender, EventArgs e) { LamMoiPhieu(); }

        private void dgvPhieu_SelectionChanged(object sender, EventArgs e) { TaiXN(); }

        private void TaiXN()
        {
            string maPK = FormHelper.O(dgvPhieu, "MaPK");
            dgvXN.DataSource = maPK == "" ? null : svc.LayXetNghiem(maPK);
        }

        private void btnThemXN_Click(object sender, EventArgs e)
        {
            string maPK = FormHelper.O(dgvPhieu, "MaPK");
            if (FormHelper.Bao(svc.ThemXetNghiem(maPK, FormHelper.Gia(cboXN), txtKQ.Text))) { txtKQ.Clear(); TaiXN(); }
        }

        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
