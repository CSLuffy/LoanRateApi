using LoanRateAPI.Models;

namespace LoanRateAPI.Data
{
    public class StaticLoanRateDataProvider : ILoanRateDataProvider
    {
        private readonly List<LoanRate> _rates =
        [
            // Owner-occupied loan rates
            new LoanRate { LoanType = "owner-occupied", Term = 30, InterestRate = 5.50m, ComparisonRate = 5.65m },
            new LoanRate { LoanType = "owner-occupied", Term = 20, InterestRate = 5.60m, ComparisonRate = 5.75m },
            new LoanRate { LoanType = "owner-occupied", Term = 30, InterestRate = 5.70m, ComparisonRate = 5.85m },
            // Investment loan rates
            new LoanRate { LoanType = "investment", Term = 15, InterestRate = 6.00m, ComparisonRate = 6.15m },
            new LoanRate { LoanType = "investment", Term = 20, InterestRate = 6.10m, ComparisonRate = 6.25m },
            new LoanRate { LoanType = "investment", Term = 30, InterestRate = 6.20m, ComparisonRate = 6.35m }
        ];

        /// <summary>
        /// Asynchronously retrieves a static list of loan rates.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation, containing a list of LoanRate objects.</returns>
        public Task<List<LoanRate>> GetLoanRatesAsync()
        {
            // Simulates an asynchronous operation (e.g., fetching from a database or external API).
            return Task.FromResult(_rates);
        }

    }
}
