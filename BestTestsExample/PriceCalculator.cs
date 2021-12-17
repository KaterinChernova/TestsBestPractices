namespace BestTestsExample
{
    public class PriceCalculator : IPriceCalculator
    {
        public int GetDiscountedPrice(int price)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
            {
                return price / 2;
            }
            else
            {
                return price;
            }
        }

        public int GetDiscountedPrice(int price, IDateTimeProvider dateTimeProvider)
        {
            if (dateTimeProvider.DayOfWeek() == DayOfWeek.Tuesday)
            {
                return price / 2;
            }
            else
            {
                return price;
            }
        }
    }
}
