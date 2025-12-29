using System;

namespace Question2
{
    class MainProgram
    {
        #region State Management
        // Holds the reference to the most recent patient bill
        static PatientBill? LastBill;
        
        // Tracking flag to ensure we don't try to access null data
        static bool HasLastBill = false;
        #endregion

        #region Main Method
        static void Main()
        {
            int choice;

            do 
            {
                // UI Refresh for each menu interaction
                Console.Clear();
                Console.WriteLine("================== MediSure Clinic Billing ==================");
                Console.WriteLine("1. Create New Bill (Enter Patient Details)");
                Console.WriteLine("2. View Last Bill");
                Console.WriteLine("3. Clear Last Bill");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your option: ");

                // Validates that the user input is a number to prevent menu crashes
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid option. Please enter a numeric value.");
                    Console.ReadLine();
                    continue;
                }

                switch (choice) 
                {
                    case 1:
                        CreateBill();
                        break;
                    case 2:
                        ViewLastBill();
                        break;
                    case 3:
                        ClearLastBill();
                        break;
                    case 4:
                        Console.WriteLine("Thank you for using MediSure. Application closed.");
                        break;
                    default:
                        Console.WriteLine("Invalid menu choice. Please select 1-4.");
                        Console.ReadLine();
                        break;
                }

            } while (choice != 4);
        }
        #endregion

        #region Operational Logic
        /// <summary>
        /// Orchestrates the data collection and creation process for a PatientBill.
        /// </summary>
        static void CreateBill()
        {
            // 1. Identification Input
            Console.Write("Enter Bill Id: ");
            string billId = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(billId))
            {
                Console.WriteLine("Error: Bill Id is a required field.");
                Console.ReadLine();
                return;
            }

            Console.Write("Enter Patient Name: ");
            string patientName = Console.ReadLine() ?? "";

            // 2. Insurance Logic: Simple string check to determine discount eligibility later
            Console.Write("Is the patient insured? (Y/N): ");
            string insuranceInput = Console.ReadLine() ?? "";
            bool hasInsurance = insuranceInput.Equals("Y", StringComparison.OrdinalIgnoreCase);

            // 3. Financial Inputs with double-validation (Type check and Range check)
            Console.Write("Enter Consultation Fee: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal consultationFee) || consultationFee <= 0)
            {
                Console.WriteLine("Error: Consultation Fee must be a positive number.");
                Console.ReadLine();
                return;
            }

            Console.Write("Enter Lab Charges: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal labCharges) || labCharges < 0)
            {
                Console.WriteLine("Error: Lab Charges cannot be negative.");
                Console.ReadLine();
                return;
            }

            Console.Write("Enter Medicine Charges: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal medicineCharges) || medicineCharges < 0)
            {
                Console.WriteLine("Error: Medicine Charges cannot be negative.");
                Console.ReadLine();
                return;
            }

            // 4. Object Instantiation and Calculation
            LastBill = new PatientBill
            {
                BillId = billId,
                PatientName = patientName,
                HasInsurance = hasInsurance,
                ConsultationFee = consultationFee,
                LabCharges = labCharges,
                MedicineCharges = medicineCharges
            };

            // Trigger internal business logic calculations
            LastBill.CalculateBill();
            HasLastBill = true;

            // Immediate summary display
            Console.WriteLine("\n--- Billing Summary ---");
            Console.WriteLine($"Gross Amount:  {LastBill.GrossAmount:F2}");
            Console.WriteLine($"Discount:      {LastBill.DiscountAmount:F2}");
            Console.WriteLine($"Final Payable: {LastBill.FinalPayable:F2}");
            Console.WriteLine("------------------------");
            Console.ReadLine();
        }

        /// <summary>
        /// Retrieves and displays the bill stored in the current session.
        /// </summary>
        static void ViewLastBill()
        {
            if (!HasLastBill)
            {
                Console.WriteLine("No bill history found in current session.");
            }
            else
            {
                // The '!' tells the compiler we've already checked that LastBill is not null
                LastBill!.PrintBill();
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Resets the application state by removing the current bill reference.
        /// </summary>
        static void ClearLastBill()
        {
            LastBill = null;
            HasLastBill = false;
            Console.WriteLine("Patient billing record cleared successfully.");
            Console.ReadLine();
        }
        #endregion
    }
}