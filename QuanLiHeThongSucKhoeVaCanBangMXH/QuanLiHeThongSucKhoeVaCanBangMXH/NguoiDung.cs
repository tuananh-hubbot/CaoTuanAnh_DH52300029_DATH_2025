<<<<<<< HEAD
<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    internal class NguoiDung
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public double ThoiGianDungMXH { get; set; }  
        public double ChatLuongGiacNgu { get; set; }      
        public double MucDoStress { get; set; }         
        public double ThoiGianKhongMXH { get; set; }      
        public double TanSuatTapLuyen { get; set; }      
        public string AppSuDung { get; set; }
        public double MucDoHanhPhuc { get; set; }       

        public NguoiDung(string Name, int Age, string Gender, double ThoiGianDungMXH, double ChatLuongGiacNgu, double MucDoStreet, double ThoiGianKhongMXH, double TanSuatTapLuyen, string AppSuDung, double MucDoHanhPhuc)
        {
            this.Name = Name;
            this.Age = Age;
            this.Gender = Gender;
            this.ThoiGianDungMXH = ThoiGianDungMXH;
            this.ChatLuongGiacNgu = ChatLuongGiacNgu;
            this.MucDoStress = MucDoStreet;
            this.ThoiGianKhongMXH = ThoiGianKhongMXH;
            this.TanSuatTapLuyen = TanSuatTapLuyen;
            this.AppSuDung = AppSuDung;
            this.MucDoHanhPhuc = MucDoHanhPhuc;
            
        }

        public override string ToString()
        {
            return $"{Name} ({Age}t, {Gender}) - " +
                   $"MXH: {ThoiGianDungMXH:F1}h | " + //F1 dùng giữ lại số thập phân 
                   $"Giấc ngủ: {ChatLuongGiacNgu}/10 | " +
                   $"Stress: {MucDoStress}/10 | " +
                   $"Hạnh phúc: {MucDoHanhPhuc}/10 | ";
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    internal class NguoiDung
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public double ThoiGianDungMXH { get; set; }  
        public double ChatLuongGiacNgu { get; set; }      
        public double MucDoStress { get; set; }         
        public double ThoiGianKhongMXH { get; set; }      
        public double TanSuatTapLuyen { get; set; }      
        public string AppSuDung { get; set; }
        public double MucDoHanhPhuc { get; set; }       

        public NguoiDung(string Name, int Age, string Gender, double ThoiGianDungMXH, double ChatLuongGiacNgu, double MucDoStreet, double ThoiGianKhongMXH, double TanSuatTapLuyen, string AppSuDung, double MucDoHanhPhuc)
        {
            this.Name = Name;
            this.Age = Age;
            this.Gender = Gender;
            this.ThoiGianDungMXH = ThoiGianDungMXH;
            this.ChatLuongGiacNgu = ChatLuongGiacNgu;
            this.MucDoStress = MucDoStreet;
            this.ThoiGianKhongMXH = ThoiGianKhongMXH;
            this.TanSuatTapLuyen = TanSuatTapLuyen;
            this.AppSuDung = AppSuDung;
            this.MucDoHanhPhuc = MucDoHanhPhuc;
            
        }

        public override string ToString()
        {
            return $"{Name} ({Age}t, {Gender}) - " +
                   $"MXH: {ThoiGianDungMXH:F1}h | " + //F1 dùng giữ lại số thập phân 
                   $"Giấc ngủ: {ChatLuongGiacNgu}/10 | " +
                   $"Stress: {MucDoStress}/10 | " +
                   $"Hạnh phúc: {MucDoHanhPhuc}/10 | ";
        }
    }
}
>>>>>>> 2514022022a8e65ca2db7b469a3bbd8106c1b849
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    internal class NguoiDung
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public double ThoiGianDungMXH { get; set; }  
        public double ChatLuongGiacNgu { get; set; }      
        public double MucDoStress { get; set; }         
        public double ThoiGianKhongMXH { get; set; }      
        public double TanSuatTapLuyen { get; set; }      
        public string AppSuDung { get; set; }
        public double MucDoHanhPhuc { get; set; }       

        public NguoiDung(string Name, int Age, string Gender, double ThoiGianDungMXH, double ChatLuongGiacNgu, double MucDoStreet, double ThoiGianKhongMXH, double TanSuatTapLuyen, string AppSuDung, double MucDoHanhPhuc)
        {
            this.Name = Name;
            this.Age = Age;
            this.Gender = Gender;
            this.ThoiGianDungMXH = ThoiGianDungMXH;
            this.ChatLuongGiacNgu = ChatLuongGiacNgu;
            this.MucDoStress = MucDoStreet;
            this.ThoiGianKhongMXH = ThoiGianKhongMXH;
            this.TanSuatTapLuyen = TanSuatTapLuyen;
            this.AppSuDung = AppSuDung;
            this.MucDoHanhPhuc = MucDoHanhPhuc;
            
        }

        public override string ToString()
        {
            return $"{Name} ({Age}t, {Gender}) - " +
                   $"MXH: {ThoiGianDungMXH:F1}h | " + //F1 dùng giữ lại số thập phân 
                   $"Giấc ngủ: {ChatLuongGiacNgu}/10 | " +
                   $"Stress: {MucDoStress}/10 | " +
                   $"Hạnh phúc: {MucDoHanhPhuc}/10 | ";
        }
    }
}
>>>>>>> 2514022022a8e65ca2db7b469a3bbd8106c1b849
