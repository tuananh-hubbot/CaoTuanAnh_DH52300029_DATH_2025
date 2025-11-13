<<<<<<< HEAD
<<<<<<< HEAD
﻿namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    partial class MainForm
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
            this.btnDocCSV = new System.Windows.Forms.Button();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.btnDocFile = new System.Windows.Forms.Button();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.cboSapXep = new System.Windows.Forms.ComboBox();
            this.btnSapXep = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.btnXemCayCon = new System.Windows.Forms.Button();
            this.btnKiemTraTang = new System.Windows.Forms.Button();
            this.txtTang = new System.Windows.Forms.TextBox();
            this.lblNhapTang = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.nguoiDungBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nguoiDungBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDocCSV
            // 
            this.btnDocCSV.Location = new System.Drawing.Point(683, 260);
            this.btnDocCSV.Name = "btnDocCSV";
            this.btnDocCSV.Size = new System.Drawing.Size(87, 40);
            this.btnDocCSV.TabIndex = 0;
            this.btnDocCSV.Text = "Loading";
            this.btnDocCSV.UseVisualStyleBackColor = true;
            this.btnDocCSV.Click += new System.EventHandler(this.btnDocCSV_Click);
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.Location = new System.Drawing.Point(18, 125);
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.RowHeadersWidth = 62;
            this.dgvKetQua.RowTemplate.Height = 28;
            this.dgvKetQua.Size = new System.Drawing.Size(649, 453);
            this.dgvKetQua.TabIndex = 1;
            // 
            // btnDocFile
            // 
            this.btnDocFile.Location = new System.Drawing.Point(18, 12);
            this.btnDocFile.Name = "btnDocFile";
            this.btnDocFile.Size = new System.Drawing.Size(160, 33);
            this.btnDocFile.TabIndex = 2;
            this.btnDocFile.Text = "Đọc dữ liệu từ CSV\r\n\r\n";
            this.btnDocFile.UseVisualStyleBackColor = true;
            this.btnDocFile.Click += new System.EventHandler(this.btnDocFile_Click);
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Location = new System.Drawing.Point(586, 20);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(101, 26);
            this.txtTuKhoa.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(693, 19);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(95, 36);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(693, 61);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(95, 34);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // cboSapXep
            // 
            this.cboSapXep.FormattingEnabled = true;
            this.cboSapXep.Location = new System.Drawing.Point(297, 17);
            this.cboSapXep.Name = "cboSapXep";
            this.cboSapXep.Size = new System.Drawing.Size(98, 28);
            this.cboSapXep.TabIndex = 6;
            this.cboSapXep.Visible = false;
            // 
            // btnSapXep
            // 
            this.btnSapXep.Location = new System.Drawing.Point(419, 15);
            this.btnSapXep.Name = "btnSapXep";
            this.btnSapXep.Size = new System.Drawing.Size(93, 36);
            this.btnSapXep.TabIndex = 7;
            this.btnSapXep.Text = "Sắp Xếp";
            this.btnSapXep.UseVisualStyleBackColor = true;
            this.btnSapXep.Visible = false;
            this.btnSapXep.Click += new System.EventHandler(this.btnSapXep_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(794, 20);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblKetQua);
            this.splitContainer1.Panel1.Controls.Add(this.btnXemCayCon);
            this.splitContainer1.Panel1.Controls.Add(this.btnKiemTraTang);
            this.splitContainer1.Panel1.Controls.Add(this.txtTang);
            this.splitContainer1.Panel1.Controls.Add(this.lblNhapTang);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(865, 558);
            this.splitContainer1.SplitterDistance = 287;
            this.splitContainer1.TabIndex = 8;
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Location = new System.Drawing.Point(12, 397);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(72, 20);
            this.lblKetQua.TabIndex = 4;
            this.lblKetQua.Text = "Kết quả: ";
            // 
            // btnXemCayCon
            // 
            this.btnXemCayCon.Location = new System.Drawing.Point(152, 343);
            this.btnXemCayCon.Name = "btnXemCayCon";
            this.btnXemCayCon.Size = new System.Drawing.Size(122, 37);
            this.btnXemCayCon.TabIndex = 3;
            this.btnXemCayCon.Text = "Xem cây con";
            this.btnXemCayCon.UseVisualStyleBackColor = true;
            this.btnXemCayCon.Click += new System.EventHandler(this.btnXemCayCon_Click);
            // 
            // btnKiemTraTang
            // 
            this.btnKiemTraTang.Location = new System.Drawing.Point(16, 343);
            this.btnKiemTraTang.Name = "btnKiemTraTang";
            this.btnKiemTraTang.Size = new System.Drawing.Size(130, 37);
            this.btnKiemTraTang.TabIndex = 2;
            this.btnKiemTraTang.Text = "Kiểm tra tầng";
            this.btnKiemTraTang.UseVisualStyleBackColor = true;
            this.btnKiemTraTang.Click += new System.EventHandler(this.btnKiemTraTang_Click);
            // 
            // txtTang
            // 
            this.txtTang.Location = new System.Drawing.Point(195, 311);
            this.txtTang.Name = "txtTang";
            this.txtTang.Size = new System.Drawing.Size(72, 26);
            this.txtTang.TabIndex = 1;
            // 
            // lblNhapTang
            // 
            this.lblNhapTang.AutoSize = true;
            this.lblNhapTang.Location = new System.Drawing.Point(12, 311);
            this.lblNhapTang.Name = "lblNhapTang";
            this.lblNhapTang.Size = new System.Drawing.Size(177, 20);
            this.lblNhapTang.TabIndex = 0;
            this.lblNhapTang.Text = "Nhập tầng cần kiểm tra:";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(695, 101);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(93, 35);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // nguoiDungBindingSource
            // 
            this.nguoiDungBindingSource.DataSource = typeof(QuanLiHeThongSucKhoeVaCanBangMXH.NguoiDung);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1689, 653);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnSapXep);
            this.Controls.Add(this.cboSapXep);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTuKhoa);
            this.Controls.Add(this.btnDocFile);
            this.Controls.Add(this.dgvKetQua);
            this.Controls.Add(this.btnDocCSV);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nguoiDungBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDocCSV;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.Button btnDocFile;
        private System.Windows.Forms.BindingSource nguoiDungBindingSource;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.ComboBox cboSapXep;
        private System.Windows.Forms.Button btnSapXep;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.Button btnXemCayCon;
        private System.Windows.Forms.Button btnKiemTraTang;
        private System.Windows.Forms.TextBox txtTang;
        private System.Windows.Forms.Label lblNhapTang;
    }
}

