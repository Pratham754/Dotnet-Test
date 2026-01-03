using System;
using System.Collections.Generic;
using LibItems = LibrarySystem.Items;

namespace LibrarySystem
{
    /// <summary>
    /// Application entry point demonstrating all required OOP concepts.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region Task 1 – Abstraction

            LibItems.Book book = new LibItems.Book("C# Fundamentals", "John Doe", 101);

            LibItems.Magazine magazine = new LibItems.Magazine("Tech Today", "Jane Doe", 201);

            book.DisplayItemDetails();
            Console.WriteLine($"Late Fee for 3 days: {book.CalculateLateFee(3)}");

            magazine.DisplayItemDetails();
            Console.WriteLine($"Late Fee for 3 days: {magazine.CalculateLateFee(3)}");

            #endregion

            #region Task 2 & 4 – Explicit Interfaces

            LibItems.IReservable reservable = book;
            LibItems.INotifiable notifiable = book;

            reservable.Reserve();
            notifiable.SendNotification("Your reserved book is ready.");

            #endregion

            #region Task 3 – Polymorphism

            List<LibItems.LibraryItem> items = new List<LibItems.LibraryItem> { book, magazine };

            foreach (var item in items)
            {
                item.DisplayItemDetails();
                Console.WriteLine();
            }

            #endregion

            #region Task 6 – Static & Partial

            LibraryAnalytics.TotalBorrowedItems = 5;
            LibraryAnalytics.DisplayAnalytics();

            #endregion

            #region Task 7 – Enums

            Users.Member user = new Users.Member { Name = "Alice", Role = Users.UserRole.Member };

            Console.WriteLine($"User Role: {user.Role}");

            #endregion
        }
    }
}