using System;

namespace Question2
{
    /// <summary>
    /// Represents a patient's medical bill and handles the calculation of insurance discounts.
    /// </summary>
    public class PatientBill
    {
        #region Properties
        // Auto-implemented properties for patient and bill identification
        public string BillId { get; set; } = "";
        public string PatientName { get; set; } = "";
        public bool HasInsurance { get; set; } // Boolean flag to trigger discount logic

        // Input fee components
        public decimal ConsultationFee { get; set; }
        public decimal LabCharges { get; set; }
        public decimal MedicineCharges { get; set; }

        // Output calculation components
        public decimal GrossAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalPayable { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Performs the arithmetic required to generate the final bill totals.
        /// </summary>
        public void CalculateBill()
        {
            // Sum all individual charges to get the base total
            GrossAmount = ConsultationFee + LabCharges + MedicineCharges;

            // Business Rule: Insured patients receive a 10% discount on the total gross
            if (HasInsurance)
            {
                // 'm' suffix indicates a decimal literal in C#
                DiscountAmount = GrossAmount * 0.10m; 
            }
            else
            {
                DiscountAmount = 0;
            }

            // The actual amount the patient needs to pay
            FinalPayable = GrossAmount - DiscountAmount;
        }

        /// <summary>
        /// Outputs a formatted medical invoice to the console.
        /// </summary>
        public void PrintBill()
        {
            Console.WriteLine("----------- Patient Medical Bill -----------");
            Console.WriteLine($"Bill ID:    {BillId}");
            Console.WriteLine($"Patient:    {PatientName}");
            
            // Using a ternary operator to display "Yes" or "No" instead of "True" or "False"
            Console.WriteLine($"Insured:    {(HasInsurance ? "Yes" : "No")}");
            
            Console.WriteLine("--------------------------------------------");
            
            // :F2 ensures two decimal places for currency consistency
            Console.WriteLine($"Consultation: {ConsultationFee,15:F2}");
            Console.WriteLine($"Lab Charges:  {LabCharges,15:F2}");
            Console.WriteLine($"Medicines:    {MedicineCharges,15:F2}");
            
            Console.WriteLine("--------------------------------------------");
            
            Console.WriteLine($"Gross Total:  {GrossAmount,15:F2}");
            Console.WriteLine($"Discount:    -{DiscountAmount,15:F2}");
            Console.WriteLine($"TOTAL DUE:    {FinalPayable,15:F2}");
            
            Console.WriteLine("--------------------------------------------");
        }
        #endregion
    }
}