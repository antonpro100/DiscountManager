using System;
using System.Linq;
using DiscountEngine.Core.Basket;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiscountEngine.Tests
{
    [TestClass]
    public class BasketTests
    {
        [TestMethod]
        public void AddProductTest_AddNew()
        {
            //Arrange
            var basket = new Basket();
            //Action
            basket.AddProduct(TestData.ProductOne);
            var resultItem = basket.LineItems.FirstOrDefault(l => l.ProductId == TestData.ProductOne.Id);
            //Asset
            Assert.AreEqual(basket.LineItems.Count, 1);
            Assert.IsNotNull(resultItem);
            Assert.AreEqual(resultItem.Count, 1);
        }

        [TestMethod]
        public void AddProductTest_AddExisting()
        {
            //Arrange
            var basket = new Basket();

            //Action
            basket.AddProduct(TestData.ProductOne);
            basket.AddProduct(TestData.ProductOne);
            var resultItem = basket.LineItems.FirstOrDefault(l => l.ProductId == TestData.ProductOne.Id);

            //Asset
            Assert.AreEqual(basket.LineItems.Count, 1);
            Assert.IsNotNull(resultItem);
            Assert.AreEqual(resultItem.Count, 2);
        }

        [TestMethod]
        public void AddProductTest_AddTwo()
        {
            //Arrange
            var basket = new Basket();

            //Action
            basket.AddProduct(TestData.ProductOne);
            basket.AddProduct(TestData.ProductTwo);
            var resultItem = basket.LineItems.FirstOrDefault(l => l.ProductId == TestData.ProductTwo.Id);

            //Asset
            Assert.AreEqual(basket.LineItems.Count, 2);
            Assert.IsNotNull(resultItem);
            Assert.AreEqual(resultItem.Count, 1);
        }

        [TestMethod]
        public void AddProductTest_AddNull()
        {
            //Arrange
            var basket = new Basket();

            //Action
            Action action = () => basket.AddProduct(null);

            //Asset
            Assert.ThrowsException<ArgumentNullException>(action);
        }
    }
}
