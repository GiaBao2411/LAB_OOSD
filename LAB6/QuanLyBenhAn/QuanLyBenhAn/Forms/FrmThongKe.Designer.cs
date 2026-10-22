namespace QuanLyBenhAn.Forms
{
    partial class FrmThongKe
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
            this.tpBS = new System.Windows.Forms.TabPage();
            this.tpHan = new System.Windows.Forms.TabPage();
            this.tpPU = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.dtTu = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtDen = new System.Windows.Forms.DateTimePicker();
            this.btnTK = new System.Windows.Forms.Button();
            this.dgvBS = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.numNgay = new System.Windows.Forms.NumericUpDown();
            this.btnXemHan = new System.Windows.Forms.Button();
            this.dgvHan = new System.Windows.Forms.DataGridView();
            this.btnXemPU = new System.Windows.Forms.Button();
            this.dgvPU = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPU)).BeginInit();
            this.SuspendLayout();
            this.tabTK.SuspendLayout();
            this.tpBS.SuspendLayout();
            this.tpHan.SuspendLayout();
            this.tpPU.SuspendLayout();
            this.tabTK.Name = "tabTK";
            this.tabTK.Location = new System.Drawing.Point(10, 10);
            this.tabTK.Size = new System.Drawing.Size(940, 500);
            this.tabTK.TabIndex = 0;
            this.Controls.Add(this.tabTK);
            this.tpBS.Name = "tpBS";
            this.tpBS.Text = "Theo bác sĩ";
            this.tpBS.Padding = new System.Windows.Forms.Padding(3);
            this.tpBS.UseVisualStyleBackColor = true;
            this.tabTK.Controls.Add(this.tpBS);
            this.tpHan.Name = "tpHan";
            this.tpHan.Text = "Hồ sơ sắp hết hạn";
            this.tpHan.Padding = new System.Windows.Forms.Padding(3);
            this.tpHan.UseVisualStyleBackColor = true;
            this.tabTK.Controls.Add(this.tpHan);
            this.tpPU.Name = "tpPU";
            this.tpPU.Text = "Phản ứng phụ của thuốc";
            this.tpPU.Padding = new System.Windows.Forms.Padding(3);
            this.tpPU.UseVisualStyleBackColor = true;
            this.tabTK.Controls.Add(this.tpPU);
            this.label1.Name = "label1";
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.AutoSize = true;
            this.label1.Text = "Từ ngày";
            this.label1.TabIndex = 1;
            this.tpBS.Controls.Add(this.label1);
            this.dtTu.Name = "dtTu";
            this.dtTu.Location = new System.Drawing.Point(70, 15);
            this.dtTu.Size = new System.Drawing.Size(110, 23);
            this.dtTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTu.CustomFormat = "dd/MM/yyyy";
            this.dtTu.TabIndex = 2;
            this.tpBS.Controls.Add(this.dtTu);
            this.label2.Name = "label2";
            this.label2.Location = new System.Drawing.Point(250, 18);
            this.label2.AutoSize = true;
            this.label2.Text = "Đến ngày";
            this.label2.TabIndex = 3;
            this.tpBS.Controls.Add(this.label2);
            this.dtDen.Name = "dtDen";
            this.dtDen.Location = new System.Drawing.Point(315, 15);
            this.dtDen.Size = new System.Drawing.Size(110, 23);
            this.dtDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDen.CustomFormat = "dd/MM/yyyy";
            this.dtDen.TabIndex = 4;
            this.tpBS.Controls.Add(this.dtDen);
            this.btnTK.Name = "btnTK";
            this.btnTK.Location = new System.Drawing.Point(470, 12);
            this.btnTK.Size = new System.Drawing.Size(120, 28);
            this.btnTK.Text = "Thống kê";
            this.btnTK.UseVisualStyleBackColor = true;
            this.btnTK.TabIndex = 5;
            this.btnTK.Click += new System.EventHandler(this.btnTK_Click);
            this.tpBS.Controls.Add(this.btnTK);
            this.dgvBS.Name = "dgvBS";
            this.dgvBS.Location = new System.Drawing.Point(10, 55);
            this.dgvBS.Size = new System.Drawing.Size(900, 410);
            this.dgvBS.AllowUserToAddRows = false;
            this.dgvBS.AllowUserToDeleteRows = false;
            this.dgvBS.ReadOnly = true;
            this.dgvBS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBS.MultiSelect = false;
            this.dgvBS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBS.RowHeadersVisible = false;
            this.dgvBS.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvBS.TabIndex = 6;
            this.tpBS.Controls.Add(this.dgvBS);
            this.label3.Name = "label3";
            this.label3.Location = new System.Drawing.Point(10, 18);
            this.label3.AutoSize = true;
            this.label3.Text = "Còn hạn trong (ngày)";
            this.label3.TabIndex = 7;
            this.tpHan.Controls.Add(this.label3);
            this.numNgay.Name = "numNgay";
            this.numNgay.Location = new System.Drawing.Point(145, 15);
            this.numNgay.Size = new System.Drawing.Size(70, 23);
            this.numNgay.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numNgay.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            this.numNgay.Value = new decimal(new int[] { 30, 0, 0, 0 });
            this.numNgay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numNgay.TabIndex = 8;
            this.tpHan.Controls.Add(this.numNgay);
            this.btnXemHan.Name = "btnXemHan";
            this.btnXemHan.Location = new System.Drawing.Point(300, 12);
            this.btnXemHan.Size = new System.Drawing.Size(100, 28);
            this.btnXemHan.Text = "Xem";
            this.btnXemHan.UseVisualStyleBackColor = true;
            this.btnXemHan.TabIndex = 9;
            this.btnXemHan.Click += new System.EventHandler(this.btnXemHan_Click);
            this.tpHan.Controls.Add(this.btnXemHan);
            this.dgvHan.Name = "dgvHan";
            this.dgvHan.Location = new System.Drawing.Point(10, 55);
            this.dgvHan.Size = new System.Drawing.Size(900, 410);
            this.dgvHan.AllowUserToAddRows = false;
            this.dgvHan.AllowUserToDeleteRows = false;
            this.dgvHan.ReadOnly = true;
            this.dgvHan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHan.MultiSelect = false;
            this.dgvHan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHan.RowHeadersVisible = false;
            this.dgvHan.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvHan.TabIndex = 10;
            this.tpHan.Controls.Add(this.dgvHan);
            this.btnXemPU.Name = "btnXemPU";
            this.btnXemPU.Location = new System.Drawing.Point(10, 12);
            this.btnXemPU.Size = new System.Drawing.Size(100, 28);
            this.btnXemPU.Text = "Làm mới";
            this.btnXemPU.UseVisualStyleBackColor = true;
            this.btnXemPU.TabIndex = 11;
            this.btnXemPU.Click += new System.EventHandler(this.btnXemPU_Click);
            this.tpPU.Controls.Add(this.btnXemPU);
            this.dgvPU.Name = "dgvPU";
            this.dgvPU.Location = new System.Drawing.Point(10, 55);
            this.dgvPU.Size = new System.Drawing.Size(900, 410);
            this.dgvPU.AllowUserToAddRows = false;
            this.dgvPU.AllowUserToDeleteRows = false;
            this.dgvPU.ReadOnly = true;
            this.dgvPU.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPU.MultiSelect = false;
            this.dgvPU.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPU.RowHeadersVisible = false;
            this.dgvPU.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPU.TabIndex = 12;
            this.tpPU.Controls.Add(this.dgvPU);
            this.btnDong.Name = "btnDong";
            this.btnDong.Location = new System.Drawing.Point(850, 518);
            this.btnDong.Size = new System.Drawing.Size(100, 28);
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.TabIndex = 13;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            this.Controls.Add(this.btnDong);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPU)).EndInit();
            this.tabTK.ResumeLayout(false);
            this.tpBS.ResumeLayout(false);
            this.tpHan.ResumeLayout(false);
            this.tpPU.ResumeLayout(false);
            //
            // FrmThongKe
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 560);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thống kê";
            this.Load += new System.EventHandler(this.FrmThongKe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabTK;
        private System.Windows.Forms.TabPage tpBS;
        private System.Windows.Forms.TabPage tpHan;
        private System.Windows.Forms.TabPage tpPU;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtTu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDen;
        private System.Windows.Forms.Button btnTK;
        private System.Windows.Forms.DataGridView dgvBS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numNgay;
        private System.Windows.Forms.Button btnXemHan;
        private System.Windows.Forms.DataGridView dgvHan;
        private System.Windows.Forms.Button btnXemPU;
        private System.Windows.Forms.DataGridView dgvPU;
        private System.Windows.Forms.Button btnDong;
    }
}
