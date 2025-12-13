using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    public class DuplicationList
    {
        public List<NguoiDung> items { get; private set; } = new List<NguoiDung>();
        public void Add(NguoiDung data)
        {
            items.Add(data);
        }
        public List<NguoiDung> ToList()
        {
            return new List<NguoiDung>(items);
        }
        public int Count => items.Count;
    }
}
