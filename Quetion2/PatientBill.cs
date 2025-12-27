using System;

namespace Question2
{
    public class PatientBill
    {
        #region Description
        public string BillId { get; set; } = "";
        public string PatientName { get; set; } = "";
        public bool HasInsurance { get; set; }

        public decimal ConsultationFee { get; set; }
        public decimal LabCharges { get; set; }
        public decimal MedicineCharges { get; set; }

        public decimal GrossAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalPayable { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Calculates the bill amounts.
        /// </summary>
        public void CalculateBill()
        {
            GrossAmount = ConsultationFee + LabCharges + MedicineCharges; // Total before discount

            if (HasInsurance)
                DiscountAmount = GrossAmount * 0.10m;
            else
                DiscountAmount = 0;

            FinalPayable = GrossAmount - DiscountAmount; // Total after discount
        }

        /// <summary>
        /// Prints the bill details.
        /// </summary>
        public void PrintBill()
        {
            Console.WriteLine("----------- Last Bill -----------");
            Console.WriteLine($"BillId: {BillId}");
            Console.WriteLine($"Patient: {PatientName}");
            Console.WriteLine($"Insured: {(HasInsurance ? "Yes" : "No")}");
            Console.WriteLine($"Consultation Fee: {ConsultationFee:F2}");
            Console.WriteLine($"Lab Charges: {LabCharges:F2}");
            Console.WriteLine($"Medicine Charges: {MedicineCharges:F2}");
            Console.WriteLine($"Gross Amount: {GrossAmount:F2}");
            Console.WriteLine($"Discount Amount: {DiscountAmount:F2}");
            Console.WriteLine($"Final Payable: {FinalPayable:F2}");
            Console.WriteLine("--------------------------------");
        }
        #endregion
    }
}
