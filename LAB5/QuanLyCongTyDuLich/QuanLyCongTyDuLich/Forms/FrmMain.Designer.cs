namespace QuanLyCongTyDuLich.Forms
{
    partial class FrmMain
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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.btnDanhMuc = new System.Windows.Forms.Button();
            this.btnTour = new System.Windows.Forms.Button();
            this.btnChuyenLe = new System.Windows.Forms.Button();
            this.btnDangKyLe = new System.Windows.Forms.Button();
            this.btnDangKyDoan = new System.Windows.Forms.Button();
            this.btnPhanCong = new System.Windows.Forms.Button();
            this.btnKetThuc = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Location = new System.Drawing.Point(0, 25);
            this.lblTieuDe.Size = new System.Drawing.Size(640, 40);
            this.lblTieuDe.AutoSize = false;
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTieuDe.Text = "QUẢN LÝ CÔNG TY DU LỊCH VĂN HÓA VIỆT";
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.TabIndex = 0;
            this.Controls.Add(this.lblTieuDe);
            this.btnDanhMuc.Name = "btnDanhMuc";
            this.btnDanhMuc.Location = new System.Drawing.Point(30, 90);
            this.btnDanhMuc.Size = new System.Drawing.Size(180, 60);
            this.btnDanhMuc.Text = "Danh mục";
            this.btnDanhMuc.UseVisualStyleBackColor = true;
            this.btnDanhMuc.TabIndex = 1;
            this.btnDanhMuc.Click += new System.EventHandler(this.btnDanhMuc_Click);
            this.Controls.Add(this.btnDanhMuc);
            this.btnTour.Name = "btnTour";
            this.btnTour.Location = new System.Drawing.Point(230, 90);
            this.btnTour.Size = new System.Drawing.Size(180, 60);
            this.btnTour.Text = "Tour - hành trình";
            this.btnTour.UseVisualStyleBackColor = true;
            this.btnTour.TabIndex = 2;
            this.btnTour.Click += new System.EventHandler(this.btnTour_Click);
            this.Controls.Add(this.btnTour);
            this.btnChuyenLe.Name = "btnChuyenLe";
            this.btnChuyenLe.Location = new System.Drawing.Point(430, 90);
            this.btnChuyenLe.Size = new System.Drawing.Size(180, 60);
            this.btnChuyenLe.Text = "Lịch chuyến khách lẻ";
            this.btnChuyenLe.UseVisualStyleBackColor = true;
            this.btnChuyenLe.TabIndex = 3;
            this.btnChuyenLe.Click += new System.EventHandler(this.btnChuyenLe_Click);
            this.Controls.Add(this.btnChuyenLe);
            this.btnDangKyLe.Name = "btnDangKyLe";
            this.btnDangKyLe.Location = new System.Drawing.Point(30, 175);
            this.btnDangKyLe.Size = new System.Drawing.Size(180, 60);
            this.btnDangKyLe.Text = "Đăng ký khách lẻ";
            this.btnDangKyLe.UseVisualStyleBackColor = true;
            this.btnDangKyLe.TabIndex = 4;
            this.btnDangKyLe.Click += new System.EventHandler(this.btnDangKyLe_Click);
            this.Controls.Add(this.btnDangKyLe);
            this.btnDangKyDoan.Name = "btnDangKyDoan";
            this.btnDangKyDoan.Location = new System.Drawing.Point(230, 175);
            this.btnDangKyDoan.Size = new System.Drawing.Size(180, 60);
            this.btnDangKyDoan.Text = "Đăng ký theo đoàn";
            this.btnDangKyDoan.UseVisualStyleBackColor = true;
            this.btnDangKyDoan.TabIndex = 5;
            this.btnDangKyDoan.Click += new System.EventHandler(this.btnDangKyDoan_Click);
            this.Controls.Add(this.btnDangKyDoan);
            this.btnPhanCong.Name = "btnPhanCong";
            this.btnPhanCong.Location = new System.Drawing.Point(430, 175);
            this.btnPhanCong.Size = new System.Drawing.Size(180, 60);
            this.btnPhanCong.Text = "Phân công hướng dẫn viên";
            this.btnPhanCong.UseVisualStyleBackColor = true;
            this.btnPhanCong.TabIndex = 6;
            this.btnPhanCong.Click += new System.EventHandler(this.btnPhanCong_Click);
            this.Controls.Add(this.btnPhanCong);
            this.btnKetThuc.Name = "btnKetThuc";
            this.btnKetThuc.Location = new System.Drawing.Point(30, 260);
            this.btnKetThuc.Size = new System.Drawing.Size(180, 60);
            this.btnKetThuc.Text = "Kết thúc tour - khảo sát";
            this.btnKetThuc.UseVisualStyleBackColor = true;
            this.btnKetThuc.TabIndex = 7;
            this.btnKetThuc.Click += new System.EventHandler(this.btnKetThuc_Click);
            this.Controls.Add(this.btnKetThuc);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Location = new System.Drawing.Point(230, 260);
            this.btnThongKe.Size = new System.Drawing.Size(180, 60);
            this.btnThongKe.Text = "Lương - thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.TabIndex = 8;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            this.Controls.Add(this.btnThongKe);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Location = new System.Drawing.Point(430, 260);
            this.btnThoat.Size = new System.Drawing.Size(180, 60);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            this.Controls.Add(this.btnThoat);
            //
            // FrmMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 400);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý công ty du lịch Văn Hóa Việt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Button btnDanhMuc;
        private System.Windows.Forms.Button btnTour;
        private System.Windows.Forms.Button btnChuyenLe;
        private System.Windows.Forms.Button btnDangKyLe;
        private System.Windows.Forms.Button btnDangKyDoan;
        private System.Windows.Forms.Button btnPhanCong;
        private System.Windows.Forms.Button btnKetThuc;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnThoat;
    }
}
