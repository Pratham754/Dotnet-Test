namespace LibrarySystem
{
    // Part 2
    
    public partial class LibraryAnalytics
    {
        #region Static Methods

        public static void DisplayAnalytics()
        {
            Console.WriteLine($"Total Items Borrowed: {TotalBorrowedItems}");
        }

        #endregion
    }
}