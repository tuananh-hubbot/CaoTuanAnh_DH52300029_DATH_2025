using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    public class AVLTreeNode<T> : Node<T> //Khai báo class mới là AVLTreeNode<T> mô tả 1 node trong cây AVL
                                          //Kế thừa các thuộc tính cơ bản của Node<T> khi khai báo kiểu này
    {
        public int height = 1;
        public int count = 1;
        public AVLTreeNode(T data) : base(data) { } //Khai báo constructor nhận giá trị data truyền cho constructor của lớp Node<T>
    }
}
