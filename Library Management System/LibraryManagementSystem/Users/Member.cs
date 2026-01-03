using System;

namespace LibrarySystem.Users
{
    /// <summary>
    /// Defines roles available in the library system.
    /// </summary>
    public enum UserRole
    {
        Admin,
        Librarian,
        Member
    }

    /// <summary>
    /// Represents a library user.
    /// </summary>
    public class Member
    {
        #region Properties

        public string Name { get; set; } = "";
        public UserRole Role { get; set; }

        #endregion

        #region Methods

        public void ReceiveNotification(string message)
        {
            if (Role == UserRole.Admin)
                Console.WriteLine($"Admin Alert: {message}");
            else
                Console.WriteLine($"Member Notification: {message}");
        }

        #endregion
    }
}
