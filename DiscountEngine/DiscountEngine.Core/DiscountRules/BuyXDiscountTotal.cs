using System;
using DiscountEngine.Core.Basket;
using System.Linq;


namespace DiscountEngine.Core.DiscountRules
{
    public class BuyXDiscountTotal : IDiscountRule
    {
        private readonly Product _productToBuy;
        private readonly int _productToBuyCount;
        private readonly decimal _discountPercent;


        public BuyXDiscountTotal(Product productToBuy, int productToBuyCount, decimal discountPercent)
        {
            _productToBuy = productToBuy;
            _productToBuyCount = productToBuyCount;
            _discountPercent = discountPercent;
        }

        public decimal CalculateDiscount(IBasket basket)
        {
            if (basket == null)
                throw new ArgumentNullException(nameof(basket), "Product cannot be null");

            var product = basket.LineItems.FirstOrDefault(p => p.ProductId == _productToBuy.Id);

            if (product == null || product.Count < _productToBuyCount)
                return 0;

            var discoupt = basket.GetTotalPrice() * (_discountPercent / 100);

            return discoupt;
        }
    }
}
