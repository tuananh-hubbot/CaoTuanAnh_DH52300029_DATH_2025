using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    public class Node<T> //Khai báo class Node dạng generic (tổng quát)
    {
        public T Data { get; set; } //Lưu trữ dữ liệu node
        public Node<T> Left { get; set; } //
        public Node<T> Right { get; set; }
        public Node(T data) //Khởi tạo constructor có tham số mới
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
}
