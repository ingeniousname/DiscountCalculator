namespace DiscountCalculator.Core
{
    public class DiscountCalculator
    {
        HashSet<string> TenOffCodes = new HashSet<string>() { "SAVE10NOW" };
        HashSet<string> TwentyOffCodes = new HashSet<string>() { "DISCOUNT20OFF" };
        HashSet<string> FiftyOffCodes = new HashSet<string>();

        public decimal CalculateDiscount(decimal price, string discountCode)
        {
            if (price < 0)
                throw new ArgumentException("Negatives not allowed");

            if (string.IsNullOrEmpty(discountCode))
                return price;

            decimal discountedPrice = price;
            if(FiftyOffCodes.Contains(discountCode))
            {
                FiftyOffCodes.Remove(discountCode);
                discountedPrice *= 0.5M;
            }
            else if (TenOffCodes.Contains(discountCode))
                discountedPrice *= 0.9M;
            else if (TwentyOffCodes.Contains(discountCode))
                discountedPrice *= 0.8M;
            else throw new ArgumentException("Invalid discount code");

            return discountedPrice;
        }

        public void addFiftyOffCode(string fiftyOffCode) 
        {
            FiftyOffCodes.Add(fiftyOffCode);
        }
    }
}
