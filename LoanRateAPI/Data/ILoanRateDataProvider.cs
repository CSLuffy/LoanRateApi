using LoanRateAPI.Models;

namespace LoanRateAPI.Data
{
    public interface ILoanRateDataProvider
    {
        Task<List<LoanRate>> GetLoanRatesAsync(); // Asynchronously gets all available loan rates.
    }
}
