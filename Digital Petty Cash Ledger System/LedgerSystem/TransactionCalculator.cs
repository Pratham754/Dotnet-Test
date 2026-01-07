namespace LedgerSystem
{
    public static class TransactionCalculator
    {

        /// <summary>
        /// Calculates the total income.
        /// </summary>
        public static decimal CalculateIncomeTotal(List<IncomeTransaction> incomes)
        {
            decimal total = 0;
            foreach (var income in incomes)
            {
                total += income.Amount;
            }
            return total;
        }

        /// <summary>
        /// Calculates the total expense.
        /// </summary>
        public static decimal CalculateExpenseTotal(List<ExpenseTransaction> expenses)
        {
            decimal total = 0;
            foreach (var expense in expenses)
            {
                total += expense.Amount;
            }
            return total;
        }

        /// <summary>
        /// calculate the net balances
        /// </summary>
        public static decimal CalculateNetBalance(
           List<IncomeTransaction> incomes,
           List<ExpenseTransaction> expenses)
        {
            return CalculateIncomeTotal(incomes) - CalculateExpenseTotal(expenses);
        }
    }
}