=======
﻿namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    partial class MainForm
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
            this.btnDocCSV = new System.Windows.Forms.Button();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.btnDocFile = new System.Windows.Forms.Button();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.cboSapXep = new System.Windows.Forms.ComboBox();
            this.btnSapXep = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.btnXemCayCon = new System.Windows.Forms.Button();
            this.btnKiemTraTang = new System.Windows.Forms.Button();
            this.txtTang = new System.Windows.Forms.TextBox();
            this.lblNhapTang = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.nguoiDungBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nguoiDungBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDocCSV
            // 
            this.btnDocCSV.Location = new System.Drawing.Point(683, 260);
            this.btnDocCSV.Name = "btnDocCSV";
            this.btnDocCSV.Size = new System.Drawing.Size(87, 40);
            this.btnDocCSV.TabIndex = 0;
            this.btnDocCSV.Text = "Loading";
            this.btnDocCSV.UseVisualStyleBackColor = true;
            this.btnDocCSV.Click += new System.EventHandler(this.btnDocCSV_Click);
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.Location = new System.Drawing.Point(18, 125);
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.RowHeadersWidth = 62;
            this.dgvKetQua.RowTemplate.Height = 28;
            this.dgvKetQua.Size = new System.Drawing.Size(649, 453);
            this.dgvKetQua.TabIndex = 1;
            // 
            // btnDocFile
            // 
            this.btnDocFile.Location = new System.Drawing.Point(18, 12);
            this.btnDocFile.Name = "btnDocFile";
            this.btnDocFile.Size = new System.Drawing.Size(160, 33);
            this.btnDocFile.TabIndex = 2;
            this.btnDocFile.Text = "Đọc dữ liệu từ CSV\r\n\r\n";
            this.btnDocFile.UseVisualStyleBackColor = true;
            this.btnDocFile.Click += new System.EventHandler(this.btnDocFile_Click);
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Location = new System.Drawing.Point(586, 20);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(101, 26);
            this.txtTuKhoa.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(693, 19);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(95, 36);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(693, 61);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(95, 34);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // cboSapXep
            // 
            this.cboSapXep.FormattingEnabled = true;
            this.cboSapXep.Location = new System.Drawing.Point(297, 17);
            this.cboSapXep.Name = "cboSapXep";
            this.cboSapXep.Size = new System.Drawing.Size(98, 28);
            this.cboSapXep.TabIndex = 6;
            this.cboSapXep.Visible = false;
            // 
            // btnSapXep
            // 
            this.btnSapXep.Location = new System.Drawing.Point(419, 15);
            this.btnSapXep.Name = "btnSapXep";
            this.btnSapXep.Size = new System.Drawing.Size(93, 36);
            this.btnSapXep.TabIndex = 7;
            this.btnSapXep.Text = "Sắp Xếp";
            this.btnSapXep.UseVisualStyleBackColor = true;
            this.btnSapXep.Visible = false;
            this.btnSapXep.Click += new System.EventHandler(this.btnSapXep_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(794, 20);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblKetQua);
            this.splitContainer1.Panel1.Controls.Add(this.btnXemCayCon);
            this.splitContainer1.Panel1.Controls.Add(this.btnKiemTraTang);
            this.splitContainer1.Panel1.Controls.Add(this.txtTang);
            this.splitContainer1.Panel1.Controls.Add(this.lblNhapTang);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(865, 558);
            this.splitContainer1.SplitterDistance = 287;
            this.splitContainer1.TabIndex = 8;
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Location = new System.Drawing.Point(12, 397);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(72, 20);
            this.lblKetQua.TabIndex = 4;
            this.lblKetQua.Text = "Kết quả: ";
            // 
            // btnXemCayCon
            // 
            this.btnXemCayCon.Location = new System.Drawing.Point(152, 343);
            this.btnXemCayCon.Name = "btnXemCayCon";
            this.btnXemCayCon.Size = new System.Drawing.Size(122, 37);
            this.btnXemCayCon.TabIndex = 3;
            this.btnXemCayCon.Text = "Xem cây con";
            this.btnXemCayCon.UseVisualStyleBackColor = true;
            this.btnXemCayCon.Click += new System.EventHandler(this.btnXemCayCon_Click);
            // 
            // btnKiemTraTang
            // 
            this.btnKiemTraTang.Location = new System.Drawing.Point(16, 343);
            this.btnKiemTraTang.Name = "btnKiemTraTang";
            this.btnKiemTraTang.Size = new System.Drawing.Size(130, 37);
            this.btnKiemTraTang.TabIndex = 2;
            this.btnKiemTraTang.Text = "Kiểm tra tầng";
            this.btnKiemTraTang.UseVisualStyleBackColor = true;
            this.btnKiemTraTang.Click += new System.EventHandler(this.btnKiemTraTang_Click);
            // 
            // txtTang
            // 
            this.txtTang.Location = new System.Drawing.Point(195, 311);
            this.txtTang.Name = "txtTang";
            this.txtTang.Size = new System.Drawing.Size(72, 26);
            this.txtTang.TabIndex = 1;
            // 
            // lblNhapTang
            // 
            this.lblNhapTang.AutoSize = true;
            this.lblNhapTang.Location = new System.Drawing.Point(12, 311);
            this.lblNhapTang.Name = "lblNhapTang";
            this.lblNhapTang.Size = new System.Drawing.Size(177, 20);
            this.lblNhapTang.TabIndex = 0;
            this.lblNhapTang.Text = "Nhập tầng cần kiểm tra:";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(695, 101);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(93, 35);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // nguoiDungBindingSource
            // 
            this.nguoiDungBindingSource.DataSource = typeof(QuanLiHeThongSucKhoeVaCanBangMXH.NguoiDung);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1689, 653);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnSapXep);
            this.Controls.Add(this.cboSapXep);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTuKhoa);
            this.Controls.Add(this.btnDocFile);
            this.Controls.Add(this.dgvKetQua);
            this.Controls.Add(this.btnDocCSV);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nguoiDungBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDocCSV;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.Button btnDocFile;
        private System.Windows.Forms.BindingSource nguoiDungBindingSource;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.ComboBox cboSapXep;
        private System.Windows.Forms.Button btnSapXep;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.Button btnXemCayCon;
        private System.Windows.Forms.Button btnKiemTraTang;
        private System.Windows.Forms.TextBox txtTang;
        private System.Windows.Forms.Label lblNhapTang;
    }
}

