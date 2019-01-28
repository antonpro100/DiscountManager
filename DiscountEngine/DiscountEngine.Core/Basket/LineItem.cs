using System;

namespace DiscountEngine.Core.Basket
{
    public class LineItem
    {
        public LineItem(Product product, int count)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null");

            ProductId = product.Id;
            ProductName = product.Name;
            ProductPrice = product.Price;
            Count = count;
        }

        public string ProductId { get; }
        public string ProductName { get; }
        public decimal ProductPrice { get; }
        public int Count { get; set; }
        public decimal TotalPrice => ProductPrice * Count;
    }
}
