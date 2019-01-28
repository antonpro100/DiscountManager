using System;
using DiscountEngine.Core.Basket;
using DiscountEngine.Core.DiscountRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiscountEngine.Tests.DiscountRulesTests
{
    [TestClass]
    public class BuyXDiscountTotalTests
    {
        [TestMethod]
        public void CalculateDiscount_Test1()
        {
            //Arrange
            var basket = new Basket();
            basket.AddProduct(TestData.ProductOne);
            basket.AddProduct(TestData.ProductOne);
            basket.AddProduct(TestData.ProductOne);
            basket.AddProduct(TestData.ProductOne);
            basket.AddProduct(TestData.ProductOne);
            var discountRule = new BuyXDiscountTotal(TestData.ProductOne, 5, 30);

            var expectedResult = 13.425m;
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
            basket.AddProduct(TestData.ProductOne);
            basket.AddProduct(TestData.ProductOne);
            basket.AddProduct(TestData.ProductOne);
            basket.AddProduct(TestData.ProductOne);
            var discountRule = new BuyXDiscountTotal(TestData.ProductOne, 5, 30);

            var expectedResult = 0;
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
            basket.AddProduct(TestData.ProductOne);
            basket.AddProduct(TestData.ProductOne);
            basket.AddProduct(TestData.ProductOne);
            basket.AddProduct(TestData.ProductOne);
            basket.AddProduct(TestData.ProductOne);
            basket.AddProduct(TestData.ProductOne);
            var discountRule = new BuyXDiscountTotal(TestData.ProductOne, 5, 30);

            var expectedResult = 16.110m;
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
            var discountRule = new BuyXDiscountTotal(TestData.ProductOne, 5, 30);

            var expectedResult = 0;
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
            basket.AddProduct(TestData.ProductTwo);
            basket.AddProduct(TestData.ProductTwo);
            basket.AddProduct(TestData.ProductTwo);
            basket.AddProduct(TestData.ProductTwo);
            basket.AddProduct(TestData.ProductTwo);
            var discountRule = new BuyXDiscountTotal(TestData.ProductOne, 5, 30);
            var expectedResult = 0;

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
            basket.AddProduct(TestData.ProductOne);
            basket.AddProduct(TestData.ProductOne);
            basket.AddProduct(TestData.ProductOne);
            var discountRule = new BuyXDiscountTotal(TestData.ProductOne, 3, 10);

            var expectedResult = 2.685m;
            //Action
            var result = discountRule.CalculateDiscount(basket);

            //Asset
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CalculateDiscount_Test7()
        {
            //Arrange
            var discountRule = new BuyXDiscountTotal(TestData.ProductOne, 5, 30);

            //Action
            Action action = () => discountRule.CalculateDiscount(null);

            //Asset
            Assert.ThrowsException<ArgumentNullException>(action);
        }
    }
}