using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    public class PureTree
    {
        public PureNode Root { get; private set; }
        private Func<NguoiDung, IComparable> keySelector;
        public DuplicationList DuplicateUsers { get; private set; } = new DuplicationList();
        public PureTree(Func<NguoiDung,IComparable> keySelector)
        {
            this.keySelector = keySelector;
        }
        public void Insert(NguoiDung nd)
        {
            Root = Insert(Root, nd);
        }
        public PureNode Insert(PureNode node, NguoiDung nd)
        {
            if(node == null)
                return new PureNode(nd);
            var keyNew = keySelector(nd);
            var keyCurrent = keySelector(node.Data);
            if(keyNew.CompareTo(keyCurrent) < 0)
                node.Left = Insert(node.Left, nd);
            else if (keyNew.CompareTo(keyCurrent) > 0)
                node.Right = Insert(node.Right, nd);
            else
                DuplicateUsers.Add(nd);
            return node;
        }
    }
}
