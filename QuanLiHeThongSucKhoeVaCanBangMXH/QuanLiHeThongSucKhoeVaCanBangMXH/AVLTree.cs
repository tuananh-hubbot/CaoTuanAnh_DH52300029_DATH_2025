using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;


namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    internal partial class AVLTree<T> //Khai báo nội bộ và chia nhỏ class mới tên AVLTree<T>
    {
        public AVLTreeNode<T> Root { get; private set; } 
        private Func<T, IComparable> keySelector;


        public AVLTree(Func<T, IComparable> keySelector) // Khai báo constructor của class 
        {
            this.keySelector = keySelector;
            Root = null;

        }
        private int height(AVLTreeNode<T> node) //Hàm height hỗ trợ dùng để truy xuất chiều cao của một node trong cây AVL
        {
            return node == null ? 0 : node.height;
        }

        private int GetBalance(AVLTreeNode<T> node) //Hàm GetBalance dùng tính hệ số cân bằng của một node trong cây AVL xem nó có lệch hay không
        {
            return node == null ? 0 : height((AVLTreeNode<T>)node.Left) - height((AVLTreeNode<T>)node.Right);

        }

        private int Compare(T a, T b) //Hàm Compare cho phép cho sánh giá trị 2 node dựa trên keySelector được chọn (thuộc tính người dùng)
        {
            var keyA = keySelector(a); //Lấy trường cần so sánh của nút a
            var keyB = keySelector(b); //Lấy trường cần so sánh của nút b
            if (keyA == null && keyB == null) return 0; //Thực hiện điều kiện so sánh. Nếu cả 2 null xem như bằng nhau
            if (keyA == null) return -1; //Nếu chỉ 1 trường null - trường null luôn nhỏ hơn khóa có giá trị
            if (keyB == null) return 1;
            return keyA.CompareTo(keyB); //Thực hiện so sánh
        }   
    }
}
   
        
            
        
        

        

        
        
        
