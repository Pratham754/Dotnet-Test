using System;

namespace Question2
{
    class MainProgram
    {
        #region Description
        
        static PatientBill? LastBill;
        static bool HasLastBill = false;
        #endregion

        #region Main Method
        static void Main()
        {
            int choice;

            do // Main menu loop
            {
                Console.Clear();
                Console.WriteLine("================== MediSure Clinic Billing ==================");
                Console.WriteLine("1. Create New Bill (Enter Patient Details)");
                Console.WriteLine("2. View Last Bill");
                Console.WriteLine("3. Clear Last Bill");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your option: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid option. Please enter a number.");
                    Console.ReadLine();
                    continue;
                }

                switch (choice) // Handle menu options
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
                        Console.WriteLine("Thank you. Application closed normally.");
                        break;
                    default:
                        Console.WriteLine("Invalid menu option. Try again.");
                        Console.ReadLine();
                        break;
                }

            } while (choice != 4);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates a new patient bill by taking user input.
        /// </summary>
        static void CreateBill()
        {
            Console.Write("Enter Bill Id: ");
            string billId = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(billId))
            {
                Console.WriteLine("Bill Id cannot be empty.");
                Console.ReadLine();
                return;
            }

            Console.Write("Enter Patient Name: ");
            string patientName = Console.ReadLine() ?? "";

            Console.Write("Is the patient insured? (Y/N): ");
            string insuranceInput = Console.ReadLine() ?? "";
            bool hasInsurance = insuranceInput.Equals("Y", StringComparison.OrdinalIgnoreCase);

            Console.Write("Enter Consultation Fee: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal consultationFee) || consultationFee <= 0)
            {
                Console.WriteLine("Consultation Fee must be greater than 0.");
                Console.ReadLine();
                return;
            }

            Console.Write("Enter Lab Charges: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal labCharges) || labCharges < 0)
            {
                Console.WriteLine("Lab Charges must be >= 0.");
                Console.ReadLine();
                return;
            }

            Console.Write("Enter Medicine Charges: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal medicineCharges) || medicineCharges < 0)
            {
                Console.WriteLine("Medicine Charges must be >= 0.");
                Console.ReadLine();
                return;
            }

            // Create and calculate the bill
            LastBill = new PatientBill
            {
                BillId = billId,
                PatientName = patientName,
                HasInsurance = hasInsurance,
                ConsultationFee = consultationFee,
                LabCharges = labCharges,
                MedicineCharges = medicineCharges
            };

            LastBill.CalculateBill();
            HasLastBill = true;

            Console.WriteLine("\nBill created successfully.");
            Console.WriteLine($"Gross Amount: {LastBill.GrossAmount:F2}");
            Console.WriteLine($"Discount Amount: {LastBill.DiscountAmount:F2}");
            Console.WriteLine($"Final Payable: {LastBill.FinalPayable:F2}");
            Console.WriteLine("------------------------------------------------------------");
            Console.ReadLine();
        }

        /// <summary>
        /// Displays the last bill details.
        /// </summary>
        static void ViewLastBill()
        {
            if (!HasLastBill)
            {
                Console.WriteLine("No bill available. Please create a new bill first.");
            }
            else
            {
                LastBill!.PrintBill();
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Clears the last bill details.
        /// </summary>
        static void ClearLastBill()
        {
            LastBill = null;
            HasLastBill = false;
            Console.WriteLine("Last bill cleared.");
            Console.ReadLine();
        }
        #endregion
    }
}
