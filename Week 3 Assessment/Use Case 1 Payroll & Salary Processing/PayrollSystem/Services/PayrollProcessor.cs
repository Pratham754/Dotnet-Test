using System;
using System.Collections.Generic;
using PayrollSystem.Models;
using PayrollSystem.Delegates;

namespace PayrollSystem.Services
{
    #region Payroll Processor

    /// <summary>
    /// Handles payroll calculation, tax deduction, and notification processing.
    /// </summary>
    public class PayrollProcessor
    {
        #region Fields

        private Dictionary<string, decimal> _departmentTaxRules;
        public SalaryProcessedHandler OnSalaryProcessed;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes payroll processor with default tax rules.
        /// </summary>
        public PayrollProcessor()
        {
            _departmentTaxRules = new Dictionary<string, decimal>
            {
                { "IT", 0.10m },
                { "HR", 0.08m },
                { "Finance", 0.12m },
                { "Admin", 0.05m }
            };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Processes a batch of employees and generates payslips.
        /// </summary>
        public List<PaySlip> ProcessBatch(List<Employee> employees)
        {
            var results = new List<PaySlip>();

            Console.WriteLine("Processing Payroll Batch...\n");

            foreach (var emp in employees)
            {
                // Validation
                if (!emp.Validate(out string errorMsg))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ERROR processing {emp.Name}: {errorMsg}");
                    Console.ResetColor();
                    continue;
                }

                // Gross pay calculation (polymorphism)
                decimal gross = emp.CalculateGrossPay();

                // Tax deduction
                decimal taxRate = _departmentTaxRules.ContainsKey(emp.Department)
                    ? _departmentTaxRules[emp.Department]
                    : 0.15m;

                decimal deduction = gross * taxRate;
                decimal net = gross - deduction;

                // Create payslip
                var slip = new PaySlip
                {
                    EmployeeId = emp.Id,
                    EmployeeName = emp.Name,
                    EmployeeType = emp.GetType().Name,
                    GrossPay = gross,
                    TaxDeduction = deduction,
                    NetPay = net,
                    ProcessedDate = DateTime.Now
                };

                results.Add(slip);

                // Fire notification delegate
                OnSalaryProcessed?.Invoke(slip);

                Console.WriteLine("--------------------------------------------------");
            }

            return results;
        }

        #endregion
    }

    #endregion
}