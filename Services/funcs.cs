using System;
using System.IO;
using ExpenseTracker.Data;
using ExpenseTracker.Struct;
using ExpenseTracker.Parser;
using System.Linq;

namespace ExpenseTracker.Services
{
    public class ExpenseMethods
    {
        public static void AddExpense(string reason, int amount)
        {
            string level;
            var entries = FileStorage.ReadAll();
            if (amount < 100)
            {
                level = Expense.Impact.Low.ToString();
            }
            else if (amount < 500)
            {
                level = Expense.Impact.Medium.ToString();
            }
            else
            {
                level = Expense.Impact.High.ToString();
            }
            
            entries.Add($"${amount} | {reason} | Impact: {level}");
            FileStorage.WriteAll(entries);
        }

        public static void RemoveExpense(int entry)
        {
            var entries = FileStorage.ReadAll();
            if (entry < 1 || entry > entries.Count)
            {
                Console.Write("\nInvalid Index.");
                return;
            }
            entries.RemoveAt(entry-1);
            FileStorage.WriteAll(entries);
        }

        public static int GetTotal()
        {
            var entries = FileStorage.ReadAll();
            int total = 0;
            if (entries.Count == 0)
            {
                return 0;
            }
            foreach (var entry in entries)
            {
                string[] temp = entry.Split('|');
                if (!int.TryParse(temp[0].Replace("$", "").Trim(), out int n))
                {
                    Console.WriteLine("Invalid Entry in Expense List.");
                }

                total += n;
            }
            return total;
        }

        public static void ShowExpenses()
        {
            Console.Clear();
            Console.WriteLine("Expenses:");
            Console.WriteLine("---------------");
            var expenses = FileStorage.ReadAll().Select(ExpenseParser.Parse).ToList();
            int index = 1;
            foreach (var expense in expenses)
            {
                Console.WriteLine($"{index}. ${expense.Amount} - {expense.Reason} ({expense.Level})");
                index++;
            }
            Console.WriteLine("Total: $" + GetTotal());
            Console.WriteLine("---------------");
        }
    }
}

