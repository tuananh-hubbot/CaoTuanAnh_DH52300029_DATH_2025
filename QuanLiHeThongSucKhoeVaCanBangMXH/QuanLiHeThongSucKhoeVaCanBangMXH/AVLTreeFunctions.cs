using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    internal class AVLTreeFunctions<T>
    where T : class
    {
        private AVLTree<T> tree;

        public Dictionary<string, Action> Actions { get; private set; }

        public AVLTreeFunctions(AVLTree<T> tree)
        {
            this.tree = tree;
            Actions = new Dictionary<string, Action>();
        }

        public void InitializeFunctions(Func<string> getField, Action<string> output)
        {
            Actions["Tổng"] = () =>
            {
                string field = getField();
                var prop = typeof(T).GetProperty(field);

                if (prop == null)
                {
                    output($"Trường {field} không tồn tại!");
                    return;
                }

                if (!IsNumeric(prop.PropertyType))
                {
                    output($"Trường {field} không phải kiểu số!");
                    return;
                }

                double sum = tree.SumField(x => Convert.ToDouble(prop.GetValue(x)));
                output($"Tổng {field}: {sum}");
            };


            Actions["Đếm Node"] = () => output($"Tổng Node: {tree.Count()}");
            Actions["Đếm Node Lá"] = () => output($"Node Lá: {tree.CountLeaves()}");
            Actions["Node 1 Con"] = () => output($"Node 1 con: {tree.CountOneChild()}");
            Actions["Node 2 Con"] = () => output($"Node 2 con: {tree.CountTwoChild()}");


            Actions["Nhỏ nhất"] = () =>
            {
                string field = getField();
                var prop = typeof(T).GetProperty(field);

                if (prop == null)
                {
                    output($"Trường {field} không tồn tại!");
                    return;
                }

                if (!typeof(IComparable).IsAssignableFrom(prop.PropertyType))
                {
                    output($"Trường {field} không thể so sánh!");
                    return;
                }

                var min = tree.MinBy(x => (IComparable)prop.GetValue(x));
                output($"Nhỏ nhất {field}: {prop.GetValue(min)}");
            };


            Actions["Lớn nhất"] = () =>
            {
                string field = getField();
                var prop = typeof(T).GetProperty(field);

                if (prop == null)
                {
                    output($"Trường {field} không tồn tại!");
                    return;
                }

                if (!typeof(IComparable).IsAssignableFrom(prop.PropertyType))
                {
                    output($"Trường {field} không thể so sánh!");
                    return;
                }

                var max = tree.MaxBy(x => (IComparable)prop.GetValue(x));
                output($"Lớn nhất {field}: {prop.GetValue(max)}");
            };
        }

        public void Execute(string actionName)
        {
            if (Actions.ContainsKey(actionName)) Actions[actionName]();
            else MessageBox.Show("Chức năng chưa được định nghĩa!");
        }

        private bool IsNumeric(Type t)
            => t == typeof(int) || t == typeof(double) || t == typeof(float) || t == typeof(decimal);
    }
}
