using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WahooFitnessFramework;

namespace WahooPageObject.Pages
{
    public class Devices
    {
        private const string ProductsList = "//*[@id='section-4']//li";
        private const string ColourDropDown = "//*[@id='attribute92']";
        private const string AddToCartID = "product-addtocart-button";
        private const string ViewAndEditCheckOutXpath = "//*[contains(text(),'View and Edit Cart')]";
        private const string outOfStock = "//*[contains(text(),'out of stock')]";
        private const string itemName = "//*[@class = 'product-name']//*[@itemprop='name']";
        private const string sliderItemName = "//*[@class 'product-item-name']";
        private const string remove = "//*[contains(@title,'Remove item')]";
        private const string miniclose = "btn-minicart-close";
        private const string removeOK = "//*[contains(@class,'action-primary action-accept')]";
        public IReadOnlyCollection<IWebElement> Products
        {
            get
            {
                return DriverContext.Driver.FindElements(By.XPath(ProductsList));
            }
        }
        public IWebElement ItemName
        {
            get
            {
                return DriverContext.Driver.FindElement(By.XPath(itemName));
            }
        }

        public IWebElement RemoveOK
        {
            get
            {
                return DriverContext.Driver.FindElement(By.XPath(removeOK));
            }
        }
        public IWebElement MiniClose
        {
            get
            {
                return DriverContext.Driver.FindElement(By.Id(miniclose));
            }
        }
        public IWebElement Remove
        {
            get
            {
                return DriverContext.Driver.FindElement(By.XPath(remove));
            }
        }
        public IWebElement OutOfStock
        {
            get
            {
                return DriverContext.Driver.FindElement(By.XPath(outOfStock));
            }
        }

        public IWebElement DropDown
        {
            get
            {
                return DriverContext.Driver.FindElement(By.XPath(ColourDropDown));
            }
        }

        public IWebElement AddToCart
        {
            get
            {
                return DriverContext.Driver.FindElement(By.Id(AddToCartID));
            }
        }

        public IWebElement ViewAndEditCheckOut
        {
            get
            {
                return DriverContext.Driver.FindElement(By.XPath(ViewAndEditCheckOutXpath));
            }
        }

        public void SelectProduct()
        {

            foreach (var product in Products)
            {
                if (product.Text.Contains("RIVAL MULTISPORT GPS WATCH"))
                {
                    product.Click();
                    break;
                }
            }

        }

        public void AddProductToCart()
        {
            try
            {
                if (OutOfStock.Displayed)
                {

                }
            }
            catch (Exception ex)
            {
                if (DropDown.Displayed)
                {
                    SelectElement selectOption = new SelectElement(DropDown);
                    selectOption.SelectByIndex(1);
                }
                string productName;
                string productXPath;
                productName = ItemName.Text;
                AddToCart.Click();
                //productXPath = String.Format("//*[contains(text(),'You added {0}')]", productName);
                productXPath = String.Format("//*[contains(text(),'You added')]");
                Thread.Sleep(15);
                var ele = DriverContext.Driver.FindElement(By.XPath(productXPath));
                
                var elementDisplayed = ele.Displayed;
                Assert.IsTrue(elementDisplayed);
            }
        }
        public void RemoveFromCart()
        {
            Remove.Click();
            Thread.Sleep(15);
            RemoveOK.Click();
            Thread.Sleep(15);
            MiniClose.Click();
        }

        public void CheckOut()
        {

            ViewAndEditCheckOut.Click();
        }
    }
}
