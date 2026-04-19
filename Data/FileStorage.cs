using System;
using System.IO;
using System.Linq;

namespace ExpenseTracker.Data
{
    public class FileStorage
    {
        const string Path = "Expenses.txt";

        public static List<string> ReadAll()
        {
            if (!File.Exists(Path))
            {
                File.WriteAllText(Path, "");
            }
            return File.ReadAllLines(Path).ToList();
        }

        public static void WriteAll(List<string> data)
        {
            File.WriteAllLines(Path, data);
        }
    }
}