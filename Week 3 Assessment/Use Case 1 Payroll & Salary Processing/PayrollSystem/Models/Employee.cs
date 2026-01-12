namespace PayrollSystem.Models
{
    #region Employee Base Class

    /// <summary>
    /// Represents a base employee with common properties and behaviors.
    /// </summary>
    public abstract class Employee
    {
        #region Properties

        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        protected decimal BasePay { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new employee instance.
        /// </summary>
        public Employee(int id, string name, string email, string dept, decimal basePay)
        {
            Id = id;
            Name = name;
            Email = email;
            Department = dept;
            BasePay = basePay;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Calculates the gross pay for the employee.
        /// </summary>
        public abstract decimal CalculateGrossPay();

        /// <summary>
        /// Validates employee data.
        /// </summary>
        public virtual bool Validate(out string error)
        {
            if (BasePay < 0)
            {
                error = "Base pay cannot be negative.";
                return false;
            }

            error = string.Empty;
            return true;
        }

        #endregion
    }

    #endregion
}