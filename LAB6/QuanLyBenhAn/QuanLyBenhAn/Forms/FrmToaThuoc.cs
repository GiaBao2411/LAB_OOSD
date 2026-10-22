using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    /// <summary>Nghiệp vụ "Lập toa thuốc": bác sĩ kê toa sau khi khám.</summary>
    public partial class FrmToaThuoc : Form
    {
        private readonly ToaThuocService svc = new ToaThuocService();
        private readonly DanhMucService dm = new DanhMucService();
        private readonly DataTable dtDong = new DataTable();

        public FrmToaThuoc() { InitializeComponent(); }

        private void FrmToaThuoc_Load(object sender, EventArgs e)
        {
            dtDong.Columns.Add("MaThuoc", typeof(string));
            dtDong.Columns.Add("TenThuoc", typeof(string));
            dtDong.Columns.Add("SoLuong", typeof(int));
            dtDong.Columns.Add("LieuDung", typeof(string));
            dgvDong.DataSource = dtDong;
            FormHelper.Nap(cboThuoc, dm.LayThuoc(), "TenThuoc", "MaThuoc");
            TaiPhieu();
            TaiToa();
        }

        private void TaiPhieu() { FormHelper.Nap(cboPhieu, svc.LayPhieuChuaCoToa(), "HienThi", "MaPK"); }
        private void TaiToa() { dgvToa.DataSource = svc.LayDongToa(); }

        private void cboPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            var r = cboPhieu.SelectedItem as DataRowView;
            lblTrieuChung.Text = r == null ? "" : "Triệu chứng: " + Convert.ToString(r["TrieuChung"]);
            dtLap.Value = DateTime.Now;
        }

        private void btnThemDong_Click(object sender, EventArgs e)
        {
            string ma = FormHelper.Gia(cboThuoc);
            if (ma == "") { Canh("Chưa chọn thuốc."); return; }
            if (string.IsNullOrWhiteSpace(txtLieu.Text)) { Canh("Hãy nhập liều dùng cho thuốc."); return; }
            foreach (DataRow r in dtDong.Rows)
                if (Convert.ToString(r["MaThuoc"]) == ma) { Canh("Thuốc này đã có trong toa."); return; }
            dtDong.Rows.Add(ma, cboThuoc.Text, (int)numSL.Value, txtLieu.Text.Trim());
            txtLieu.Clear();
            numSL.Value = 1;
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (dgvDong.CurrentRow == null) return;
            dtDong.Rows.RemoveAt(dgvDong.CurrentRow.Index);
        }

        private void btnLapToa_Click(object sender, EventArgs e)
        {
            var ds = new List<DongToaItem>();
            foreach (DataRow r in dtDong.Rows)
                ds.Add(new DongToaItem { MaThuoc = Convert.ToString(r["MaThuoc"]), SoLuong = Convert.ToInt32(r["SoLuong"]), LieuDung = Convert.ToString(r["LieuDung"]) });
            var kq = svc.LapToa(txtMaToa.Text, FormHelper.Gia(cboPhieu), dtLap.Value, txtGhiChu.Text, ds);
            if (FormHelper.Bao(kq))
            {
                dtDong.Rows.Clear();
                txtMaToa.Clear(); txtGhiChu.Clear();
                TaiPhieu();
                TaiToa();
            }
        }

        private void dgvToa_SelectionChanged(object sender, EventArgs e) { txtPhanUng.Text = FormHelper.O(dgvToa, "PhanUngPhu"); }

        private void btnGhiPU_Click(object sender, EventArgs e)
        {
            if (FormHelper.Bao(svc.GhiPhanUng(FormHelper.O(dgvToa, "MaToa"), FormHelper.O(dgvToa, "MaThuoc"), txtPhanUng.Text))) TaiToa();
        }

        private static void Canh(string s) { MessageBox.Show(s, "Không thực hiện được", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
