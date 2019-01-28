using DiscountEngine.Core.Basket;
using DiscountEngine.Core.DiscountRules;
using System.Collections.Generic;

namespace DiscountEngine.Tests
{
    public static class TestData
    {
        public static Product ProductOne => new Product
        {
            Id = "RP-5NS-DITB",
            Name = "Shurikens",
            Description = "5 pointed Shurikens made from stainless steel.",
            Price = 8.95m
        };

        public static Product ProductTwo => new Product
        {
            Id = "RP-25D-SITB",
            Name = "Bag of Pogs",
            Description = "25 Random pogs designs",
            Price = 5.31m
        };

        public static Product ProductThree => new Product
        {
            Id = "RP-1TB-EITB",
            Name = "Large bowl of Trifle",
            Description = "Large collectors edition bowl of Trifle.",
            Price = 2.75m
        };

        public static Product ProductFour => new Product
        {
            Id = "RP-RPM-FITB",
            Name = "Paper Mask",
            Description = "Randomly selected paper mask.",
            Price = 0.30m
        };

        public static List<IDiscountRule> AvailableDiscountRules => new List<IDiscountRule>
        {
            new BuyXDiscount(ProductTwo, 1, 50),
            new BuyXGetYFree(ProductThree, 1, ProductFour, 1),
            new BuyXDiscountTotal(ProductOne, 5, 30),
        };
    }
}
