using System;
using System.Windows.Forms;

namespace CaoTuanAnh_VisualCode_Read
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Bật giao diện Windows hiện đại
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 🔹 Chạy Form1 khi mở chương trình
            Application.Run(new Form1());
        }
    }
}
