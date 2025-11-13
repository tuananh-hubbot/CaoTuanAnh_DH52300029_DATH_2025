using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    public partial class MainForm : Form
    {
        private AVLTree cayNguoiDung; //Hàm dựng
        private List<NguoiDung> dsNguoiDungGoc;
        public MainForm()
        {
            InitializeComponent();
            cayNguoiDung = new AVLTree();
            dsNguoiDungGoc = new List<NguoiDung>();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void btnDocCSV_Click(object sender, EventArgs e)
        {
            string filePath = @"E:\\DOANTINHOC\\QuanLiHeThongSucKhoeVaCanBangMXH\\QuanLiHeThongSucKhoeVaCanBangMXH\\Dataset.csv";
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Không tìm thấy file CSV" + filePath);
                return;
            }
            //1. Đọc dữ liệu từ CSV
            dsNguoiDungGoc = DocFileCSV(filePath);
            if (dsNguoiDungGoc.Count == 0)
            {
                MessageBox.Show("File không có dữ liệu!");
                return;
            }
            cayNguoiDung = new AVLTree(nd => nd.Name); // Sắp xếp mặc định theo Tên
            foreach (var nd in dsNguoiDungGoc)
                cayNguoiDung.Insert(nd);
            //3.Duyệt cây(in-order) để lấy danh sách người dùng
            //4.Ghi file text và binary (Hàm đã có trong AVLTree)
            cayNguoiDung.SaveToText(cayNguoiDung.Root, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data_clean.txt"));
            cayNguoiDung.SaveToBinary(cayNguoiDung.Root, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data_clean.bin"));

            //5.Hiện thị lên DataGridView - dgvKetQua
            dgvKetQua.DataSource = null;
            dgvKetQua.DataSource = dsNguoiDungGoc;

            MessageBox.Show("Đã đọc CSV, lưu cây và ghi file sạch thành công!");
            // Hiện ComboBox và nút Sắp xếp
            cboSapXep.Visible = true;
            btnSapXep.Visible = true;

            // Lấy danh sách các thuộc tính của lớp NguoiDung
            var properties = typeof(NguoiDung).GetProperties()
                                              .Select(p => p.Name)
                                              .ToArray();

            cboSapXep.Items.Clear();
            cboSapXep.Items.AddRange(properties);

            // Chọn mặc định thuộc tính đầu tiên
            if (cboSapXep.Items.Count > 0)
                cboSapXep.SelectedIndex = 0;
            splitContainer1.Panel1.Invalidate();
            splitContainer1.Panel2.Invalidate();
        }
        //Hàm đọc CSV - sửa theo cấu trúc file csv thực tế
        private List<NguoiDung> DocFileCSV(string path)
        {
            var ds = new List<NguoiDung>();

            // Đọc tất cả dòng, bỏ dòng tiêu đề
            var allLines = File.ReadAllLines(path);
            if (allLines.Length <= 1) return ds;

            foreach (var raw in allLines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(raw)) continue;

                var parts = raw.Split(',');

                // Kiểm tra đủ cột (10 cột CSV)
                if (parts.Length < 10) continue;

                try
                {
                    string Name = parts[0].Trim();
                    int Age = int.TryParse(parts[1].Trim(), out int t) ? t : 0;
                    string Gender = parts[2].Trim();
                    double ThoiGianDungMXH = double.TryParse(parts[3].Trim(), out double tg) ? tg : 0.0;
                    double ChatLuongGiacNgu = double.TryParse(parts[4].Trim(), out double cl) ? cl : 0.0;
                    double MucDoStress = double.TryParse(parts[5].Trim(), out double ms) ? ms : 0.0;
                    double ThoiGianKhongMXH = double.TryParse(parts[6].Trim(), out double tk) ? tk : 0.0;
                    double TanSuatTapLuyen = double.TryParse(parts[7].Trim(), out double ts) ? ts : 0.0;
                    string AppSuDung = parts[8].Trim();
                    double MucDoHanhPhuc = double.TryParse(parts[9].Trim(), out double mh) ? mh : 0.0;

                    // Khởi tạo NguoiDung mới với 10 thuộc tính
                    var nd = new NguoiDung(
                        Name, Age, Gender,
                        ThoiGianDungMXH, ChatLuongGiacNgu, MucDoStress,
                        ThoiGianKhongMXH, TanSuatTapLuyen, AppSuDung,
                        MucDoHanhPhuc
                    );

                    ds.Add(nd);
                }
                catch
                {
                    continue; // bỏ qua dòng lỗi
                }
            }

            return ds;
        }


        //-Nếu muốn bổ sung OpenFileDialog để chọn file bằng giao diện
        private void btnDocFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV file (*.csv)|*.csv|All files (*.*)|*.*";
            ofd.Title = "Chọn file dữ liệu CSV";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;

                dsNguoiDungGoc = DocFileCSV(filePath);
                if (dsNguoiDungGoc != null && dsNguoiDungGoc.Count > 0)
                {
                    dgvKetQua.DataSource = null;
                    dgvKetQua.DataSource = dsNguoiDungGoc;
                    MessageBox.Show("Đọc dữ liệu thành công!");
                }
                else
                {
                    MessageBox.Show("File không có dữ liệu hoặc đọc lỗi!");
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string ten = txtTuKhoa.Text.Trim();
            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Hãy nhập tên cần tìm!");
                return;
            }

            var kq = cayNguoiDung.Search(cayNguoiDung.Root, ten);
            if (kq == null)
            {
                MessageBox.Show("Không tìm thấy người dùng!");
                return;
            }

            dgvKetQua.DataSource = new List<NguoiDung> { kq };
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ten = txtTuKhoa.Text.Trim();
            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Hãy nhập tên cần xóa!");
                return;
            }

            var kq = cayNguoiDung.Search(cayNguoiDung.Root, ten);
            if (kq == null)
            {
                MessageBox.Show("Không tìm thấy người dùng để xóa!");
                return;
            }

            // Xóa khỏi cây
            cayNguoiDung.Remove(kq);

            // Xóa khỏi danh sách gốc
            dsNguoiDungGoc.Remove(kq);

            // Cập nhật DataGridView
            dgvKetQua.DataSource = null;
            dgvKetQua.DataSource = dsNguoiDungGoc;

            MessageBox.Show("Đã xóa thành công!");
        }

        private void btnSapXep_Click(object sender, EventArgs e)
        {
            if (dsNguoiDungGoc == null || dsNguoiDungGoc.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu! Hãy đọc CSV trước.");
                return;
            }

            string fieldName = cboSapXep.SelectedItem.ToString();

            // Tạo cây mới theo property được chọn
            cayNguoiDung = new AVLTree(nd =>
            {
                var prop = typeof(NguoiDung).GetProperty(fieldName);
                return (IComparable)prop.GetValue(nd);
            });

            foreach (var nd in dsNguoiDungGoc)
                cayNguoiDung.Insert(nd);

            // Lấy kết quả InOrder
            var dsSapXep = new List<NguoiDung>();
            cayNguoiDung.InOrder(cayNguoiDung.Root, dsSapXep);

            dgvKetQua.DataSource = null;
            dgvKetQua.DataSource = dsSapXep;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            if (cayNguoiDung == null || cayNguoiDung.Root == null)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Vẽ cây ở giữa panel
            DrawNode(g, cayNguoiDung.Root, splitContainer1.Panel2.Width / 2, 40, splitContainer1.Panel2.Width / 4);
        }
        private void DrawNode(Graphics g, Node node, int x, int y, int offset)
        {
            if (node == null) return;

            int radius = 25;
            var font = new Font("Arial", 9);
            var pen = Pens.Black;
            var brush = Brushes.LightGreen;

            // Vẽ vòng tròn node
            g.FillEllipse(brush, x - radius, y - radius, radius * 2, radius * 2);
            g.DrawEllipse(pen, x - radius, y - radius, radius * 2, radius * 2);

            // Lấy dữ liệu hiển thị (tuỳ class Node của bạn)
            string text = node.Data?.Name ?? node.Data?.ToString() ?? "?";
            var textSize = g.MeasureString(text, font);
            g.DrawString(text, font, Brushes.Black,
                x - textSize.Width / 2, y - textSize.Height / 2);

            // Vẽ nhánh trái
            if (node.Left != null)
            {
                g.DrawLine(pen, x, y + radius, x - offset, y + 80 - radius);
                DrawNode(g, node.Left, x - offset, y + 80, offset / 2);
            }

            // Vẽ nhánh phải
            if (node.Right != null)
            {
                g.DrawLine(pen, x, y + radius, x + offset, y + 80 - radius);
                DrawNode(g, node.Right, x + offset, y + 80, offset / 2);
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            if (cayNguoiDung == null || cayNguoiDung.Root == null)
            {
                e.Graphics.DrawString("Chưa có dữ liệu cây.", Font, Brushes.Gray, 10, 10);
                return;
            }

            var stats = cayNguoiDung.GetStats();

            float y = 10;
            e.Graphics.DrawString($"📊 Thống kê cây AVL", new Font("Segoe UI", 11, FontStyle.Bold), Brushes.DarkBlue, 10, y);
            y += 30;
            e.Graphics.DrawString($"Tổng số nút: {stats.TotalNodes}", Font, Brushes.Black, 10, y); y += 25;
            e.Graphics.DrawString($"Chiều cao cây: {stats.Height}", Font, Brushes.Black, 10, y); y += 25;
            e.Graphics.DrawString($"Số nút nhánh trái: {stats.LeftCount}", Font, Brushes.Black, 10, y); y += 25;
            e.Graphics.DrawString($"Số nút nhánh phải: {stats.RightCount}", Font, Brushes.Black, 10, y); y += 25;
            e.Graphics.DrawString($"Tình trạng cân bằng: {stats.BalanceState}", Font, Brushes.DarkGreen, 10, y);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát chương trình không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Thoát toàn bộ chương trình
            }
        }


        private void btnKiemTraTang_Click(object sender, EventArgs e)
        {
            if (cayNguoiDung == null || cayNguoiDung.Root == null)
            {
                MessageBox.Show("Chưa có dữ liệu cây!");
                return;
            }

            if (!int.TryParse(txtTang.Text.Trim(), out int k) || k < 0)
            {
                MessageBox.Show("Nhập số tầng hợp lệ (>=0)!");
                return;
            }

            var nodesAtLevel = cayNguoiDung.GetNodesAtLevel(k);
            int count = nodesAtLevel.Count;

            if (count == 0)
            {
                lblKetQua.Text = $"Tầng {k} không có node nào.";
            }
            else
            {
                // Lấy tên người dùng tầng k
                string names = string.Join(", ", nodesAtLevel.Select(nd => nd.Name));
                lblKetQua.Text = $"Tầng {k} có {count} node(s): {names}";
            }
        }

        private void btnXemCayCon_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtTang.Text, out int k))
            {
                MessageBox.Show("Nhập tầng hợp lệ!");
                return;
            }

            var result = MessageBox.Show("Xem nhánh trái? (Chọn No để xem nhánh phải)", "Chọn hướng", MessageBoxButtons.YesNo);
            string direction = result == DialogResult.Yes ? "left" : "right";

            Node subtree = cayNguoiDung.GetSubTree(cayNguoiDung.Root, k, 0, direction);
            if (subtree == null)
            {
                MessageBox.Show("Không tìm thấy cây con ở tầng này.");
                return;
            }

            using (Graphics g = splitContainer1.Panel2.CreateGraphics())
            {
                g.Clear(splitContainer1.Panel2.BackColor);
                DrawNode(g, subtree, splitContainer1.Panel2.Width / 2, 50, 200);
            }
        }
    }
}
    
