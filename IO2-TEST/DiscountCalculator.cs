namespace DiscountCalculator.Core
{
    public class DiscountCalculator
    {
        HashSet<string> TenOffCodes = new HashSet<string>() { "SAVE10NOW"};
        HashSet<string> TwentyOffCodes = new HashSet<string>() { "DISCOUNT20OFF" };

        public decimal CalculateDiscount(decimal price, string discountCode)
        {
            if (TenOffCodes.Contains(discountCode))
                return price * 0.9M;
            if (TwentyOffCodes.Contains(discountCode))
                return price * 0.8M;
            return price;
        }
    }
}
