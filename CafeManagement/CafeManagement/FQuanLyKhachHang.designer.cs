using System.Windows.Forms;
namespace CafeManagement
{
    partial class FQuanLyKhachHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FQuanLyKhachHang));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRank = new System.Windows.Forms.Button();
            this.txtTongChiTieu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiemTichLuy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnXoaKH = new System.Windows.Forms.Button();
            this.btnSuaKH = new System.Windows.Forms.Button();
            this.btnTimKiemTenKH = new System.Windows.Forms.Button();
            this.btnTimKiemMaKH = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtMaKhachHang = new System.Windows.Forms.TextBox();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvKhachHang = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chartTongChiTieu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDiemTichLuy = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTongChiTieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDiemTichLuy)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PeachPuff;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1531, 92);
            this.panel1.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SandyBrown;
            this.label1.Location = new System.Drawing.Point(484, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(407, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "Khách Hàng Thân Thiết";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(940, 2);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 60);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(381, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRank);
            this.panel2.Controls.Add(this.txtTongChiTieu);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtDiemTichLuy);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Controls.Add(this.btnXoaKH);
            this.panel2.Controls.Add(this.btnSuaKH);
            this.panel2.Controls.Add(this.btnTimKiemTenKH);
            this.panel2.Controls.Add(this.btnTimKiemMaKH);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.txtMaKhachHang);
            this.panel2.Controls.Add(this.txtTenKhachHang);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(0, 92);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1531, 160);
            this.panel2.TabIndex = 23;
            // 
            // btnRank
            // 
            this.btnRank.BackColor = System.Drawing.Color.SandyBrown;
            this.btnRank.FlatAppearance.BorderSize = 0;
            this.btnRank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRank.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRank.Location = new System.Drawing.Point(1176, 87);
            this.btnRank.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRank.Name = "btnRank";
            this.btnRank.Size = new System.Drawing.Size(68, 28);
            this.btnRank.TabIndex = 72;
            this.btnRank.Text = "Rank";
            this.btnRank.UseVisualStyleBackColor = false;
            this.btnRank.Click += new System.EventHandler(this.btnRank_Click);
            // 
            // txtTongChiTieu
            // 
            this.txtTongChiTieu.Enabled = false;
            this.txtTongChiTieu.Location = new System.Drawing.Point(619, 116);
            this.txtTongChiTieu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTongChiTieu.Name = "txtTongChiTieu";
            this.txtTongChiTieu.ReadOnly = true;
            this.txtTongChiTieu.Size = new System.Drawing.Size(275, 22);
            this.txtTongChiTieu.TabIndex = 71;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(419, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 19);
            this.label5.TabIndex = 70;
            this.label5.Text = "Tổng Chi Tiêu";
            // 
            // txtDiemTichLuy
            // 
            this.txtDiemTichLuy.Enabled = false;
            this.txtDiemTichLuy.Location = new System.Drawing.Point(619, 89);
            this.txtDiemTichLuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiemTichLuy.Name = "txtDiemTichLuy";
            this.txtDiemTichLuy.ReadOnly = true;
            this.txtDiemTichLuy.Size = new System.Drawing.Size(275, 22);
            this.txtDiemTichLuy.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(419, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 19);
            this.label2.TabIndex = 68;
            this.label2.Text = "Điểm Tích Lũy";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.SandyBrown;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(1103, 87);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(68, 28);
            this.btnReset.TabIndex = 67;
            this.btnReset.Text = "Tải Lại";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnXoaKH
            // 
            this.btnXoaKH.BackColor = System.Drawing.Color.SandyBrown;
            this.btnXoaKH.FlatAppearance.BorderSize = 0;
            this.btnXoaKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaKH.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaKH.Location = new System.Drawing.Point(1176, 54);
            this.btnXoaKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoaKH.Name = "btnXoaKH";
            this.btnXoaKH.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnXoaKH.Size = new System.Drawing.Size(68, 28);
            this.btnXoaKH.TabIndex = 66;
            this.btnXoaKH.Text = "Xóa";
            this.btnXoaKH.UseVisualStyleBackColor = false;
            this.btnXoaKH.Click += new System.EventHandler(this.btnXoaKH_Click);
            // 
            // btnSuaKH
            // 
            this.btnSuaKH.BackColor = System.Drawing.Color.SandyBrown;
            this.btnSuaKH.FlatAppearance.BorderSize = 0;
            this.btnSuaKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaKH.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaKH.Location = new System.Drawing.Point(1103, 54);
            this.btnSuaKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSuaKH.Name = "btnSuaKH";
            this.btnSuaKH.Size = new System.Drawing.Size(68, 28);
            this.btnSuaKH.TabIndex = 65;
            this.btnSuaKH.Text = "Sửa";
            this.btnSuaKH.UseVisualStyleBackColor = false;
            this.btnSuaKH.Click += new System.EventHandler(this.btnSuaKH_Click);
            // 
            // btnTimKiemTenKH
            // 
            this.btnTimKiemTenKH.BackColor = System.Drawing.Color.SandyBrown;
            this.btnTimKiemTenKH.FlatAppearance.BorderSize = 0;
            this.btnTimKiemTenKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiemTenKH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiemTenKH.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiemTenKH.Image")));
            this.btnTimKiemTenKH.Location = new System.Drawing.Point(940, 59);
            this.btnTimKiemTenKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimKiemTenKH.Name = "btnTimKiemTenKH";
            this.btnTimKiemTenKH.Size = new System.Drawing.Size(37, 21);
            this.btnTimKiemTenKH.TabIndex = 30;
            this.btnTimKiemTenKH.UseVisualStyleBackColor = false;
            this.btnTimKiemTenKH.Click += new System.EventHandler(this.btnTimKiemTenKH_Click);
            // 
            // btnTimKiemMaKH
            // 
            this.btnTimKiemMaKH.BackColor = System.Drawing.Color.SandyBrown;
            this.btnTimKiemMaKH.FlatAppearance.BorderSize = 0;
            this.btnTimKiemMaKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiemMaKH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiemMaKH.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiemMaKH.Image")));
            this.btnTimKiemMaKH.Location = new System.Drawing.Point(940, 31);
            this.btnTimKiemMaKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimKiemMaKH.Name = "btnTimKiemMaKH";
            this.btnTimKiemMaKH.Size = new System.Drawing.Size(37, 21);
            this.btnTimKiemMaKH.TabIndex = 29;
            this.btnTimKiemMaKH.UseVisualStyleBackColor = false;
            this.btnTimKiemMaKH.Click += new System.EventHandler(this.btnTimKiemMaKH_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(15, 7);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(175, 145);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // txtMaKhachHang
            // 
            this.txtMaKhachHang.Location = new System.Drawing.Point(619, 31);
            this.txtMaKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaKhachHang.Name = "txtMaKhachHang";
            this.txtMaKhachHang.Size = new System.Drawing.Size(275, 22);
            this.txtMaKhachHang.TabIndex = 26;
            this.txtMaKhachHang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaKhachHang_KeyPress);
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Location = new System.Drawing.Point(619, 59);
            this.txtTenKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.Size = new System.Drawing.Size(275, 22);
            this.txtTenKhachHang.TabIndex = 28;
            this.txtTenKhachHang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenKhachHang_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(419, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 19);
            this.label3.TabIndex = 25;
            this.label3.Text = "Mã Khách Hàng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(419, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 19);
            this.label4.TabIndex = 27;
            this.label4.Text = "Tên Khách Hàng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvKhachHang);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.SandyBrown;
            this.groupBox1.Location = new System.Drawing.Point(275, 257);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(853, 257);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Khách Hàng";
            // 
            // lvKhachHang
            // 
            this.lvKhachHang.AllowDrop = true;
            this.lvKhachHang.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvKhachHang.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvKhachHang.Font = new System.Drawing.Font("Times New Roman", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvKhachHang.FullRowSelect = true;
            this.lvKhachHang.HideSelection = false;
            this.lvKhachHang.Location = new System.Drawing.Point(15, 28);
            this.lvKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvKhachHang.Name = "lvKhachHang";
            this.lvKhachHang.Size = new System.Drawing.Size(821, 218);
            this.lvKhachHang.TabIndex = 48;
            this.lvKhachHang.UseCompatibleStateImageBehavior = false;
            this.lvKhachHang.View = System.Windows.Forms.View.Details;
            this.lvKhachHang.SelectedIndexChanged += new System.EventHandler(this.lvKhachHang_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Mã Khách Hàng";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tên Khách Hàng";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Điểm Tích Lũy ";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Tổng Chi Tiêu";
            this.columnHeader6.Width = 173;
            // 
            // chartTongChiTieu
            // 
            this.chartTongChiTieu.BackColor = System.Drawing.Color.Linen;
            chartArea1.Name = "ChartArea1";
            this.chartTongChiTieu.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Linen;
            legend1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartTongChiTieu.Legends.Add(legend1);
            this.chartTongChiTieu.Location = new System.Drawing.Point(-24, 519);
            this.chartTongChiTieu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartTongChiTieu.Name = "chartTongChiTieu";
            this.chartTongChiTieu.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Color = System.Drawing.Color.PeachPuff;
            series1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "VND";
            series1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            this.chartTongChiTieu.Series.Add(series1);
            this.chartTongChiTieu.Size = new System.Drawing.Size(793, 297);
            this.chartTongChiTieu.TabIndex = 51;
            this.chartTongChiTieu.Text = "chart1";
            title1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "chartDoanhThu";
            title1.Text = "Xếp Hạng Khách Hàng Theo Tổng Chi Tiêu";
            this.chartTongChiTieu.Titles.Add(title1);
            // 
            // chartDiemTichLuy
            // 
            this.chartDiemTichLuy.BackColor = System.Drawing.Color.Linen;
            chartArea2.Name = "ChartArea1";
            this.chartDiemTichLuy.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.Linen;
            legend2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            this.chartDiemTichLuy.Legends.Add(legend2);
            this.chartDiemTichLuy.Location = new System.Drawing.Point(733, 519);
            this.chartDiemTichLuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartDiemTichLuy.Name = "chartDiemTichLuy";
            this.chartDiemTichLuy.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.PeachPuff;
            series2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "Điểm";
            series2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            this.chartDiemTichLuy.Series.Add(series2);
            this.chartDiemTichLuy.Size = new System.Drawing.Size(649, 306);
            this.chartDiemTichLuy.TabIndex = 52;
            this.chartDiemTichLuy.Text = "chart1";
            title2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "chartDoanhThu";
            title2.Text = "Xếp Hạng Khách Hàng Theo Điểm Tích Lũy";
            this.chartDiemTichLuy.Titles.Add(title2);
            // 
            // QuanLyKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(1531, 863);
            this.Controls.Add(this.chartDiemTichLuy);
            this.Controls.Add(this.chartTongChiTieu);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "QuanLyKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ KHÁCH HÀNG";
            this.Load += new System.EventHandler(this.QuanLyKhachHang_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTongChiTieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDiemTichLuy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtMaKhachHang;
        private System.Windows.Forms.TextBox txtTenKhachHang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTimKiemTenKH;
        private System.Windows.Forms.Button btnTimKiemMaKH;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvKhachHang;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnXoaKH;
        private System.Windows.Forms.Button btnSuaKH;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtTongChiTieu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiemTichLuy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRank;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTongChiTieu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDiemTichLuy;
    }
}