using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WahooFitnessFramework;

namespace WahooPageObject.Pages
{
    public class CheckOut
    {
        private const string placeOrderXpath = "//*[@title='Place Order']";
        private const string expressShippingXpath = "//*[@id='label_method_amstrates22_amstrates']";
        private const string emailID = "customer-email";
        private const string nameXpath = "//*[@id='shipping-new-address-form']//input[contains(@name,'firstname')]";
        private const string lastName = "//*[@id='shipping-new-address-form']//input[contains(@name,'lastname')]";
        private const string streetAddressXpath = "//*[@id='shipping-new-address-form']//*[contains(@name,'street[0]')]";
        private const string city = "//*[@id='shipping-new-address-form']//input[contains(@name,'city')]";
        private const string state = "//*[@id='shipping-new-address-form']//select[contains(@name,'region_id')]";
        private const string country = "//*[@id='shipping-new-address-form']//select[contains(@name,'country_id')]";
        private const string zipCode = "//*[@id='shipping-new-address-form']//input[contains(@name,'postcode')]";
        private const string phone = "//*[@id='shipping-new-address-form']//input[contains(@name,'telephone')]";
       // private string creditCardNoID = "//input[@class='__PrivateStripeElement-input']";
        private const string creditCardNoID = "//div[contains(@id,'stripe-payments-card-number')]";
        private string expirationDate = "//div[contains(@id,'stripe-payments-card-expiry')]";        
        private string cvc = "//div[contains(@id,'stripe-payments-card-cvc')]";
        private string framename = "//*[contains(@name,'__privateStripeController')]";

        #region Properties

        public IWebElement PlaceOrder
        {
            get
            {
                return DriverContext.Driver.FindElement(By.XPath(placeOrderXpath));
            }
        }
        public IWebElement CreditFrame
        {
            get
            {
                return DriverContext.Driver.FindElement(By.XPath(framename));
            }
        }
        public IWebElement ExpressShipping
        {
            get
            {
                return DriverContext.Driver.FindElement(By.XPath(expressShippingXpath));
            }
        }
        public IWebElement EmailAddress
        {
            get
            {
                return DriverContext.Driver.FindElement(By.Id(emailID));
            }
        }

        public IWebElement Name
        {
            get
            {
                return DriverContext.Driver.FindElement(By.XPath(nameXpath));
            }
        }

        public IWebElement LastName
        {
            get
            {
                return DriverContext.Driver.FindElement(By.XPath(lastName));
            }
        }
        public IWebElement Street
        {
            get
            {
                return DriverContext.Driver.FindElement(By.XPath(streetAddressXpath));
            }
        }

        public IWebElement City
        {
            get
            {
                return DriverContext.Driver.FindElement(By.XPath(city));
            }
        }
        public IWebElement State
        {
            get
            {
                return DriverContext.Driver.FindElement(By.XPath(state));
            }
        }
        public IWebElement Country
        {
            get
            {
                return DriverContext.Driver.FindElement(By.XPath(country));
            }
        }

        public IWebElement Zipcode
        {
            get
            {
                return DriverContext.Driver.FindElement(By.XPath(zipCode));
            }
        }
        public IWebElement Phone
        {
            get
            {
                return DriverContext.Driver.FindElement(By.XPath(phone));
            }
        }

        public IWebElement CreditCard
        {
            get
            {
                return DriverContext.Driver.FindElement(By.XPath(creditCardNoID));
            }
        }

        public IWebElement ExpirationDate
        {
            get
            {
                return DriverContext.Driver.FindElement(By.XPath(expirationDate));
            }
        }

        public IWebElement CVC
        {
            get
            {
                return DriverContext.Driver.FindElement(By.XPath(cvc));
            }
        }

        #endregion

        public void AddDetails()
        {
            
            EmailAddress.SendKeys("someone@whocares.com");

            Name.SendKeys("Test");
            LastName.SendKeys("Tester");
            Street.SendKeys("Comandante Izarduy 67");
            City.SendKeys("Barcelona");
            SelectElement country = new SelectElement(Country);
            country.SelectByText("Spain");
            SelectElement state = new SelectElement(State);
            state.SelectByText("Cantabria");
            Zipcode.SendKeys("08940");
            Phone.SendKeys("5555555555");
            ExpressShipping.Click();
        }

        public void AddCardDetails()
        {
           // DriverContext.Driver.SwitchTo().Frame(CreditFrame);
            IJavaScriptExecutor js = (IJavaScriptExecutor)DriverContext.Driver;
            js.ExecuteScript("arguments[0].setAttribute('value', arguments[1])", CreditCard, 4111111111111111);
            js.ExecuteScript("arguments[0].value = '" + 4111111111111111 + "';", CreditCard);
            js.ExecuteScript("arguments[0].value = '" + 824 + "';", ExpirationDate);
            js.ExecuteScript("arguments[0].value = '" + 111 + "';", CVC);
            CreditCard.SendKeys("4111111111111111");
            ExpirationDate.SendKeys("824");
            CVC.SendKeys("111");
        }
        public void ClickPlaceOrder()
        {
            PlaceOrder.Click();
        }
    }
}

