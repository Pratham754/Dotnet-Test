using System;
using PayRoll.Models;

namespace PayRoll.Notifications
{
    #region Notification Handlers

    /// <summary>
    /// Helper class containing Delegate methods for notifications.
    /// </summary>
    public static class NotificationHandlers
    {
        #region Delegate Methods

        /// <summary>
        /// Notifies HR about processed salary.
        /// </summary>
        public static void NotifyHR(PaySlip slip)
        {
            Console.WriteLine($"[HR Notification] PDF Generated for {slip.Name}. Net: {slip.Net:C}");
        }

        /// <summary>
        /// Notifies Finance about tax recording.
        /// </summary>
        public static void NotifyFinance(PaySlip slip)
        {
            Console.WriteLine($"[Finance Notification] Tax of {slip.Deduction:C} recorded for ID {slip.Id}.");
        }

        #endregion
    }

    #endregion
}