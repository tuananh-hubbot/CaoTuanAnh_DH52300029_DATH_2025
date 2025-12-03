using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    public class PureNode
    {
        public NguoiDung Data {  get; set; }
        public PureNode Left { get; set; }
        public PureNode Right { get; set;}
        public PureNode(NguoiDung data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
}
