using DiscountEngine.Core.Basket;

namespace DiscountEngine.Core.DiscountRules
{
    public interface IDiscountRule
    {
        decimal CalculateDiscount(IBasket basket);
    } 
}
