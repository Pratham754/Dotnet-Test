using System;

namespace Question1
{
    class Program
    {
        #region State Variables
        // Holds the data for the most recent transaction; nullable in case no transaction exists yet
        static SaleTransaction? LastTransaction;
        
        // A flag to quickly check if a transaction has been created in the current session
        static bool HasLastTransaction = false;
        #endregion

        #region Main Method
        static void Main()
        {
            int choice;

            // Main menu loop: keeps the application running until the user selects 'Exit'
            do
            {
                Console.Clear();
                Console.WriteLine("================== QuickMart Traders ==================");
                Console.WriteLine("1. Create New Transaction");
                Console.WriteLine("2. View Last Transaction");
                Console.WriteLine("3. Calculate Profit/Loss");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your option: ");

                // Validate that the input is an integer to prevent crashes
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                    Console.ReadLine();
                    continue;
                }

                // Route the user to the appropriate method based on their choice
                switch (choice) 
                {
                    case 1:
                        CreateTransaction();
                        break;
                    case 2:
                        ViewLastTransaction();
                        break;
                    case 3:
                        CalculateProfitOrLoss();
                        break;
                    case 4:
                        Console.WriteLine("Thank you. Application closed normally.");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

            } while (choice != 4); 
        }
        #endregion

        #region Operational Methods
        /// <summary>
        /// Collects transaction data from the user and instantiates a SaleTransaction object.
        /// </summary>
        static void CreateTransaction()
        {
            // Gather basic string data with null-coalescing to ensure no null values
            Console.Write("Enter Invoice No: ");
            string invoiceNo = Console.ReadLine() ?? "";

            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine() ?? "";

            Console.Write("Enter Item Name: ");
            string itemName = Console.ReadLine() ?? "";

            // Validate Quantity: must be a number and greater than zero
            Console.Write("Enter Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Error: Quantity must be a positive whole number.");
                Console.ReadLine();
                return;
            }

            // Validate Purchase Amount: must be a decimal and greater than zero
            Console.Write("Enter Purchase Amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal purchaseAmount) || purchaseAmount <= 0)
            {
                Console.WriteLine("Error: Purchase amount must be a positive numeric value.");
                Console.ReadLine();
                return;
            }

            // Validate Selling Amount
            Console.Write("Enter Selling Amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal sellingAmount))
            {
                Console.WriteLine("Error: Selling amount must be a numeric value.");
                Console.ReadLine();
                return;
            }

            // Object Initialization: Create and store the new transaction in memory
            LastTransaction = new SaleTransaction
            {
                InvoiceNo = invoiceNo,
                CustomerName = customerName,
                ItemName = itemName,
                Quantity = quantity,
                PurchaseAmount = purchaseAmount,
                SellingAmount = sellingAmount
            };

            // Calculate business logic immediately upon creation
            LastTransaction.CalculateProfitOrLoss();
            HasLastTransaction = true; // Set flag so other methods know data is available

            Console.WriteLine("Transaction saved successfully. Press Enter to return to menu.");
            Console.ReadLine();
        }

        /// <summary>
        /// Displays the stored transaction details if available.
        /// </summary>
        static void ViewLastTransaction()
        {
            // Defensive check: ensure data exists before attempting to print
            if (!HasLastTransaction)
                Console.WriteLine("No transaction history found. Please create one first.");
            else
                LastTransaction!.PrintTransaction();

            Console.ReadLine();
        }

        /// <summary>
        /// Recalculates and prints the profit/loss status of the current transaction.
        /// </summary>
        static void CalculateProfitOrLoss()
        {
            if (!HasLastTransaction)
            {
                Console.WriteLine("No transaction available for calculation.");
            }
            else
            {
                // Ensure calculations are up to date before printing
                LastTransaction!.CalculateProfitOrLoss();
                LastTransaction.PrintTransaction();
            }

            Console.ReadLine();
        }
        #endregion
    }
}