namespace PayRoll.Models
{
    #region PaySlip Model

    /// <summary>
    /// Class having properties of Employee and their salary details.
    /// Represents the final calculated output.
    /// </summary>
    public class PaySlip
    {
        #region Properties

        public int Id { get; }
        public string? Name { get; }
        public string? Type { get; }
        public decimal Gross { get; }   // Total Pay before deduction
        public decimal Deduction { get; }   // Tax amount
        public decimal Net { get; }     // Total Pay after deduction

        #endregion

        #region Constructors

        /// <summary>
        /// Public constructor to assign values to PaySlip properties.
        /// </summary>
        public PaySlip(int id, string name, string type, decimal gross, decimal deduction, decimal net)
        {
            Id = id;
            Name = name;
            Type = type;
            Gross = gross;
            Deduction = deduction;
            Net = net;
        }

        #endregion
    }

    #endregion
}