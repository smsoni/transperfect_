using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace WahooFitnessFramework
{
    public partial class DriverContext
    {
        private static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get { return _driver; }
            set { _driver = value; }
        }
    }

    public class DriverInfo
    {
        #region Properties
        /// <summary>
        /// The path to the browsers driver.
        /// </summary>
        public string DriverPath { get; set; }

        /// <summary>
        /// Type of the browser.
        /// </summary>
        public DriverType DriverType { get; set; }
        #endregion
    }
}
