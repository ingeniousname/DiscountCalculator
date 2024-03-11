using FluentAssertions;

namespace DiscountCalculator.Test
{
    [TestClass]
    public class DiscountCalculatorTests
    {
        DiscountCalculator.Core.DiscountCalculator calculator = new();

        [TestMethod]
        public void CalculateDiscount_should_return_the_same_price_when_code_is_null()
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

        [TestMethod]
        public void CalculateDiscount_should_throw_ArgumentException_when_price_is_negative()
        {
            // arrange
            string code = "";
            decimal price = -100;

            // act
            var f = () => calculator.CalculateDiscount(price, code);

            // assert
            f.Should().ThrowExactly<ArgumentException>().WithMessage("Negatives not allowed");
            
        }

        [TestMethod]
        public void CalculateDiscount_should_throw_ArgumentException_when_code_is_invalid()
        {
            // arrange
            string code = "uieghesk";
            decimal price = 100;

            // act
            var f = () => calculator.CalculateDiscount(price, code);

            // assert
            f.Should().ThrowExactly<ArgumentException>().WithMessage("Invalid discount code");

        }

        [TestMethod]
        public void CalculateDiscount_should_return_price_lower_by_50precent_when_used_for_the_first_time()
        {
            // arrange
            string code = "50OFFCODE";
            calculator.addFiftyOffCode(code);

            decimal price = 100;
            decimal coefficient1 = 0.5M;
            decimal coefficient2 = 1.0M;

            // act
            decimal priceAfterFirstDiscount = calculator.CalculateDiscount(price, code);
            decimal priceAfterSecondDiscount = calculator.CalculateDiscount(price, code);

            // assert
            priceAfterFirstDiscount.Should().Be(price * coefficient1);
            priceAfterSecondDiscount.Should().Be(price * coefficient2);

        }
    }
}