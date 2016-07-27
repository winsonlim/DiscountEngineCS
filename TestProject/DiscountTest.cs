using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionCS;

namespace TestProject
{
    [TestClass]
    public class DiscountTest
    {
        [TestMethod]
        public void Test1ABuy1Item()
        {
            //setup
            Promotion promo = new Promotion(); //TODO: setup the promotion as you see fit
            DiscountCalculator dc = new DiscountCalculator(promo);

            Order order = null; //TODO: setup the order, you can refer to SampleTest.cs for example

            //exercise
            Order newOrder = dc.CalculateDiscount(order);

            //verify
            double expectedValue = 0;//TODO: set the expected value;
            Assert.AreEqual(expectedValue, newOrder.TotalPrice, 0.001);
            //TODO: add additional verification if necessary
        }
    }
}
