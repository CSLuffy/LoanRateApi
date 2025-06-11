using LoanRateAPI.Models;

namespace LoanRateAPI.Services
{
    public interface ILoanRateService
    {
        /// <summary>
        /// Gets loan rates based on optional filtering criteria.
        /// </summary>
        /// <param name="loanType">Optional: The type of loan to filter by.</param>
        /// <param name="term">Optional: The loan term in years to filter by.</param>
        /// <returns>A LoanRateResponse containing the filtered rates.</returns>
        Task<LoanRateResponse> GetRatesAsync(string? loanType, int? term);
    }
}
