using System.Collections.Generic;
using DiscountEngine.Core.Basket;

namespace DiscountEngine.Core.ViewModels
{
    public class BasketViewModel
    {
        public BasketViewModel()
        {
            LineItems = new List<LineItem>();
        }

        public IList<LineItem> LineItems { get; set; }
        public decimal ProductsTotalPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice => ProductsTotalPrice - Discount;
    }
}
