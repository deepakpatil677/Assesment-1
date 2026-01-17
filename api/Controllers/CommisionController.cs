using Microsoft.AspNetCore.Mvc;

namespace AvalphaTechnologies.CommissionCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommisionController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(CommissionCalculationResponse), 200)]
        [ProducesResponseType(400)]
        public IActionResult Calculate(CommissionCalculationRequest calculationRequest)
        {
            if (calculationRequest == null)
                return BadRequest("Request cannot be null.");

            if (calculationRequest.LocalSalesCount < 0 ||
                calculationRequest.ForeignSalesCount < 0 ||
                calculationRequest.AverageSaleAmount < 0)
            {
                return BadRequest("Inputs must be non-negative values.");
            }

            // Avalpha commission
            decimal avalphaLocal =
                calculationRequest.LocalSalesCount * calculationRequest.AverageSaleAmount * 0.20m;

            decimal avalphaForeign =
                calculationRequest.ForeignSalesCount * calculationRequest.AverageSaleAmount * 0.35m;

            decimal avalphaTotal = avalphaLocal + avalphaForeign;

            // Competitor commission
            decimal competitorLocal =
                calculationRequest.LocalSalesCount * calculationRequest.AverageSaleAmount * 0.02m;

            decimal competitorForeign =
                calculationRequest.ForeignSalesCount * calculationRequest.AverageSaleAmount * 0.0755m;

            decimal competitorTotal = competitorLocal + competitorForeign;

            var response = new CommissionCalculationResponse
            {
                AvalphaTechnologiesCommissionAmount = avalphaTotal,
                CompetitorCommissionAmount = competitorTotal
            };

            return Ok(response);
        }

    }

    public class CommissionCalculationRequest
    {
        public int LocalSalesCount { get; set; }
        public int ForeignSalesCount { get; set; }
        public decimal AverageSaleAmount { get; set; }
    }

    public class CommissionCalculationResponse
    {
        public decimal AvalphaTechnologiesCommissionAmount { get; set; }

        public decimal CompetitorCommissionAmount { get; set; }
    }
}
