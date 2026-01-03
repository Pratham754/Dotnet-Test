using System;

namespace LibrarySystem.Items
{
    /// <summary>
    /// Defines behaviors related to reserving library items.
    /// </summary>
    public interface IReservable
    {
        #region Methods
        void Reserve();
        #endregion
    }

    /// <summary>
    /// Defines notification functionality for library items.
    /// </summary>
    public interface INotifiable
    {
        #region Methods
        void SendNotification(string message);
        #endregion
    }
}
