using System;
using PayrollSystem.Models;

namespace PayrollSystem.Services
{
    #region Notification Service

    /// <summary>
    /// Handles notifications related to payroll processing.
    /// </summary>
    public class NotificationService
    {
        #region Methods

        /// <summary>
        /// Sends a notification to the HR department after payslip generation.
        /// </summary>
        public void NotifyHR(PaySlip slip)
        {
            Console.WriteLine(
                $"[HR Notification] PDF Generated for {slip.EmployeeName}. Net: {slip.NetPay:C}");
        }

        /// <summary>
        /// Sends a notification to the finance department for tax recording.
        /// </summary>
        public void NotifyFinance(PaySlip slip)
        {
            Console.WriteLine(
                $"[Finance Notification] Tax of {slip.TaxDeduction:C} recorded for ID {slip.EmployeeId}.");
        }

        #endregion
    }

    #endregion
}
