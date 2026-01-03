using System;

namespace LibrarySystem.Items
{
    /// <summary>
    /// Represents the base class for all library items.
    /// Enforces common properties and behaviors.
    /// </summary>
    public abstract class LibraryItem
    {
        #region Properties

        public string Title { get; set; }
        public string Author { get; set; }
        public int ItemID { get; set; }

        #endregion

        #region Constructor

        protected LibraryItem(string title, string author, int itemId)
        {
            Title = title;
            Author = author;
            ItemID = itemId;
        }

        #endregion

        #region Abstract Methods

        public abstract void DisplayItemDetails();
        public abstract double CalculateLateFee(int days);

        #endregion
    }

    /// <summary>
    /// Represents the availability state of a library item.
    /// </summary>
    public enum ItemStatus
    {
        Available,
        Borrowed,
        Reserved,
        Lost
    }
}