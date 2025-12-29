using System;

namespace Question1
{
    /// <summary>
    /// Represents a single sales record and handles business logic for financial calculations.
    /// </summary>
    public class SaleTransaction
    {
        #region Properties
        // Basic transaction details
        public string? InvoiceNo { get; set; }
        public string CustomerName { get; set; } = "";
        public string ItemName { get; set; } = "";
        public int Quantity { get; set; }
        public decimal PurchaseAmount { get; set; }
        public decimal SellingAmount { get; set; }

        // Calculated financial fields
        public string ProfitOrLossStatus { get; set; } = "";
        public decimal ProfitOrLossAmount { get; set; }
        public decimal ProfitMarginPercent { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Analyzes the purchase and selling amounts to determine financial performance.
        /// </summary>
        public void CalculateProfitOrLoss()
        {
            // Case 1: Selling price is higher than cost price
            if (SellingAmount > PurchaseAmount)
            {
                ProfitOrLossStatus = "PROFIT";
                ProfitOrLossAmount = SellingAmount - PurchaseAmount;
            }
            // Case 2: Selling price is lower than cost price
            else if (SellingAmount < PurchaseAmount)
            {
                ProfitOrLossStatus = "LOSS";
                // We calculate the absolute difference for the 'Amount' field
                ProfitOrLossAmount = PurchaseAmount - SellingAmount;
            }
            // Case 3: Prices are equal
            else
            {
                ProfitOrLossStatus = "BREAK-EVEN";
                ProfitOrLossAmount = 0;
            }

            // Margin Calculation: (Difference / Cost) * 100
            // Tertiary check prevents "Division by Zero" error if PurchaseAmount is 0
            ProfitMarginPercent = PurchaseAmount > 0
                ? (ProfitOrLossAmount / PurchaseAmount) * 100
                : 0;
        }

        /// <summary>
        /// Outputs the transaction report to the console window.
        /// </summary>
        public void PrintTransaction()
        {
            Console.WriteLine("-------------- Last Transaction --------------");
            Console.WriteLine($"Invoice No: {InvoiceNo}");
            Console.WriteLine($"Customer: {CustomerName}");
            Console.WriteLine($"Item: {ItemName}");
            Console.WriteLine($"Quantity: {Quantity}");

            // :F2 format specifier ensures the currency is shown with 2 decimal places
            Console.WriteLine($"Purchase Amount: {PurchaseAmount:F2}");
            Console.WriteLine($"Selling Amount: {SellingAmount:F2}");
            
            // Visual feedback on the financial outcome
            Console.WriteLine($"Status: {ProfitOrLossStatus}");
            Console.WriteLine($"Profit/Loss Amount: {ProfitOrLossAmount:F2}");
            Console.WriteLine($"Profit Margin (%): {ProfitMarginPercent:F2}%");
            Console.WriteLine("--------------------------------------------");
        }
        #endregion
    }
}