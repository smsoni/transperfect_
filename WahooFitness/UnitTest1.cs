using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WahooFitnessFramework;

using WahooPageObject.Pages;

namespace WahooFitness
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            WahooHomePage homePage = new WahooHomePage();
            homePage.ShopItems();

            Devices device = new Devices();
            device.SelectProduct();
            device.AddProductToCart();
            device.RemoveFromCart();
            device.AddProductToCart();
            device.CheckOut();

            Cart cart = new Cart();
            cart.ChangeQuantity();
            cart.ClickUpdateCart();
            cart.ClickProceedToCheckOut();

            CheckOut checkout = new CheckOut();
            checkout.AddDetails();
            checkout.AddCardDetails();
            checkout.ClickPlaceOrder();

        }
    }
}
