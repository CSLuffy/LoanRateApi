using LoanRateAPI.Data;
using LoanRateAPI.Models;

namespace LoanRateAPI.Services
{
    /// <summary>
    /// Constructor for LoanRateService, injecting the data provider dependency.
    /// Adheres to DIP.
    /// </summary>
    /// <param name="dataProvider">The data provider for loan rates.</param>
    public class LoanRateService(ILoanRateDataProvider dataProvider) : ILoanRateService
    {
        private readonly ILoanRateDataProvider _dataProvider = dataProvider;

        /// <summary>
        /// Asynchronously gets loan rates based on optional filtering criteria.
        /// </summary>
        /// <param name="loanType">Optional: The type of loan to filter by.</param>
        /// <param name="term">Optional: The loan term in years to filter by.</param>
        /// <returns>A LoanRateResponse containing the filtered rates.</returns>
        public async Task<LoanRateResponse> GetRatesAsync(string? loanType, int? term)
        {
            // Fetch all rates from the data provider.
            var allRates = await _dataProvider.GetLoanRatesAsync();
            var filteredRates = allRates.AsEnumerable(); // Start with all rates

            // Apply filters if provided.
            if (!string.IsNullOrWhiteSpace(loanType))
            {
                filteredRates = filteredRates.Where(r => r.LoanType.Equals(loanType, StringComparison.OrdinalIgnoreCase));
            }

            if (term.HasValue)
            {
                filteredRates = filteredRates.Where(r => r.Term == term.Value);
            }

            // Return a response object with the filtered rates.
            return new LoanRateResponse
            {
                Rates = filteredRates.ToList(),
                Message = filteredRates.Any() ? "Successfully retrieved matching loan rates." : "No loan rates found for the given criteria."
            };
        }
    }
}
