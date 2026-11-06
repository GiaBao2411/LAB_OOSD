using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyChoThueVanPhong.Common
{
    /// <summary>
    /// Các hàm dựng control dùng chung cho mọi Form: nhãn, ô nhập, nút, lưới, hàng nhập liệu.
    /// Nhờ vậy các Form chỉ tập trung vào nghiệp vụ, không lặp lại code giao diện.
    /// </summary>
    public static class Ui
    {
        public static readonly Font FontChung = new Font("Segoe UI", 10F);

        public static Label Lb(string text)
        {
            return new Label { Text = text, AutoSize = true, Margin = new Padding(6, 10, 3, 0) };
        }

        public static Label Tieu(string text)
        {
            return new Label
            {
                Text = text,
                AutoSize = true,
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Padding = new Padding(10, 8, 0, 4)
            };
        }

        public static TextBox Tx(int w)
        {
            return new TextBox { Width = w, Margin = new Padding(3, 6, 12, 6) };
        }

        public static ComboBox Cb(int w)
        {
            return new ComboBox
            {
                Width = w,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Margin = new Padding(3, 6, 12, 6)
            };
        }

        public static NumericUpDown Num(int w, decimal max, int soLeThapPhan)
        {
            return new NumericUpDown
            {
                Width = w,
                Maximum = max,
                Minimum = 0,
                DecimalPlaces = soLeThapPhan,
                ThousandsSeparator = true,
                Margin = new Padding(3, 6, 12, 6)
            };
        }

        public static DateTimePicker Dt(int w)
        {
            return new DateTimePicker
            {
                Width = w,
                Format = DateTimePickerFormat.Short,
                Margin = new Padding(3, 6, 12, 6)
            };
        }

        public static CheckBox Chk(string text)
        {
            return new CheckBox { Text = text, AutoSize = true, Margin = new Padding(6, 9, 12, 6) };
        }

        public static Button Bt(string text, EventHandler click)
        {
            var b = new Button
            {
                Text = text,
                AutoSize = true,
                Padding = new Padding(10, 4, 10, 4),
                Margin = new Padding(8, 5, 3, 5)
            };
            if (click != null) b.Click += click;
            return b;
        }

        /// <summary>Một hàng nhập liệu tự xuống dòng, đặt ở đỉnh vùng chứa.</summary>
        public static FlowLayoutPanel Hang(params Control[] controls)
        {
            var p = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                WrapContents = true,
                Padding = new Padding(8, 4, 8, 4)
            };
            if (controls != null) p.Controls.AddRange(controls);
            return p;
        }

        public static DataGridView Luoi(DockStyle dock, int height)
        {
            var g = new DataGridView
            {
                Dock = dock,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White,
                RowHeadersVisible = false
            };
            if (height > 0) g.Height = height;
            return g;
        }

        public static TabPage Trang(string text)
        {
            return new TabPage(text) { Padding = new Padding(8), BackColor = Color.White };
        }

        /// <summary>Nạp dữ liệu cho ComboBox theo cột hiển thị và cột giá trị.</summary>
        public static void NapCombo(ComboBox cb, DataTable dt, string cotHienThi, string cotGiaTri)
        {
            cb.DataSource = null;
            cb.DisplayMember = cotHienThi;
            cb.ValueMember = cotGiaTri;
            cb.DataSource = dt;
            cb.SelectedIndex = dt != null && dt.Rows.Count > 0 ? 0 : -1;
        }

        public static string GiaTri(ComboBox cb)
        {
            return cb.SelectedValue == null ? null : Convert.ToString(cb.SelectedValue);
        }

        /// <summary>Lấy giá trị một ô của dòng đang chọn trên lưới.</summary>
        public static object OChon(DataGridView g, string tenCot)
        {
            if (g.CurrentRow == null) return null;
            if (!g.Columns.Contains(tenCot)) return null;
            return g.CurrentRow.Cells[tenCot].Value;
        }

        public static string ChuoiChon(DataGridView g, string tenCot)
        {
            object o = OChon(g, tenCot);
            return o == null || o == DBNull.Value ? null : Convert.ToString(o);
        }

        public static void Bao(KetQuaXuLy kq)
        {
            MessageBox.Show(kq.ThongBao,
                kq.ThanhCong ? "Thành công" : "Không thực hiện được",
                MessageBoxButtons.OK,
                kq.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        public static void Loi(string thongBao)
        {
            MessageBox.Show(thongBao, "Thiếu thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>Thiết lập chung cho mọi Form con.</summary>
        public static void ChuanHoa(Form f, string tieuDe, int rong, int cao)
        {
            f.AutoScaleMode = AutoScaleMode.None;
            f.Text = tieuDe;
            f.ClientSize = new Size(rong, cao);
            f.StartPosition = FormStartPosition.CenterParent;
            f.Font = FontChung;
            f.BackColor = Color.White;
        }
    }
}
