namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    partial class FrmPureTree
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvShowDuplicate = new System.Windows.Forms.DataGridView();
            this.ShowDuplicate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowDuplicate)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(394, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 606);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dgvShowDuplicate
            // 
            this.dgvShowDuplicate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowDuplicate.Location = new System.Drawing.Point(12, 79);
            this.dgvShowDuplicate.Name = "dgvShowDuplicate";
            this.dgvShowDuplicate.RowHeadersWidth = 62;
            this.dgvShowDuplicate.RowTemplate.Height = 28;
            this.dgvShowDuplicate.Size = new System.Drawing.Size(361, 554);
            this.dgvShowDuplicate.TabIndex = 1;
            // 
            // ShowDuplicate
            // 
            this.ShowDuplicate.Location = new System.Drawing.Point(88, 27);
            this.ShowDuplicate.Name = "ShowDuplicate";
            this.ShowDuplicate.Size = new System.Drawing.Size(195, 35);
            this.ShowDuplicate.TabIndex = 2;
            this.ShowDuplicate.Text = "Hiện Thị Dữ Liệu Trùng";
            this.ShowDuplicate.UseVisualStyleBackColor = true;
            this.ShowDuplicate.Click += new System.EventHandler(this.ShowDuplicate_Click);
            // 
            // FrmPureTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 660);
            this.Controls.Add(this.ShowDuplicate);
            this.Controls.Add(this.dgvShowDuplicate);
            this.Controls.Add(this.panel1);
            this.Name = "FrmPureTree";
            this.Text = "FrmPureTree";
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowDuplicate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvShowDuplicate;
        private System.Windows.Forms.Button ShowDuplicate;
    }
}