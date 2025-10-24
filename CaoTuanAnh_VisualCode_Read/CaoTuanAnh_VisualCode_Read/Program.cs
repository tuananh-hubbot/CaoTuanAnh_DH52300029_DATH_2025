//using System;
//using System.IO;
//using System.Collections.Generic;

//class ReadCsv
//{
//    static List<string[]> ReadCsvFile(string filePath)
//    {
//        List<string[]> rows = new List<string[]>();

//        try
//        {
//            // Read all lines from the CSV file
//            string[] lines = File.ReadAllLines(filePath);

//            // Process each line and split by the comma to get individual values
//            foreach (string line in lines)
//            {
//                string[] values = line.Split(',');

//                // Add the values to the list of rows
//                rows.Add(values);
//            }

//            Console.WriteLine("CSV file read successfully!");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"An error occurred: {ex.Message}");
//        }

//        return rows;
//    }

//    static void Main()
//    {
//        // Specify the path to the CSV file
//        string csvFilePath = "Dataset.csv";

//        // Call the method to read and process the CSV data
//        List<string[]> csvData = ReadCsvFile(csvFilePath);

//        // Display the read data
//        foreach (string[] row in csvData)
//        {
//            Console.WriteLine(string.Join(", ", row));
//        }
//    }
//}

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
