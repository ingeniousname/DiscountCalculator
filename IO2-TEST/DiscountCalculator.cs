namespace DiscountCalculator.Core
{
    public class DiscountCalculator
    {
        HashSet<string> TenOffCodes = new HashSet<string>() { "SAVE10NOW"};
        HashSet<string> TwentyOffCodes = new HashSet<string>() { };

        public decimal CalculateDiscount(decimal price, string discountCode)
        {
            if (TenOffCodes.Contains(discountCode))
                return price * 0.9M;
            return price;
        }
    }
}
