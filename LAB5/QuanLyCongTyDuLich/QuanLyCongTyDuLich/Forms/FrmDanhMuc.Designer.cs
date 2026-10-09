namespace QuanLyCongTyDuLich.Forms
{
    partial class FrmDanhMuc
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
            this.tabDanhMuc = new System.Windows.Forms.TabControl();
            this.tpPT = new System.Windows.Forms.TabPage();
            this.dgvPT = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPTMa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPTTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPTGhiChu = new System.Windows.Forms.TextBox();
            this.btnThemPT = new System.Windows.Forms.Button();
            this.tpDB = new System.Windows.Forms.TabPage();
            this.dgvDB = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDBMa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDBTen = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDBDiaChi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDBDT = new System.Windows.Forms.TextBox();
            this.btnThemDB = new System.Windows.Forms.Button();
            this.tpHDV = new System.Windows.Forms.TabPage();
            this.dgvHDV = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHDVMa = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHDVTen = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtHDVDT = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThemHDV = new System.Windows.Forms.Button();
            this.tpDTQ = new System.Windows.Forms.TabPage();
            this.dgvDTQ = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDTQMa = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDTQTen = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDTQDiaDiem = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDTQNoiDung = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDTQYNghia = new System.Windows.Forms.TextBox();
            this.btnThemDTQ = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabDanhMuc.SuspendLayout();
            this.tpPT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPT)).BeginInit();
            this.tpDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDB)).BeginInit();
            this.tpHDV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLuong)).BeginInit();
            this.tpDTQ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDTQ)).BeginInit();
            this.SuspendLayout();
            // 
            // tabDanhMuc
            // 
            this.tabDanhMuc.Controls.Add(this.tpPT);
            this.tabDanhMuc.Controls.Add(this.tpDB);
            this.tabDanhMuc.Controls.Add(this.tpHDV);
            this.tabDanhMuc.Controls.Add(this.tpDTQ);
            this.tabDanhMuc.Location = new System.Drawing.Point(10, 10);
            this.tabDanhMuc.Name = "tabDanhMuc";
            this.tabDanhMuc.SelectedIndex = 0;
            this.tabDanhMuc.Size = new System.Drawing.Size(880, 450);
            this.tabDanhMuc.TabIndex = 0;
            // 
            // tpPT
            // 
            this.tpPT.Controls.Add(this.dgvPT);
            this.tpPT.Controls.Add(this.label1);
            this.tpPT.Controls.Add(this.txtPTMa);
            this.tpPT.Controls.Add(this.label2);
            this.tpPT.Controls.Add(this.txtPTTen);
            this.tpPT.Controls.Add(this.label3);
            this.tpPT.Controls.Add(this.txtPTGhiChu);
            this.tpPT.Controls.Add(this.btnThemPT);
            this.tpPT.Location = new System.Drawing.Point(4, 29);
            this.tpPT.Name = "tpPT";
            this.tpPT.Padding = new System.Windows.Forms.Padding(3);
            this.tpPT.Size = new System.Drawing.Size(872, 417);
            this.tpPT.TabIndex = 0;
            this.tpPT.Text = "Phương tiện";
            this.tpPT.UseVisualStyleBackColor = true;
            // 
            // dgvPT
            // 
            this.dgvPT.AllowUserToAddRows = false;
            this.dgvPT.AllowUserToDeleteRows = false;
            this.dgvPT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPT.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPT.ColumnHeadersHeight = 29;
            this.dgvPT.Location = new System.Drawing.Point(10, 10);
            this.dgvPT.MultiSelect = false;
            this.dgvPT.Name = "dgvPT";
            this.dgvPT.ReadOnly = true;
            this.dgvPT.RowHeadersVisible = false;
            this.dgvPT.RowHeadersWidth = 51;
            this.dgvPT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPT.Size = new System.Drawing.Size(850, 300);
            this.dgvPT.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã PT";
            // 
            // txtPTMa
            // 
            this.txtPTMa.Location = new System.Drawing.Point(90, 325);
            this.txtPTMa.Name = "txtPTMa";
            this.txtPTMa.Size = new System.Drawing.Size(110, 27);
            this.txtPTMa.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên PT";
            // 
            // txtPTTen
            // 
            this.txtPTTen.Location = new System.Drawing.Point(337, 325);
            this.txtPTTen.Name = "txtPTTen";
            this.txtPTTen.Size = new System.Drawing.Size(200, 27);
            this.txtPTTen.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(587, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ghi chú";
            // 
            // txtPTGhiChu
            // 
            this.txtPTGhiChu.Location = new System.Drawing.Point(660, 325);
            this.txtPTGhiChu.Name = "txtPTGhiChu";
            this.txtPTGhiChu.Size = new System.Drawing.Size(200, 27);
            this.txtPTGhiChu.TabIndex = 7;
            // 
            // btnThemPT
            // 
            this.btnThemPT.Location = new System.Drawing.Point(760, 372);
            this.btnThemPT.Name = "btnThemPT";
            this.btnThemPT.Size = new System.Drawing.Size(100, 28);
            this.btnThemPT.TabIndex = 8;
            this.btnThemPT.Text = "Thêm";
            this.btnThemPT.UseVisualStyleBackColor = true;
            this.btnThemPT.Click += new System.EventHandler(this.btnThemPT_Click);
            // 
            // tpDB
            // 
            this.tpDB.Controls.Add(this.dgvDB);
            this.tpDB.Controls.Add(this.label4);
            this.tpDB.Controls.Add(this.txtDBMa);
            this.tpDB.Controls.Add(this.label5);
            this.tpDB.Controls.Add(this.txtDBTen);
            this.tpDB.Controls.Add(this.label6);
            this.tpDB.Controls.Add(this.txtDBDiaChi);
            this.tpDB.Controls.Add(this.label7);
            this.tpDB.Controls.Add(this.txtDBDT);
            this.tpDB.Controls.Add(this.btnThemDB);
            this.tpDB.Location = new System.Drawing.Point(4, 29);
            this.tpDB.Name = "tpDB";
            this.tpDB.Padding = new System.Windows.Forms.Padding(3);
            this.tpDB.Size = new System.Drawing.Size(872, 417);
            this.tpDB.TabIndex = 1;
            this.tpDB.Text = "Điểm bán vé";
            this.tpDB.UseVisualStyleBackColor = true;
            // 
            // dgvDB
            // 
            this.dgvDB.AllowUserToAddRows = false;
            this.dgvDB.AllowUserToDeleteRows = false;
            this.dgvDB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDB.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDB.ColumnHeadersHeight = 29;
            this.dgvDB.Location = new System.Drawing.Point(10, 10);
            this.dgvDB.MultiSelect = false;
            this.dgvDB.Name = "dgvDB";
            this.dgvDB.ReadOnly = true;
            this.dgvDB.RowHeadersVisible = false;
            this.dgvDB.RowHeadersWidth = 51;
            this.dgvDB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDB.Size = new System.Drawing.Size(850, 300);
            this.dgvDB.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Mã điểm bán";
            // 
            // txtDBMa
            // 
            this.txtDBMa.Location = new System.Drawing.Point(113, 325);
            this.txtDBMa.Name = "txtDBMa";
            this.txtDBMa.Size = new System.Drawing.Size(97, 27);
            this.txtDBMa.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tên điểm bán";
            // 
            // txtDBTen
            // 
            this.txtDBTen.Location = new System.Drawing.Point(365, 325);
            this.txtDBTen.Name = "txtDBTen";
            this.txtDBTen.Size = new System.Drawing.Size(235, 27);
            this.txtDBTen.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 363);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Địa chỉ";
            // 
            // txtDBDiaChi
            // 
            this.txtDBDiaChi.Location = new System.Drawing.Point(100, 360);
            this.txtDBDiaChi.Name = "txtDBDiaChi";
            this.txtDBDiaChi.Size = new System.Drawing.Size(300, 27);
            this.txtDBDiaChi.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(450, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Điện thoại";
            // 
            // txtDBDT
            // 
            this.txtDBDT.Location = new System.Drawing.Point(534, 360);
            this.txtDBDT.Name = "txtDBDT";
            this.txtDBDT.Size = new System.Drawing.Size(143, 27);
            this.txtDBDT.TabIndex = 17;
            // 
            // btnThemDB
            // 
            this.btnThemDB.Location = new System.Drawing.Point(766, 383);
            this.btnThemDB.Name = "btnThemDB";
            this.btnThemDB.Size = new System.Drawing.Size(100, 28);
            this.btnThemDB.TabIndex = 18;
            this.btnThemDB.Text = "Thêm";
            this.btnThemDB.UseVisualStyleBackColor = true;
            this.btnThemDB.Click += new System.EventHandler(this.btnThemDB_Click);
            // 
            // tpHDV
            // 
            this.tpHDV.Controls.Add(this.dgvHDV);
            this.tpHDV.Controls.Add(this.label8);
            this.tpHDV.Controls.Add(this.txtHDVMa);
            this.tpHDV.Controls.Add(this.label9);
            this.tpHDV.Controls.Add(this.txtHDVTen);
            this.tpHDV.Controls.Add(this.label10);
            this.tpHDV.Controls.Add(this.txtHDVDT);
            this.tpHDV.Controls.Add(this.label11);
            this.tpHDV.Controls.Add(this.numLuong);
            this.tpHDV.Controls.Add(this.btnThemHDV);
            this.tpHDV.Location = new System.Drawing.Point(4, 29);
            this.tpHDV.Name = "tpHDV";
            this.tpHDV.Padding = new System.Windows.Forms.Padding(3);
            this.tpHDV.Size = new System.Drawing.Size(872, 417);
            this.tpHDV.TabIndex = 2;
            this.tpHDV.Text = "Hướng dẫn viên";
            this.tpHDV.UseVisualStyleBackColor = true;
            // 
            // dgvHDV
            // 
            this.dgvHDV.AllowUserToAddRows = false;
            this.dgvHDV.AllowUserToDeleteRows = false;
            this.dgvHDV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHDV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvHDV.ColumnHeadersHeight = 29;
            this.dgvHDV.Location = new System.Drawing.Point(10, 10);
            this.dgvHDV.MultiSelect = false;
            this.dgvHDV.Name = "dgvHDV";
            this.dgvHDV.ReadOnly = true;
            this.dgvHDV.RowHeadersVisible = false;
            this.dgvHDV.RowHeadersWidth = 51;
            this.dgvHDV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHDV.Size = new System.Drawing.Size(850, 300);
            this.dgvHDV.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 328);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Mã HDV";
            // 
            // txtHDVMa
            // 
            this.txtHDVMa.Location = new System.Drawing.Point(90, 325);
            this.txtHDVMa.Name = "txtHDVMa";
            this.txtHDVMa.Size = new System.Drawing.Size(110, 27);
            this.txtHDVMa.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(230, 328);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "Họ tên";
            // 
            // txtHDVTen
            // 
            this.txtHDVTen.Location = new System.Drawing.Point(310, 325);
            this.txtHDVTen.Name = "txtHDVTen";
            this.txtHDVTen.Size = new System.Drawing.Size(220, 27);
            this.txtHDVTen.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 363);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 20);
            this.label10.TabIndex = 24;
            this.label10.Text = "Điện thoại";
            // 
            // txtHDVDT
            // 
            this.txtHDVDT.Location = new System.Drawing.Point(90, 360);
            this.txtHDVDT.Name = "txtHDVDT";
            this.txtHDVDT.Size = new System.Drawing.Size(130, 27);
            this.txtHDVDT.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(300, 363);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 20);
            this.label11.TabIndex = 26;
            this.label11.Text = "Lương căn bản";
            // 
            // numLuong
            // 
            this.numLuong.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numLuong.Location = new System.Drawing.Point(413, 360);
            this.numLuong.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.numLuong.Name = "numLuong";
            this.numLuong.Size = new System.Drawing.Size(127, 27);
            this.numLuong.TabIndex = 27;
            this.numLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numLuong.ThousandsSeparator = true;
            // 
            // btnThemHDV
            // 
            this.btnThemHDV.Location = new System.Drawing.Point(700, 357);
            this.btnThemHDV.Name = "btnThemHDV";
            this.btnThemHDV.Size = new System.Drawing.Size(100, 28);
            this.btnThemHDV.TabIndex = 28;
            this.btnThemHDV.Text = "Thêm";
            this.btnThemHDV.UseVisualStyleBackColor = true;
            this.btnThemHDV.Click += new System.EventHandler(this.btnThemHDV_Click);
            // 
            // tpDTQ
            // 
            this.tpDTQ.Controls.Add(this.dgvDTQ);
            this.tpDTQ.Controls.Add(this.label12);
            this.tpDTQ.Controls.Add(this.txtDTQMa);
            this.tpDTQ.Controls.Add(this.label13);
            this.tpDTQ.Controls.Add(this.txtDTQTen);
            this.tpDTQ.Controls.Add(this.label14);
            this.tpDTQ.Controls.Add(this.txtDTQDiaDiem);
            this.tpDTQ.Controls.Add(this.label15);
            this.tpDTQ.Controls.Add(this.txtDTQNoiDung);
            this.tpDTQ.Controls.Add(this.label16);
            this.tpDTQ.Controls.Add(this.txtDTQYNghia);
            this.tpDTQ.Controls.Add(this.btnThemDTQ);
            this.tpDTQ.Location = new System.Drawing.Point(4, 29);
            this.tpDTQ.Name = "tpDTQ";
            this.tpDTQ.Padding = new System.Windows.Forms.Padding(3);
            this.tpDTQ.Size = new System.Drawing.Size(872, 417);
            this.tpDTQ.TabIndex = 3;
            this.tpDTQ.Text = "Điểm tham quan";
            this.tpDTQ.UseVisualStyleBackColor = true;
            // 
            // dgvDTQ
            // 
            this.dgvDTQ.AllowUserToAddRows = false;
            this.dgvDTQ.AllowUserToDeleteRows = false;
            this.dgvDTQ.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDTQ.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDTQ.ColumnHeadersHeight = 29;
            this.dgvDTQ.Location = new System.Drawing.Point(10, 10);
            this.dgvDTQ.MultiSelect = false;
            this.dgvDTQ.Name = "dgvDTQ";
            this.dgvDTQ.ReadOnly = true;
            this.dgvDTQ.RowHeadersVisible = false;
            this.dgvDTQ.RowHeadersWidth = 51;
            this.dgvDTQ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDTQ.Size = new System.Drawing.Size(850, 280);
            this.dgvDTQ.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 303);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 20);
            this.label12.TabIndex = 30;
            this.label12.Text = "Mã điểm TQ";
            // 
            // txtDTQMa
            // 
            this.txtDTQMa.Location = new System.Drawing.Point(107, 300);
            this.txtDTQMa.Name = "txtDTQMa";
            this.txtDTQMa.Size = new System.Drawing.Size(83, 27);
            this.txtDTQMa.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(230, 303);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 20);
            this.label13.TabIndex = 32;
            this.label13.Text = "Tên điểm TQ";
            // 
            // txtDTQTen
            // 
            this.txtDTQTen.Location = new System.Drawing.Point(329, 300);
            this.txtDTQTen.Name = "txtDTQTen";
            this.txtDTQTen.Size = new System.Drawing.Size(201, 27);
            this.txtDTQTen.TabIndex = 33;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(560, 303);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 20);
            this.label14.TabIndex = 34;
            this.label14.Text = "Địa điểm";
            // 
            // txtDTQDiaDiem
            // 
            this.txtDTQDiaDiem.Location = new System.Drawing.Point(636, 300);
            this.txtDTQDiaDiem.Name = "txtDTQDiaDiem";
            this.txtDTQDiaDiem.Size = new System.Drawing.Size(164, 27);
            this.txtDTQDiaDiem.TabIndex = 35;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 338);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 20);
            this.label15.TabIndex = 36;
            this.label15.Text = "Nội dung";
            // 
            // txtDTQNoiDung
            // 
            this.txtDTQNoiDung.Location = new System.Drawing.Point(90, 335);
            this.txtDTQNoiDung.Name = "txtDTQNoiDung";
            this.txtDTQNoiDung.Size = new System.Drawing.Size(340, 27);
            this.txtDTQNoiDung.TabIndex = 37;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(450, 338);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 20);
            this.label16.TabIndex = 38;
            this.label16.Text = "Ý nghĩa";
            // 
            // txtDTQYNghia
            // 
            this.txtDTQYNghia.Location = new System.Drawing.Point(510, 335);
            this.txtDTQYNghia.Name = "txtDTQYNghia";
            this.txtDTQYNghia.Size = new System.Drawing.Size(290, 27);
            this.txtDTQYNghia.TabIndex = 39;
            // 
            // btnThemDTQ
            // 
            this.btnThemDTQ.Location = new System.Drawing.Point(760, 383);
            this.btnThemDTQ.Name = "btnThemDTQ";
            this.btnThemDTQ.Size = new System.Drawing.Size(100, 28);
            this.btnThemDTQ.TabIndex = 40;
            this.btnThemDTQ.Text = "Thêm";
            this.btnThemDTQ.UseVisualStyleBackColor = true;
            this.btnThemDTQ.Click += new System.EventHandler(this.btnThemDTQ_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(790, 470);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 28);
            this.btnDong.TabIndex = 41;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 520);
            this.Controls.Add(this.tabDanhMuc);
            this.Controls.Add(this.btnDong);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDanhMuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh mục";
            this.Load += new System.EventHandler(this.FrmDanhMuc_Load);
            this.tabDanhMuc.ResumeLayout(false);
            this.tpPT.ResumeLayout(false);
            this.tpPT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPT)).EndInit();
            this.tpDB.ResumeLayout(false);
            this.tpDB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDB)).EndInit();
            this.tpHDV.ResumeLayout(false);
            this.tpHDV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLuong)).EndInit();
            this.tpDTQ.ResumeLayout(false);
            this.tpDTQ.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDTQ)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDanhMuc;
        private System.Windows.Forms.TabPage tpPT;
        private System.Windows.Forms.TabPage tpDB;
        private System.Windows.Forms.TabPage tpHDV;
        private System.Windows.Forms.TabPage tpDTQ;
        private System.Windows.Forms.DataGridView dgvPT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPTMa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPTTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPTGhiChu;
        private System.Windows.Forms.Button btnThemPT;
        private System.Windows.Forms.DataGridView dgvDB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDBMa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDBTen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDBDiaChi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDBDT;
        private System.Windows.Forms.Button btnThemDB;
        private System.Windows.Forms.DataGridView dgvHDV;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtHDVMa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtHDVTen;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtHDVDT;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numLuong;
        private System.Windows.Forms.Button btnThemHDV;
        private System.Windows.Forms.DataGridView dgvDTQ;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDTQMa;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDTQTen;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDTQDiaDiem;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDTQNoiDung;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtDTQYNghia;
        private System.Windows.Forms.Button btnThemDTQ;
        private System.Windows.Forms.Button btnDong;
    }
}
