namespace LedgerSystem
{
    #region Base Model
    /// <summary>
    /// Represents the abstract base for all transactions.
    /// cannot create a generic transaction; it must be specifically an Income or an Expense.
    /// Implements IReportable to ensure summary capabilities.
    /// </summary>
    public abstract class Transaction : IReportable
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }

        /// <summary>
        /// Abstract method to be implemented by derived classes to provide specific details.
        /// </summary>
        public abstract string GetSummary(); //It declares GetSummary() as abstract, forcing derived classes to provide their own specific details.
    }
    #endregion

    #region Derived Models
    /// <summary>
    /// Represents a cash outflow categorized by usage.
    /// </summary>
    public class ExpenseTransaction : Transaction
    {
        public string? Category { get; set; }

        public override string GetSummary()
        {
            return $"Expense ID: {Id}, Date: {Date:d}, Amount: ${Amount}, Description: {Description}, Category: {Category}";
        }
    }

    /// <summary>
    /// Represents a cash inflow categorized by its source.
    /// </summary>
    public class IncomeTransaction : Transaction
    {
        public string? Source { get; set; }

        public override string GetSummary()
        {
            return $"Income ID: {Id}, Date: {Date:d}, Amount: ${Amount}, Description: {Description}, Source: {Source}";
        }
    }
    #endregion
}