using DiscountEngine.Core.DiscountRules;
using System.Collections.Generic;
using DiscountEngine.Core.Basket;
using DiscountEngine.Core.ViewModels;

namespace DiscountEngine.Core
{
    public class BasketDiscountManager
    {
        private readonly IEnumerable<IDiscountRule> _discountRules;
        private readonly IBasket _basket;
        private decimal _discount;

        public BasketDiscountManager(IEnumerable<IDiscountRule> discountRule, IBasket basket)
        {
            _discountRules = discountRule;
            _basket = basket;
            _discount = 0;
        }

        public decimal CalculateDiscount()
        {
            foreach (var rule in _discountRules)
            {
                _discount += rule.CalculateDiscount(_basket);
            }

            return _discount;
        }

        public BasketViewModel Display()
        {            
            return new BasketViewModel
            {
                LineItems = _basket.LineItems,
                Discount = CalculateDiscount(),
                ProductsTotalPrice = _basket.GetTotalPrice(),
            };
        }
    }
}
