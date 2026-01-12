using System;

namespace PayrollSystem.Models
{
    #region PaySlip Model

    /// <summary>
    /// Represents a payroll slip generated for an employee.
    /// </summary>
    public class PaySlip
    {
        #region Properties

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeType { get; set; }
        public decimal GrossPay { get; set; }
        public decimal TaxDeduction { get; set; }
        public decimal NetPay { get; set; }
        public DateTime ProcessedDate { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a formatted string representation of the payslip.
        /// </summary>
        public override string ToString()
        {
            return $"ID: {EmployeeId} | Name: {EmployeeName} | Net: {NetPay:C}";
        }

        #endregion
    }

    #endregion
}
