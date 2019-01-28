using DiscountEngine.Core.Basket;
using DiscountEngine.Core.DiscountRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiscountEngine.Tests.DiscountRulesTests
{
    [TestClass]
    public class BuyXGetYFreeTests
    {
        [TestMethod]
        public void CalculateDiscount_Test1()
        {
            //Arrange
            var basket = new Basket();
            basket.AddProduct(TestData.ProductThree);
            basket.AddProduct(TestData.ProductFour);
            var discountRule = new BuyXGetYFree(TestData.ProductThree, 1, TestData.ProductFour, 1);
            var expectedResult = TestData.ProductFour.Price;

            //Action
            var result = discountRule.CalculateDiscount(basket);

            //Asset
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CalculateDiscount_Test2()
        {
            //Arrange
            var basket = new Basket();
            basket.AddProduct(TestData.ProductThree);
            basket.AddProduct(TestData.ProductThree);
            basket.AddProduct(TestData.ProductFour);
            basket.AddProduct(TestData.ProductFour);
            var discountRule = new BuyXGetYFree(TestData.ProductThree, 1, TestData.ProductFour, 1);
            var expectedResult = TestData.ProductFour.Price * 2;

            //Action
            var result = discountRule.CalculateDiscount(basket);

            //Asset
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CalculateDiscount_Test3()
        {
            //Arrange
            var basket = new Basket();
            basket.AddProduct(TestData.ProductThree);
            basket.AddProduct(TestData.ProductThree);
            basket.AddProduct(TestData.ProductFour);
            var discountRule = new BuyXGetYFree(TestData.ProductThree, 1, TestData.ProductFour, 1);
            var expectedResult = TestData.ProductFour.Price;

            //Action
            var result = discountRule.CalculateDiscount(basket);

            //Asset
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CalculateDiscount_Test4()
        {
            //Arrange
            var basket = new Basket();
            basket.AddProduct(TestData.ProductThree);
            basket.AddProduct(TestData.ProductThree);
            basket.AddProduct(TestData.ProductThree);
            basket.AddProduct(TestData.ProductFour);
            var discountRule = new BuyXGetYFree(TestData.ProductThree, 2, TestData.ProductFour, 1);
            var expectedResult = TestData.ProductFour.Price;

            //Action
            var result = discountRule.CalculateDiscount(basket);

            //Asset
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CalculateDiscount_Test5()
        {
            //Arrange
            var basket = new Basket();
            basket.AddProduct(TestData.ProductThree);
            basket.AddProduct(TestData.ProductThree);
            basket.AddProduct(TestData.ProductThree);
            basket.AddProduct(TestData.ProductFour);
            var discountRule = new BuyXGetYFree(TestData.ProductThree, 2, TestData.ProductFour, 1);
            var expectedResult = TestData.ProductFour.Price; 
            //Action
            var result = discountRule.CalculateDiscount(basket);

            //Asset
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CalculateDiscount_Test6()
        {
            //Arrange
            var basket = new Basket();
            basket.AddProduct(TestData.ProductThree);
            basket.AddProduct(TestData.ProductThree);
            var discountRule = new BuyXGetYFree(TestData.ProductThree, 2, TestData.ProductFour, 1);
            var expectedResult = 0;

            //Action
            var result = discountRule.CalculateDiscount(basket);

            //Asset
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CalculateDiscount_Test7()
        {
            //Arrange
            var basket = new Basket();
            basket.AddProduct(TestData.ProductOne);
            basket.AddProduct(TestData.ProductFour);
            var discountRule = new BuyXGetYFree(TestData.ProductThree, 2, TestData.ProductFour, 1);
            var expectedResult = 0;

            //Action
            var result = discountRule.CalculateDiscount(basket);

            //Asset
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CalculateDiscount_Test8()
        {
            //Arrange
            var basket = new Basket();
            basket.AddProduct(TestData.ProductThree);
            basket.AddProduct(TestData.ProductFour);
            basket.AddProduct(TestData.ProductFour);
            basket.AddProduct(TestData.ProductFour);
            var discountRule = new BuyXGetYFree(TestData.ProductThree, 1, TestData.ProductFour, 1);
            var expectedResult = TestData.ProductFour.Price;

            //Action
            var result = discountRule.CalculateDiscount(basket);

            //Asset
            Assert.AreEqual(expectedResult, result);
        }
    }
}
