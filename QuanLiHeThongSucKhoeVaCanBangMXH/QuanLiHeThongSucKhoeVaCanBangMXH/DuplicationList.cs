using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    public class DuplicationList
    {
        public DuplicationNode Head { get; private set; }
        public void Add(NguoiDung data)
        {
            var newNode = new DuplicationNode(data);
            newNode.Next = Head;
            Head = newNode;

        }
        public List<NguoiDung> ToList()
        {
            var list = new List<NguoiDung>();
            var current = Head;
            while(current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }
            return list;
        }

    }
}
