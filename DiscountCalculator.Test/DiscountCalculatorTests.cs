using FluentAssertions;

namespace DiscountCalculator.Test
{
    [TestClass]
    public class DiscountCalculatorTests
    {
        private readonly DiscountCalculator.Core.DiscountCalculator calculator = new();

        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void CalculateDiscount_should_return_the_same_price_when_code_is_null_or_empty(string code)
        {
            // arrange
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

            // act
            decimal priceAfterDiscount = calculator.CalculateDiscount(price, code);

            // assert
            priceAfterDiscount.Should().Be(90M);

        }

        [TestMethod]
        public void CalculateDiscount_should_return_price_lower_by_20precent_when_passed_code_DISCOUNT20OFF()
        {
            // arrange
            string code = "DISCOUNT20OFF";
            decimal price = 100;

            // act
            decimal priceAfterDiscount = calculator.CalculateDiscount(price, code);

            // assert
            priceAfterDiscount.Should().Be(80M);

        }

        [TestMethod]
        public void CalculateDiscount_should_throw_ArgumentException_when_price_is_negative()
        {
            // arrange
            string code = "";
            decimal price = -100;

            // act
            var invokeCalculateDiscount = () => calculator.CalculateDiscount(price, code);

            // assert
            invokeCalculateDiscount.Should().ThrowExactly<ArgumentException>().WithMessage("Negatives not allowed");
            
        }

        [TestMethod]
        public void CalculateDiscount_should_throw_ArgumentException_when_code_is_invalid()
        {
            // arrange
            string code = "uieghesk";
            decimal price = 100;

            // act
            var invokeCalculateDiscount = () => calculator.CalculateDiscount(price, code);

            // assert
            invokeCalculateDiscount.Should().ThrowExactly<ArgumentException>().WithMessage("Invalid discount code");

        }

        [TestMethod]
        public void CalculateDiscount_should_return_price_lower_by_50precent_when_passed_fifty_off_code()
        {
            // arrange
            string code = "50OFFCODE";
            calculator.addFiftyOffCode(code);

            decimal price = 100;

            // act
            decimal priceAfterFirstDiscount = calculator.CalculateDiscount(price, code);

            // assert
            priceAfterFirstDiscount.Should().Be(50M);
        }

        [TestMethod]
        public void CalculateDiscount_should_throw_ArgumentException_when_50_off_code_used_multiple_times()
        {
            // arrange
            string code = "50OFFCODE";
            calculator.addFiftyOffCode(code);

            decimal price = 100;
            decimal priceAfterFirstDiscount = calculator.CalculateDiscount(price, code);

            // act
            var invokeCalculateDiscount = () => calculator.CalculateDiscount(price, code);

            // assert
            invokeCalculateDiscount.Should().ThrowExactly<ArgumentException>().WithMessage("Invalid discount code");
        }
    }
}