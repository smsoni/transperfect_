using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WahooFitnessFramework
{
    public static class Driver
    {

        public static void GoToUrl(string url)
        {
            DriverContext.Driver.Url = url;
        }

        public static void BrowserInitialize(DriverInfo driverInfo)
        {
            switch (driverInfo.DriverType)
            {
                case DriverType.IE:
                    break;
                case DriverType.FIREFOX:
                    break;
                case DriverType.CHROME:
                    ChromeOptions options = new ChromeOptions();    
                    DriverContext.Driver = new ChromeDriver(driverInfo.DriverPath, options, TimeSpan.FromMinutes(2));                   
                    DriverContext.Driver.Manage().Window.Maximize();
                    break;
                default:
                    break;
            }
        }

    }

}
