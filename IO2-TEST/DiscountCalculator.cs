namespace DiscountCalculator.Core
{
    public class DiscountCalculator
    {
        HashSet<string> TenOffCodes = new HashSet<string>() { "SAVE10NOW"};
        HashSet<string> TwentyOffCodes = new HashSet<string>() { "DISCOUNT20OFF" };

        public decimal CalculateDiscount(decimal price, string discountCode)
        {
            if (price < 0)
                throw new ArgumentException("Negatives not allowed");

            if (string.IsNullOrEmpty(discountCode))
                return price;

            if (TenOffCodes.Contains(discountCode))
                return price * 0.9M;
            else if (TwentyOffCodes.Contains(discountCode))
                return price * 0.8M;
            else throw new ArgumentException("Invalid discount code");
        }   
    }
}
