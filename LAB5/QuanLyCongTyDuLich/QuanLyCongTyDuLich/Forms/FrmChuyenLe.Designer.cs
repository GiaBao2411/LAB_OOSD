namespace QuanLyCongTyDuLich.Forms
{
    partial class FrmChuyenLe
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
            this.txtMa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTour = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtDi = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNgayVe = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDon = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnDongDK = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            this.label1.Name = "label1";
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.AutoSize = true;
            this.label1.Text = "Mã chuyến";
            this.label1.TabIndex = 0;
            this.Controls.Add(this.label1);
            this.txtMa.Name = "txtMa";
            this.txtMa.Location = new System.Drawing.Point(90, 15);
            this.txtMa.Size = new System.Drawing.Size(100, 23);
            this.txtMa.TabIndex = 1;
            this.Controls.Add(this.txtMa);
            this.label2.Name = "label2";
            this.label2.Location = new System.Drawing.Point(230, 18);
            this.label2.AutoSize = true;
            this.label2.Text = "Tour";
            this.label2.TabIndex = 2;
            this.Controls.Add(this.label2);
            this.cboTour.Name = "cboTour";
            this.cboTour.Location = new System.Drawing.Point(270, 15);
            this.cboTour.Size = new System.Drawing.Size(300, 23);
            this.cboTour.FormattingEnabled = true;
            this.cboTour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTour.TabIndex = 3;
            this.cboTour.SelectedIndexChanged += new System.EventHandler(this.TinhNgayVe);
            this.Controls.Add(this.cboTour);
            this.label3.Name = "label3";
            this.label3.Location = new System.Drawing.Point(600, 18);
            this.label3.AutoSize = true;
            this.label3.Text = "Ngày đi";
            this.label3.TabIndex = 4;
            this.Controls.Add(this.label3);
            this.dtDi.Name = "dtDi";
            this.dtDi.Location = new System.Drawing.Point(660, 15);
            this.dtDi.Size = new System.Drawing.Size(110, 23);
            this.dtDi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDi.CustomFormat = "dd/MM/yyyy";
            this.dtDi.TabIndex = 5;
            this.dtDi.ValueChanged += new System.EventHandler(this.TinhNgayVe);
            this.Controls.Add(this.dtDi);
            this.label4.Name = "label4";
            this.label4.Location = new System.Drawing.Point(10, 55);
            this.label4.AutoSize = true;
            this.label4.Text = "Ngày về:";
            this.label4.TabIndex = 6;
            this.Controls.Add(this.label4);
            this.lblNgayVe.Name = "lblNgayVe";
            this.lblNgayVe.Location = new System.Drawing.Point(90, 55);
            this.lblNgayVe.AutoSize = true;
            this.lblNgayVe.Text = "-";
            this.lblNgayVe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNgayVe.TabIndex = 7;
            this.Controls.Add(this.lblNgayVe);
            this.label5.Name = "label5";
            this.label5.Location = new System.Drawing.Point(230, 53);
            this.label5.AutoSize = true;
            this.label5.Text = "Địa điểm đón";
            this.label5.TabIndex = 8;
            this.Controls.Add(this.label5);
            this.txtDon.Name = "txtDon";
            this.txtDon.Location = new System.Drawing.Point(320, 50);
            this.txtDon.Size = new System.Drawing.Size(300, 23);
            this.txtDon.TabIndex = 9;
            this.Controls.Add(this.txtDon);
            this.btnThem.Name = "btnThem";
            this.btnThem.Location = new System.Drawing.Point(640, 48);
            this.btnThem.Size = new System.Drawing.Size(110, 28);
            this.btnThem.Text = "Tạo chuyến";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.TabIndex = 10;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.Controls.Add(this.btnThem);
            this.btnDongDK.Name = "btnDongDK";
            this.btnDongDK.Location = new System.Drawing.Point(760, 48);
            this.btnDongDK.Size = new System.Drawing.Size(120, 28);
            this.btnDongDK.Text = "Đóng đăng ký";
            this.btnDongDK.UseVisualStyleBackColor = true;
            this.btnDongDK.TabIndex = 11;
            this.btnDongDK.Click += new System.EventHandler(this.btnDongDK_Click);
            this.Controls.Add(this.btnDongDK);
            this.dgv.Name = "dgv";
            this.dgv.Location = new System.Drawing.Point(10, 95);
            this.dgv.Size = new System.Drawing.Size(880, 370);
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ReadOnly = true;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.MultiSelect = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.RowHeadersVisible = false;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv.TabIndex = 12;
            this.Controls.Add(this.dgv);
            this.btnDong.Name = "btnDong";
            this.btnDong.Location = new System.Drawing.Point(790, 478);
            this.btnDong.Size = new System.Drawing.Size(100, 28);
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.TabIndex = 13;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            this.Controls.Add(this.btnDong);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            //
            // FrmChuyenLe
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 520);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChuyenLe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lịch chuyến khách lẻ";
            this.Load += new System.EventHandler(this.FrmChuyenLe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTour;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtDi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNgayVe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDon;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnDongDK;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnDong;
    }
}
