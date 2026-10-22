using System;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    /// <summary>Bác sĩ / phòng CSKH tra cứu lý lịch bệnh án bằng mã hồ sơ, họ tên hoặc điện thoại.</summary>
    public partial class FrmTraCuuHoSo : Form
    {
        private readonly HoSoService hs = new HoSoService();
        private readonly PhieuKhamService pk = new PhieuKhamService();
        private readonly ToaThuocService toa = new ToaThuocService();

        public FrmTraCuuHoSo() { InitializeComponent(); }

        private void FrmTraCuuHoSo_Load(object sender, EventArgs e) { btnTim_Click(null, null); }

        private void btnTim_Click(object sender, EventArgs e) { dgvHoSo.DataSource = hs.Tim(txtTim.Text); }

        private void dgvHoSo_SelectionChanged(object sender, EventArgs e)
        {
            string ma = FormHelper.O(dgvHoSo, "MaHoSo");
            if (picAnh.Image != null) { picAnh.Image.Dispose(); picAnh.Image = null; }
            if (ma == "")
            {
                lblMaHoSo.Text = lblHoTen.Text = lblNgaySinh.Text = lblDiaChi.Text = lblDT.Text = lblHan.Text = "-";
                dgvPhieu.DataSource = null;
                return;
            }
            var r = dgvHoSo.CurrentRow;
            lblMaHoSo.Text = ma;
            lblHoTen.Text = Convert.ToString(r.Cells["HoTen"].Value);
            lblNgaySinh.Text = Convert.ToDateTime(r.Cells["NgaySinh"].Value).ToString("dd/MM/yyyy");
            lblDiaChi.Text = Convert.ToString(r.Cells["DiaChi"].Value);
            lblDT.Text = Convert.ToString(r.Cells["DienThoai"].Value);
            lblHan.Text = Convert.ToDateTime(r.Cells["NgayHetHan"].Value).ToString("dd/MM/yyyy") + " (" + Convert.ToString(r.Cells["TrangThai"].Value) + ")";
            picAnh.Image = FormHelper.DocAnh(hs.LayAnh(FormHelper.O(dgvHoSo, "MaBN")));
            dgvPhieu.DataSource = pk.LayPhieuTheoHoSo(ma);
        }

        private void dgvPhieu_SelectionChanged(object sender, EventArgs e)
        {
            string maPK = FormHelper.O(dgvPhieu, "MaPK");
            if (maPK == "") { dgvXN.DataSource = null; dgvToa.DataSource = null; return; }
            dgvXN.DataSource = pk.LayXetNghiem(maPK);
            dgvToa.DataSource = toa.LayToaTheoPhieu(maPK);
        }

        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
