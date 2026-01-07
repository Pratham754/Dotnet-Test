using System;
using System.Collections.Generic;
using LedgerSystem;

/// <summary>
/// Entry point for the Digital Petty Cash Ledger System.
/// </summary>
public class Program
{
    public static void Main()
    {
        #region Initialization
        // Initialize separate ledgers for Income and Expenses
        var incomeLedger = new Ledger<IncomeTransaction>();
        var expenseLedger = new Ledger<ExpenseTransaction>();
        #endregion

        #region Data Entry
        // 1. Record Fund Replenishment
        incomeLedger.AddEntry(new IncomeTransaction { Id = 1, Amount = 500, Description = "New Record Added", Source = "Main Cash", Date = DateTime.Now });
        // 2. Record Daily Spends
        expenseLedger.AddEntry(new ExpenseTransaction { Id = 2, Amount = 20, Description = "New Record Added", Category = "Stationery", Date = DateTime.Now });
        expenseLedger.AddEntry(new ExpenseTransaction { Id = 3, Amount = 15, Description = "New Record Added", Category = "Food", Date = DateTime.Now });
        #endregion

        #region Calculation & Reporting
        // Calculate Totals
        decimal totalIn = TransactionCalculator.CalculateIncomeTotal(incomeLedger.GetAll());
        decimal totalOut = TransactionCalculator.CalculateExpenseTotal(expenseLedger.GetAll());
        decimal net = TransactionCalculator.CalculateNetBalance(incomeLedger.GetAll(), expenseLedger.GetAll());


        Console.WriteLine($"Total Income: ${totalIn}");
        Console.WriteLine($"Total Expense: ${totalOut}");
        Console.WriteLine($"Net Balance: ${net}");
        Console.WriteLine("--------------------------------");

        // Polymorphism to display all types in one master list
        // We create a base-type list to hold both types of transactions
        List<Transaction> masterReport = [];

        // Manually add items from both ledgers
        foreach (var item in incomeLedger.GetAll()) { masterReport.Add(item); }
        foreach (var item in expenseLedger.GetAll()) { masterReport.Add(item); }

        Console.WriteLine("FULL TRANSACTION REPORT:");
        foreach (Transaction t in masterReport)
        {
            // Even though 't' is a 'Transaction', it calls the correct 
            // 'GetSummary' for Income or Expense automatically.
            Console.WriteLine(t.GetSummary());
        }
        #endregion

        // Demonstrate type safety
        // expenseLedger.AddEntry(new IncomeTransaction { Id = 4, Amount = 500, Description = "New Record Added", Source = "Main Cash", Date = DateTime.Now }); // Error: Cannot convert IncomeTransaction to ExpenseTransaction
    }
}