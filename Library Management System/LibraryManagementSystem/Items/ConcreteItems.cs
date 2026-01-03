using System;

namespace LibrarySystem.Items
{
    /// <summary>
    /// Contains all concrete implementations of LibraryItem.
    /// Demonstrates inheritance, polymorphism, and explicit interfaces.
    /// </summary>
    public class Book : LibraryItem, IReservable, INotifiable
    {
        #region Constructor

        public Book(string title, string author, int itemId)
            : base(title, author, itemId) { }

        #endregion

        #region Overridden Methods

        public override void DisplayItemDetails()
        {
            Console.WriteLine("Item Type: Book");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Item ID: {ItemID}");
        }

        public override double CalculateLateFee(int days)
        {
            return days * 1.0;
        }

        #endregion

        #region Explicit Interface Implementations

        void IReservable.Reserve()
        {
            Console.WriteLine("Book reserved successfully.");
        }

        void INotifiable.SendNotification(string message)
        {
            Console.WriteLine($"Notification sent: {message}");
        }

        #endregion
    }

    /// <summary>
    /// Represents a magazine in the library system.
    /// </summary>
    public class Magazine : LibraryItem
    {
        #region Constructor

        public Magazine(string title, string author, int itemId)
            : base(title, author, itemId) { }

        #endregion

        #region Overridden Methods

        public override void DisplayItemDetails()
        {
            Console.WriteLine("Item Type: Magazine");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Item ID: {ItemID}");
        }

        public override double CalculateLateFee(int days)
        {
            return days * 0.5;
        }

        #endregion
    }

    /// <summary>
    /// Represents a digital eBook item.
    /// </summary>
    public class eBook : LibraryItem
    {
        #region Constructor

        public eBook(string title, string author, int itemId)
            : base(title, author, itemId) { }

        #endregion

        #region Overridden Methods

        public override void DisplayItemDetails()
        {
            Console.WriteLine("Item Type: eBook");
            Console.WriteLine($"Title: {Title}");
        }

        public override double CalculateLateFee(int days)
        {
            return 0.0;
        }

        #endregion

        #region Digital-Specific Behavior

        public void Download()
        {
            Console.WriteLine("eBook downloaded successfully.");
        }

        #endregion
    }
}