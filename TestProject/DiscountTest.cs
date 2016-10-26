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
            Promotion promo = new Promotion("multi", 0.30, 2);
            DiscountCalculator dc = new DiscountCalculator(promo);

            Order o = new Order();
            o.Add(Products.GetProduct("blueDress"), 1);

            //exercise
            Order newOrder = dc.CalculateDiscount(o);

            //verify
            double expectedValue = 100;

            Assert.AreEqual(expectedValue, newOrder.TotalPrice, 0.001);
            
        }

        [TestMethod]
        public void Test2Buy2Items()
        {
            //setup
            Promotion promo = new Promotion("multi", 0.30, 2);
            DiscountCalculator dc = new DiscountCalculator(promo);

            Order o = new Order();
            o.Add(Products.GetProduct("blueDress"), 2);

            //exercise
            Order newOrder = dc.CalculateDiscount(o);

            //verify
            double expectedValue = 170;

            Assert.AreEqual(expectedValue, newOrder.DiscountedPrice, 0.001);

        }

        [TestMethod]
        public void Test3ABuy4Items()
        {
            //setup
            Promotion promo = new Promotion("multi", 0.30, 2);
            DiscountCalculator dc = new DiscountCalculator(promo);

            Order o = new Order();
            o.Add(Products.GetProduct("blueDress"), 4);

            //exercise
            Order newOrder = dc.CalculateDiscount(o);

            //verify
            double expectedValue = 340;

            Assert.AreEqual(expectedValue, newOrder.DiscountedPrice, 0.001);

        }

        [TestMethod]
        public void TestProgressiveDiscountBuy1Item()
        {
            //setup
            Promotion promo = new Promotion("progressive", 0.10, 0);
            DiscountCalculator dc = new DiscountCalculator(promo);

            Order o = new Order();
            o.Add(Products.GetProduct("blueDress"), 1);

            //exercise
            Order newOrder = dc.CalculateDiscount(o);

            //verify
            double expectedValue = 90;

            Assert.AreEqual(expectedValue, newOrder.DiscountedPrice, 0.001);

        }

        [TestMethod]
        public void TestProgressiveDiscountBuy2Items()
        {
            //setup
            Promotion promo = new Promotion("progressive", 0.10, 0);
            DiscountCalculator dc = new DiscountCalculator(promo);

            Order o = new Order();
            o.Add(Products.GetProduct("blueDress"), 2);

            //exercise
            Order newOrder = dc.CalculateDiscount(o);

            //verify
            double expectedValue = 190;

            Assert.AreEqual(expectedValue, newOrder.DiscountedPrice, 0.001);
        }


        [TestMethod]
        public void TestProgressiveDiscountBuy3Items()
        {
            //setup
            Promotion promo = new Promotion("progressive", 0.20, 0);
            DiscountCalculator dc = new DiscountCalculator(promo);

            Order o = new Order();
            o.Add(Products.GetProduct("blueDress"), 3);
            o.Add(Products.GetProduct("redDress"), 3);

            //exercise
            Order newOrder = dc.CalculateDiscount(o);

            //verify
            double expectedValue = 480;

            Assert.AreEqual(expectedValue, newOrder.DiscountedPrice, 0.001);

        }
    }
}
