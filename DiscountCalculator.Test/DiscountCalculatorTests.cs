using FluentAssertions;

namespace DiscountCalculator.Test
{
    [TestClass]
    public class DiscountCalculatorTests
    {
        DiscountCalculator.Core.DiscountCalculator calculator = new();

        [TestMethod]
        public void CalculateDiscount_should_not_discount_when_code_is_null()
        {
            // arrange
            string code = "";
            decimal price = 100;

            // act
            decimal priceAfterDiscount = calculator.CalculateDiscount(price, code);

            // assert
            priceAfterDiscount.Should().Be(price);  

        }
    }
}