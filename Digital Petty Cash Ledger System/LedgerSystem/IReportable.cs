namespace LedgerSystem
{
    /// <summary>
    /// Defines a contract for objects that can provide a string-based summary report.
    /// Any class that implements this interface must provide an implementation for the GetSummary() method.
    /// </summary>
    public interface IReportable
    {
        string GetSummary();
    }
}