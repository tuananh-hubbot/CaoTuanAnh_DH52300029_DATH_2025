using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CaoTuanAnh_VisualCode_Read
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                // 🔹 Đường dẫn đầy đủ đến file CSV
                string filePath = @"C:\Users\PcCenter.vn\OneDrive\Documents\GitHub\CaoTuanAnh_DH52300029_DATH_2025\CaoTuanAnh_VisualCode_Read\CaoTuanAnh_VisualCode_Read\bin\Debug\Dataset.csv";

                // 🔹 Tạo bảng dữ liệu
                DataTable dt = new DataTable();

                // 🔹 Đọc tất cả các dòng trong file
                string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);

                if (lines.Length > 0)
                {
                    // Dòng đầu là tiêu đề cột
                    string[] headerLabels = lines[0].Split(',');
                    foreach (string headerWord in headerLabels)
                    {
                        dt.Columns.Add(headerWord.Trim());
                    }

                    // Dữ liệu các dòng còn lại
                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] dataWords = lines[i].Split(',');
                        dt.Rows.Add(dataWords);
                    }

                    // 🔹 Gán dữ liệu cho DataGridView
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["User_ID"].HeaderText = "Mã ID";
                    dataGridView1.Columns["Age"].HeaderText = "Tuổi";
                    dataGridView1.Columns["Gender"].HeaderText = "Giới Tính";
                }
                else
                {
                    MessageBox.Show("File CSV trống hoặc không có dữ liệu!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc file CSV: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
