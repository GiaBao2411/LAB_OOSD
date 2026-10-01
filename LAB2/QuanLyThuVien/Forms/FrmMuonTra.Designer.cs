namespace QuanLyThuVien.Forms
{
    partial class FrmMuonTra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabMuon = new System.Windows.Forms.TabPage();
            this.btnLapPhieu = new System.Windows.Forms.Button();
            this.btnBoSach = new System.Windows.Forms.Button();
            this.btnThemSach = new System.Windows.Forms.Button();
            this.dgvSachChon = new System.Windows.Forms.DataGridView();
            this.dgvSachCon = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtHenTra = new System.Windows.Forms.DateTimePicker();
            this.dtNgayMuon = new System.Windows.Forms.DateTimePicker();
            this.cboNhanVienMuon = new System.Windows.Forms.ComboBox();
            this.cboDocGia = new System.Windows.Forms.ComboBox();
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabTra = new System.Windows.Forms.TabPage();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnTraSach = new System.Windows.Forms.Button();
            this.numPhiPhat = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboTinhTrang = new System.Windows.Forms.ComboBox();
            this.dgvDangMuon = new System.Windows.Forms.DataGridView();
            this.dtNgayTra = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnTaiSachMuon = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cboNhanVienTra = new System.Windows.Forms.ComboBox();
            this.cboDocGiaTra = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabs.SuspendLayout();
            this.tabMuon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachChon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachCon)).BeginInit();
            this.tabTra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPhiPhat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangMuon)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabMuon);
            this.tabs.Controls.Add(this.tabTra);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1228, 656);
            this.tabs.TabIndex = 0;
            // 
            // tabMuon
            // 
            this.tabMuon.Controls.Add(this.btnLapPhieu);
            this.tabMuon.Controls.Add(this.btnBoSach);
            this.tabMuon.Controls.Add(this.btnThemSach);
            this.tabMuon.Controls.Add(this.dgvSachChon);
            this.tabMuon.Controls.Add(this.dgvSachCon);
            this.tabMuon.Controls.Add(this.label5);
            this.tabMuon.Controls.Add(this.label4);
            this.tabMuon.Controls.Add(this.dtHenTra);
            this.tabMuon.Controls.Add(this.dtNgayMuon);
            this.tabMuon.Controls.Add(this.cboNhanVienMuon);
            this.tabMuon.Controls.Add(this.cboDocGia);
            this.tabMuon.Controls.Add(this.btnKiemTra);
            this.tabMuon.Controls.Add(this.lblTrangThai);
            this.tabMuon.Controls.Add(this.label6);
            this.tabMuon.Controls.Add(this.label3);
            this.tabMuon.Controls.Add(this.label2);
            this.tabMuon.Controls.Add(this.label1);
            this.tabMuon.Location = new System.Drawing.Point(4, 25);
            this.tabMuon.Name = "tabMuon";
            this.tabMuon.Padding = new System.Windows.Forms.Padding(3);
            this.tabMuon.Size = new System.Drawing.Size(1220, 627);
            this.tabMuon.TabIndex = 0;
            this.tabMuon.Text = "Mượn sách";
            this.tabMuon.UseVisualStyleBackColor = true;
            this.tabMuon.Click += new System.EventHandler(this.tabMuon_Click);
            // 
            // btnLapPhieu
            // 
            this.btnLapPhieu.Location = new System.Drawing.Point(871, 452);
            this.btnLapPhieu.Name = "btnLapPhieu";
            this.btnLapPhieu.Size = new System.Drawing.Size(132, 50);
            this.btnLapPhieu.TabIndex = 17;
            this.btnLapPhieu.Text = "Lập phiếu mượn";
            this.btnLapPhieu.UseVisualStyleBackColor = true;
            this.btnLapPhieu.Click += new System.EventHandler(this.btnLapPhieu_Click);
            // 
            // btnBoSach
            // 
            this.btnBoSach.Location = new System.Drawing.Point(539, 275);
            this.btnBoSach.Name = "btnBoSach";
            this.btnBoSach.Size = new System.Drawing.Size(101, 50);
            this.btnBoSach.TabIndex = 17;
            this.btnBoSach.Text = "<< Bỏ";
            this.btnBoSach.UseVisualStyleBackColor = true;
            this.btnBoSach.Click += new System.EventHandler(this.btnBoSach_Click);
            // 
            // btnThemSach
            // 
            this.btnThemSach.Location = new System.Drawing.Point(539, 191);
            this.btnThemSach.Name = "btnThemSach";
            this.btnThemSach.Size = new System.Drawing.Size(101, 50);
            this.btnThemSach.TabIndex = 17;
            this.btnThemSach.Text = "Thêm >>";
            this.btnThemSach.UseVisualStyleBackColor = true;
            this.btnThemSach.Click += new System.EventHandler(this.btnThemSach_Click);
            // 
            // dgvSachChon
            // 
            this.dgvSachChon.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSachChon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSachChon.Location = new System.Drawing.Point(685, 132);
            this.dgvSachChon.Name = "dgvSachChon";
            this.dgvSachChon.RowHeadersWidth = 51;
            this.dgvSachChon.RowTemplate.Height = 24;
            this.dgvSachChon.Size = new System.Drawing.Size(484, 291);
            this.dgvSachChon.TabIndex = 16;
            // 
            // dgvSachCon
            // 
            this.dgvSachCon.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSachCon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSachCon.Location = new System.Drawing.Point(20, 132);
            this.dgvSachCon.Name = "dgvSachCon";
            this.dgvSachCon.RowHeadersWidth = 51;
            this.dgvSachCon.RowTemplate.Height = 24;
            this.dgvSachCon.Size = new System.Drawing.Size(468, 291);
            this.dgvSachCon.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(754, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Hạn trả: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(389, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Ngày mượn:";
            // 
            // dtHenTra
            // 
            this.dtHenTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHenTra.Location = new System.Drawing.Point(816, 53);
            this.dtHenTra.Name = "dtHenTra";
            this.dtHenTra.Size = new System.Drawing.Size(200, 22);
            this.dtHenTra.TabIndex = 12;
            // 
            // dtNgayMuon
            // 
            this.dtNgayMuon.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayMuon.Location = new System.Drawing.Point(483, 50);
            this.dtNgayMuon.Name = "dtNgayMuon";
            this.dtNgayMuon.Size = new System.Drawing.Size(200, 22);
            this.dtNgayMuon.TabIndex = 12;
            // 
            // cboNhanVienMuon
            // 
            this.cboNhanVienMuon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVienMuon.FormattingEnabled = true;
            this.cboNhanVienMuon.Location = new System.Drawing.Point(158, 45);
            this.cboNhanVienMuon.Name = "cboNhanVienMuon";
            this.cboNhanVienMuon.Size = new System.Drawing.Size(157, 24);
            this.cboNhanVienMuon.TabIndex = 11;
            // 
            // cboDocGia
            // 
            this.cboDocGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocGia.FormattingEnabled = true;
            this.cboDocGia.Location = new System.Drawing.Point(158, 12);
            this.cboDocGia.Name = "cboDocGia";
            this.cboDocGia.Size = new System.Drawing.Size(157, 24);
            this.cboDocGia.TabIndex = 11;
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.Location = new System.Drawing.Point(483, 13);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(160, 23);
            this.btnKiemTra.TabIndex = 10;
            this.btnKiemTra.Text = "Kiểm tra điều kiện";
            this.btnKiemTra.UseVisualStyleBackColor = true;
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(754, 16);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(52, 16);
            this.lblTrangThai.TabIndex = 9;
            this.lblTrangThai.Text = "Kết quả";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(682, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Sách còn trong kho:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sách còn trong kho:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nhân viên lập phiếu: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Độc giả:";
            // 
            // tabTra
            // 
            this.tabTra.Controls.Add(this.btnDong);
            this.tabTra.Controls.Add(this.btnTraSach);
            this.tabTra.Controls.Add(this.numPhiPhat);
            this.tabTra.Controls.Add(this.label11);
            this.tabTra.Controls.Add(this.label10);
            this.tabTra.Controls.Add(this.cboTinhTrang);
            this.tabTra.Controls.Add(this.dgvDangMuon);
            this.tabTra.Controls.Add(this.dtNgayTra);
            this.tabTra.Controls.Add(this.label9);
            this.tabTra.Controls.Add(this.label8);
            this.tabTra.Controls.Add(this.btnTaiSachMuon);
            this.tabTra.Controls.Add(this.label7);
            this.tabTra.Controls.Add(this.cboNhanVienTra);
            this.tabTra.Controls.Add(this.cboDocGiaTra);
            this.tabTra.Location = new System.Drawing.Point(4, 25);
            this.tabTra.Name = "tabTra";
            this.tabTra.Padding = new System.Windows.Forms.Padding(3);
            this.tabTra.Size = new System.Drawing.Size(1220, 627);
            this.tabTra.TabIndex = 1;
            this.tabTra.Text = "Trả sách";
            this.tabTra.UseVisualStyleBackColor = true;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(1081, 46);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 38);
            this.btnDong.TabIndex = 12;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnTraSach
            // 
            this.btnTraSach.Location = new System.Drawing.Point(504, 152);
            this.btnTraSach.Name = "btnTraSach";
            this.btnTraSach.Size = new System.Drawing.Size(147, 38);
            this.btnTraSach.TabIndex = 11;
            this.btnTraSach.Text = "Xác nhận trả sách";
            this.btnTraSach.UseVisualStyleBackColor = true;
            this.btnTraSach.Click += new System.EventHandler(this.btnTraSach_Click);
            // 
            // numPhiPhat
            // 
            this.numPhiPhat.Location = new System.Drawing.Point(504, 115);
            this.numPhiPhat.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numPhiPhat.Name = "numPhiPhat";
            this.numPhiPhat.Size = new System.Drawing.Size(147, 22);
            this.numPhiPhat.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(413, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 16);
            this.label11.TabIndex = 9;
            this.label11.Text = "Phí phạt";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(412, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 16);
            this.label10.TabIndex = 8;
            this.label10.Text = "Tình trạng";
            // 
            // cboTinhTrang
            // 
            this.cboTinhTrang.FormattingEnabled = true;
            this.cboTinhTrang.Location = new System.Drawing.Point(504, 69);
            this.cboTinhTrang.Name = "cboTinhTrang";
            this.cboTinhTrang.Size = new System.Drawing.Size(147, 24);
            this.cboTinhTrang.TabIndex = 7;
            // 
            // dgvDangMuon
            // 
            this.dgvDangMuon.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDangMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDangMuon.Location = new System.Drawing.Point(26, 196);
            this.dgvDangMuon.MultiSelect = false;
            this.dgvDangMuon.Name = "dgvDangMuon";
            this.dgvDangMuon.ReadOnly = true;
            this.dgvDangMuon.RowHeadersWidth = 51;
            this.dgvDangMuon.RowTemplate.Height = 24;
            this.dgvDangMuon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDangMuon.Size = new System.Drawing.Size(1175, 392);
            this.dgvDangMuon.TabIndex = 6;
            // 
            // dtNgayTra
            // 
            this.dtNgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayTra.Location = new System.Drawing.Point(181, 116);
            this.dtNgayTra.Name = "dtNgayTra";
            this.dtNgayTra.Size = new System.Drawing.Size(200, 22);
            this.dtNgayTra.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "Ngày trả";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "Nhân viên nhận trả:";
            // 
            // btnTaiSachMuon
            // 
            this.btnTaiSachMuon.Location = new System.Drawing.Point(415, 15);
            this.btnTaiSachMuon.Name = "btnTaiSachMuon";
            this.btnTaiSachMuon.Size = new System.Drawing.Size(236, 32);
            this.btnTaiSachMuon.TabIndex = 2;
            this.btnTaiSachMuon.Text = "Tải sách đang mượn";
            this.btnTaiSachMuon.UseVisualStyleBackColor = true;
            this.btnTaiSachMuon.Click += new System.EventHandler(this.btnTaiSachMuon_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Độc giả trả sách";
            // 
            // cboNhanVienTra
            // 
            this.cboNhanVienTra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVienTra.FormattingEnabled = true;
            this.cboNhanVienTra.Location = new System.Drawing.Point(182, 65);
            this.cboNhanVienTra.Name = "cboNhanVienTra";
            this.cboNhanVienTra.Size = new System.Drawing.Size(200, 24);
            this.cboNhanVienTra.TabIndex = 0;
            // 
            // cboDocGiaTra
            // 
            this.cboDocGiaTra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocGiaTra.FormattingEnabled = true;
            this.cboDocGiaTra.Location = new System.Drawing.Point(181, 20);
            this.cboDocGiaTra.Name = "cboDocGiaTra";
            this.cboDocGiaTra.Size = new System.Drawing.Size(200, 24);
            this.cboDocGiaTra.TabIndex = 0;
            this.cboDocGiaTra.SelectedIndexChanged += new System.EventHandler(this.cboDocGiaTra_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FrmMuonTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 753);
            this.Controls.Add(this.tabs);
            this.Name = "FrmMuonTra";
            this.Text = "FrmMuonTra";
            this.Load += new System.EventHandler(this.FrmMuonTra_Load);
            this.tabs.ResumeLayout(false);
            this.tabMuon.ResumeLayout(false);
            this.tabMuon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachChon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachCon)).EndInit();
            this.tabTra.ResumeLayout(false);
            this.tabTra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPhiPhat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangMuon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabMuon;
        private System.Windows.Forms.TabPage tabTra;
        private System.Windows.Forms.DateTimePicker dtNgayMuon;
        private System.Windows.Forms.ComboBox cboNhanVienMuon;
        private System.Windows.Forms.ComboBox cboDocGia;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvSachChon;
        private System.Windows.Forms.DataGridView dgvSachCon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtHenTra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBoSach;
        private System.Windows.Forms.Button btnThemSach;
        private System.Windows.Forms.Button btnLapPhieu;
        private System.Windows.Forms.Button btnTaiSachMuon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboDocGiaTra;
        private System.Windows.Forms.DataGridView dgvDangMuon;
        private System.Windows.Forms.DateTimePicker dtNgayTra;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboNhanVienTra;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnTraSach;
        private System.Windows.Forms.NumericUpDown numPhiPhat;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboTinhTrang;
        private System.Windows.Forms.ImageList imageList1;
    }
}