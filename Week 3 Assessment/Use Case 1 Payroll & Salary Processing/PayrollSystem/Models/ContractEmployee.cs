using System;

namespace PayRoll.Models
{
    #region Contract Employee

    /// <summary>
    /// Child class of Employee. 
    /// Calculates pay based on Hourly Rate * Hours.
    /// </summary>
    public class ContractEmployee : Employee
    {
        #region Properties

        public decimal HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new contract employee instance.
        /// Validates working hours (0-350) upon creation.
        /// </summary>
        public ContractEmployee(int id, string name, string dept, decimal hourlyRate, int hours) 
            : base(id, name, dept, "Contract")
        {
            if (hours < 0 || hours > 350)
            {
                throw new Exception($"Invalid working hours for {name} (must be 0-350).");
            }

            HourlyRate = hourlyRate;
            HoursWorked = hours;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method Overriding: Calculates Net Pay.
        /// </summary>
        public override decimal CalculatePay()
        {
            return GetGross() - GetDeduction();
        }

        /// <summary>
        /// Logic: Gross = Hourly Rate * Hours Worked
        /// </summary>
        public override decimal GetGross()
        {
            return HourlyRate * HoursWorked;
        }

        /// <summary>
        /// Logic: Fixed deduction for contractors (e.g. 5%)
        /// </summary>
        public override decimal GetDeduction()
        {
            return GetGross() * 0.05m; 
        }

        #endregion
    }

    #endregion
}