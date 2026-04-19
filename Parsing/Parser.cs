using System;
using ExpenseTracker.Struct;

namespace ExpenseTracker.Parser
{
    public class ExpenseParser
    {
        public static Expense Parse(string line)
        {
            var parts = line.Split("|");
            
            if (parts.Length != 3)
            {
                throw new FormatException("Invalid Format");
            }
            
            var amountPart = double.Parse(parts[0].Replace("$", "").Trim());
            var reasonPart = parts[1].Trim();
            
            var impactString = parts[2].Replace("Impact: ", "").Trim();
            if (!Enum.TryParse<Expense.Impact>(impactString, out var impactPart))
            {
                throw new FormatException("Invalid impact value");
            }
            return new Expense(amountPart, reasonPart, impactPart);
        }
    }
}
