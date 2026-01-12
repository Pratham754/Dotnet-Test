namespace PayRoll.Models
{
    #region Employee Base Class

    /// <summary>
    /// Base Abstract class defining the contract for all employee types.
    /// Includes base properties like Id, Name, Type and abstract methods for polymorphism.
    /// </summary>
    public abstract class Employee
    {
        #region Properties

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public string? Type { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Protected constructor to restrict direct object creation.
        /// Only child classes can call this.
        /// </summary>
        protected Employee(int id, string name, string department, string employeeType)
        {
            Id = id;
            Name = name;
            Department = department;
            Type = employeeType;
        }

        #endregion

        #region Abstract Methods

        /// <summary>
        /// Calculates the net pay after deductions.
        /// </summary>
        public abstract decimal CalculatePay();

        /// <summary>
        /// Polymorphic helper to get Gross pay.
        /// </summary>
        public abstract decimal GetGross();

        /// <summary>
        /// Polymorphic helper to get Deductions.
        /// </summary>
        public abstract decimal GetDeduction();

        #endregion
    }

    #endregion
}