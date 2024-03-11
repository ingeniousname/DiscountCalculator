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

        [TestMethod]
        public void CalculateDiscount_should_return_price_lower_by_10precent_when_passed_code_SAVE10NOW()
        {
            // arrange
            string code = "SAVE10NOW";
            decimal price = 100;
            decimal coefficient = 0.9M;

            // act
            decimal priceAfterDiscount = calculator.CalculateDiscount(price, code);

            // assert
            priceAfterDiscount.Should().Be(price * coefficient);

        }

        [TestMethod]
        public void CalculateDiscount_should_return_price_lower_by_20precent_when_passed_code_DISCOUNT20OFF()
        {
            // arrange
            string code = "DISCOUNT20OFF";
            decimal price = 100;
            decimal coefficient = 0.8M;

            // act
            decimal priceAfterDiscount = calculator.CalculateDiscount(price, code);

            // assert
            priceAfterDiscount.Should().Be(price * coefficient);

        }
    }
}