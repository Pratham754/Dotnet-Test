using System.Collections.Generic;
using PayRoll.Models;

namespace PayRoll.Data
{
    #region Employee Repository

    /// <summary>
    /// Repository class to manage Employee data storage.
    /// Simulates a database using a static list.
    /// </summary>
    public class EmployeeRepository
    {
        #region Fields

        // Static list: Shared across all instances to persist data
        private static List<Employee> _employees = new();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the repository with hardcoded seed data.
        /// </summary>
        public EmployeeRepository()
        {
            // Only populate if empty to prevent duplicates on re-initialization
            if (_employees.Count == 0)
            {
                // Department Tax Rules applied directly: IT=0.10, HR=0.08, Finance=0.12, Admin=0.05
                _employees.Add(new FullTimeEmployee(1, "Pratham", "IT", 5000, 0.10m, 0.10m));
                _employees.Add(new FullTimeEmployee(2, "Thiluck", "HR", 4000, 0.05m, 0.08m));
                
                // Contractors
                _employees.Add(new ContractEmployee(3, "Vishwajeet", "Admin", 50, 100));
                _employees.Add(new ContractEmployee(4, "Avishek", "IT", 80, 160));
                _employees.Add(new FullTimeEmployee(5, "Kamaljeet", "Finance", 6000, 0.02m, 0.12m));
                
                // Note: "Annu" (hours -10) is omitted to prevent Constructor Exception during initialization
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Retrieves all employees.
        /// </summary>
        public List<Employee> GetAllEmp()
        {
            return _employees;
        }

        /// <summary>
        /// Adds new employees to the existing list (for Test Cases).
        /// </summary>
        public void AddEmp(List<Employee> newEmployees)
        {
            _employees.AddRange(newEmployees);
        }

        #endregion
    }

    #endregion
}