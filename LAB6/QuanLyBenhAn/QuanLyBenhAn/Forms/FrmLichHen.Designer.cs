namespace QuanLyBenhAn.Forms
{
    partial class FrmLichHen
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboHoSo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtHen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnDat = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.lblGoiY = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            this.label1.Name = "label1";
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.AutoSize = true;
            this.label1.Text = "Hồ sơ";
            this.label1.TabIndex = 0;
            this.Controls.Add(this.label1);
            this.cboHoSo.Name = "cboHoSo";
            this.cboHoSo.Location = new System.Drawing.Point(55, 12);
            this.cboHoSo.Size = new System.Drawing.Size(380, 23);
            this.cboHoSo.FormattingEnabled = true;
            this.cboHoSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHoSo.TabIndex = 1;
            this.cboHoSo.SelectedIndexChanged += new System.EventHandler(this.cboHoSo_SelectedIndexChanged);
            this.Controls.Add(this.cboHoSo);
            this.label2.Name = "label2";
            this.label2.Location = new System.Drawing.Point(440, 15);
            this.label2.AutoSize = true;
            this.label2.Text = "Ngày giờ hẹn";
            this.label2.TabIndex = 2;
            this.Controls.Add(this.label2);
            this.dtHen.Name = "dtHen";
            this.dtHen.Location = new System.Drawing.Point(530, 12);
            this.dtHen.Size = new System.Drawing.Size(170, 23);
            this.dtHen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHen.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtHen.TabIndex = 3;
            this.Controls.Add(this.dtHen);
            this.label3.Name = "label3";
            this.label3.Location = new System.Drawing.Point(10, 53);
            this.label3.AutoSize = true;
            this.label3.Text = "Ghi chú";
            this.label3.TabIndex = 4;
            this.Controls.Add(this.label3);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Location = new System.Drawing.Point(55, 50);
            this.txtGhiChu.Size = new System.Drawing.Size(380, 23);
            this.txtGhiChu.TabIndex = 5;
            this.Controls.Add(this.txtGhiChu);
            this.btnDat.Name = "btnDat";
            this.btnDat.Location = new System.Drawing.Point(440, 47);
            this.btnDat.Size = new System.Drawing.Size(130, 28);
            this.btnDat.Text = "Đặt lịch hẹn";
            this.btnDat.UseVisualStyleBackColor = true;
            this.btnDat.TabIndex = 6;
            this.btnDat.Click += new System.EventHandler(this.btnDat_Click);
            this.Controls.Add(this.btnDat);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Location = new System.Drawing.Point(580, 47);
            this.btnHuy.Size = new System.Drawing.Size(150, 28);
            this.btnHuy.Text = "Hủy lịch đang chọn";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            this.Controls.Add(this.btnHuy);
            this.lblGoiY.Name = "lblGoiY";
            this.lblGoiY.Location = new System.Drawing.Point(10, 88);
            this.lblGoiY.AutoSize = true;
            this.lblGoiY.Text = "Quyền lợi: mỗi quý khám sức khỏe định kỳ 1 lần, miễn phí. Giờ làm việc 07:00 - 17:00, không nhận Chủ nhật.";
            this.lblGoiY.TabIndex = 8;
            this.Controls.Add(this.lblGoiY);
            this.dgv.Name = "dgv";
            this.dgv.Location = new System.Drawing.Point(10, 115);
            this.dgv.Size = new System.Drawing.Size(940, 375);
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ReadOnly = true;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.MultiSelect = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.RowHeadersVisible = false;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv.TabIndex = 9;
            this.Controls.Add(this.dgv);
            this.btnDong.Name = "btnDong";
            this.btnDong.Location = new System.Drawing.Point(850, 505);
            this.btnDong.Size = new System.Drawing.Size(100, 28);
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.TabIndex = 10;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            this.Controls.Add(this.btnDong);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            //
            // FrmLichHen
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 550);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLichHen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hẹn khám sức khỏe định kỳ";
            this.Load += new System.EventHandler(this.FrmLichHen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboHoSo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtHen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnDat;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label lblGoiY;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnDong;
    }
}
