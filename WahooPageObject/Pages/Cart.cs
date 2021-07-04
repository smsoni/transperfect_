using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WahooFitnessFramework;

namespace WahooPageObject.Pages
{
    public class Cart
    {
        private const string quantity = "//*[@class='input-text qty']";
        private const string updateCart = "//*[@title='Update Cart']";
        private const string proceedToCheckout = "//*[@title='Proceed to Checkout']";
        public IWebElement Quantity
        {
            get
            {
                return DriverContext.Driver.FindElement(By.XPath(quantity));


            }
        }
        public IWebElement UpdateCart
        {
            get
            {
                return DriverContext.Driver.FindElement(By.XPath(updateCart));
            }
        }
        public IWebElement ProceedToCheckOut
        {
            get
            {
                return DriverContext.Driver.FindElement(By.XPath(proceedToCheckout));
            }
        }
        public void ChangeQuantity()
        {
            Quantity.Clear();
            Quantity.SendKeys("2");
        }
        public void ClickUpdateCart()
        {
            UpdateCart.Click();
        }
        public void ClickProceedToCheckOut()
        {
            Thread.Sleep(5);
            ProceedToCheckOut.Click();
         }
    }
}
