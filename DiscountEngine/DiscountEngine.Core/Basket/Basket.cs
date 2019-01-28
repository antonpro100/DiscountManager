using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscountEngine.Core.Basket
{
    public class Basket : IBasket
    {
        public Basket()
        {
            LineItems = new List<LineItem>();
        }

        public IList<LineItem> LineItems { get;}

        public decimal GetTotalPrice()
        {
            return LineItems.Sum(l => l.TotalPrice);
        }

        public void AddProduct(Product product)
        {
            if(product == null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null");

            var productToAdd = LineItems.FirstOrDefault(l => l.ProductId == product.Id);
            if (productToAdd != null)
            {
                productToAdd.Count++;
            }
            else
            {
                LineItems.Add(new LineItem(product, 1));
            }
        }

        public void RemoveProduct(string productId)
        {
            if (productId == null)
                throw new ArgumentNullException(nameof(productId), "Product cannot be null");

            var productToRemove = LineItems.FirstOrDefault(l => l.ProductId == productId);
            if (productToRemove == null)
            {
                return;
            }

            if (productToRemove.Count > 1)
            {
                productToRemove.Count--;
            }
            else
            {
                LineItems.Remove(productToRemove);
            }
        }

        public void RemoveProductSet(string productId)
        {
            if (productId == null)
                throw new ArgumentNullException(nameof(productId), "Product cannot be null");
            var productToRemove = LineItems.FirstOrDefault(l => l.ProductId == productId);
            if (productToRemove == null)
            {
                return;
            }        
            LineItems.Remove(productToRemove);
        }

        public void ClearBasket()
        {
            LineItems.Clear();
        }
    }
}
