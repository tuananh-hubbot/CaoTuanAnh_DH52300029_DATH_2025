using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    internal partial class AVLTree<T>
    {
        private void InOrder(AVLTreeNode<T> node, List<T> list) //Hàm sắp xếp LNR
        {
            if (node == null) return; //Hàm luôn trả về danh sách với giá trị tăng dần
            {
                InOrder(node.Left as AVLTreeNode<T>, list);
                list.Add(node.Data);
                InOrder(node.Right as AVLTreeNode<T>, list);
            }
        }
        private void PreOrder(AVLTreeNode<T> node, List<T> list) //Hàm sắp xếp NLR
        {
            if (node == null) return;
            {
                list.Add(node.Data);
                PreOrder(node.Left as AVLTreeNode<T>, list);      
                PreOrder(node.Right as AVLTreeNode<T>, list);
            }
        }
        private void PostOrder(AVLTreeNode<T> node, List<T> list) //Hàm sắp xếp LRN
        {
            if (node == null) return; 
            {
                PostOrder(node.Left as AVLTreeNode<T>, list);                
                PostOrder(node.Right as AVLTreeNode<T>, list);
                list.Add(node.Data);
            }
        }
        public List<T> ToList() //Trả về danh sách dữ liệu muốn sắp xếp
        {
            var list = new List<T>();
            InOrder(Root, list);
            return list;
        }
        public List<T> LevelOrder()
        {
            var result = new List<T>();
            if (Root == null) return result;

            Queue<AVLTreeNode<T>> q = new Queue<AVLTreeNode<T>>();
            q.Enqueue(Root);

            while (q.Count > 0)
            {
                var current = q.Dequeue();
                result.Add(current.Data);

                if (current.Left != null) q.Enqueue(current.Left as AVLTreeNode<T>);
                if (current.Right != null) q.Enqueue(current.Right as AVLTreeNode<T>);
            }

            return result;
        }

    }
}
