namespace QuanLyCongTyDuLich.Forms
{
    partial class FrmDangKyLe
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
            this.txtSo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboChuyen = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboDiemBan = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numNguoi = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numNguoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            this.label1.Name = "label1";
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.AutoSize = true;
            this.label1.Text = "Số đăng ký";
            this.label1.TabIndex = 0;
            this.Controls.Add(this.label1);
            this.txtSo.Name = "txtSo";
            this.txtSo.Location = new System.Drawing.Point(85, 15);
            this.txtSo.Size = new System.Drawing.Size(100, 23);
            this.txtSo.TabIndex = 1;
            this.Controls.Add(this.txtSo);
            this.label2.Name = "label2";
            this.label2.Location = new System.Drawing.Point(260, 18);
            this.label2.AutoSize = true;
            this.label2.Text = "Chuyến";
            this.label2.TabIndex = 2;
            this.Controls.Add(this.label2);
            this.cboChuyen.Name = "cboChuyen";
            this.cboChuyen.Location = new System.Drawing.Point(315, 15);
            this.cboChuyen.Size = new System.Drawing.Size(420, 23);
            this.cboChuyen.FormattingEnabled = true;
            this.cboChuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChuyen.TabIndex = 3;
            this.cboChuyen.SelectedIndexChanged += new System.EventHandler(this.TinhTien);
            this.Controls.Add(this.cboChuyen);
            this.label3.Name = "label3";
            this.label3.Location = new System.Drawing.Point(700, 18);
            this.label3.AutoSize = true;
            this.label3.Text = "Điểm bán vé";
            this.label3.TabIndex = 4;
            this.Controls.Add(this.label3);
            this.cboDiemBan.Name = "cboDiemBan";
            this.cboDiemBan.Location = new System.Drawing.Point(780, 15);
            this.cboDiemBan.Size = new System.Drawing.Size(170, 23);
            this.cboDiemBan.FormattingEnabled = true;
            this.cboDiemBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiemBan.TabIndex = 5;
            this.Controls.Add(this.cboDiemBan);
            this.label4.Name = "label4";
            this.label4.Location = new System.Drawing.Point(10, 53);
            this.label4.AutoSize = true;
            this.label4.Text = "Người đăng ký";
            this.label4.TabIndex = 6;
            this.Controls.Add(this.label4);
            this.txtTen.Name = "txtTen";
            this.txtTen.Location = new System.Drawing.Point(100, 50);
            this.txtTen.Size = new System.Drawing.Size(170, 23);
            this.txtTen.TabIndex = 7;
            this.Controls.Add(this.txtTen);
            this.label5.Name = "label5";
            this.label5.Location = new System.Drawing.Point(330, 53);
            this.label5.AutoSize = true;
            this.label5.Text = "Điện thoại";
            this.label5.TabIndex = 8;
            this.Controls.Add(this.label5);
            this.txtDT.Name = "txtDT";
            this.txtDT.Location = new System.Drawing.Point(400, 50);
            this.txtDT.Size = new System.Drawing.Size(120, 23);
            this.txtDT.TabIndex = 9;
            this.Controls.Add(this.txtDT);
            this.label6.Name = "label6";
            this.label6.Location = new System.Drawing.Point(520, 53);
            this.label6.AutoSize = true;
            this.label6.Text = "Số người (1-11)";
            this.label6.TabIndex = 10;
            this.Controls.Add(this.label6);
            this.numNguoi.Name = "numNguoi";
            this.numNguoi.Location = new System.Drawing.Point(620, 50);
            this.numNguoi.Size = new System.Drawing.Size(60, 23);
            this.numNguoi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numNguoi.Maximum = new decimal(new int[] { 11, 0, 0, 0 });
            this.numNguoi.Value = new decimal(new int[] { 2, 0, 0, 0 });
            this.numNguoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numNguoi.TabIndex = 11;
            this.numNguoi.ValueChanged += new System.EventHandler(this.TinhTien);
            this.Controls.Add(this.numNguoi);
            this.label7.Name = "label7";
            this.label7.Location = new System.Drawing.Point(740, 53);
            this.label7.AutoSize = true;
            this.label7.Text = "Thành tiền:";
            this.label7.TabIndex = 12;
            this.Controls.Add(this.label7);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Location = new System.Drawing.Point(820, 53);
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Text = "0 đ";
            this.lblThanhTien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblThanhTien.TabIndex = 13;
            this.Controls.Add(this.lblThanhTien);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Location = new System.Drawing.Point(10, 88);
            this.btnDangKy.Size = new System.Drawing.Size(220, 28);
            this.btnDangKy.Text = "Đăng ký và thanh toán vé";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.TabIndex = 14;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            this.Controls.Add(this.btnDangKy);
            this.dgv.Name = "dgv";
            this.dgv.Location = new System.Drawing.Point(10, 128);
            this.dgv.Size = new System.Drawing.Size(980, 375);
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ReadOnly = true;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.MultiSelect = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.RowHeadersVisible = false;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv.TabIndex = 15;
            this.Controls.Add(this.dgv);
            this.btnDong.Name = "btnDong";
            this.btnDong.Location = new System.Drawing.Point(890, 515);
            this.btnDong.Size = new System.Drawing.Size(100, 28);
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.TabIndex = 16;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            this.Controls.Add(this.btnDong);
            ((System.ComponentModel.ISupportInitialize)(this.numNguoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            //
            // FrmDangKyLe
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 560);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDangKyLe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng ký khách lẻ";
            this.Load += new System.EventHandler(this.FrmDangKyLe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboChuyen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboDiemBan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numNguoi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnDong;
    }
}
