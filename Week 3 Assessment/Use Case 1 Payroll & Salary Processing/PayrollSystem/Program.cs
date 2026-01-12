using System;
using PayRoll.Data;
using PayRoll.Services;
using PayRoll.Notifications;
using PayRoll.Models;

namespace PayRoll
{
    #region Program Entry Point

    /// <summary>
    /// Application entry point for the Payroll System.
    /// </summary>
    class Program
    {
        #region Main Method

        static void Main(string[] args)
        {
            Console.WriteLine("=== Starting Payroll System ===\n");

            // 1. Initialize Repository (Loads hardcoded data)
            EmployeeRepository repository = new EmployeeRepository();
            
            // Optional: Add test cases here using repository.AddEmp() if needed
            // var testList = new List<Employee> { ... };
            // repository.AddEmp(testList);

            // 2. Initialize Engine
            PayrollEngine engine = new PayrollEngine(repository.GetAllEmp());

            // 3. Subscribe to Notifications (Multicasting)
            engine.SalaryProcessed += NotificationHandlers.NotifyHR;
            engine.SalaryProcessed += NotificationHandlers.NotifyFinance;

            // 4. Process Payroll
            engine.ProcessPayroll();

            // 5. Display Final Report
            PrintReport(engine.GetPaySlips());
        }

        #endregion

        #region Reporting

        /// <summary>
        /// Prints the final payroll summary report.
        /// </summary>
        static void PrintReport(List<PaySlip> slips)
        {
            Console.WriteLine("\n=========== FINAL PAYROLL SUMMARY ===========");
            Console.WriteLine($"{"ID",-5} {"Name",-15} {"Type",-15} {"Net Pay",-10}");

            foreach(var slip in slips)
            {
                 Console.WriteLine($"{slip.Id,-5} {slip.Name,-15} {slip.Type,-15} {slip.Net,-10:C}");
            }
        }

        #endregion
    }

    #endregion
}