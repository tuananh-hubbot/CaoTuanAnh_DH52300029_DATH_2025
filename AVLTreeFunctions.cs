using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    internal class AVLTreeFunctions
    {
        private AVLTree tree;
        public Dictionary<string, Action> Actions { get; private set; }
        public AVLTreeFunctions(AVLTree tree)
        {
            this.tree = tree;
            Actions = new Dictionary<string, Action>();
        }
        public void InitializeFunctions(Func<string> getSelectedField, Action<string> ketQua)
        {
            // Tổng node (toàn bộ hoặc node lá)
            void SumNodes(Func<Node, Func<NguoiDung, double>, double> sumFunc, string name)
            {
                if (tree.Root == null) { ketQua("Cây đang trống!"); return; }

                var field = getSelectedField();
                var prop = typeof(NguoiDung).GetProperty(field);

                if (prop == null) { ketQua($"Trường {field} không tồn tại!"); return; }
                if (!IsNumericType(prop.PropertyType)) { ketQua($"Trường {field} không phải kiểu số!"); return; }

                try
                {
                    double tong = sumFunc(tree.Root, nd => Convert.ToDouble(prop.GetValue(nd)));
                    ketQua($"{name} {field}: {tong}");
                }
                catch (Exception ex)
                {
                    ketQua($"Lỗi khi tính tổng: {ex.Message}");
                }
            }

            Actions["Tổng"] = () => SumNodes(tree.tongNode, "Tổng Node");
            Actions["Tổng Node Lá"] = () => SumNodes(tree.tongNodeLa, "Tổng (Node lá)");

            // Node min/max
            void MinMaxNode(bool findMin)
            {
                if (tree.Root == null) { ketQua("Cây đang trống!"); return; }

                var field = getSelectedField();
                var prop = typeof(NguoiDung).GetProperty(field);
                if (prop == null) { ketQua($"Trường {field} không tồn tại!"); return; }
                if (!typeof(IComparable).IsAssignableFrom(prop.PropertyType)) { ketQua($"Trường {field} không thể so sánh!"); return; }

                try
                {
                    Func<NguoiDung, IComparable> selector = nd => (IComparable)prop.GetValue(nd);
                    Node node = findMin ? NodeMin(tree.Root, selector) : NodeMax(tree.Root, selector);
                    if (node != null) ketQua($"{(findMin ? "Nhỏ nhất" : "Lớn nhất")} ({field}): {selector(node.Data)}");
                    else ketQua("Không tìm thấy node phù hợp!");
                }
                catch (Exception ex)
                {
                    ketQua($"Lỗi khi tìm Node: {ex.Message}");
                }
            }

            Actions["Nhỏ nhất"] = () => MinMaxNode(true);
            Actions["Lớn nhất"] = () => MinMaxNode(false);

            // Đếm node
            Actions["Đếm"] = () => ketQua($"Tổng node: {Count(tree.Root)}");
            Actions["Đếm Node Lá"] = () => ketQua($"Số node lá: {CountLeaves(tree.Root)}");
            Actions["Node 1 Con"] = () => ketQua($"Số node 1 con: {CountOneChild(tree.Root)}");
            Actions["Node 2 Con"] = () => ketQua($"Số node 2 con: {CountTwoChild(tree.Root)}");
        }

        // Node Min/Max
        private Node NodeMin(Node node, Func<NguoiDung, IComparable> sel)
        {
            if (node == null) return null;
            Node left = NodeMin(node.Left, sel), right = NodeMin(node.Right, sel);
            Node min = node;
            if (left != null && sel(left.Data).CompareTo(sel(min.Data)) < 0) min = left;
            if (right != null && sel(right.Data).CompareTo(sel(min.Data)) < 0) min = right;
            return min;
        }

        private Node NodeMax(Node node, Func<NguoiDung, IComparable> sel)
        {
            if (node == null) return null;
            Node left = NodeMax(node.Left, sel), right = NodeMax(node.Right, sel);
            Node max = node;
            if (left != null && sel(left.Data).CompareTo(sel(max.Data)) > 0) max = left;
            if (right != null && sel(right.Data).CompareTo(sel(max.Data)) > 0) max = right;
            return max;
        }

        // Đếm node
        private int Count(Node node) => node == null ? 0 : 1 + Count(node.Left) + Count(node.Right);
        private int CountLeaves(Node node) => node == null ? 0 : (node.Left == null && node.Right == null ? 1 : CountLeaves(node.Left) + CountLeaves(node.Right));
        private int CountOneChild(Node node) => node == null ? 0 : ((node.Left == null ^ node.Right == null ? 1 : 0) + CountOneChild(node.Left) + CountOneChild(node.Right));
        private int CountTwoChild(Node node) => node == null ? 0 : ((node.Left != null && node.Right != null ? 1 : 0) + CountTwoChild(node.Left) + CountTwoChild(node.Right));

        public void Execute(string actionName)
        {
            if (Actions.ContainsKey(actionName)) Actions[actionName]();
            else MessageBox.Show("Chức năng chưa được định nghĩa!");
        }

        private bool IsNumericType(Type t) => t == typeof(int) || t == typeof(double) || t == typeof(float) || t == typeof(decimal);
    }
}


