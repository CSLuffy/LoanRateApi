namespace LoanRateAPI.Models
{
    public class LoanRate
    {
        public string LoanType { get; set; } = string.Empty; // Type of loan (e.g., owner-occupied, investment)
        public int Term { get; set; } // Loan term in years
        public decimal InterestRate { get; set; } // The interest rate for the loan
        public decimal ComparisonRate { get; set; } // The comparison rate for the loan

    }
}
