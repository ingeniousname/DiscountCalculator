namespace DiscountCalculator.Core
{
    public class DiscountCalculator
    {
        HashSet<string> TenOffCodes = new HashSet<string>() { };
        HashSet<string> TwentyOffCodes = new HashSet<string>() { };

        public decimal CalculateDiscount(decimal price, string discountCode)
        {
            return price;
        }
    }
}
