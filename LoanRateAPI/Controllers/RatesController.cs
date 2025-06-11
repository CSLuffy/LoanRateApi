using LoanRateAPI.Models;
using LoanRateAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoanRateAPI.Controllers
{
    /// <summary>
    /// Constructor for RatesController, injecting the loan rate service dependency.
    /// Adheres to DIP.
    /// </summary>
    /// <param name="loanRateService">The service for retrieving and filtering loan rates.</param>
    [ApiController]
    [Route("api/[controller]")]
    public class RatesController(ILoanRateService loanRateService) : ControllerBase
    {
        private readonly ILoanRateService _loanRateService = loanRateService;

        /// <summary>
        /// GET /api/rates endpoint to retrieve loan rates.
        /// Filters rates based on optional loanType and term query parameters.
        /// </summary>
        /// <param name="loanType">Optional query parameter: 'owner-occupied' or 'investment'.</param>
        /// <param name="term">Optional query parameter: Loan term in years (e.g., 15, 20, 30).</param>
        /// <returns>An ActionResult containing a LoanRateResponse object.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(LoanRateResponse), StatusCodes.Status200OK)] // Document successful response type.
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Document bad request response.
        public async Task<ActionResult<LoanRateResponse>> GetRates(
            [FromQuery] string? loanType,
            [FromQuery] int? term)
        {
            // Basic validation for loanType
            if (!string.IsNullOrWhiteSpace(loanType) && loanType != "owner-occupied" && loanType != "investment")
            {
                return BadRequest(new { Message = "Invalid loanType. Must be 'owner-occupied' or 'investment'." });
            }

            // Basic validation for term
            if (term.HasValue && (term.Value <= 0 || (term.Value % 5 != 0 && term.Value != 15 && term.Value != 20 && term.Value != 30)))
            {
                return BadRequest(new { Message = "Invalid term. Must be a positive integer, typically 15, 20, or 30 for these mock rates." });
            }

            // Delegate business logic to the service layer.
            var response = await _loanRateService.GetRatesAsync(loanType, term);

            // Return OK with the response object.
            return Ok(response);
        }
    }
}
