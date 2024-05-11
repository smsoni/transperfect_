using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelExecutionDriver
{
    public class DriverType
    {
        public static IConfiguration InitializeConfig()
        {
            var config = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();
            return config;
        }
        public static IWebDriver BrowserSetup(IWebDriver driver)
        {
            var browser = InitializeConfig();
            var type = browser["BrowserType"];
            if(type.Equals(BrowserType.Chrome))
            {
                driver= new ChromeDriver();
            }

            return driver;

        }
    }
}
