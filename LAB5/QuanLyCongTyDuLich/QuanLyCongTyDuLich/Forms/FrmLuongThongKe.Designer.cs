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
            this.label1 = new System.Windows.Forms.Label();
            this.numThang = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.btnLuong = new System.Windows.Forms.Button();
            this.dgvLuong = new System.Windows.Forms.DataGridView();
            this.tpTH = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.dtTu = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtDen = new System.Windows.Forms.DateTimePicker();
            this.btnTongHop = new System.Windows.Forms.Button();
            this.dgvTongHop = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabTK.SuspendLayout();
            this.tpLuong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).BeginInit();
            this.tpTH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongHop)).BeginInit();
            this.SuspendLayout();
            // 
            // tabTK
            // 
            this.tabTK.Controls.Add(this.tpLuong);
            this.tabTK.Controls.Add(this.tpTH);
            this.tabTK.Location = new System.Drawing.Point(10, 10);
            this.tabTK.Name = "tabTK";
            this.tabTK.SelectedIndex = 0;
            this.tabTK.Size = new System.Drawing.Size(880, 500);
            this.tabTK.TabIndex = 0;
            // 
            // tpLuong
            // 
            this.tpLuong.Controls.Add(this.label1);
            this.tpLuong.Controls.Add(this.numThang);
            this.tpLuong.Controls.Add(this.label2);
            this.tpLuong.Controls.Add(this.numNam);
            this.tpLuong.Controls.Add(this.btnLuong);
            this.tpLuong.Controls.Add(this.dgvLuong);
            this.tpLuong.Location = new System.Drawing.Point(4, 29);
            this.tpLuong.Name = "tpLuong";
            this.tpLuong.Padding = new System.Windows.Forms.Padding(3);
            this.tpLuong.Size = new System.Drawing.Size(872, 467);
            this.tpLuong.TabIndex = 0;
            this.tpLuong.Text = "Lương hướng dẫn viên";
            this.tpLuong.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tháng";
            // 
            // numThang
            // 
            this.numThang.Location = new System.Drawing.Point(60, 15);
            this.numThang.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numThang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThang.Name = "numThang";
            this.numThang.Size = new System.Drawing.Size(60, 27);
            this.numThang.TabIndex = 2;
            this.numThang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numThang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Năm";
            // 
            // numNam
            // 
            this.numNam.Location = new System.Drawing.Point(247, 15);
            this.numNam.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numNam.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numNam.Name = "numNam";
            this.numNam.Size = new System.Drawing.Size(80, 27);
            this.numNam.TabIndex = 4;
            this.numNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numNam.Value = new decimal(new int[] {
            2026,
            0,
            0,
            0});
            // 
            // btnLuong
            // 
            this.btnLuong.Location = new System.Drawing.Point(385, 13);
            this.btnLuong.Name = "btnLuong";
            this.btnLuong.Size = new System.Drawing.Size(120, 28);
            this.btnLuong.TabIndex = 5;
            this.btnLuong.Text = "Tính lương";
            this.btnLuong.UseVisualStyleBackColor = true;
            this.btnLuong.Click += new System.EventHandler(this.btnLuong_Click);
            // 
            // dgvLuong
            // 
            this.dgvLuong.AllowUserToAddRows = false;
            this.dgvLuong.AllowUserToDeleteRows = false;
            this.dgvLuong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLuong.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvLuong.ColumnHeadersHeight = 29;
            this.dgvLuong.Location = new System.Drawing.Point(10, 55);
            this.dgvLuong.MultiSelect = false;
            this.dgvLuong.Name = "dgvLuong";
            this.dgvLuong.ReadOnly = true;
            this.dgvLuong.RowHeadersVisible = false;
            this.dgvLuong.RowHeadersWidth = 51;
            this.dgvLuong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLuong.Size = new System.Drawing.Size(850, 400);
            this.dgvLuong.TabIndex = 6;
            // 
            // tpTH
            // 
            this.tpTH.Controls.Add(this.label3);
            this.tpTH.Controls.Add(this.dtTu);
            this.tpTH.Controls.Add(this.label4);
            this.tpTH.Controls.Add(this.dtDen);
            this.tpTH.Controls.Add(this.btnTongHop);
            this.tpTH.Controls.Add(this.dgvTongHop);
            this.tpTH.Location = new System.Drawing.Point(4, 29);
            this.tpTH.Name = "tpTH";
            this.tpTH.Padding = new System.Windows.Forms.Padding(3);
            this.tpTH.Size = new System.Drawing.Size(872, 467);
            this.tpTH.TabIndex = 1;
            this.tpTH.Text = "Thống kê tổng hợp";
            this.tpTH.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Từ ngày";
            // 
            // dtTu
            // 
            this.dtTu.CustomFormat = "dd/MM/yyyy";
            this.dtTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTu.Location = new System.Drawing.Point(78, 15);
            this.dtTu.Name = "dtTu";
            this.dtTu.Size = new System.Drawing.Size(110, 27);
            this.dtTu.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(250, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Đến ngày";
            // 
            // dtDen
            // 
            this.dtDen.CustomFormat = "dd/MM/yyyy";
            this.dtDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDen.Location = new System.Drawing.Point(328, 15);
            this.dtDen.Name = "dtDen";
            this.dtDen.Size = new System.Drawing.Size(110, 27);
            this.dtDen.TabIndex = 10;
            // 
            // btnTongHop
            // 
            this.btnTongHop.Location = new System.Drawing.Point(482, 14);
            this.btnTongHop.Name = "btnTongHop";
            this.btnTongHop.Size = new System.Drawing.Size(120, 28);
            this.btnTongHop.TabIndex = 11;
            this.btnTongHop.Text = "Thống kê";
            this.btnTongHop.UseVisualStyleBackColor = true;
            this.btnTongHop.Click += new System.EventHandler(this.btnTongHop_Click);
            // 
            // dgvTongHop
            // 
            this.dgvTongHop.AllowUserToAddRows = false;
            this.dgvTongHop.AllowUserToDeleteRows = false;
            this.dgvTongHop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTongHop.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTongHop.ColumnHeadersHeight = 29;
            this.dgvTongHop.Location = new System.Drawing.Point(10, 55);
            this.dgvTongHop.MultiSelect = false;
            this.dgvTongHop.Name = "dgvTongHop";
            this.dgvTongHop.ReadOnly = true;
            this.dgvTongHop.RowHeadersVisible = false;
            this.dgvTongHop.RowHeadersWidth = 51;
            this.dgvTongHop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTongHop.Size = new System.Drawing.Size(850, 400);
            this.dgvTongHop.TabIndex = 12;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(790, 518);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 28);
            this.btnDong.TabIndex = 13;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmLuongThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 560);
            this.Controls.Add(this.tabTK);
            this.Controls.Add(this.btnDong);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLuongThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lương - thống kê";
            this.Load += new System.EventHandler(this.FrmLuongThongKe_Load);
            this.tabTK.ResumeLayout(false);
            this.tpLuong.ResumeLayout(false);
            this.tpLuong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).EndInit();
            this.tpTH.ResumeLayout(false);
            this.tpTH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongHop)).EndInit();
            this.ResumeLayout(false);

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
