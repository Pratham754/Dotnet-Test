namespace LedgerSystem
{
    /// <summary>
    /// A generic repository for managing transaction data.
    /// </summary>
    /// <typeparam name="T">Must be a type derived from Transaction.</typeparam>
    public class Ledger<T> where T : Transaction
    {
        #region Private Fields
        // In-memory storage for transactions
        private readonly List<T> transactions = [];
        #endregion

        #region Public Methods
        /// <summary>
        /// Adds a new transaction entry to the ledger.
        /// </summary>
        public void AddEntry(T entry)
        {
            transactions.Add(entry);
        }

        /// <summary>
        /// Retrieves all transactions stored in the ledger.
        /// </summary>
        public List<T> GetAll()
        {
            return transactions;
        }

        /// <summary>
        /// Filters transactions based on a specific date.
        /// </summary>
        public List<T> GetTransactionsByDate(DateTime date)
        {
            List<T> filteredResults = [];
            foreach (T transaction in transactions)
            {
                if (transaction.Date.Date == date.Date)
                {
                    filteredResults.Add(transaction);
                }
            }
            return filteredResults;
        }
        #endregion
    }
}