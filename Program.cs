using System;
using ExpenseTracker.Data;
using ExpenseTracker.Parser;
using ExpenseTracker.Services;

namespace ExpenseTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FileStorage.ReadAll();
            while (true)
            {

                ExpenseMethods.ShowExpenses();

                Console.WriteLine("\n1. Add Expense");
                Console.WriteLine("2. Remove Expense");
                Console.WriteLine("3. Exit");
                Console.Write("> ");
                if (!int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.Write("Invalid Input");
                    Console.ReadKey();
                }
                else if (option < 1 || option > 3)
                {
                    Console.Write("Input out of range, enter only 1-3 next time!");
                    Console.ReadKey();
                }
                else
                {
                    if (option == 1)
                    {
                        Console.Write("Enter the expense: ");
                        if (!int.TryParse(Console.ReadLine(), out int amount))
                        {
                            Console.Write("Invalid Input, enter a number.");
                            Console.ReadKey();
                            continue;
                        }
                        Console.Write("Enter the reason of spending: ");
                        string reason = Console.ReadLine();
                        ExpenseMethods.AddExpense(reason, amount);
                        Console.Write("\n Expense record added! Press any key to continue");
                        Console.ReadKey();
                    }
                    else if (option == 2)
                    {
                        Console.Write("Enter the index of the record you wish to remove (starts at 1): ");

                        if (!int.TryParse(Console.ReadLine(), out int index))
                        {
                            Console.Write("Invalid input.");
                            Console.ReadKey();
                            continue;
                        }

                        ExpenseMethods.RemoveExpense(index);
                        Console.Write("\nExpense removed! Press any key...");
                        Console.ReadKey();
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}