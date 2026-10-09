namespace QuanLyCongTyDuLich.Forms
{
    partial class FrmTour
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
            this.cboTour = new System.Windows.Forms.ComboBox();
            this.tabTour = new System.Windows.Forms.TabControl();
            this.tpTour = new System.Windows.Forms.TabPage();
            this.dgvTour = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numNgay = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numDem = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numGia = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.btnThemTour = new System.Windows.Forms.Button();
            this.tpDD = new System.Windows.Forms.TabPage();
            this.dgvDiemDung = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.numThuTu = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDiemDung = new System.Windows.Forms.TextBox();
            this.chkDoiPT = new System.Windows.Forms.CheckBox();
            this.chkAn = new System.Windows.Forms.CheckBox();
            this.chkKS = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numSao = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.txtGhiChuDD = new System.Windows.Forms.TextBox();
            this.btnThemDD = new System.Windows.Forms.Button();
            this.tpChang = new System.Windows.Forms.TabPage();
            this.dgvChang = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.numChang = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.cboPT = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtGhiChuPT = new System.Windows.Forms.TextBox();
            this.btnThemChang = new System.Windows.Forms.Button();
            this.tpTQ = new System.Windows.Forms.TabPage();
            this.dgvTQ = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.cboDTQ = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.numThuTuTQ = new System.Windows.Forms.NumericUpDown();
            this.btnThemTQ = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabTour.SuspendLayout();
            this.tpTour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGia)).BeginInit();
            this.tpDD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiemDung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThuTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSao)).BeginInit();
            this.tpChang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChang)).BeginInit();
            this.tpTQ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThuTuTQ)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tour đang chọn (cho các tab hành trình):";
            // 
            // cboTour
            // 
            this.cboTour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTour.FormattingEnabled = true;
            this.cboTour.Location = new System.Drawing.Point(291, 12);
            this.cboTour.Name = "cboTour";
            this.cboTour.Size = new System.Drawing.Size(420, 28);
            this.cboTour.TabIndex = 1;
            this.cboTour.SelectedIndexChanged += new System.EventHandler(this.cboTour_SelectedIndexChanged);
            // 
            // tabTour
            // 
            this.tabTour.Controls.Add(this.tpTour);
            this.tabTour.Controls.Add(this.tpDD);
            this.tabTour.Controls.Add(this.tpChang);
            this.tabTour.Controls.Add(this.tpTQ);
            this.tabTour.Location = new System.Drawing.Point(10, 45);
            this.tabTour.Name = "tabTour";
            this.tabTour.SelectedIndex = 0;
            this.tabTour.Size = new System.Drawing.Size(940, 500);
            this.tabTour.TabIndex = 2;
            // 
            // tpTour
            // 
            this.tpTour.Controls.Add(this.dgvTour);
            this.tpTour.Controls.Add(this.label2);
            this.tpTour.Controls.Add(this.txtMa);
            this.tpTour.Controls.Add(this.label3);
            this.tpTour.Controls.Add(this.txtTen);
            this.tpTour.Controls.Add(this.label4);
            this.tpTour.Controls.Add(this.numNgay);
            this.tpTour.Controls.Add(this.label5);
            this.tpTour.Controls.Add(this.numDem);
            this.tpTour.Controls.Add(this.label6);
            this.tpTour.Controls.Add(this.numGia);
            this.tpTour.Controls.Add(this.label7);
            this.tpTour.Controls.Add(this.txtMoTa);
            this.tpTour.Controls.Add(this.btnThemTour);
            this.tpTour.Location = new System.Drawing.Point(4, 29);
            this.tpTour.Name = "tpTour";
            this.tpTour.Padding = new System.Windows.Forms.Padding(3);
            this.tpTour.Size = new System.Drawing.Size(932, 467);
            this.tpTour.TabIndex = 0;
            this.tpTour.Text = "Tour";
            this.tpTour.UseVisualStyleBackColor = true;
            // 
            // dgvTour
            // 
            this.dgvTour.AllowUserToAddRows = false;
            this.dgvTour.AllowUserToDeleteRows = false;
            this.dgvTour.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTour.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTour.ColumnHeadersHeight = 29;
            this.dgvTour.Location = new System.Drawing.Point(10, 10);
            this.dgvTour.MultiSelect = false;
            this.dgvTour.Name = "dgvTour";
            this.dgvTour.ReadOnly = true;
            this.dgvTour.RowHeadersVisible = false;
            this.dgvTour.RowHeadersWidth = 51;
            this.dgvTour.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTour.Size = new System.Drawing.Size(910, 300);
            this.dgvTour.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mã tour";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(90, 325);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(90, 27);
            this.txtMa.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tên tour";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(310, 325);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(300, 27);
            this.txtTen.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 363);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Số ngày";
            // 
            // numNgay
            // 
            this.numNgay.Location = new System.Drawing.Point(90, 360);
            this.numNgay.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numNgay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNgay.Name = "numNgay";
            this.numNgay.Size = new System.Drawing.Size(70, 27);
            this.numNgay.TabIndex = 9;
            this.numNgay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numNgay.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 363);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Số đêm";
            // 
            // numDem
            // 
            this.numDem.Location = new System.Drawing.Point(310, 360);
            this.numDem.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numDem.Name = "numDem";
            this.numDem.Size = new System.Drawing.Size(70, 27);
            this.numDem.TabIndex = 11;
            this.numDem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDem.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(400, 363);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Đơn giá/khách";
            // 
            // numGia
            // 
            this.numGia.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numGia.Location = new System.Drawing.Point(512, 360);
            this.numGia.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.numGia.Name = "numGia";
            this.numGia.Size = new System.Drawing.Size(130, 27);
            this.numGia.TabIndex = 13;
            this.numGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numGia.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 398);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Mô tả";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(90, 395);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(552, 27);
            this.txtMoTa.TabIndex = 15;
            // 
            // btnThemTour
            // 
            this.btnThemTour.Location = new System.Drawing.Point(806, 433);
            this.btnThemTour.Name = "btnThemTour";
            this.btnThemTour.Size = new System.Drawing.Size(120, 28);
            this.btnThemTour.TabIndex = 16;
            this.btnThemTour.Text = "Thêm tour";
            this.btnThemTour.UseVisualStyleBackColor = true;
            this.btnThemTour.Click += new System.EventHandler(this.btnThemTour_Click);
            // 
            // tpDD
            // 
            this.tpDD.Controls.Add(this.dgvDiemDung);
            this.tpDD.Controls.Add(this.label8);
            this.tpDD.Controls.Add(this.numThuTu);
            this.tpDD.Controls.Add(this.label9);
            this.tpDD.Controls.Add(this.txtDiemDung);
            this.tpDD.Controls.Add(this.chkDoiPT);
            this.tpDD.Controls.Add(this.chkAn);
            this.tpDD.Controls.Add(this.chkKS);
            this.tpDD.Controls.Add(this.label10);
            this.tpDD.Controls.Add(this.numSao);
            this.tpDD.Controls.Add(this.label11);
            this.tpDD.Controls.Add(this.txtGhiChuDD);
            this.tpDD.Controls.Add(this.btnThemDD);
            this.tpDD.Location = new System.Drawing.Point(4, 29);
            this.tpDD.Name = "tpDD";
            this.tpDD.Padding = new System.Windows.Forms.Padding(3);
            this.tpDD.Size = new System.Drawing.Size(932, 467);
            this.tpDD.TabIndex = 1;
            this.tpDD.Text = "Điểm dừng";
            this.tpDD.UseVisualStyleBackColor = true;
            // 
            // dgvDiemDung
            // 
            this.dgvDiemDung.AllowUserToAddRows = false;
            this.dgvDiemDung.AllowUserToDeleteRows = false;
            this.dgvDiemDung.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiemDung.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDiemDung.ColumnHeadersHeight = 29;
            this.dgvDiemDung.Location = new System.Drawing.Point(10, 10);
            this.dgvDiemDung.MultiSelect = false;
            this.dgvDiemDung.Name = "dgvDiemDung";
            this.dgvDiemDung.ReadOnly = true;
            this.dgvDiemDung.RowHeadersVisible = false;
            this.dgvDiemDung.RowHeadersWidth = 51;
            this.dgvDiemDung.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiemDung.Size = new System.Drawing.Size(910, 290);
            this.dgvDiemDung.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 318);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "Thứ tự";
            // 
            // numThuTu
            // 
            this.numThuTu.Location = new System.Drawing.Point(90, 315);
            this.numThuTu.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numThuTu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThuTu.Name = "numThuTu";
            this.numThuTu.Size = new System.Drawing.Size(60, 27);
            this.numThuTu.TabIndex = 19;
            this.numThuTu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numThuTu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(180, 318);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Tên điểm dừng";
            // 
            // txtDiemDung
            // 
            this.txtDiemDung.Location = new System.Drawing.Point(295, 315);
            this.txtDiemDung.Name = "txtDiemDung";
            this.txtDiemDung.Size = new System.Drawing.Size(200, 27);
            this.txtDiemDung.TabIndex = 21;
            // 
            // chkDoiPT
            // 
            this.chkDoiPT.AutoSize = true;
            this.chkDoiPT.Location = new System.Drawing.Point(520, 316);
            this.chkDoiPT.Name = "chkDoiPT";
            this.chkDoiPT.Size = new System.Drawing.Size(140, 24);
            this.chkDoiPT.TabIndex = 22;
            this.chkDoiPT.Text = "Đổi phương tiện";
            this.chkDoiPT.UseVisualStyleBackColor = true;
            // 
            // chkAn
            // 
            this.chkAn.AutoSize = true;
            this.chkAn.Location = new System.Drawing.Point(677, 316);
            this.chkAn.Name = "chkAn";
            this.chkAn.Size = new System.Drawing.Size(94, 24);
            this.chkAn.TabIndex = 23;
            this.chkAn.Text = "Có nơi ăn";
            this.chkAn.UseVisualStyleBackColor = true;
            // 
            // chkKS
            // 
            this.chkKS.AutoSize = true;
            this.chkKS.Location = new System.Drawing.Point(799, 316);
            this.chkKS.Name = "chkKS";
            this.chkKS.Size = new System.Drawing.Size(117, 24);
            this.chkKS.TabIndex = 24;
            this.chkKS.Text = "Có khách sạn";
            this.chkKS.UseVisualStyleBackColor = true;
            this.chkKS.CheckedChanged += new System.EventHandler(this.chkKS_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 358);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 20);
            this.label10.TabIndex = 25;
            this.label10.Text = "Hạng sao";
            // 
            // numSao
            // 
            this.numSao.Enabled = false;
            this.numSao.Location = new System.Drawing.Point(90, 355);
            this.numSao.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numSao.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numSao.Name = "numSao";
            this.numSao.Size = new System.Drawing.Size(60, 27);
            this.numSao.TabIndex = 26;
            this.numSao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSao.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(180, 358);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 20);
            this.label11.TabIndex = 27;
            this.label11.Text = "Ghi chú";
            // 
            // txtGhiChuDD
            // 
            this.txtGhiChuDD.Location = new System.Drawing.Point(295, 355);
            this.txtGhiChuDD.Name = "txtGhiChuDD";
            this.txtGhiChuDD.Size = new System.Drawing.Size(200, 27);
            this.txtGhiChuDD.TabIndex = 28;
            // 
            // btnThemDD
            // 
            this.btnThemDD.Location = new System.Drawing.Point(780, 433);
            this.btnThemDD.Name = "btnThemDD";
            this.btnThemDD.Size = new System.Drawing.Size(140, 28);
            this.btnThemDD.TabIndex = 29;
            this.btnThemDD.Text = "Thêm điểm dừng";
            this.btnThemDD.UseVisualStyleBackColor = true;
            this.btnThemDD.Click += new System.EventHandler(this.btnThemDD_Click);
            // 
            // tpChang
            // 
            this.tpChang.Controls.Add(this.dgvChang);
            this.tpChang.Controls.Add(this.label12);
            this.tpChang.Controls.Add(this.numChang);
            this.tpChang.Controls.Add(this.label13);
            this.tpChang.Controls.Add(this.cboPT);
            this.tpChang.Controls.Add(this.label14);
            this.tpChang.Controls.Add(this.txtGhiChuPT);
            this.tpChang.Controls.Add(this.btnThemChang);
            this.tpChang.Location = new System.Drawing.Point(4, 29);
            this.tpChang.Name = "tpChang";
            this.tpChang.Padding = new System.Windows.Forms.Padding(3);
            this.tpChang.Size = new System.Drawing.Size(932, 467);
            this.tpChang.TabIndex = 2;
            this.tpChang.Text = "Phương tiện theo chặng";
            this.tpChang.UseVisualStyleBackColor = true;
            // 
            // dgvChang
            // 
            this.dgvChang.AllowUserToAddRows = false;
            this.dgvChang.AllowUserToDeleteRows = false;
            this.dgvChang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChang.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvChang.ColumnHeadersHeight = 29;
            this.dgvChang.Location = new System.Drawing.Point(10, 10);
            this.dgvChang.MultiSelect = false;
            this.dgvChang.Name = "dgvChang";
            this.dgvChang.ReadOnly = true;
            this.dgvChang.RowHeadersVisible = false;
            this.dgvChang.RowHeadersWidth = 51;
            this.dgvChang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChang.Size = new System.Drawing.Size(910, 300);
            this.dgvChang.TabIndex = 30;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 328);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 20);
            this.label12.TabIndex = 31;
            this.label12.Text = "Chặng thứ";
            // 
            // numChang
            // 
            this.numChang.Location = new System.Drawing.Point(90, 325);
            this.numChang.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numChang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numChang.Name = "numChang";
            this.numChang.Size = new System.Drawing.Size(60, 27);
            this.numChang.TabIndex = 32;
            this.numChang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numChang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(200, 328);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 20);
            this.label13.TabIndex = 33;
            this.label13.Text = "Phương tiện";
            // 
            // cboPT
            // 
            this.cboPT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPT.FormattingEnabled = true;
            this.cboPT.Location = new System.Drawing.Point(290, 325);
            this.cboPT.Name = "cboPT";
            this.cboPT.Size = new System.Drawing.Size(180, 28);
            this.cboPT.TabIndex = 34;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(500, 328);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 20);
            this.label14.TabIndex = 35;
            this.label14.Text = "Ghi chú";
            // 
            // txtGhiChuPT
            // 
            this.txtGhiChuPT.Location = new System.Drawing.Point(560, 325);
            this.txtGhiChuPT.Name = "txtGhiChuPT";
            this.txtGhiChuPT.Size = new System.Drawing.Size(200, 27);
            this.txtGhiChuPT.TabIndex = 36;
            // 
            // btnThemChang
            // 
            this.btnThemChang.Location = new System.Drawing.Point(786, 433);
            this.btnThemChang.Name = "btnThemChang";
            this.btnThemChang.Size = new System.Drawing.Size(140, 28);
            this.btnThemChang.TabIndex = 37;
            this.btnThemChang.Text = "Gắn phương tiện";
            this.btnThemChang.UseVisualStyleBackColor = true;
            this.btnThemChang.Click += new System.EventHandler(this.btnThemChang_Click);
            // 
            // tpTQ
            // 
            this.tpTQ.Controls.Add(this.dgvTQ);
            this.tpTQ.Controls.Add(this.label15);
            this.tpTQ.Controls.Add(this.cboDTQ);
            this.tpTQ.Controls.Add(this.label16);
            this.tpTQ.Controls.Add(this.numThuTuTQ);
            this.tpTQ.Controls.Add(this.btnThemTQ);
            this.tpTQ.Location = new System.Drawing.Point(4, 29);
            this.tpTQ.Name = "tpTQ";
            this.tpTQ.Padding = new System.Windows.Forms.Padding(3);
            this.tpTQ.Size = new System.Drawing.Size(932, 467);
            this.tpTQ.TabIndex = 3;
            this.tpTQ.Text = "Điểm tham quan";
            this.tpTQ.UseVisualStyleBackColor = true;
            // 
            // dgvTQ
            // 
            this.dgvTQ.AllowUserToAddRows = false;
            this.dgvTQ.AllowUserToDeleteRows = false;
            this.dgvTQ.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTQ.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTQ.ColumnHeadersHeight = 29;
            this.dgvTQ.Location = new System.Drawing.Point(10, 10);
            this.dgvTQ.MultiSelect = false;
            this.dgvTQ.Name = "dgvTQ";
            this.dgvTQ.ReadOnly = true;
            this.dgvTQ.RowHeadersVisible = false;
            this.dgvTQ.RowHeadersWidth = 51;
            this.dgvTQ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTQ.Size = new System.Drawing.Size(910, 300);
            this.dgvTQ.TabIndex = 38;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 328);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(120, 20);
            this.label15.TabIndex = 39;
            this.label15.Text = "Điểm tham quan";
            // 
            // cboDTQ
            // 
            this.cboDTQ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDTQ.FormattingEnabled = true;
            this.cboDTQ.Location = new System.Drawing.Point(136, 325);
            this.cboDTQ.Name = "cboDTQ";
            this.cboDTQ.Size = new System.Drawing.Size(260, 28);
            this.cboDTQ.TabIndex = 40;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(430, 328);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 20);
            this.label16.TabIndex = 41;
            this.label16.Text = "Thứ tự";
            // 
            // numThuTuTQ
            // 
            this.numThuTuTQ.Location = new System.Drawing.Point(488, 325);
            this.numThuTuTQ.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numThuTuTQ.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThuTuTQ.Name = "numThuTuTQ";
            this.numThuTuTQ.Size = new System.Drawing.Size(60, 27);
            this.numThuTuTQ.TabIndex = 42;
            this.numThuTuTQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numThuTuTQ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnThemTQ
            // 
            this.btnThemTQ.Location = new System.Drawing.Point(780, 433);
            this.btnThemTQ.Name = "btnThemTQ";
            this.btnThemTQ.Size = new System.Drawing.Size(140, 28);
            this.btnThemTQ.TabIndex = 43;
            this.btnThemTQ.Text = "Gắn điểm TQ";
            this.btnThemTQ.UseVisualStyleBackColor = true;
            this.btnThemTQ.Click += new System.EventHandler(this.btnThemTQ_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(850, 555);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 28);
            this.btnDong.TabIndex = 44;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmTour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 600);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTour);
            this.Controls.Add(this.tabTour);
            this.Controls.Add(this.btnDong);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTour";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tour - hành trình";
            this.Load += new System.EventHandler(this.FrmTour_Load);
            this.tabTour.ResumeLayout(false);
            this.tpTour.ResumeLayout(false);
            this.tpTour.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGia)).EndInit();
            this.tpDD.ResumeLayout(false);
            this.tpDD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiemDung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThuTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSao)).EndInit();
            this.tpChang.ResumeLayout(false);
            this.tpChang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChang)).EndInit();
            this.tpTQ.ResumeLayout(false);
            this.tpTQ.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThuTuTQ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTour;
        private System.Windows.Forms.TabControl tabTour;
        private System.Windows.Forms.TabPage tpTour;
        private System.Windows.Forms.TabPage tpDD;
        private System.Windows.Forms.TabPage tpChang;
        private System.Windows.Forms.TabPage tpTQ;
        private System.Windows.Forms.DataGridView dgvTour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numNgay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numDem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numGia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Button btnThemTour;
        private System.Windows.Forms.DataGridView dgvDiemDung;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numThuTu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDiemDung;
        private System.Windows.Forms.CheckBox chkDoiPT;
        private System.Windows.Forms.CheckBox chkAn;
        private System.Windows.Forms.CheckBox chkKS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numSao;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtGhiChuDD;
        private System.Windows.Forms.Button btnThemDD;
        private System.Windows.Forms.DataGridView dgvChang;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numChang;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboPT;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtGhiChuPT;
        private System.Windows.Forms.Button btnThemChang;
        private System.Windows.Forms.DataGridView dgvTQ;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboDTQ;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numThuTuTQ;
        private System.Windows.Forms.Button btnThemTQ;
        private System.Windows.Forms.Button btnDong;
    }
}