>>>>>>> 2514022022a8e65ca2db7b469a3bbd8106c1b849
=======
﻿namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    partial class MainForm
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
            this.btnDocCSV = new System.Windows.Forms.Button();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.btnDocFile = new System.Windows.Forms.Button();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.cboSapXep = new System.Windows.Forms.ComboBox();
            this.btnSapXep = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.btnXemCayCon = new System.Windows.Forms.Button();
            this.btnKiemTraTang = new System.Windows.Forms.Button();
            this.txtTang = new System.Windows.Forms.TextBox();
            this.lblNhapTang = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.nguoiDungBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nguoiDungBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDocCSV
            // 
            this.btnDocCSV.Location = new System.Drawing.Point(683, 260);
            this.btnDocCSV.Name = "btnDocCSV";
            this.btnDocCSV.Size = new System.Drawing.Size(87, 40);
            this.btnDocCSV.TabIndex = 0;
            this.btnDocCSV.Text = "Loading";
            this.btnDocCSV.UseVisualStyleBackColor = true;
            this.btnDocCSV.Click += new System.EventHandler(this.btnDocCSV_Click);
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.Location = new System.Drawing.Point(18, 125);
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.RowHeadersWidth = 62;
            this.dgvKetQua.RowTemplate.Height = 28;
            this.dgvKetQua.Size = new System.Drawing.Size(649, 453);
            this.dgvKetQua.TabIndex = 1;
            // 
            // btnDocFile
            // 
            this.btnDocFile.Location = new System.Drawing.Point(18, 12);
            this.btnDocFile.Name = "btnDocFile";
            this.btnDocFile.Size = new System.Drawing.Size(160, 33);
            this.btnDocFile.TabIndex = 2;
            this.btnDocFile.Text = "Đọc dữ liệu từ CSV\r\n\r\n";
            this.btnDocFile.UseVisualStyleBackColor = true;
            this.btnDocFile.Click += new System.EventHandler(this.btnDocFile_Click);
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Location = new System.Drawing.Point(586, 20);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(101, 26);
            this.txtTuKhoa.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(693, 19);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(95, 36);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(693, 61);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(95, 34);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // cboSapXep
            // 
            this.cboSapXep.FormattingEnabled = true;
            this.cboSapXep.Location = new System.Drawing.Point(297, 17);
            this.cboSapXep.Name = "cboSapXep";
            this.cboSapXep.Size = new System.Drawing.Size(98, 28);
            this.cboSapXep.TabIndex = 6;
            this.cboSapXep.Visible = false;
            // 
            // btnSapXep
            // 
            this.btnSapXep.Location = new System.Drawing.Point(419, 15);
            this.btnSapXep.Name = "btnSapXep";
            this.btnSapXep.Size = new System.Drawing.Size(93, 36);
            this.btnSapXep.TabIndex = 7;
            this.btnSapXep.Text = "Sắp Xếp";
            this.btnSapXep.UseVisualStyleBackColor = true;
            this.btnSapXep.Visible = false;
            this.btnSapXep.Click += new System.EventHandler(this.btnSapXep_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(794, 20);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblKetQua);
            this.splitContainer1.Panel1.Controls.Add(this.btnXemCayCon);
            this.splitContainer1.Panel1.Controls.Add(this.btnKiemTraTang);
            this.splitContainer1.Panel1.Controls.Add(this.txtTang);
            this.splitContainer1.Panel1.Controls.Add(this.lblNhapTang);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(865, 558);
            this.splitContainer1.SplitterDistance = 287;
            this.splitContainer1.TabIndex = 8;
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Location = new System.Drawing.Point(12, 397);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(72, 20);
            this.lblKetQua.TabIndex = 4;
            this.lblKetQua.Text = "Kết quả: ";
            // 
            // btnXemCayCon
            // 
            this.btnXemCayCon.Location = new System.Drawing.Point(152, 343);
            this.btnXemCayCon.Name = "btnXemCayCon";
            this.btnXemCayCon.Size = new System.Drawing.Size(122, 37);
            this.btnXemCayCon.TabIndex = 3;
            this.btnXemCayCon.Text = "Xem cây con";
            this.btnXemCayCon.UseVisualStyleBackColor = true;
            this.btnXemCayCon.Click += new System.EventHandler(this.btnXemCayCon_Click);
            // 
            // btnKiemTraTang
            // 
            this.btnKiemTraTang.Location = new System.Drawing.Point(16, 343);
            this.btnKiemTraTang.Name = "btnKiemTraTang";
            this.btnKiemTraTang.Size = new System.Drawing.Size(130, 37);
            this.btnKiemTraTang.TabIndex = 2;
            this.btnKiemTraTang.Text = "Kiểm tra tầng";
            this.btnKiemTraTang.UseVisualStyleBackColor = true;
            this.btnKiemTraTang.Click += new System.EventHandler(this.btnKiemTraTang_Click);
            // 
            // txtTang
            // 
            this.txtTang.Location = new System.Drawing.Point(195, 311);
            this.txtTang.Name = "txtTang";
            this.txtTang.Size = new System.Drawing.Size(72, 26);
            this.txtTang.TabIndex = 1;
            // 
            // lblNhapTang
            // 
            this.lblNhapTang.AutoSize = true;
            this.lblNhapTang.Location = new System.Drawing.Point(12, 311);
            this.lblNhapTang.Name = "lblNhapTang";
            this.lblNhapTang.Size = new System.Drawing.Size(177, 20);
            this.lblNhapTang.TabIndex = 0;
            this.lblNhapTang.Text = "Nhập tầng cần kiểm tra:";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(695, 101);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(93, 35);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // nguoiDungBindingSource
            // 
            this.nguoiDungBindingSource.DataSource = typeof(QuanLiHeThongSucKhoeVaCanBangMXH.NguoiDung);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1689, 653);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnSapXep);
            this.Controls.Add(this.cboSapXep);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTuKhoa);
            this.Controls.Add(this.btnDocFile);
            this.Controls.Add(this.dgvKetQua);
            this.Controls.Add(this.btnDocCSV);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nguoiDungBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDocCSV;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.Button btnDocFile;
        private System.Windows.Forms.BindingSource nguoiDungBindingSource;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.ComboBox cboSapXep;
        private System.Windows.Forms.Button btnSapXep;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.Button btnXemCayCon;
        private System.Windows.Forms.Button btnKiemTraTang;
        private System.Windows.Forms.TextBox txtTang;
        private System.Windows.Forms.Label lblNhapTang;
    }
}

>>>>>>> 2514022022a8e65ca2db7b469a3bbd8106c1b849
