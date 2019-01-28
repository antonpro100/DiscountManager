using System;
using DiscountEngine.Core.Basket;
using DiscountEngine.Core.DiscountRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiscountEngine.Tests.DiscountRulesTests
{
    [TestClass]
    public class BuyXDiscountTest
    {
        [TestMethod]
        public void CalculateDiscount_Test1()
        {
            //Arrange
            var basket = new Basket();
            basket.AddProduct(TestData.ProductTwo);
            var discountRule = new BuyXDiscount(TestData.ProductTwo, 1, 50);

            var expectedResult = 0;
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
            basket.AddProduct(TestData.ProductTwo);
            basket.AddProduct(TestData.ProductTwo);
            var discountRule = new BuyXDiscount(TestData.ProductTwo, 1, 50);

            var expectedResult = 2.655m;
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
            basket.AddProduct(TestData.ProductTwo);
            basket.AddProduct(TestData.ProductTwo);
            basket.AddProduct(TestData.ProductTwo);
            var discountRule = new BuyXDiscount(TestData.ProductTwo, 1, 50);

            var expectedResult = 5.31m;
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
            basket.AddProduct(TestData.ProductTwo);
            basket.AddProduct(TestData.ProductTwo);
            basket.AddProduct(TestData.ProductTwo);
            var discountRule = new BuyXDiscount(TestData.ProductTwo, 5, 50);

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
            basket.AddProduct(TestData.ProductTwo);
            basket.AddProduct(TestData.ProductTwo);
            basket.AddProduct(TestData.ProductTwo);
            var discountRule = new BuyXDiscount(TestData.ProductThree, 5, 50);

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
            basket.AddProduct(TestData.ProductTwo);
            basket.AddProduct(TestData.ProductTwo);
            var discountRule = new BuyXDiscount(TestData.ProductTwo, 1, 25);

            var expectedResult = 1.3275m;
            //Action
            var result = discountRule.CalculateDiscount(basket);

            //Asset
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CalculateDiscount_Test8()
        {
            //Arrange
            var discountRule = new BuyXDiscount(TestData.ProductOne, 5, 30);

            //Action
            Action action = () => discountRule.CalculateDiscount(null);

            //Asset
            Assert.ThrowsException<ArgumentNullException>(action);
        }
    }
}
