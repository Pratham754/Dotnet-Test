using System;
using System.Collections.Generic;
using PayrollSystem.Models;
using PayrollSystem.Services;

namespace PayrollSystem
{
    #region Program Entry Point

    /// <summary>
    /// Application entry point for the Payroll System.
    /// </summary>
    class Program
    {
        #region Main Method

        /// <summary>
        /// Starts payroll processing execution.
        /// </summary>
        static void Main(string[] args)
        {
            // Create sample employee data
            List<Employee> employees = new List<Employee>
            {
                new FullTimeEmployee(1, "Pratham",      "pratham@test.com",     "IT",       5000,   0.10m),
                new FullTimeEmployee(2, "Thiluck",      "thiluck@test.com",     "HR",       4000,   0.05m),
                new ContractEmployee(3, "Vishwajeet",   "vishwajeet@test.com",  "Admin",    50,     100),
                new ContractEmployee(4, "Avishek",      "avishek@test.com",     "IT",       80,     160),
                new ContractEmployee(9, "Annu",         "annu@test.com",        "IT",       50,     -10),
                new FullTimeEmployee(5, "Kamaljeet",    "kamaljeet@test.com",   "Finance",  6000,   0.02m)
            };

            // Initialize services
            
            PayrollProcessor processor = new PayrollProcessor();
            NotificationService notifier = new NotificationService();

            // Subscribe to salary processed notifications
            processor.OnSalaryProcessed += notifier.NotifyHR;
            processor.OnSalaryProcessed += notifier.NotifyFinance;

            // Execute payroll processing
            List<PaySlip> finalSlips = processor.ProcessBatch(employees);

            // Display final report
            PrintReport(finalSlips);

        }

        #endregion

        #region Reporting

        /// <summary>
        /// Prints the final payroll summary report.
        /// </summary>
        static void PrintReport(List<PaySlip> slips)
        {
            Console.WriteLine("\n=========== FINAL PAYROLL SUMMARY ===========");
            Console.WriteLine($"{"ID",-5} {"Name",-15} {"Type",-18} {"Net Pay",-10}");

            decimal totalPaid = 0;

            foreach (var s in slips)
            {
                Console.WriteLine(
                    $"{s.EmployeeId,-5} {s.EmployeeName,-15} {s.EmployeeType,-18} {s.NetPay,-10:C}");
                totalPaid += s.NetPay;
            }

            Console.WriteLine("=======================================");
            Console.WriteLine($"Total Payout: {totalPaid:C}");
            Console.WriteLine($"Total Processed: {slips.Count}");
        }

        #endregion
    }

    #endregion
}
