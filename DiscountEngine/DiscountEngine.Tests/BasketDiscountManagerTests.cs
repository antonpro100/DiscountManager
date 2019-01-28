using DiscountEngine.Core;
using DiscountEngine.Core.Basket;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiscountEngine.Tests
{
    [TestClass]
    public class BasketDiscountManagerTests
    {
        [TestMethod]
        public void CalculateDiscount_TestAll()
        {
            //Arrange
            var basket = new Basket();
            basket.AddProduct(TestData.ProductTwo);
            basket.AddProduct(TestData.ProductTwo);
            basket.AddProduct(TestData.ProductThree);
            basket.AddProduct(TestData.ProductFour);
            basket.AddProduct(TestData.ProductOne);
            basket.AddProduct(TestData.ProductOne);
            basket.AddProduct(TestData.ProductOne);
            basket.AddProduct(TestData.ProductOne);
            basket.AddProduct(TestData.ProductOne);

            var expectedResult = 20.481m;

            var basketDiscountManager = new BasketDiscountManager(TestData.AvailableDiscountRules, basket);

            //Action
            var result = basketDiscountManager.CalculateDiscount();

            //Assert

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CalculateDiscount_Test_ApplyTwoDiscounts()
        {
            //Arrange
            var basket = new Basket();
            basket.AddProduct(TestData.ProductTwo);
            basket.AddProduct(TestData.ProductTwo);
            basket.AddProduct(TestData.ProductThree);
            basket.AddProduct(TestData.ProductFour);
            basket.AddProduct(TestData.ProductOne);
            basket.AddProduct(TestData.ProductOne);
            basket.AddProduct(TestData.ProductOne);

            var expectedResult = 2.955m;

            var basketDiscountManager = new BasketDiscountManager(TestData.AvailableDiscountRules, basket);

            //Action
            var result = basketDiscountManager.CalculateDiscount();

            //Assert

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CalculateDiscount_Test_ApplyOneDiscount()
        {
            //Arrange
            var basket = new Basket();
            basket.AddProduct(TestData.ProductTwo);
            basket.AddProduct(TestData.ProductTwo);

            var expectedResult = 2.655m;

            var basketDiscountManager = new BasketDiscountManager(TestData.AvailableDiscountRules, basket);

            //Action
            var result = basketDiscountManager.CalculateDiscount();

            //Assert

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CalculateDiscount_Test_ApplyNoDiscounts()
        {
            //Arrange
            var basket = new Basket();
            basket.AddProduct(TestData.ProductTwo);
            basket.AddProduct(TestData.ProductOne);

            var expectedResult = 0;

            var basketDiscountManager = new BasketDiscountManager(TestData.AvailableDiscountRules, basket);

            //Action
            var result = basketDiscountManager.CalculateDiscount();

            //Assert

            Assert.AreEqual(expectedResult, result);
        }
    }
}
