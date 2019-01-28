using System.Collections.Generic;

namespace DiscountEngine.Core.Basket
{
    public interface IBasket
    {
        IList<LineItem> LineItems { get; }

        decimal GetTotalPrice();
        void AddProduct(Product product);
        void RemoveProduct(string productId);
        void RemoveProductSet(string productId);
        void ClearBasket();
    }
}
