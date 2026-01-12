using System;
using System.Collections.Generic;
using PayRoll.Models;

namespace PayRoll.Services
{
    #region Payroll Engine

    /// <summary>
    /// Central brain of the system.
    /// Handles payroll calculation and multicasting notifications.
    /// </summary>
    public class PayrollEngine
    {
        #region Fields

        private readonly List<Employee> _employees;
        private readonly List<PaySlip> _paySlips = new();

        // Delegate: Using Action<T> for multicasting
        public Action<PaySlip>? SalaryProcessed;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor to inject the employees list.
        /// </summary>
        public PayrollEngine(List<Employee> employees)
        {
            _employees = employees;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Processes payroll for all employees.
        /// Uses Polymorphism for calculations and Delegates for notifications.
        /// </summary>
        public void ProcessPayroll()
        {
            foreach (Employee emp in _employees)
            {
                try 
                {
                    // Polymorphic implementation
                    decimal net = emp.CalculatePay(); 

                    // Creating payslip
                    PaySlip slip = new PaySlip(
                        emp.Id, 
                        emp.Name, 
                        emp.Type, 
                        emp.GetGross(), 
                        emp.GetDeduction(), 
                        net
                    );

                    // Adding payslip to list
                    _paySlips.Add(slip);

                    // Executing the delegate methods (Multicasting)
                    SalaryProcessed?.Invoke(slip);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Error] Could not process {emp.Name}: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Returns the generated payslips.
        /// </summary>
        public List<PaySlip> GetPaySlips() => _paySlips;

        #endregion
    }

    #endregion
}