using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    internal partial class AVLTree<T>
    {
        public void Insert(T data) //Hàm Insert dùng để chèn một phần tử data vào cây AVL
        {
            Root = InsertNode(Root, data); //Thực hiện gọi hàm đệ quy InsertNode để chèn và cập nhật lại root của cây
        }

        private AVLTreeNode<T> InsertNode(AVLTreeNode<T> node, T data) //Hàm chèn node mới vào cây AVL
        {
            if (node == null)
                return new AVLTreeNode<T>(data); //Nếu đến vị trí là null --> tạo node mới 

            int cmp = Compare(data, node.Data); //So sánh dữ liệu mới và dữ liệu hiện tại để biết node đi bên trái hay đi bên phải
            
            if (cmp < 0)
                node.Left = InsertNode(node.Left as AVLTreeNode<T>, data); //Nếu data nhỏ hơn 0 thì chèn vào nhánh trái
            else if (cmp > 0)
                node.Right = InsertNode(node.Right as AVLTreeNode<T>, data); //Nếu data lớn hơn 0 thì chèn vào nhanh phải 
            else
                return node; //Nếu bằng nhau không chèn - tránh trùng lặp node

            return Balance(node, data); //Chèn xong thì cân bằng lại cây tại node hiện tại
        }
        // Hàm cân bằng cây 
        private AVLTreeNode<T> Balance(AVLTreeNode<T> node, T data) //Khai báo hàm Balance lại cây AVL
        {
            //Cập nhật chiều cao của nút. Sử dụng hàm height để lấy chiều cao của nút con bên left/right ép kiểu sang AVLTreeNode<T>
            node.height = 1 + Math.Max(height(node.Left as AVLTreeNode<T>),height(node.Right as AVLTreeNode<T>));
            //Tính hệ số cân bằng của một nút bằng cách lấy chiều cao con bên left - con bên right
            int balance = height(node.Left as AVLTreeNode<T>) - height(node.Right as AVLTreeNode<T>);
            //Thực hiện xoay khi cây AVL lệch nếu đúng điều kiện của 4 Trường hợp bên dưới
            // Trai - Trai: nếu lệch trái và dữ liệu mới nhỏ hơn nút con trái thì xoay phải
            if (balance > 1 && Compare(data, (node.Left as AVLTreeNode<T>).Data) < 0)
                return RotateRight(node);
            // Phai - Phai: nếu lệch phải và dữ liệu mới nhỏ hơn nút con phải thì xoay trái
            if (balance < -1 && Compare(data, (node.Right as AVLTreeNode<T>).Data) > 0)
                return RotateLeft(node);

            // Trai - Phai: nếu lệch trái nhưng dữ liệu mới lớn hơn nút con trái thì xoáy left con trái và xoay right nút hiện tại
            if (balance > 1 && Compare(data, (node.Left as AVLTreeNode<T>).Data) > 0)
            {
                node.Left = RotateLeft(node.Left as AVLTreeNode<T>);
                return RotateRight(node);
            }
            // Phai - Trai: nếu lệch phải nhưng dữ liệu mới nhỏ hơn nút con phải thì xoay phải con phải và xoay trái con nút hiện tại
            if (balance < -1 && Compare(data, (node.Right as AVLTreeNode<T>).Data) < 0)
            {
                node.Right = RotateRight(node.Right as AVLTreeNode<T>);
                return RotateLeft(node);
            }
            // Nếu nút không mất cân bằng trả về nút gốc
            return node;
        }

        public void Remove(T data) //Hàm public dùng để xóa một phần tử trong cây
        {
            Root = DeleteNode(Root, data); //Gọi đệ quy hàm DeleteNode để xóa và cập nhật lại root của cây
        }

        private AVLTreeNode<T> DeleteNode(AVLTreeNode<T> node, T data)
        {
            if (node == null) return null; //Không có node cần xóa trả về null

            int cmp = Compare(data, node.Data); //So sánh dữ liệu node cần xóa và node hiện tại đang ở bên trái hay phải 
            //Tìm node cần xóa 
            if (cmp < 0) 
                node.Left = DeleteNode(node.Left as AVLTreeNode<T>, data);  
            else if (cmp > 0)
                node.Right = DeleteNode(node.Right as AVLTreeNode<T>, data);
            else //Khi tìm thấy node cần xóa 
            {
                if (node.Left == null || node.Right == null) //Trường hợp node có 0 hoặc 1 con -> thay bằng node con còn lại
                    node = node.Left as AVLTreeNode<T> ?? node.Right as AVLTreeNode<T>;
                else //Trường hợp node có 2 con 
                {
                    var min = MinValueNode(node.Right as AVLTreeNode<T>); //Lấy giá trị nhỏ nhất bên phải 
                    node.Data = min.Data; //Gán node hiện tại vào
                    node.Right = DeleteNode(node.Right as AVLTreeNode<T>, min.Data); //Xóa node tìm thấy 
                }
            }

            if (node == null) return null; // Nếu node bị xóa và trở thành null --> kết thúc
            node.height = 1 + Math.Max(height(node.Left as AVLTreeNode<T>), height(node.Right as AVLTreeNode<T>)); //Cập nhật lại height
            return Balance(node, node.Data); //Cân bằng lại
        }

        private AVLTreeNode<T> MinValueNode(AVLTreeNode<T> node) //Hàm tìm node nhỏ nhất ở cây con bên trái 
        {
            var current = node;
            while (current.Left != null) //Duyệt hết nhánh trái để tìm node nhỏ nhất 
                current = current.Left as AVLTreeNode<T>;
            return current; //Trả về node tìm thấy 
        }
        public AVLTreeNode<T> Search(T value) //Hàm public nhận 1 value kiểu T từ bên ngoài 
        {
            return SearchInternal(Root, value); //Gọi để quy để tìm kiếm value bắt đầu từ Root
        }
        private AVLTreeNode<T> SearchInternal(AVLTreeNode<T> node, T value)
        {
            if (node == null) //Nếu không tìm thấy trả về null
                return null;
            //So sánh giá trị cần tìm và dữ liệu trong cây và thực hiện tìm kiếm ở 2 nhánh và trả về giá trị cần tìm
            int cmp = Compare(value, node.Data);
            if (cmp == 0)
                return node; //Trả về giá trị cần tìm ngay tại node đó
            if (cmp < 0)
                return SearchInternal(node.Left as AVLTreeNode<T>, value); //Tìm tiếp bên nhánh trái nếu giá trị cần tìm lớn hơn node gốc

            return SearchInternal(node.Right as AVLTreeNode<T>, value); //Tìm tiếp bên nhanh phải nếu giá trị cần tìm nhỏ hơn node gốc
        }
    }
}