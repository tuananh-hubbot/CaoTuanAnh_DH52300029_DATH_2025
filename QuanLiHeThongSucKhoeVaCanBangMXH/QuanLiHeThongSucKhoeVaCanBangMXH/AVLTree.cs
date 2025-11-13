<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    internal class AVLTree
    {
        public Node Root { get; private set; }
        private Func<NguoiDung,IComparable> keySelector;
        
        public AVLTree() : this(NguoiDung => NguoiDung.Name) { }
        public AVLTree(Func<NguoiDung, IComparable> keySelector)
        {
            this.keySelector = keySelector;
            Root = null;
            
        }
        private int height(Node node)
        {
            return node == null ? 0 : node.height;
        }

        private int GetBalance(Node node)
        {
            return node == null ? 0 : height(node.Left) - height(node.Right);

        }

        private int Compare(NguoiDung a, NguoiDung b)
        {
            var keyA = keySelector(a);
            var keyB = keySelector(b);
            if (keyA == null && keyB == null) return 0;
            if (keyA == null) return -1;
            if(keyB == null) return 1;
            return keyA.CompareTo(keyB);
        }
        private Node RotateLeft(Node x)
        {
            Node y = x.Right;
            Node T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.height = 1 + Math.Max(height(x.Left), height(x.Right));
            y.height = 1 + Math.Max(height(y.Left), height(y.Right));

            return y;
        }
        private Node RotateRight(Node y)
        {
            Node x = y.Left;
            Node T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.height = 1 + Math.Max(height(y.Left), height(y.Right));
            x.height = 1 + Math.Max(height(x.Left), height(x.Right));
            return x;
        }
        public Node Insert(Node node, NguoiDung data)
        {
            if (node == null)
                return new Node(data);

            int cmp = Compare(data, node.Data);
            if (cmp < 0)
                node.Left = Insert(node.Left, data);
            else if (cmp > 0)
                node.Right = Insert(node.Right, data);
            else
                return node;

            node.height = 1 + Math.Max(height(node.Left), height(node.Right));
            int balance = GetBalance(node);
            //Trái Trái
            if (balance > 1 && Compare(data, node.Left.Data) < 0)
                return RotateRight(node);
            //Phải Phải
            if (balance < -1 && Compare(data, node.Right.Data) > 0)
                return RotateLeft(node);
            //Trái Phải
            if (balance > 1 && Compare(data, node.Left.Data) > 0)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }
            //Phải Trái
            if (balance < -1 && Compare(data, node.Right.Data) < 0)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }
            return node;
            node.count = 1 + (node.Left?.count ?? 0) + (node.Right?.count ?? 0);
        }
        public NguoiDung Search(Node node, string name)
        {
            if (node == null)
                return null;
            if (string.Equals(name, node.Data.Name, StringComparison.OrdinalIgnoreCase))
                return node.Data;
            if (string.Compare(name, node.Data.Name, StringComparison.OrdinalIgnoreCase) < 0)
                return Search(node.Left, name);
            else
                return Search(node.Right, name);
        }
        public void InOrder(Node node, List<NguoiDung> list)
        {
            if (node != null)
            {
                InOrder(node.Left, list);
                list.Add(node.Data);
                InOrder(node.Right, list);
            }
        }
        public void Insert(NguoiDung data)
        {
            Root = Insert(Root, data);
        }
        
        private Node MinValueNode(Node node)
        {
            Node current = node;
            while (current.Left != null)
                current = current.Left;
            return current;
        }

        public Node Delete(Node node, NguoiDung data)
        {
            if (node == null) return node;

            int cmp = Compare(data, node.Data);
            if (cmp < 0)
                node.Left = Delete(node.Left, data);
            else if (cmp > 0)
                node.Right = Delete(node.Right, data);
            else
            {
                // Node có 1 hoặc 0 con
                if (node.Left == null || node.Right == null)
                {
                    Node temp = node.Left ?? node.Right;
                    node = temp; // Có thể null nếu là lá
                }
                else
                {
                    // Node có 2 con → lấy Node nhỏ nhất bên phải
                    Node temp = MinValueNode(node.Right);
                    node.Data = temp.Data;
                    node.Right = Delete(node.Right, temp.Data);
                }
            }

            if (node == null) return node;

            node.height = 1 + Math.Max(height(node.Left), height(node.Right));

            int balance = GetBalance(node);

            // Cân bằng lại (4 trường hợp)
            if (balance > 1 && GetBalance(node.Left) >= 0)
                return RotateRight(node);

            if (balance > 1 && GetBalance(node.Left) < 0)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            if (balance < -1 && GetBalance(node.Right) <= 0)
                return RotateLeft(node);

            if (balance < -1 && GetBalance(node.Right) > 0)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        public void Remove(NguoiDung data)
        {
            Root = Delete(Root, data);
        }


        private void SaveToBinaryRecursive(Node node, BinaryWriter bw)
        {
            if (node == null) return;

            // Ghi cây theo thứ tự LNR
            SaveToBinaryRecursive(node.Left, bw);

            // Ghi dữ liệu người dùng ra file nhị phân
            bw.Write(node.Data.Name);
            bw.Write(node.Data.Age);
            bw.Write(node.Data.Gender);
            bw.Write(node.Data.ThoiGianDungMXH);
            bw.Write(node.Data.ChatLuongGiacNgu);
            bw.Write(node.Data.MucDoStress);
            bw.Write(node.Data.ThoiGianKhongMXH);
            bw.Write(node.Data.TanSuatTapLuyen);
            bw.Write(node.Data.AppSuDung);
            bw.Write(node.Data.MucDoHanhPhuc);

            SaveToBinaryRecursive(node.Right, bw);
        }
        private void SaveToTextRecursive(Node node, StreamWriter sw)
        {
            if (node == null) return;

            // Duyệt trái - gốc - phải
            SaveToTextRecursive(node.Left, sw);

            // Ghi dữ liệu người dùng ra file (CSV dạng text)
            sw.WriteLine($"{node.Data.Name}," +
                         $"{node.Data.Age}," +
                         $"{node.Data.Gender}," +
                         $"{node.Data.ThoiGianDungMXH}," +
                         $"{node.Data.ChatLuongGiacNgu}," +
                         $"{node.Data.MucDoStress}," +
                         $"{node.Data.ThoiGianKhongMXH}," +
                         $"{node.Data.TanSuatTapLuyen}," +
                         $"{node.Data.AppSuDung}," +
                         $"{node.Data.MucDoHanhPhuc},");

            SaveToTextRecursive(node.Right, sw);
        }


        public void SaveToBinary(Node node, string path)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                SaveToBinaryRecursive(node, bw);
            }
        }
        public void SaveToText(Node node, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                SaveToTextRecursive(node, sw);
            }
        }
        public class TreeStats
        {
            public int TotalNodes { get; set; }
            public int Height { get; set; }
            public int LeftCount { get; set; }
            public int RightCount { get; set; }
            public string BalanceState { get; set; }
        }

        public TreeStats GetStats()
        {
            if (Root == null) return new TreeStats
            { TotalNodes = 0,
              Height = 0,
              LeftCount = 0,
              RightCount = 0,
              BalanceState = "Cây rỗng"};

            int leftCount = CountNodes(Root.Left);
            int rightCount = CountNodes(Root.Right);
            int height = GetHeight(Root);
            int balance = leftCount - rightCount;

            string state;
            if (balance > 1)
                state = "Lệch trái";
            else if (balance < -1)
                state = "Lệch phải";
            else
                state = "Cân bằng";
            return new TreeStats
            {
                TotalNodes = CountNodes(Root),
                Height = height,
                LeftCount = leftCount,
                RightCount = rightCount,
                BalanceState = state
            };

        }
        //Đếm tổng nút có trên cây
        private int CountNodes ( Node node ) 
        {
            if(node == null ) return 0;
            return 1 + CountNodes(node.Left) + CountNodes(node.Right);
        }
        //Đếm tổng nút lá có trên cây
        private int CountNodesLeaves(Node node )
        {
            if(node == null) return 0;
            if (node.Left == null && node.Right == null) return 1;
            return CountNodesLeaves(node.Left)+ CountNodesLeaves(node.Right);
        }
        private int GetHeight(Node node)
        {
            if(node == null) return 0;
            return 1+ Math.Max(GetHeight(node.Right),GetHeight(node.Left));
        }



        //Lấy cây con tại tầng k và hướng (left/right)
        public Node GetSubTree(Node node, int k, int current, string direction)
        {
            if (node == null) return null;
            if (current == k)
            {
                if (direction == "left") return node.Left;
                if (direction == "right") return node.Right;
                return node;
=======
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    internal class AVLTree
    {
        public Node Root { get; private set; }
        private Func<NguoiDung,IComparable> keySelector;
        
        public AVLTree() : this(NguoiDung => NguoiDung.Name) { }
        public AVLTree(Func<NguoiDung, IComparable> keySelector)
        {
            this.keySelector = keySelector;
            Root = null;
            
        }
        private int height(Node node)
        {
            return node == null ? 0 : node.height;
        }

        private int GetBalance(Node node)
        {
            return node == null ? 0 : height(node.Left) - height(node.Right);

        }

        private int Compare(NguoiDung a, NguoiDung b)
        {
            var keyA = keySelector(a);
            var keyB = keySelector(b);
            if (keyA == null && keyB == null) return 0;
            if (keyA == null) return -1;
            if(keyB == null) return 1;
            return keyA.CompareTo(keyB);
        }
        private Node RotateLeft(Node x)
        {
            Node y = x.Right;
            Node T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.height = 1 + Math.Max(height(x.Left), height(x.Right));
            y.height = 1 + Math.Max(height(y.Left), height(y.Right));

            return y;
        }
        private Node RotateRight(Node y)
        {
            Node x = y.Left;
            Node T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.height = 1 + Math.Max(height(y.Left), height(y.Right));
            x.height = 1 + Math.Max(height(x.Left), height(x.Right));
            return x;
        }
        public Node Insert(Node node, NguoiDung data)
        {
            if (node == null)
                return new Node(data);

            int cmp = Compare(data, node.Data);
            if (cmp < 0)
                node.Left = Insert(node.Left, data);
            else if (cmp > 0)
                node.Right = Insert(node.Right, data);
            else
                return node;

            node.height = 1 + Math.Max(height(node.Left), height(node.Right));
            int balance = GetBalance(node);
            //Trái Trái
            if (balance > 1 && Compare(data, node.Left.Data) < 0)
                return RotateRight(node);
            //Phải Phải
            if (balance < -1 && Compare(data, node.Right.Data) > 0)
                return RotateLeft(node);
            //Trái Phải
            if (balance > 1 && Compare(data, node.Left.Data) > 0)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }
            //Phải Trái
            if (balance < -1 && Compare(data, node.Right.Data) < 0)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }
            return node;
            node.count = 1 + (node.Left?.count ?? 0) + (node.Right?.count ?? 0);
        }
        public NguoiDung Search(Node node, string name)
        {
            if (node == null)
                return null;
            if (string.Equals(name, node.Data.Name, StringComparison.OrdinalIgnoreCase))
                return node.Data;
            if (string.Compare(name, node.Data.Name, StringComparison.OrdinalIgnoreCase) < 0)
                return Search(node.Left, name);
            else
                return Search(node.Right, name);
        }
        public void InOrder(Node node, List<NguoiDung> list)
        {
            if (node != null)
            {
                InOrder(node.Left, list);
                list.Add(node.Data);
                InOrder(node.Right, list);
            }
        }
        public void Insert(NguoiDung data)
        {
            Root = Insert(Root, data);
        }
        
        private Node MinValueNode(Node node)
        {
            Node current = node;
            while (current.Left != null)
                current = current.Left;
            return current;
        }

        public Node Delete(Node node, NguoiDung data)
        {
            if (node == null) return node;

            int cmp = Compare(data, node.Data);
            if (cmp < 0)
                node.Left = Delete(node.Left, data);
            else if (cmp > 0)
                node.Right = Delete(node.Right, data);
            else
            {
                // Node có 1 hoặc 0 con
                if (node.Left == null || node.Right == null)
                {
                    Node temp = node.Left ?? node.Right;
                    node = temp; // Có thể null nếu là lá
                }
                else
                {
                    // Node có 2 con → lấy Node nhỏ nhất bên phải
                    Node temp = MinValueNode(node.Right);
                    node.Data = temp.Data;
                    node.Right = Delete(node.Right, temp.Data);
                }
            }

            if (node == null) return node;

            node.height = 1 + Math.Max(height(node.Left), height(node.Right));

            int balance = GetBalance(node);

            // Cân bằng lại (4 trường hợp)
            if (balance > 1 && GetBalance(node.Left) >= 0)
                return RotateRight(node);

            if (balance > 1 && GetBalance(node.Left) < 0)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            if (balance < -1 && GetBalance(node.Right) <= 0)
                return RotateLeft(node);

            if (balance < -1 && GetBalance(node.Right) > 0)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        public void Remove(NguoiDung data)
        {
            Root = Delete(Root, data);
        }


        private void SaveToBinaryRecursive(Node node, BinaryWriter bw)
        {
            if (node == null) return;

            // Ghi cây theo thứ tự LNR
            SaveToBinaryRecursive(node.Left, bw);

            // Ghi dữ liệu người dùng ra file nhị phân
            bw.Write(node.Data.Name);
            bw.Write(node.Data.Age);
            bw.Write(node.Data.Gender);
            bw.Write(node.Data.ThoiGianDungMXH);
            bw.Write(node.Data.ChatLuongGiacNgu);
            bw.Write(node.Data.MucDoStress);
            bw.Write(node.Data.ThoiGianKhongMXH);
            bw.Write(node.Data.TanSuatTapLuyen);
            bw.Write(node.Data.AppSuDung);
            bw.Write(node.Data.MucDoHanhPhuc);

            SaveToBinaryRecursive(node.Right, bw);
        }
        private void SaveToTextRecursive(Node node, StreamWriter sw)
        {
            if (node == null) return;

            // Duyệt trái - gốc - phải
            SaveToTextRecursive(node.Left, sw);

            // Ghi dữ liệu người dùng ra file (CSV dạng text)
            sw.WriteLine($"{node.Data.Name}," +
                         $"{node.Data.Age}," +
                         $"{node.Data.Gender}," +
                         $"{node.Data.ThoiGianDungMXH}," +
                         $"{node.Data.ChatLuongGiacNgu}," +
                         $"{node.Data.MucDoStress}," +
                         $"{node.Data.ThoiGianKhongMXH}," +
                         $"{node.Data.TanSuatTapLuyen}," +
                         $"{node.Data.AppSuDung}," +
                         $"{node.Data.MucDoHanhPhuc},");

            SaveToTextRecursive(node.Right, sw);
        }


        public void SaveToBinary(Node node, string path)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                SaveToBinaryRecursive(node, bw);
            }
        }
        public void SaveToText(Node node, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                SaveToTextRecursive(node, sw);
            }
        }
        public class TreeStats
        {
            public int TotalNodes { get; set; }
            public int Height { get; set; }
            public int LeftCount { get; set; }
            public int RightCount { get; set; }
            public string BalanceState { get; set; }
        }

        public TreeStats GetStats()
        {
            if (Root == null) return new TreeStats
            { TotalNodes = 0,
              Height = 0,
              LeftCount = 0,
              RightCount = 0,
              BalanceState = "Cây rỗng"};

            int leftCount = CountNodes(Root.Left);
            int rightCount = CountNodes(Root.Right);
            int height = GetHeight(Root);
            int balance = leftCount - rightCount;

            string state;
            if (balance > 1)
                state = "Lệch trái";
            else if (balance < -1)
                state = "Lệch phải";
            else
                state = "Cân bằng";
            return new TreeStats
            {
                TotalNodes = CountNodes(Root),
                Height = height,
                LeftCount = leftCount,
                RightCount = rightCount,
                BalanceState = state
            };

        }
        //Đếm tổng nút có trên cây
        private int CountNodes ( Node node ) 
        {
            if(node == null ) return 0;
            return 1 + CountNodes(node.Left) + CountNodes(node.Right);
        }
        //Đếm tổng nút lá có trên cây
        private int CountNodesLeaves(Node node )
        {
            if(node == null) return 0;
            if (node.Left == null && node.Right == null) return 1;
            return CountNodesLeaves(node.Left)+ CountNodesLeaves(node.Right);
        }
        private int GetHeight(Node node)
        {
            if(node == null) return 0;
            return 1+ Math.Max(GetHeight(node.Right),GetHeight(node.Left));
        }



        //Lấy cây con tại tầng k và hướng (left/right)
        public Node GetSubTree(Node node, int k, int current, string direction)
        {
            if (node == null) return null;
            if (current == k)
            {
                if (direction == "left") return node.Left;
                if (direction == "right") return node.Right;
                return node;
>>>>>>> 2514022022a8e65ca2db7b469a3bbd8106c1b849
=======
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    internal class AVLTree
    {
        public Node Root { get; private set; }
        private Func<NguoiDung,IComparable> keySelector;
        
        public AVLTree() : this(NguoiDung => NguoiDung.Name) { }
        public AVLTree(Func<NguoiDung, IComparable> keySelector)
        {
            this.keySelector = keySelector;
            Root = null;
            
        }
        private int height(Node node)
        {
            return node == null ? 0 : node.height;
        }

        private int GetBalance(Node node)
        {
            return node == null ? 0 : height(node.Left) - height(node.Right);

        }

        private int Compare(NguoiDung a, NguoiDung b)
        {
            var keyA = keySelector(a);
            var keyB = keySelector(b);
            if (keyA == null && keyB == null) return 0;
            if (keyA == null) return -1;
            if(keyB == null) return 1;
            return keyA.CompareTo(keyB);
        }
        private Node RotateLeft(Node x)
        {
            Node y = x.Right;
            Node T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.height = 1 + Math.Max(height(x.Left), height(x.Right));
            y.height = 1 + Math.Max(height(y.Left), height(y.Right));

            return y;
        }
        private Node RotateRight(Node y)
        {
            Node x = y.Left;
            Node T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.height = 1 + Math.Max(height(y.Left), height(y.Right));
            x.height = 1 + Math.Max(height(x.Left), height(x.Right));
            return x;
        }
        public Node Insert(Node node, NguoiDung data)
        {
            if (node == null)
                return new Node(data);

            int cmp = Compare(data, node.Data);
            if (cmp < 0)
                node.Left = Insert(node.Left, data);
            else if (cmp > 0)
                node.Right = Insert(node.Right, data);
            else
                return node;

            node.height = 1 + Math.Max(height(node.Left), height(node.Right));
            int balance = GetBalance(node);
            //Trái Trái
            if (balance > 1 && Compare(data, node.Left.Data) < 0)
                return RotateRight(node);
            //Phải Phải
            if (balance < -1 && Compare(data, node.Right.Data) > 0)
                return RotateLeft(node);
            //Trái Phải
            if (balance > 1 && Compare(data, node.Left.Data) > 0)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }
            //Phải Trái
            if (balance < -1 && Compare(data, node.Right.Data) < 0)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }
            return node;
            node.count = 1 + (node.Left?.count ?? 0) + (node.Right?.count ?? 0);
        }
        public NguoiDung Search(Node node, string name)
        {
            if (node == null)
                return null;
            if (string.Equals(name, node.Data.Name, StringComparison.OrdinalIgnoreCase))
                return node.Data;
            if (string.Compare(name, node.Data.Name, StringComparison.OrdinalIgnoreCase) < 0)
                return Search(node.Left, name);
            else
                return Search(node.Right, name);
        }
        public void InOrder(Node node, List<NguoiDung> list)
        {
            if (node != null)
            {
                InOrder(node.Left, list);
                list.Add(node.Data);
                InOrder(node.Right, list);
            }
        }
        public void Insert(NguoiDung data)
        {
            Root = Insert(Root, data);
        }
        
        private Node MinValueNode(Node node)
        {
            Node current = node;
            while (current.Left != null)
                current = current.Left;
            return current;
        }

        public Node Delete(Node node, NguoiDung data)
        {
            if (node == null) return node;

            int cmp = Compare(data, node.Data);
            if (cmp < 0)
                node.Left = Delete(node.Left, data);
            else if (cmp > 0)
                node.Right = Delete(node.Right, data);
            else
            {
                // Node có 1 hoặc 0 con
                if (node.Left == null || node.Right == null)
                {
                    Node temp = node.Left ?? node.Right;
                    node = temp; // Có thể null nếu là lá
                }
                else
                {
                    // Node có 2 con → lấy Node nhỏ nhất bên phải
                    Node temp = MinValueNode(node.Right);
                    node.Data = temp.Data;
                    node.Right = Delete(node.Right, temp.Data);
                }
            }

            if (node == null) return node;

            node.height = 1 + Math.Max(height(node.Left), height(node.Right));

            int balance = GetBalance(node);

            // Cân bằng lại (4 trường hợp)
            if (balance > 1 && GetBalance(node.Left) >= 0)
                return RotateRight(node);

            if (balance > 1 && GetBalance(node.Left) < 0)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            if (balance < -1 && GetBalance(node.Right) <= 0)
                return RotateLeft(node);

            if (balance < -1 && GetBalance(node.Right) > 0)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        public void Remove(NguoiDung data)
        {
            Root = Delete(Root, data);
        }


        private void SaveToBinaryRecursive(Node node, BinaryWriter bw)
        {
            if (node == null) return;

            // Ghi cây theo thứ tự LNR
            SaveToBinaryRecursive(node.Left, bw);

            // Ghi dữ liệu người dùng ra file nhị phân
            bw.Write(node.Data.Name);
            bw.Write(node.Data.Age);
            bw.Write(node.Data.Gender);
            bw.Write(node.Data.ThoiGianDungMXH);
            bw.Write(node.Data.ChatLuongGiacNgu);
            bw.Write(node.Data.MucDoStress);
            bw.Write(node.Data.ThoiGianKhongMXH);
            bw.Write(node.Data.TanSuatTapLuyen);
            bw.Write(node.Data.AppSuDung);
            bw.Write(node.Data.MucDoHanhPhuc);

            SaveToBinaryRecursive(node.Right, bw);
        }
        private void SaveToTextRecursive(Node node, StreamWriter sw)
        {
            if (node == null) return;

            // Duyệt trái - gốc - phải
            SaveToTextRecursive(node.Left, sw);

            // Ghi dữ liệu người dùng ra file (CSV dạng text)
            sw.WriteLine($"{node.Data.Name}," +
                         $"{node.Data.Age}," +
                         $"{node.Data.Gender}," +
                         $"{node.Data.ThoiGianDungMXH}," +
                         $"{node.Data.ChatLuongGiacNgu}," +
                         $"{node.Data.MucDoStress}," +
                         $"{node.Data.ThoiGianKhongMXH}," +
                         $"{node.Data.TanSuatTapLuyen}," +
                         $"{node.Data.AppSuDung}," +
                         $"{node.Data.MucDoHanhPhuc},");

            SaveToTextRecursive(node.Right, sw);
        }


        public void SaveToBinary(Node node, string path)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                SaveToBinaryRecursive(node, bw);
            }
        }
        public void SaveToText(Node node, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                SaveToTextRecursive(node, sw);
            }
        }
        public class TreeStats
        {
            public int TotalNodes { get; set; }
            public int Height { get; set; }
            public int LeftCount { get; set; }
            public int RightCount { get; set; }
            public string BalanceState { get; set; }
        }

        public TreeStats GetStats()
        {
            if (Root == null) return new TreeStats
            { TotalNodes = 0,
              Height = 0,
              LeftCount = 0,
              RightCount = 0,
              BalanceState = "Cây rỗng"};

            int leftCount = CountNodes(Root.Left);
            int rightCount = CountNodes(Root.Right);
            int height = GetHeight(Root);
            int balance = leftCount - rightCount;

            string state;
            if (balance > 1)
                state = "Lệch trái";
            else if (balance < -1)
                state = "Lệch phải";
            else
                state = "Cân bằng";
            return new TreeStats
            {
                TotalNodes = CountNodes(Root),
                Height = height,
                LeftCount = leftCount,
                RightCount = rightCount,
                BalanceState = state
            };

        }
        //Đếm tổng nút có trên cây
        private int CountNodes ( Node node ) 
        {
            if(node == null ) return 0;
            return 1 + CountNodes(node.Left) + CountNodes(node.Right);
        }
        //Đếm tổng nút lá có trên cây
        private int CountNodesLeaves(Node node )
        {
            if(node == null) return 0;
            if (node.Left == null && node.Right == null) return 1;
            return CountNodesLeaves(node.Left)+ CountNodesLeaves(node.Right);
        }
        private int GetHeight(Node node)
        {
            if(node == null) return 0;
            return 1+ Math.Max(GetHeight(node.Right),GetHeight(node.Left));
        }



        //Lấy cây con tại tầng k và hướng (left/right)
        public Node GetSubTree(Node node, int k, int current, string direction)
        {
            if (node == null) return null;
            if (current == k)
            {
                if (direction == "left") return node.Left;
                if (direction == "right") return node.Right;
                return node;
>>>>>>> 2514022022a8e65ca2db7b469a3bbd8106c1b849
=======
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    internal class AVLTree
    {
        public Node Root { get; private set; }
        private Func<NguoiDung,IComparable> keySelector;
        
        public AVLTree() : this(NguoiDung => NguoiDung.Name) { }
        public AVLTree(Func<NguoiDung, IComparable> keySelector)
        {
            this.keySelector = keySelector;
            Root = null;
            
        }
        private int height(Node node)
        {
            return node == null ? 0 : node.height;
        }

        private int GetBalance(Node node)
        {
            return node == null ? 0 : height(node.Left) - height(node.Right);

        }

        private int Compare(NguoiDung a, NguoiDung b)
        {
            var keyA = keySelector(a);
            var keyB = keySelector(b);
            if (keyA == null && keyB == null) return 0;
            if (keyA == null) return -1;
            if(keyB == null) return 1;
            return keyA.CompareTo(keyB);
        }
        private Node RotateLeft(Node x)
        {
            Node y = x.Right;
            Node T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.height = 1 + Math.Max(height(x.Left), height(x.Right));
            y.height = 1 + Math.Max(height(y.Left), height(y.Right));

            return y;
        }
        private Node RotateRight(Node y)
        {
            Node x = y.Left;
            Node T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.height = 1 + Math.Max(height(y.Left), height(y.Right));
            x.height = 1 + Math.Max(height(x.Left), height(x.Right));
            return x;
        }
        public Node Insert(Node node, NguoiDung data)
        {
            if (node == null)
                return new Node(data);

            int cmp = Compare(data, node.Data);
            if (cmp < 0)
                node.Left = Insert(node.Left, data);
            else if (cmp > 0)
                node.Right = Insert(node.Right, data);
            else
                return node;

            node.height = 1 + Math.Max(height(node.Left), height(node.Right));
            int balance = GetBalance(node);
            //Trái Trái
            if (balance > 1 && Compare(data, node.Left.Data) < 0)
                return RotateRight(node);
            //Phải Phải
            if (balance < -1 && Compare(data, node.Right.Data) > 0)
                return RotateLeft(node);
            //Trái Phải
            if (balance > 1 && Compare(data, node.Left.Data) > 0)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }
            //Phải Trái
            if (balance < -1 && Compare(data, node.Right.Data) < 0)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }
            return node;
            node.count = 1 + (node.Left?.count ?? 0) + (node.Right?.count ?? 0);
        }
        public NguoiDung Search(Node node, string name)
        {
            if (node == null)
                return null;
            if (string.Equals(name, node.Data.Name, StringComparison.OrdinalIgnoreCase))
                return node.Data;
            if (string.Compare(name, node.Data.Name, StringComparison.OrdinalIgnoreCase) < 0)
                return Search(node.Left, name);
            else
                return Search(node.Right, name);
        }
        public void InOrder(Node node, List<NguoiDung> list)
        {
            if (node != null)
            {
                InOrder(node.Left, list);
                list.Add(node.Data);
                InOrder(node.Right, list);
            }
        }
        public void Insert(NguoiDung data)
        {
            Root = Insert(Root, data);
        }
        
        private Node MinValueNode(Node node)
        {
            Node current = node;
            while (current.Left != null)
                current = current.Left;
            return current;
        }

        public Node Delete(Node node, NguoiDung data)
        {
            if (node == null) return node;

            int cmp = Compare(data, node.Data);
            if (cmp < 0)
                node.Left = Delete(node.Left, data);
            else if (cmp > 0)
                node.Right = Delete(node.Right, data);
            else
            {
                // Node có 1 hoặc 0 con
                if (node.Left == null || node.Right == null)
                {
                    Node temp = node.Left ?? node.Right;
                    node = temp; // Có thể null nếu là lá
                }
                else
                {
                    // Node có 2 con → lấy Node nhỏ nhất bên phải
                    Node temp = MinValueNode(node.Right);
                    node.Data = temp.Data;
                    node.Right = Delete(node.Right, temp.Data);
                }
            }

            if (node == null) return node;

            node.height = 1 + Math.Max(height(node.Left), height(node.Right));

            int balance = GetBalance(node);

            // Cân bằng lại (4 trường hợp)
            if (balance > 1 && GetBalance(node.Left) >= 0)
                return RotateRight(node);

            if (balance > 1 && GetBalance(node.Left) < 0)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            if (balance < -1 && GetBalance(node.Right) <= 0)
                return RotateLeft(node);

            if (balance < -1 && GetBalance(node.Right) > 0)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        public void Remove(NguoiDung data)
        {
            Root = Delete(Root, data);
        }


        private void SaveToBinaryRecursive(Node node, BinaryWriter bw)
        {
            if (node == null) return;

            // Ghi cây theo thứ tự LNR
            SaveToBinaryRecursive(node.Left, bw);

            // Ghi dữ liệu người dùng ra file nhị phân
            bw.Write(node.Data.Name);
            bw.Write(node.Data.Age);
            bw.Write(node.Data.Gender);
            bw.Write(node.Data.ThoiGianDungMXH);
            bw.Write(node.Data.ChatLuongGiacNgu);
            bw.Write(node.Data.MucDoStress);
            bw.Write(node.Data.ThoiGianKhongMXH);
            bw.Write(node.Data.TanSuatTapLuyen);
            bw.Write(node.Data.AppSuDung);
            bw.Write(node.Data.MucDoHanhPhuc);

            SaveToBinaryRecursive(node.Right, bw);
        }
        private void SaveToTextRecursive(Node node, StreamWriter sw)
        {
            if (node == null) return;

            // Duyệt trái - gốc - phải
            SaveToTextRecursive(node.Left, sw);

            // Ghi dữ liệu người dùng ra file (CSV dạng text)
            sw.WriteLine($"{node.Data.Name}," +
                         $"{node.Data.Age}," +
                         $"{node.Data.Gender}," +
                         $"{node.Data.ThoiGianDungMXH}," +
                         $"{node.Data.ChatLuongGiacNgu}," +
                         $"{node.Data.MucDoStress}," +
                         $"{node.Data.ThoiGianKhongMXH}," +
                         $"{node.Data.TanSuatTapLuyen}," +
                         $"{node.Data.AppSuDung}," +
                         $"{node.Data.MucDoHanhPhuc},");

            SaveToTextRecursive(node.Right, sw);
        }


        public void SaveToBinary(Node node, string path)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                SaveToBinaryRecursive(node, bw);
            }
        }
        public void SaveToText(Node node, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                SaveToTextRecursive(node, sw);
            }
        }
        public class TreeStats
        {
            public int TotalNodes { get; set; }
            public int Height { get; set; }
            public int LeftCount { get; set; }
            public int RightCount { get; set; }
            public string BalanceState { get; set; }
        }

        public TreeStats GetStats()
        {
            if (Root == null) return new TreeStats
            { TotalNodes = 0,
              Height = 0,
              LeftCount = 0,
              RightCount = 0,
              BalanceState = "Cây rỗng"};

            int leftCount = CountNodes(Root.Left);
            int rightCount = CountNodes(Root.Right);
            int height = GetHeight(Root);
            int balance = leftCount - rightCount;

            string state;
            if (balance > 1)
                state = "Lệch trái";
            else if (balance < -1)
                state = "Lệch phải";
            else
                state = "Cân bằng";
            return new TreeStats
            {
                TotalNodes = CountNodes(Root),
                Height = height,
                LeftCount = leftCount,
                RightCount = rightCount,
                BalanceState = state
            };

        }
        //Đếm tổng nút có trên cây
        private int CountNodes ( Node node ) 
        {
            if(node == null ) return 0;
            return 1 + CountNodes(node.Left) + CountNodes(node.Right);
        }
        //Đếm tổng nút lá có trên cây
        private int CountNodesLeaves(Node node )
        {
            if(node == null) return 0;
            if (node.Left == null && node.Right == null) return 1;
            return CountNodesLeaves(node.Left)+ CountNodesLeaves(node.Right);
        }
        private int GetHeight(Node node)
        {
            if(node == null) return 0;
            return 1+ Math.Max(GetHeight(node.Right),GetHeight(node.Left));
        }



        //Lấy cây con tại tầng k và hướng (left/right)
        public Node GetSubTree(Node node, int k, int current, string direction)
        {
            if (node == null) return null;
            if (current == k)
            {
                if (direction == "left") return node.Left;
                if (direction == "right") return node.Right;
                return node;
>>>>>>> 2514022022a8e65ca2db7b469a3bbd8106c1b849
            }
            Node left = GetSubTree(node.Left, k, current + 1, direction);
            if (left != null) return left;

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            return GetSubTree(node.Right, k, current + 1, direction);
        }
        
        // Đếm node tầng k
        public int CountK(int k)
        {
            return CountLevel(Root, k);
        }

        private int CountLevel (Node node, int k)
        {
            if (node == null) return 0;
            if (k == 0) return 1;
            return CountLevel(node.Left, k - 1) + CountLevel(node.Right, k - 1);
        }

        //Lấy danh sách node tầng k
        public List<NguoiDung> LayNodeTangK(int k)
        {
            var ketqua = new List<NguoiDung>();
            LayNodeOTangK(Root, k, ketqua);
            return ketqua;
        }
        private void LayNodeOTangK(Node node, int k, List<NguoiDung> ketqua)
        {
            if(node == null) return;
            if(k == 0) ketqua.Add(node.Data);
            else
            {
                LayNodeOTangK(node.Left, k, ketqua);
                LayNodeOTangK(node.Right, k, ketqua);

            }    
        }
        public List<NguoiDung> GetNodesAtLevel(int k)
        {
            var result = new List<NguoiDung>();
            void Traverse(Node node, int current)
            {
                if (node == null) return;
                if (current == k)
                {
                    result.Add(node.Data);
                    return;
                }
                Traverse(node.Left, current + 1);
                Traverse(node.Right, current + 1);
            }
            Traverse(Root, 0);
            return result;
        }

        // Trả về số lượng node ở tầng k
        public int CountNodesAtLevel(int k)
        {
            return GetNodesAtLevel(k).Count;
        }
    }
}
=======
            return GetSubTree(node.Right, k, current + 1, direction);
        }
        
        // Đếm node tầng k
        public int CountK(int k)
        {
            return CountLevel(Root, k);
        }

        private int CountLevel (Node node, int k)
        {
            if (node == null) return 0;
            if (k == 0) return 1;
            return CountLevel(node.Left, k - 1) + CountLevel(node.Right, k - 1);
        }

        //Lấy danh sách node tầng k
        public List<NguoiDung> LayNodeTangK(int k)
        {
            var ketqua = new List<NguoiDung>();
            LayNodeOTangK(Root, k, ketqua);
            return ketqua;
        }
        private void LayNodeOTangK(Node node, int k, List<NguoiDung> ketqua)
        {
            if(node == null) return;
            if(k == 0) ketqua.Add(node.Data);
            else
            {
                LayNodeOTangK(node.Left, k, ketqua);
                LayNodeOTangK(node.Right, k, ketqua);

            }    
        }
        public List<NguoiDung> GetNodesAtLevel(int k)
        {
            var result = new List<NguoiDung>();
            void Traverse(Node node, int current)
            {
                if (node == null) return;
                if (current == k)
                {
                    result.Add(node.Data);
                    return;
                }
                Traverse(node.Left, current + 1);
                Traverse(node.Right, current + 1);
            }
            Traverse(Root, 0);
            return result;
        }

        // Trả về số lượng node ở tầng k
        public int CountNodesAtLevel(int k)
        {
            return GetNodesAtLevel(k).Count;
        }
    }
}
>>>>>>> 2514022022a8e65ca2db7b469a3bbd8106c1b849
=======
            return GetSubTree(node.Right, k, current + 1, direction);
        }
        
        // Đếm node tầng k
        public int CountK(int k)
        {
            return CountLevel(Root, k);
        }

        private int CountLevel (Node node, int k)
        {
            if (node == null) return 0;
            if (k == 0) return 1;
            return CountLevel(node.Left, k - 1) + CountLevel(node.Right, k - 1);
        }

        //Lấy danh sách node tầng k
        public List<NguoiDung> LayNodeTangK(int k)
        {
            var ketqua = new List<NguoiDung>();
            LayNodeOTangK(Root, k, ketqua);
            return ketqua;
        }
        private void LayNodeOTangK(Node node, int k, List<NguoiDung> ketqua)
        {
            if(node == null) return;
            if(k == 0) ketqua.Add(node.Data);
            else
            {
                LayNodeOTangK(node.Left, k, ketqua);
                LayNodeOTangK(node.Right, k, ketqua);

            }    
        }
        public List<NguoiDung> GetNodesAtLevel(int k)
        {
            var result = new List<NguoiDung>();
            void Traverse(Node node, int current)
            {
                if (node == null) return;
                if (current == k)
                {
                    result.Add(node.Data);
                    return;
                }
                Traverse(node.Left, current + 1);
                Traverse(node.Right, current + 1);
            }
            Traverse(Root, 0);
            return result;
        }

        // Trả về số lượng node ở tầng k
        public int CountNodesAtLevel(int k)
        {
            return GetNodesAtLevel(k).Count;
        }
    }
}
>>>>>>> 2514022022a8e65ca2db7b469a3bbd8106c1b849
=======
            return GetSubTree(node.Right, k, current + 1, direction);
        }
        
        // Đếm node tầng k
        public int CountK(int k)
        {
            return CountLevel(Root, k);
        }

        private int CountLevel (Node node, int k)
        {
            if (node == null) return 0;
            if (k == 0) return 1;
            return CountLevel(node.Left, k - 1) + CountLevel(node.Right, k - 1);
        }

        //Lấy danh sách node tầng k
        public List<NguoiDung> LayNodeTangK(int k)
        {
            var ketqua = new List<NguoiDung>();
            LayNodeOTangK(Root, k, ketqua);
            return ketqua;
        }
        private void LayNodeOTangK(Node node, int k, List<NguoiDung> ketqua)
        {
            if(node == null) return;
            if(k == 0) ketqua.Add(node.Data);
            else
            {
                LayNodeOTangK(node.Left, k, ketqua);
                LayNodeOTangK(node.Right, k, ketqua);

            }    
        }
        public List<NguoiDung> GetNodesAtLevel(int k)
        {
            var result = new List<NguoiDung>();
            void Traverse(Node node, int current)
            {
                if (node == null) return;
                if (current == k)
                {
                    result.Add(node.Data);
                    return;
                }
                Traverse(node.Left, current + 1);
                Traverse(node.Right, current + 1);
            }
            Traverse(Root, 0);
            return result;
        }

        // Trả về số lượng node ở tầng k
        public int CountNodesAtLevel(int k)
        {
            return GetNodesAtLevel(k).Count;
        }
    }
}
>>>>>>> 2514022022a8e65ca2db7b469a3bbd8106c1b849
