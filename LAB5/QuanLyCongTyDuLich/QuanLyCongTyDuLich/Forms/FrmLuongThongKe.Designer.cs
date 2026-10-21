namespace QuanLyCongTyDuLich.Forms
{
    partial class FrmLuongThongKe
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabTK = new System.Windows.Forms.TabControl();
            this.tpLuong = new System.Windows.Forms.TabPage();
            this.tpTH = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.numThang = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.btnLuong = new System.Windows.Forms.Button();
            this.dgvLuong = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dtTu = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtDen = new System.Windows.Forms.DateTimePicker();
            this.btnTongHop = new System.Windows.Forms.Button();
            this.dgvTongHop = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongHop)).BeginInit();
            this.SuspendLayout();
            this.tabTK.SuspendLayout();
            this.tpLuong.SuspendLayout();
            this.tpTH.SuspendLayout();
            this.tabTK.Name = "tabTK";
            this.tabTK.Location = new System.Drawing.Point(10, 10);
            this.tabTK.Size = new System.Drawing.Size(880, 500);
            this.tabTK.TabIndex = 0;
            this.Controls.Add(this.tabTK);
            this.tpLuong.Name = "tpLuong";
            this.tpLuong.Text = "Lương hướng dẫn viên";
            this.tpLuong.Padding = new System.Windows.Forms.Padding(3);
            this.tpLuong.UseVisualStyleBackColor = true;
            this.tabTK.Controls.Add(this.tpLuong);
            this.tpTH.Name = "tpTH";
            this.tpTH.Text = "Thống kê tổng hợp";
            this.tpTH.Padding = new System.Windows.Forms.Padding(3);
            this.tpTH.UseVisualStyleBackColor = true;
            this.tabTK.Controls.Add(this.tpTH);
            this.label1.Name = "label1";
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.AutoSize = true;
            this.label1.Text = "Tháng";
            this.label1.TabIndex = 1;
            this.tpLuong.Controls.Add(this.label1);
            this.numThang.Name = "numThang";
            this.numThang.Location = new System.Drawing.Point(60, 15);
            this.numThang.Size = new System.Drawing.Size(60, 23);
            this.numThang.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numThang.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            this.numThang.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numThang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numThang.TabIndex = 2;
            this.tpLuong.Controls.Add(this.numThang);
            this.label2.Name = "label2";
            this.label2.Location = new System.Drawing.Point(200, 18);
            this.label2.AutoSize = true;
            this.label2.Text = "Năm";
            this.label2.TabIndex = 3;
            this.tpLuong.Controls.Add(this.label2);
            this.numNam.Name = "numNam";
            this.numNam.Location = new System.Drawing.Point(240, 15);
            this.numNam.Size = new System.Drawing.Size(80, 23);
            this.numNam.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.numNam.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            this.numNam.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            this.numNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numNam.TabIndex = 4;
            this.tpLuong.Controls.Add(this.numNam);
            this.btnLuong.Name = "btnLuong";
            this.btnLuong.Location = new System.Drawing.Point(380, 12);
            this.btnLuong.Size = new System.Drawing.Size(120, 28);
            this.btnLuong.Text = "Tính lương";
            this.btnLuong.UseVisualStyleBackColor = true;
            this.btnLuong.TabIndex = 5;
            this.btnLuong.Click += new System.EventHandler(this.btnLuong_Click);
            this.tpLuong.Controls.Add(this.btnLuong);
            this.dgvLuong.Name = "dgvLuong";
            this.dgvLuong.Location = new System.Drawing.Point(10, 55);
            this.dgvLuong.Size = new System.Drawing.Size(850, 400);
            this.dgvLuong.AllowUserToAddRows = false;
            this.dgvLuong.AllowUserToDeleteRows = false;
            this.dgvLuong.ReadOnly = true;
            this.dgvLuong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLuong.MultiSelect = false;
            this.dgvLuong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLuong.RowHeadersVisible = false;
            this.dgvLuong.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvLuong.TabIndex = 6;
            this.tpLuong.Controls.Add(this.dgvLuong);
            this.label3.Name = "label3";
            this.label3.Location = new System.Drawing.Point(10, 18);
            this.label3.AutoSize = true;
            this.label3.Text = "Từ ngày";
            this.label3.TabIndex = 7;
            this.tpTH.Controls.Add(this.label3);
            this.dtTu.Name = "dtTu";
            this.dtTu.Location = new System.Drawing.Point(70, 15);
            this.dtTu.Size = new System.Drawing.Size(110, 23);
            this.dtTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTu.CustomFormat = "dd/MM/yyyy";
            this.dtTu.TabIndex = 8;
            this.tpTH.Controls.Add(this.dtTu);
            this.label4.Name = "label4";
            this.label4.Location = new System.Drawing.Point(250, 18);
            this.label4.AutoSize = true;
            this.label4.Text = "Đến ngày";
            this.label4.TabIndex = 9;
            this.tpTH.Controls.Add(this.label4);
            this.dtDen.Name = "dtDen";
            this.dtDen.Location = new System.Drawing.Point(315, 15);
            this.dtDen.Size = new System.Drawing.Size(110, 23);
            this.dtDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDen.CustomFormat = "dd/MM/yyyy";
            this.dtDen.TabIndex = 10;
            this.tpTH.Controls.Add(this.dtDen);
            this.btnTongHop.Name = "btnTongHop";
            this.btnTongHop.Location = new System.Drawing.Point(470, 12);
            this.btnTongHop.Size = new System.Drawing.Size(120, 28);
            this.btnTongHop.Text = "Thống kê";
            this.btnTongHop.UseVisualStyleBackColor = true;
            this.btnTongHop.TabIndex = 11;
            this.btnTongHop.Click += new System.EventHandler(this.btnTongHop_Click);
            this.tpTH.Controls.Add(this.btnTongHop);
            this.dgvTongHop.Name = "dgvTongHop";
            this.dgvTongHop.Location = new System.Drawing.Point(10, 55);
            this.dgvTongHop.Size = new System.Drawing.Size(850, 400);
            this.dgvTongHop.AllowUserToAddRows = false;
            this.dgvTongHop.AllowUserToDeleteRows = false;
            this.dgvTongHop.ReadOnly = true;
            this.dgvTongHop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTongHop.MultiSelect = false;
            this.dgvTongHop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTongHop.RowHeadersVisible = false;
            this.dgvTongHop.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTongHop.TabIndex = 12;
            this.tpTH.Controls.Add(this.dgvTongHop);
            this.btnDong.Name = "btnDong";
            this.btnDong.Location = new System.Drawing.Point(790, 518);
            this.btnDong.Size = new System.Drawing.Size(100, 28);
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.TabIndex = 13;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            this.Controls.Add(this.btnDong);
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongHop)).EndInit();
            this.tabTK.ResumeLayout(false);
            this.tpLuong.ResumeLayout(false);
            this.tpTH.ResumeLayout(false);
            //
            // FrmLuongThongKe
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 560);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLuongThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lương - thống kê";
            this.Load += new System.EventHandler(this.FrmLuongThongKe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabTK;
        private System.Windows.Forms.TabPage tpLuong;
        private System.Windows.Forms.TabPage tpTH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numThang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numNam;
        private System.Windows.Forms.Button btnLuong;
        private System.Windows.Forms.DataGridView dgvLuong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtTu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtDen;
        private System.Windows.Forms.Button btnTongHop;
        private System.Windows.Forms.DataGridView dgvTongHop;
        private System.Windows.Forms.Button btnDong;
    }
}
