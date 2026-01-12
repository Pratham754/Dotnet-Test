namespace PayrollSystem.Models
{
    #region Full-Time Employee

    /// <summary>
    /// Represents a full-time employee with a fixed salary and bonus.
    /// </summary>
    public class FullTimeEmployee : Employee
    {
        #region Properties

        public decimal BonusPercentage { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new full-time employee instance.
        /// </summary>
        public FullTimeEmployee(
            int id,
            string name,
            string email,
            string dept,
            decimal fixedSalary,
            decimal bonusPct)
            : base(id, name, email, dept, fixedSalary)
        {
            BonusPercentage = bonusPct;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Calculates the gross pay including bonus.
        /// </summary>
        public override decimal CalculateGrossPay()
        {
            return BasePay + (BasePay * BonusPercentage);
        }

        #endregion
    }

    #endregion

    #region Contract Employee

    /// <summary>
    /// Represents a contract employee paid by hourly rate.
    /// </summary>
    public class ContractEmployee : Employee
    {
        #region Properties

        public int HoursWorked { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new contract employee instance.
        /// </summary>
        public ContractEmployee(
            int id,
            string name,
            string email,
            string dept,
            decimal hourlyRate,
            int hours)
            : base(id, name, email, dept, hourlyRate)
        {
            HoursWorked = hours;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Calculates gross pay based on hours worked.
        /// </summary>
        public override decimal CalculateGrossPay()
        {
            return BasePay * HoursWorked;
        }

        /// <summary>
        /// Validates contract employee data including working hours.
        /// </summary>
        public override bool Validate(out string error)
        {
            if (!base.Validate(out error))
                return false;

            if (HoursWorked < 0 || HoursWorked > 350)
            {
                error = "Invalid working hours (must be 0-350).";
                return false;
            }

            return true;
        }

        #endregion
    }

    #endregion
}
