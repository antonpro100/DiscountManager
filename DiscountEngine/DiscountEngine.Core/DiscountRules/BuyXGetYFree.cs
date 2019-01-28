using System;
using DiscountEngine.Core.Basket;
using System.Linq;

namespace DiscountEngine.Core.DiscountRules
{
    public class BuyXGetYFree : IDiscountRule
    {
        private readonly Product _productToBuy;
        private readonly int _productToBuyCount;
        private readonly Product _freeProduct;
        private readonly int _freeProductCount;

        public BuyXGetYFree(Product productToBuy, int productToBuyCount, Product freeProduct, int freeProductCount)
        {
            _productToBuy = productToBuy;
            _productToBuyCount = productToBuyCount;
            _freeProduct = freeProduct;
            _freeProductCount = freeProductCount;
        }

        public decimal CalculateDiscount(IBasket basket)
        {
            if (basket == null)
                throw new ArgumentNullException(nameof(basket), "Product cannot be null");

            var product = basket.LineItems.FirstOrDefault(p => p.ProductId == _productToBuy.Id);
            var freeProduct = basket.LineItems.FirstOrDefault(l => l.ProductId == _freeProduct.Id);

            if (product == null || product.Count < _productToBuyCount || freeProduct == null)
                return 0;

            var discountsCount = product.Count / _productToBuyCount;

            discountsCount = freeProduct.Count > discountsCount ? discountsCount : freeProduct.Count;
            var discount = _freeProduct.Price * discountsCount * _freeProductCount;

            return discount;        
        }
    }
}
