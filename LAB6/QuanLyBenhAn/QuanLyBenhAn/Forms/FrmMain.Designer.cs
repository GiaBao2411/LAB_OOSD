namespace QuanLyBenhAn.Forms
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
            this.btnDangKyHoSo = new System.Windows.Forms.Button();
            this.btnTraCuu = new System.Windows.Forms.Button();
            this.btnPhieuKham = new System.Windows.Forms.Button();
            this.btnToaThuoc = new System.Windows.Forms.Button();
            this.btnLichHen = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Location = new System.Drawing.Point(0, 25);
            this.lblTieuDe.Size = new System.Drawing.Size(640, 40);
            this.lblTieuDe.AutoSize = false;
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTieuDe.Text = "QUẢN LÝ HỒ SƠ BỆNH ÁN";
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
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
            this.btnDangKyHoSo.Name = "btnDangKyHoSo";
            this.btnDangKyHoSo.Location = new System.Drawing.Point(230, 90);
            this.btnDangKyHoSo.Size = new System.Drawing.Size(180, 60);
            this.btnDangKyHoSo.Text = "Đăng ký - cấp hồ sơ bệnh án";
            this.btnDangKyHoSo.UseVisualStyleBackColor = true;
            this.btnDangKyHoSo.TabIndex = 2;
            this.btnDangKyHoSo.Click += new System.EventHandler(this.btnDangKyHoSo_Click);
            this.Controls.Add(this.btnDangKyHoSo);
            this.btnTraCuu.Name = "btnTraCuu";
            this.btnTraCuu.Location = new System.Drawing.Point(430, 90);
            this.btnTraCuu.Size = new System.Drawing.Size(180, 60);
            this.btnTraCuu.Text = "Tra cứu hồ sơ bệnh án";
            this.btnTraCuu.UseVisualStyleBackColor = true;
            this.btnTraCuu.TabIndex = 3;
            this.btnTraCuu.Click += new System.EventHandler(this.btnTraCuu_Click);
            this.Controls.Add(this.btnTraCuu);
            this.btnPhieuKham.Name = "btnPhieuKham";
            this.btnPhieuKham.Location = new System.Drawing.Point(30, 175);
            this.btnPhieuKham.Size = new System.Drawing.Size(180, 60);
            this.btnPhieuKham.Text = "Lập phiếu khám";
            this.btnPhieuKham.UseVisualStyleBackColor = true;
            this.btnPhieuKham.TabIndex = 4;
            this.btnPhieuKham.Click += new System.EventHandler(this.btnPhieuKham_Click);
            this.Controls.Add(this.btnPhieuKham);
            this.btnToaThuoc.Name = "btnToaThuoc";
            this.btnToaThuoc.Location = new System.Drawing.Point(230, 175);
            this.btnToaThuoc.Size = new System.Drawing.Size(180, 60);
            this.btnToaThuoc.Text = "Lập toa thuốc";
            this.btnToaThuoc.UseVisualStyleBackColor = true;
            this.btnToaThuoc.TabIndex = 5;
            this.btnToaThuoc.Click += new System.EventHandler(this.btnToaThuoc_Click);
            this.Controls.Add(this.btnToaThuoc);
            this.btnLichHen.Name = "btnLichHen";
            this.btnLichHen.Location = new System.Drawing.Point(430, 175);
            this.btnLichHen.Size = new System.Drawing.Size(180, 60);
            this.btnLichHen.Text = "Hẹn khám định kỳ";
            this.btnLichHen.UseVisualStyleBackColor = true;
            this.btnLichHen.TabIndex = 6;
            this.btnLichHen.Click += new System.EventHandler(this.btnLichHen_Click);
            this.Controls.Add(this.btnLichHen);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Location = new System.Drawing.Point(30, 260);
            this.btnThongKe.Size = new System.Drawing.Size(180, 60);
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.TabIndex = 7;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            this.Controls.Add(this.btnThongKe);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Location = new System.Drawing.Point(230, 260);
            this.btnThoat.Size = new System.Drawing.Size(180, 60);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.TabIndex = 8;
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bệnh viện đa khoa quốc tế - Quản lý hồ sơ bệnh án";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Button btnDanhMuc;
        private System.Windows.Forms.Button btnDangKyHoSo;
        private System.Windows.Forms.Button btnTraCuu;
        private System.Windows.Forms.Button btnPhieuKham;
        private System.Windows.Forms.Button btnToaThuoc;
        private System.Windows.Forms.Button btnLichHen;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnThoat;
    }
}
