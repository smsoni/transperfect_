using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WahooFitnessFramework;

namespace WahooFitness
{
    [TestClass]
    public class BaseTest
    {
        public static DriverInfo driverInfo = ReadXMLToClass.ReadFromXMLFile<DriverInfo>(@"XML\WahooDriverInfo.xml");

        [TestInitialize]
        public void TestInit()
        {
            //Launch Browser
            Driver.BrowserInitialize(driverInfo);

            //Login to NetSuite or any other app. Login has seperate Page Object. All Controls are identified and NetSuiteLogin method in it basically
            // navigates to URL because driver is launched in above step, enters uderid and password and performs multifactor authentication etc.
            // Login login = new Login();
            // login.NetSuiteLogin(loginInfo);



        }
    }
}
