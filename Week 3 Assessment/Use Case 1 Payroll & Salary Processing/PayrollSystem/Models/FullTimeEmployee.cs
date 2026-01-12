using System;

namespace PayRoll.Models
{
    #region Full-Time Employee

    /// <summary>
    /// Child class of Employee. 
    /// Calculates pay based on Fixed Salary + Bonus.
    /// </summary>
    public class FullTimeEmployee : Employee
    {
        #region Properties

        public decimal BaseSalary { get; set; }
        public decimal BonusPercentage { get; set; }
        public decimal TaxRate { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new full-time employee instance.
        /// </summary>
        public FullTimeEmployee(int id, string name, string dept, decimal salary, decimal bonusPct, decimal taxRate) 
            : base(id, name, dept, "FullTime")
        {
            if (salary < 0)
            {
                throw new Exception("Salary must be greater than 0");
            }

            BaseSalary = salary;
            BonusPercentage = bonusPct;
            TaxRate = taxRate;
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
        /// Logic: Gross = Base + (Base * Bonus)
        /// </summary>
        public override decimal GetGross()
        {
            return BaseSalary + (BaseSalary * BonusPercentage);
        }

        /// <summary>
        /// Logic: Deduction = Gross * TaxRate
        /// </summary>
        public override decimal GetDeduction()
        {
            return GetGross() * TaxRate;
        }

        #endregion
    }

    #endregion
}