using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    public class DuplicationNode
    {
        public NguoiDung Data { get; set; }
        public DuplicationNode Next { get; set;}
        public DuplicationNode(NguoiDung data)
        {
            Data = data;
            Next = null;
        }
    }
}
