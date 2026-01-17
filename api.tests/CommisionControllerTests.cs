using AvalphaTechnologies.CommissionCalculator.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AvalphaTechnologies.CommissionCalculator.Tests
{
    public class CommisionControllerTests
    {
        [Fact]
        public void Calculate_ValidInput_ReturnsCorrectCommission()
        {
            // Arrange
            var controller = new CommisionController();

            var request = new CommissionCalculationRequest
            {
                LocalSalesCount = 10,
                ForeignSalesCount = 10,
                AverageSaleAmount = 100
            };

            // Act
            var result = controller.Calculate(request) as OkObjectResult;

            // Assert
            Assert.NotNull(result);

            var response = Assert.IsType<CommissionCalculationResponse>(result.Value);

            // Avalpha: (10 * 100 * 0.20) + (10 * 100 * 0.35) = 200 + 350 = 550
            Assert.Equal(550m, response.AvalphaTechnologiesCommissionAmount);

            // Competitor: (10 * 100 * 0.02) + (10 * 100 * 0.0755) = 20 + 75.5 = 95.5
            Assert.Equal(95.5m, response.CompetitorCommissionAmount);
        }

        [Fact]
        public void Calculate_NegativeInput_ReturnsBadRequest()
        {
            // Arrange
            var controller = new CommisionController();

            var request = new CommissionCalculationRequest
            {
                LocalSalesCount = -1,
                ForeignSalesCount = 5,
                AverageSaleAmount = 100
            };

            // Act
            var result = controller.Calculate(request);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
