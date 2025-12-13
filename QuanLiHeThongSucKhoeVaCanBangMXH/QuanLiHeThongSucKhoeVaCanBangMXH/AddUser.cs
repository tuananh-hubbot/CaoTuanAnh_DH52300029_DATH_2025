using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    public partial class AddUser: Form
    {
        public NguoiDung AddND  { get; private set; }
        public AddUser()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                AddND = new NguoiDung();
                AddND.Name = txtName.Text;
                AddND.Age = int.Parse(txtAge.Text);
                AddND.Gender = radMale.Checked ? "Male" : radFemale.Checked ? "Female" : "Other";
                AddND.ThoiGianDungMXH = double.Parse(txtThoiGianDungMXH.Text);
                AddND.ChatLuongGiacNgu = double.Parse(txtChatLuongGiacNgu.Text);
                AddND.MucDoStress = double.Parse(txtMucDoStress.Text);
                AddND.ThoiGianKhongMXH = double.Parse(txtThoiGianKhongDungMXH.Text);
                AddND.TanSuatTapLuyen = double.Parse(txtTanSuatTapLuyen.Text);
                AddND.AppSuDung = txtApSuDung.Text;
                AddND.MucDoHanhPhuc = double.Parse(txtMucDoHanhPhuc.Text);
                AddND.ThoiGianDocSach = double.Parse(txtThoiGianDocSach.Text);
   
                MessageBox.Show("Thêm thành công.", "Thông báo!", MessageBoxButtons.OK);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Nhập Liệu: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
