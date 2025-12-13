using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    public partial class FrmPureTree : Form
    {
        
        private string keyFieldName;
        private PureTree pureTree;

        public FrmPureTree(List<NguoiDung> dsNguoiDung, string keyFieldName)
        {
            InitializeComponent();
            this.keyFieldName = keyFieldName;

            // Tạo PureTree dựa trên trường dữ liệu đang chọn
            pureTree = new PureTree(nd =>
            {
                var prop = typeof(NguoiDung).GetProperty(keyFieldName);
                return (IComparable)prop.GetValue(nd);
            });

            // Chèn dữ liệu vào cây
            foreach (var nd in dsNguoiDung)
                pureTree.Insert(nd);
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (pureTree == null || pureTree.Root == null)
            {
                MessageBox.Show("Cây không có dữ liệu.");
                return;
            }

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int startX = panel1.Width / 2;
            int startY = 40;
            int horizontalSpacing = panel1.Width / 4;

            DrawNode(g, pureTree.Root, startX, startY, horizontalSpacing);
        }
            private void DrawNode(Graphics g, Node<NguoiDung> node, int x, int y, int hSpacing)
        {
            if (node == null) return;
            int nodeSize = 40; // hình tròn

            // Vẽ nhánh trái
            if (node.Left != null)
            {
                g.DrawLine(Pens.Black, x, y, x - hSpacing, y + 70);
                DrawNode(g, node.Left, x - hSpacing, y + 70, hSpacing / 2);
            }

            // Vẽ nhánh phải
            if (node.Right != null)
            {
                g.DrawLine(Pens.Black, x, y, x + hSpacing, y + 70);
                DrawNode(g, node.Right, x + hSpacing, y + 70, hSpacing / 2);
            }

            // Vẽ node hình tròn
            Rectangle rect = new Rectangle(x - nodeSize / 2, y - nodeSize / 2, nodeSize, nodeSize);
            g.FillEllipse(Brushes.LightBlue, rect);
            g.DrawEllipse(Pens.DarkBlue, rect);

            // Lấy text để hiển thị (dùng keySelector)
            string text = "?";
            if (node.Data != null)
            {
                var prop = typeof(NguoiDung).GetProperty(keyFieldName);
                if (prop != null)
                    text = prop.GetValue(node.Data)?.ToString() ?? "?";
            }

            // Chỉnh giữa text
            var textSize = g.MeasureString(text, this.Font);
            g.DrawString(
                text,
                this.Font,
                Brushes.Black,
                x - textSize.Width / 2,
                y - textSize.Height / 2);
        }

        private void ShowDuplicate_Click(object sender, EventArgs e)
        {
            if (pureTree == null)
            {
                MessageBox.Show("Chưa có cây PureTree.");
                return;
            }

            var dupList = pureTree.DuplicateUsers.ToList();

            if (dupList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu trùng!");
                dgvShowDuplicate.DataSource = null;
                return;
            }

            dgvShowDuplicate.DataSource = null;
            dgvShowDuplicate.DataSource = dupList;
        }
    }
}
