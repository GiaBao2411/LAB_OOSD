namespace QuanLyCongTyDuLich.Forms
{
    partial class FrmKetThucKhaoSat
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
            this.tabKT = new System.Windows.Forms.TabControl();
            this.tpTT = new System.Windows.Forms.TabPage();
            this.dgvDoan = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoTT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoDK = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtTT = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.numTien = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.tpKS = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.cboLoaiKS = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboDangKy = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMaKS = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtGui = new System.Windows.Forms.DateTimePicker();
            this.btnGui = new System.Windows.Forms.Button();
            this.dgvKS = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.txtKSChon = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtPH = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.numDiem = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.txtGopY = new System.Windows.Forms.TextBox();
            this.btnGhiPH = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabKT.SuspendLayout();
            this.tpTT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTien)).BeginInit();
            this.tpKS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiem)).BeginInit();
            this.SuspendLayout();
            // 
            // tabKT
            // 
            this.tabKT.Controls.Add(this.tpTT);
            this.tabKT.Controls.Add(this.tpKS);
            this.tabKT.Location = new System.Drawing.Point(10, 10);
            this.tabKT.Name = "tabKT";
            this.tabKT.SelectedIndex = 0;
            this.tabKT.Size = new System.Drawing.Size(980, 560);
            this.tabKT.TabIndex = 0;
            // 
            // tpTT
            // 
            this.tpTT.Controls.Add(this.dgvDoan);
            this.tpTT.Controls.Add(this.label1);
            this.tpTT.Controls.Add(this.txtSoTT);
            this.tpTT.Controls.Add(this.label2);
            this.tpTT.Controls.Add(this.txtSoDK);
            this.tpTT.Controls.Add(this.label3);
            this.tpTT.Controls.Add(this.dtTT);
            this.tpTT.Controls.Add(this.label4);
            this.tpTT.Controls.Add(this.numTien);
            this.tpTT.Controls.Add(this.label5);
            this.tpTT.Controls.Add(this.txtGhiChu);
            this.tpTT.Controls.Add(this.btnThanhToan);
            this.tpTT.Location = new System.Drawing.Point(4, 29);
            this.tpTT.Name = "tpTT";
            this.tpTT.Padding = new System.Windows.Forms.Padding(3);
            this.tpTT.Size = new System.Drawing.Size(972, 527);
            this.tpTT.TabIndex = 0;
            this.tpTT.Text = "Thanh toán sau tour (đoàn)";
            this.tpTT.UseVisualStyleBackColor = true;
            // 
            // dgvDoan
            // 
            this.dgvDoan.AllowUserToAddRows = false;
            this.dgvDoan.AllowUserToDeleteRows = false;
            this.dgvDoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoan.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDoan.ColumnHeadersHeight = 29;
            this.dgvDoan.Location = new System.Drawing.Point(10, 10);
            this.dgvDoan.MultiSelect = false;
            this.dgvDoan.Name = "dgvDoan";
            this.dgvDoan.ReadOnly = true;
            this.dgvDoan.RowHeadersVisible = false;
            this.dgvDoan.RowHeadersWidth = 51;
            this.dgvDoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoan.Size = new System.Drawing.Size(950, 330);
            this.dgvDoan.TabIndex = 1;
            this.dgvDoan.SelectionChanged += new System.EventHandler(this.dgvDoan_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 358);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Số thanh toán";
            // 
            // txtSoTT
            // 
            this.txtSoTT.Location = new System.Drawing.Point(117, 355);
            this.txtSoTT.Name = "txtSoTT";
            this.txtSoTT.Size = new System.Drawing.Size(110, 27);
            this.txtSoTT.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 358);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Phiếu đoàn";
            // 
            // txtSoDK
            // 
            this.txtSoDK.Location = new System.Drawing.Point(389, 355);
            this.txtSoDK.Name = "txtSoDK";
            this.txtSoDK.ReadOnly = true;
            this.txtSoDK.Size = new System.Drawing.Size(110, 27);
            this.txtSoDK.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(520, 358);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ngày thanh toán";
            // 
            // dtTT
            // 
            this.dtTT.CustomFormat = "dd/MM/yyyy";
            this.dtTT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTT.Location = new System.Drawing.Point(645, 355);
            this.dtTT.Name = "dtTT";
            this.dtTT.Size = new System.Drawing.Size(110, 27);
            this.dtTT.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 395);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Số tiền";
            // 
            // numTien
            // 
            this.numTien.Increment = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numTien.Location = new System.Drawing.Point(100, 392);
            this.numTien.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.numTien.Name = "numTien";
            this.numTien.Size = new System.Drawing.Size(150, 27);
            this.numTien.TabIndex = 9;
            this.numTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTien.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 395);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ghi chú";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(375, 392);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(330, 27);
            this.txtGhiChu.TabIndex = 11;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(730, 391);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(190, 28);
            this.btnThanhToan.TabIndex = 12;
            this.btnThanhToan.Text = "Ghi nhận thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // tpKS
            // 
            this.tpKS.Controls.Add(this.label6);
            this.tpKS.Controls.Add(this.cboLoaiKS);
            this.tpKS.Controls.Add(this.label7);
            this.tpKS.Controls.Add(this.cboDangKy);
            this.tpKS.Controls.Add(this.label8);
            this.tpKS.Controls.Add(this.txtMaKS);
            this.tpKS.Controls.Add(this.label9);
            this.tpKS.Controls.Add(this.dtGui);
            this.tpKS.Controls.Add(this.btnGui);
            this.tpKS.Controls.Add(this.dgvKS);
            this.tpKS.Controls.Add(this.label10);
            this.tpKS.Controls.Add(this.txtKSChon);
            this.tpKS.Controls.Add(this.label11);
            this.tpKS.Controls.Add(this.dtPH);
            this.tpKS.Controls.Add(this.label12);
            this.tpKS.Controls.Add(this.numDiem);
            this.tpKS.Controls.Add(this.label13);
            this.tpKS.Controls.Add(this.txtGopY);
            this.tpKS.Controls.Add(this.btnGhiPH);
            this.tpKS.Location = new System.Drawing.Point(4, 29);
            this.tpKS.Name = "tpKS";
            this.tpKS.Padding = new System.Windows.Forms.Padding(3);
            this.tpKS.Size = new System.Drawing.Size(972, 527);
            this.tpKS.TabIndex = 1;
            this.tpKS.Text = "Khảo sát khách hàng";
            this.tpKS.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Loại khách";
            // 
            // cboLoaiKS
            // 
            this.cboLoaiKS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiKS.FormattingEnabled = true;
            this.cboLoaiKS.Location = new System.Drawing.Point(85, 15);
            this.cboLoaiKS.Name = "cboLoaiKS";
            this.cboLoaiKS.Size = new System.Drawing.Size(80, 28);
            this.cboLoaiKS.TabIndex = 14;
            this.cboLoaiKS.SelectedIndexChanged += new System.EventHandler(this.cboLoaiKS_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(190, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Đăng ký đã kết thúc";
            // 
            // cboDangKy
            // 
            this.cboDangKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDangKy.FormattingEnabled = true;
            this.cboDangKy.Location = new System.Drawing.Point(336, 15);
            this.cboDangKy.Name = "cboDangKy";
            this.cboDangKy.Size = new System.Drawing.Size(239, 28);
            this.cboDangKy.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(620, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Mã KS";
            // 
            // txtMaKS
            // 
            this.txtMaKS.Location = new System.Drawing.Point(677, 15);
            this.txtMaKS.Name = "txtMaKS";
            this.txtMaKS.Size = new System.Drawing.Size(80, 27);
            this.txtMaKS.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(784, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "Ngày gửi";
            // 
            // dtGui
            // 
            this.dtGui.CustomFormat = "dd/MM/yyyy";
            this.dtGui.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtGui.Location = new System.Drawing.Point(860, 16);
            this.dtGui.Name = "dtGui";
            this.dtGui.Size = new System.Drawing.Size(100, 27);
            this.dtGui.TabIndex = 20;
            // 
            // btnGui
            // 
            this.btnGui.Location = new System.Drawing.Point(10, 50);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(170, 28);
            this.btnGui.TabIndex = 21;
            this.btnGui.Text = "Gửi phiếu khảo sát";
            this.btnGui.UseVisualStyleBackColor = true;
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // dgvKS
            // 
            this.dgvKS.AllowUserToAddRows = false;
            this.dgvKS.AllowUserToDeleteRows = false;
            this.dgvKS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKS.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvKS.ColumnHeadersHeight = 29;
            this.dgvKS.Location = new System.Drawing.Point(10, 90);
            this.dgvKS.MultiSelect = false;
            this.dgvKS.Name = "dgvKS";
            this.dgvKS.ReadOnly = true;
            this.dgvKS.RowHeadersVisible = false;
            this.dgvKS.RowHeadersWidth = 51;
            this.dgvKS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKS.Size = new System.Drawing.Size(950, 250);
            this.dgvKS.TabIndex = 22;
            this.dgvKS.SelectionChanged += new System.EventHandler(this.dgvKS_SelectionChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 358);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 20);
            this.label10.TabIndex = 23;
            this.label10.Text = "Phiếu chọn";
            // 
            // txtKSChon
            // 
            this.txtKSChon.Location = new System.Drawing.Point(97, 355);
            this.txtKSChon.Name = "txtKSChon";
            this.txtKSChon.ReadOnly = true;
            this.txtKSChon.Size = new System.Drawing.Size(100, 27);
            this.txtKSChon.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(300, 358);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 20);
            this.label11.TabIndex = 25;
            this.label11.Text = "Ngày phản hồi";
            // 
            // dtPH
            // 
            this.dtPH.CustomFormat = "dd/MM/yyyy";
            this.dtPH.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPH.Location = new System.Drawing.Point(412, 355);
            this.dtPH.Name = "dtPH";
            this.dtPH.Size = new System.Drawing.Size(110, 27);
            this.dtPH.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(580, 358);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 20);
            this.label12.TabIndex = 27;
            this.label12.Text = "Điểm (1-5)";
            // 
            // numDiem
            // 
            this.numDiem.Location = new System.Drawing.Point(667, 355);
            this.numDiem.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numDiem.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDiem.Name = "numDiem";
            this.numDiem.Size = new System.Drawing.Size(60, 27);
            this.numDiem.TabIndex = 28;
            this.numDiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDiem.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 395);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 20);
            this.label13.TabIndex = 29;
            this.label13.Text = "Góp ý";
            // 
            // txtGopY
            // 
            this.txtGopY.Location = new System.Drawing.Point(85, 392);
            this.txtGopY.Name = "txtGopY";
            this.txtGopY.Size = new System.Drawing.Size(620, 27);
            this.txtGopY.TabIndex = 30;
            // 
            // btnGhiPH
            // 
            this.btnGhiPH.Location = new System.Drawing.Point(729, 392);
            this.btnGhiPH.Name = "btnGhiPH";
            this.btnGhiPH.Size = new System.Drawing.Size(190, 28);
            this.btnGhiPH.TabIndex = 31;
            this.btnGhiPH.Text = "Ghi nhận góp ý";
            this.btnGhiPH.UseVisualStyleBackColor = true;
            this.btnGhiPH.Click += new System.EventHandler(this.btnGhiPH_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(890, 580);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 28);
            this.btnDong.TabIndex = 32;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmKetThucKhaoSat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 620);
            this.Controls.Add(this.tabKT);
            this.Controls.Add(this.btnDong);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmKetThucKhaoSat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kết thúc tour - khảo sát";
            this.Load += new System.EventHandler(this.FrmKetThucKhaoSat_Load);
            this.tabKT.ResumeLayout(false);
            this.tpTT.ResumeLayout(false);
            this.tpTT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTien)).EndInit();
            this.tpKS.ResumeLayout(false);
            this.tpKS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabKT;
        private System.Windows.Forms.TabPage tpTT;
        private System.Windows.Forms.TabPage tpKS;
        private System.Windows.Forms.DataGridView dgvDoan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoTT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoDK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtTT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numTien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboLoaiKS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboDangKy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaKS;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtGui;
        private System.Windows.Forms.Button btnGui;
        private System.Windows.Forms.DataGridView dgvKS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtKSChon;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtPH;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numDiem;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtGopY;
        private System.Windows.Forms.Button btnGhiPH;
        private System.Windows.Forms.Button btnDong;
    }
}
