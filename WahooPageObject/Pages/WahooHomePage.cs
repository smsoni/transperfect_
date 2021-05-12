using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WahooFitnessFramework;

namespace WahooPageObject.Pages
{
    public class WahooHomePage
    {
        #region Constructor
        public WahooHomePage()
        {
            DriverInfo driver = new DriverInfo();
            driver.DriverPath = ".\\";
            driver.DriverType = DriverType.CHROME;
            Driver.BrowserInitialize(driver);
            Driver.GoToUrl("https://eu.wahoofitness.com/");
        }
        #endregion Constructor

        #region Fields
        public const string TopNavigation = "//*[@id='top_nav']//li";        
            
        #endregion

        public IWebElement NavigationPane
        {
            get
            {
                return DriverContext.Driver.FindElement(By.XPath(TopNavigation));
            }
        }

        public void ShopItems()
        {
            NavigationPane.Click();
        }
    }
}
