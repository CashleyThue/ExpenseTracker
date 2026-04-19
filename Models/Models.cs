using System;

namespace ExpenseTracker.Struct
{
    public class Expense
    {
        public double Amount { get; set; }
        public string Reason { get; set; }
        public enum Impact
        {
            Low,
            Medium,
            High
        }
        public Impact Level { get; set; }

        public Expense(double amount, string reason, Impact level)
        {
            Amount = amount;
            Reason = reason;
            Level = level;
        }
    }
}