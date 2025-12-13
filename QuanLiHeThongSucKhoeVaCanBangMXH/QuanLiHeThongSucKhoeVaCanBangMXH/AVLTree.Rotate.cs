using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    internal partial class AVLTree<T>
    {
        private AVLTreeNode<T> RotateLeft(AVLTreeNode<T> x) //Hàm xoay trái 
        {
            var y = x.Right as AVLTreeNode<T>; //Lấy node bên phải của x, gọi là y sẽ trở thành node gốc mới sau khi xoay
            var T2 = y.Left; //Lưu lại cây con trái của y
            //Đảo chiều quan hệ để cây cân bằng
            y.Left = x; // y đưa x xuống làm con trái
            x.Right = T2; //nhánh T2 được đưa sang làm con phải của x 
            //Cập nhật lại chiều cao 
            x.height = 1 + Math.Max(height(x.Left as AVLTreeNode<T>), height(x.Right as AVLTreeNode<T>));
            y.height = 1 + Math.Max(height(y.Left as AVLTreeNode<T>), height(y.Right as AVLTreeNode<T>));
            //Trả về root mới
            return y;
        }

        private AVLTreeNode<T> RotateRight(AVLTreeNode<T> y) //Hàm xoay phải
        {
            var x = y.Left as AVLTreeNode<T>; //x là con trái của y, sẽ trở thành root mới sau khi xoay
            var T2 = x.Right; //lưu nhánh con phải của x, nhánh này sẽ được gàn về bên trái của y sau khi xoay
            //Tiến hành xoay
            x.Right = y; //x đưa y xuống làm con phải
            y.Left = T2; //Cây con T2 sẽ được chuyển sang bên trái của y
            //Cập nhật lại chiều cao
            y.height = 1 + Math.Max(height(y.Left as AVLTreeNode<T>), height(y.Right as AVLTreeNode<T>));
            x.height = 1 + Math.Max(height(x.Left as AVLTreeNode<T>), height(x.Right as AVLTreeNode<T>));
            //Trả về root mới
            return x;
        }
    }
}
