using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    internal partial class AVLTree<T> where T : class
    {
        //TỔNG Node
        public double SumField(Func<T, double> selector) => SumField(Root, selector);
        private double SumField(AVLTreeNode<T> node, Func<T, double> selector)
            => node == null ? 0 : selector(node.Data) + SumField(node.Left as AVLTreeNode<T>, selector) + SumField(node.Right as AVLTreeNode<T>, selector);
        //ĐẾM node   
        public int Count() => CountNodes(Root);
        private int CountNodes(AVLTreeNode<T> node)
            => node == null ? 0 : 1 + CountNodes(node.Left as AVLTreeNode<T>) + CountNodes(node.Right as AVLTreeNode<T>);
        //ĐẾM node lá
        public int CountLeaves() => CountLeaves(Root);
        private int CountLeaves(AVLTreeNode<T> node)
            => node == null ? 0 :  (node.Left == null && node.Right == null ? 1 : CountLeaves(node.Left as AVLTreeNode<T>) + CountLeaves(node.Right as AVLTreeNode<T>));
        //ĐẾM node 1 con
        public int CountOneChild() => CountOneChild(Root);
        private int CountOneChild(AVLTreeNode<T> node)
            => node == null ? 0 : ((node.Left == null ^ node.Right == null) ? 1 : 0) + CountOneChild(node.Left as AVLTreeNode<T>) + CountOneChild(node.Right as AVLTreeNode<T>);
        //ĐẾM node 2 con 
        public int CountTwoChild() => CountTwoChild(Root);
        private int CountTwoChild(AVLTreeNode<T> node)
            => node == null ? 0 :
               ((node.Left != null && node.Right != null) ? 1 : 0) + CountTwoChild(node.Left as AVLTreeNode<T>) + CountTwoChild(node.Right as AVLTreeNode<T>);

        // ===========================
        //         MIN / MAX
        // ===========================
        public T MinBy(Func<T, IComparable> selector) => NodeMin(Root, selector)?.Data; 
        public T MaxBy(Func<T, IComparable> selector) => NodeMax(Root, selector)?.Data;

        private AVLTreeNode<T> NodeMin(AVLTreeNode<T> node, Func<T, IComparable> sel) //Hàm tìm giá trị node nhỏ nhất 
        {
            if (node == null) return null;
            AVLTreeNode<T> minNode = node;
            var leftMin = NodeMin(node.Left as AVLTreeNode<T>, sel);
            var rightMin = NodeMin(node.Right as AVLTreeNode<T>, sel);
            if (leftMin != null && sel(leftMin.Data).CompareTo(sel(minNode.Data)) < 0)
                minNode = leftMin;
            if (rightMin != null && sel(rightMin.Data).CompareTo(sel(minNode.Data)) < 0)
                minNode = rightMin;
            return minNode;
        }

        private AVLTreeNode<T> NodeMax(AVLTreeNode<T> node, Func<T, IComparable> sel) //Hàm tìm giá trị node lớn nhất
        {
            if (node == null) return null;
            AVLTreeNode<T> maxNode = node;
            var leftMax = NodeMax(node.Left as AVLTreeNode<T>, sel);
            var rightMax = NodeMax(node.Right as AVLTreeNode<T>, sel);
            if (leftMax != null && sel(leftMax.Data).CompareTo(sel(maxNode.Data)) > 0)
                maxNode = leftMax;
            if (rightMax != null && sel(rightMax.Data).CompareTo(sel(maxNode.Data)) > 0)
                maxNode = rightMax;
            return maxNode;
        }

        // ===========================
        //        HEIGHT & LEVEL
        // ===========================
        public int Height() => TreeHeight(Root);
        private int TreeHeight(AVLTreeNode<T> node) //Hàm tính chiều cao cây
            => node == null ? 0 : 1 + Math.Max(TreeHeight(node.Left as AVLTreeNode<T>),TreeHeight(node.Right as AVLTreeNode<T>));
        public List<T> GetNodesAtLevel(int k) //Trả về danh sách các node có ở tầng k
        {
            var list = new List<T>();
            TraverseLevel(Root, 0, k, list);
            return list;
        }
        private void TraverseLevel(AVLTreeNode<T> node, int depth, int k, List<T> list) //Hàm tìm tầng k
        {
            if (node == null) return;
            if (depth == k)
            {
                list.Add(node.Data);
                return;
            }
            TraverseLevel(node.Left as AVLTreeNode<T>, depth + 1, k, list);
            TraverseLevel(node.Right as AVLTreeNode<T>, depth + 1, k, list);
        }

        public int CountAtLevel(int k) => GetNodesAtLevel(k).Count; //Hàm đếm node có ở tầng

        //        SUBTREE
        public AVLTreeNode<T> GetSubTree(int k, string direction)
        {
            return GetSubTree(Root, 0, k, direction);
        }

        private AVLTreeNode<T> GetSubTree(AVLTreeNode<T> node, int current, int k, string direction) //Lấy node ở tầng k
        {
            if (node == null) return null;
            if (current == k)
            {
                if (direction == "left") return node.Left as AVLTreeNode<T>;
                if (direction == "right") return node.Right as AVLTreeNode<T>;
                return node;
            }

            var left = GetSubTree(node.Left as AVLTreeNode<T>, current + 1, k, direction);
            if (left != null) return left;

            return GetSubTree(node.Right as AVLTreeNode<T>, current + 1, k, direction);
        }

        // ===========================
        //          IO
        // ===========================
        public void SaveToBinary(string path) //Lưu file nhị phân
        {
            using (var bw = new BinaryWriter(File.Open(path, FileMode.Create)))
                SaveToBinaryRecursive(Root, bw);
        }
        private void SaveToBinaryRecursive(AVLTreeNode<T> node, BinaryWriter bw) //Hàm lưu file nhị phân
        {
            if (node == null) return;
            SaveToBinaryRecursive(node.Left as AVLTreeNode<T>, bw);
            if (node.Data is NguoiDung nd) //Lưu các thuộc tính vào
            {
                bw.Write(nd.Name);
                bw.Write(nd.Age);
                bw.Write(nd.Gender);
                bw.Write(nd.ThoiGianDungMXH);
                bw.Write(nd.ChatLuongGiacNgu);
                bw.Write(nd.MucDoStress);
                bw.Write(nd.ThoiGianKhongMXH);
                bw.Write(nd.TanSuatTapLuyen);
                bw.Write(nd.AppSuDung);
                bw.Write(nd.MucDoHanhPhuc);
            }
            SaveToBinaryRecursive(node.Right as AVLTreeNode<T>, bw); //Gọi để quy để thực hiện lưu
        }
        public void SaveToText(string path) //Lưu file txt
        {
            using (var sw = new StreamWriter(path))
                SaveToTextRecursive(Root, sw);
        }
        private void SaveToTextRecursive(AVLTreeNode<T> node, StreamWriter sw) //Hàm lưu thành file txt, nội dung trong file
        {
            if (node == null) return;
            SaveToTextRecursive(node.Left as AVLTreeNode<T>, sw);
            if (node.Data is NguoiDung nd)
                sw.WriteLine($"{nd.Name},{nd.Age},{nd.Gender},{nd.ThoiGianDungMXH},{nd.ChatLuongGiacNgu},{nd.MucDoStress},{nd.ThoiGianKhongMXH},{nd.TanSuatTapLuyen},{nd.AppSuDung},{nd.MucDoHanhPhuc}");
            SaveToTextRecursive(node.Right as AVLTreeNode<T>, sw);
        }
        public class TreeStats
        {
            public int TotalNodes { get; set; }
            public int Height { get; set; }
            public int LeftCount { get; set; }
            public int RightCount { get; set; }
            public string BalanceState { get; set; }
            public int NodeTrung { get; set; }
            public string GiaTriTrungNhieuNhat { get; set; }
            public int MostDuplicatedCount { get; set; }
        }
        public Dictionary<object, int> DuplicationStats = new Dictionary<object, int>();
        public DuplicationList DupList = new DuplicationList();
        public TreeStats GetStats()
        {
            if (Root == null)
                return new TreeStats { BalanceState = "Cây rỗng" };

            int leftCount = CountNodes(Root.Left as AVLTreeNode<T>);
            int rightCount = CountNodes(Root.Right as AVLTreeNode<T>);
            int height = TreeHeight(Root);
            int balance = leftCount - rightCount;

            string state = balance > 1 ? "Lệch trái"
                        : balance < -1 ? "Lệch phải"
                        : "Cân bằng";

            // NEW: Tìm giá trị trùng nhiều nhất
            string mostValue = "";
            int maxCount = 0;
            if (DuplicationStats != null)
            {
                foreach (var kv in DuplicationStats)
                {
                    if (kv.Value > maxCount)
                    {
                        maxCount = kv.Value;
                        mostValue = kv.Key?.ToString();
                    }
                }
            }
            return new TreeStats
            {
                TotalNodes = CountNodes(Root),
                Height = height,
                LeftCount = leftCount,
                RightCount = rightCount,
                BalanceState = state,
                NodeTrung = DupList.Count,
                GiaTriTrungNhieuNhat = mostValue,
                MostDuplicatedCount = maxCount
            };
        }

    }
}