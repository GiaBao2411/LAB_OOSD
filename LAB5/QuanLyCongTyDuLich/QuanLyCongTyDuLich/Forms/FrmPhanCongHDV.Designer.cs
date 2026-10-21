namespace QuanLyCongTyDuLich.Forms
{
    partial class FrmPhanCongHDV
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
            this.txtMaPC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboHDV = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDoiTuong = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numThuLao = new System.Windows.Forms.NumericUpDown();
            this.btnPhanCong = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numThuLao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            this.label1.Name = "label1";
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.AutoSize = true;
            this.label1.Text = "Mã phân công";
            this.label1.TabIndex = 0;
            this.Controls.Add(this.label1);
            this.txtMaPC.Name = "txtMaPC";
            this.txtMaPC.Location = new System.Drawing.Point(100, 15);
            this.txtMaPC.Size = new System.Drawing.Size(100, 23);
            this.txtMaPC.TabIndex = 1;
            this.Controls.Add(this.txtMaPC);
            this.label2.Name = "label2";
            this.label2.Location = new System.Drawing.Point(330, 18);
            this.label2.AutoSize = true;
            this.label2.Text = "Hướng dẫn viên";
            this.label2.TabIndex = 2;
            this.Controls.Add(this.label2);
            this.cboHDV.Name = "cboHDV";
            this.cboHDV.Location = new System.Drawing.Point(435, 15);
            this.cboHDV.Size = new System.Drawing.Size(220, 23);
            this.cboHDV.FormattingEnabled = true;
            this.cboHDV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHDV.TabIndex = 3;
            this.Controls.Add(this.cboHDV);
            this.label3.Name = "label3";
            this.label3.Location = new System.Drawing.Point(620, 18);
            this.label3.AutoSize = true;
            this.label3.Text = "Loại";
            this.label3.TabIndex = 4;
            this.Controls.Add(this.label3);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Location = new System.Drawing.Point(660, 15);
            this.cboLoai.Size = new System.Drawing.Size(100, 23);
            this.cboLoai.FormattingEnabled = true;
            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.TabIndex = 5;
            this.cboLoai.SelectedIndexChanged += new System.EventHandler(this.cboLoai_SelectedIndexChanged);
            this.Controls.Add(this.cboLoai);
            this.label4.Name = "label4";
            this.label4.Location = new System.Drawing.Point(10, 55);
            this.label4.AutoSize = true;
            this.label4.Text = "Chuyến / đoàn";
            this.label4.TabIndex = 6;
            this.Controls.Add(this.label4);
            this.cboDoiTuong.Name = "cboDoiTuong";
            this.cboDoiTuong.Location = new System.Drawing.Point(100, 52);
            this.cboDoiTuong.Size = new System.Drawing.Size(420, 23);
            this.cboDoiTuong.FormattingEnabled = true;
            this.cboDoiTuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoiTuong.TabIndex = 7;
            this.Controls.Add(this.cboDoiTuong);
            this.label5.Name = "label5";
            this.label5.Location = new System.Drawing.Point(620, 55);
            this.label5.AutoSize = true;
            this.label5.Text = "Thù lao tour";
            this.label5.TabIndex = 8;
            this.Controls.Add(this.label5);
            this.numThuLao.Name = "numThuLao";
            this.numThuLao.Location = new System.Drawing.Point(700, 52);
            this.numThuLao.Size = new System.Drawing.Size(130, 23);
            this.numThuLao.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numThuLao.Maximum = new decimal(new int[] { 2000000000, 0, 0, 0 });
            this.numThuLao.Increment = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numThuLao.Value = new decimal(new int[] { 0, 0, 0, 0 });
            this.numThuLao.ThousandsSeparator = true;
            this.numThuLao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numThuLao.TabIndex = 9;
            this.Controls.Add(this.numThuLao);
            this.btnPhanCong.Name = "btnPhanCong";
            this.btnPhanCong.Location = new System.Drawing.Point(770, 49);
            this.btnPhanCong.Size = new System.Drawing.Size(110, 28);
            this.btnPhanCong.Text = "Phân công";
            this.btnPhanCong.UseVisualStyleBackColor = true;
            this.btnPhanCong.TabIndex = 10;
            this.btnPhanCong.Click += new System.EventHandler(this.btnPhanCong_Click);
            this.Controls.Add(this.btnPhanCong);
            this.dgv.Name = "dgv";
            this.dgv.Location = new System.Drawing.Point(10, 92);
            this.dgv.Size = new System.Drawing.Size(880, 350);
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ReadOnly = true;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.MultiSelect = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.RowHeadersVisible = false;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv.TabIndex = 11;
            this.Controls.Add(this.dgv);
            this.btnDong.Name = "btnDong";
            this.btnDong.Location = new System.Drawing.Point(790, 455);
            this.btnDong.Size = new System.Drawing.Size(100, 28);
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.TabIndex = 12;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            this.Controls.Add(this.btnDong);
            ((System.ComponentModel.ISupportInitialize)(this.numThuLao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            //
            // FrmPhanCongHDV
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPhanCongHDV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Phân công hướng dẫn viên";
            this.Load += new System.EventHandler(this.FrmPhanCongHDV_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaPC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboHDV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDoiTuong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numThuLao;
        private System.Windows.Forms.Button btnPhanCong;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnDong;
    }
}
