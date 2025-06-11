namespace LoanRateAPI.Models
{
    public class LoanRateResponse
    {
        public List<LoanRate> Rates { get; set; } = new List<LoanRate>(); // List of loan rates
        public string Message { get; set; } = "Successfully retrieved loan rates."; // A message for the client

    }
}
