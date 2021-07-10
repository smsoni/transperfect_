using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WahooFitnessFramework
{
    public partial class DriverContext
    {
        public static Elements elements = new Elements();
        public static Combobox combobox = new Combobox();
        public static Checkbox checkbox = new Checkbox();
    }

    public class Elements
    {
        public IWebElement FindElementByName(string Name)
        {
            return DriverContext.Driver.FindElement(By.Name(Name));
        }

        public IWebElement FindElementByTagName(string tagname)
        {
            return DriverContext.Driver.FindElement(By.TagName(tagname));
        }

        public IWebElement FindElementById(string id)
        {
            return DriverContext.Driver.FindElement(By.Id(id));
        }

        public ReadOnlyCollection<IWebElement> FindElementsById(string id)
        {
            return DriverContext.Driver.FindElements(By.Id(id));
        }

        public IWebElement FindElementByClasName(string Class)
        {
            return DriverContext.Driver.FindElement(By.ClassName(Class));
        }

        public ReadOnlyCollection<IWebElement> FindElementsByClasName(string Class)
        {
            return DriverContext.Driver.FindElements(By.ClassName(Class));
        }

        public IWebElement FindElementByXpath(string xpath)
        {
            return DriverContext.Driver.FindElement(By.XPath(xpath));
        }

        public IWebElement FindElementByXpathWithVisibilityWait(string xpath)
        {
            WebDriverWait wait = new WebDriverWait(DriverContext.Driver, TimeSpan.FromSeconds(5));
            // return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            return null; //wrote to remove error
        }

        public IWebElement FindElementByNextSiblingwithID(string id, string tag)
        {

            return DriverContext.Driver.FindElement(By.XPath((String.Format(@"//*[@id=""{0}""]/following-sibling::{1}[1]", id, tag))));
        }

        public IWebElement FindElementByIDContains(string idstartwith)
        {

            return DriverContext.Driver.FindElement(By.XPath((String.Format(@"//*[contains(@id,""{0}"")]", idstartwith))));
        }

        public IWebElement FindElementByNameWithDisplayCondition(string Name, bool contains = false)
        {
            ReadOnlyCollection<IWebElement> elements = null;
            if (!contains)
                elements = DriverContext.Driver.FindElements(By.Name(Name));
            else
                elements = DriverContext.Driver.FindElements(By.XPath(String.Format(@"//*[@name=""{0}""]", Name)));

            foreach (IWebElement item in elements)
            {
                if (item.Displayed && (!string.IsNullOrEmpty(item.GetAttribute("title"))))
                    return item;
            }
            return null;
        }

    }

    public class Combobox
    {
        public bool SelectComboboxValueFromDropdown(string inputname, string valuetoselect, IWebElement element = null)
        {

            IWebElement dropdown = null;
            IWebElement dropdownbutton = null;
            IWebElement inputtextbox = null;
            if (element == null)
            {
                dropdownbutton = DriverContext.elements.FindElementByXpath("//input[@name='" + inputname + "']/following-sibling::span");
            }
            else
            {
                try
                {
                    dropdownbutton = element.FindElement(By.XPath("//div/span/div/input[@name='" + inputname + "']/following-sibling::span"));

                }
                catch (Exception)
                {
                    element.Click();
                    dropdownbutton = element.FindElement(By.XPath("//div/span/div/input[@name='" + inputname + "']/following-sibling::span"));
                }
            }


            dropdown = ClickOnDropdown(dropdownbutton);

            ReadOnlyCollection<IWebElement> dropoptions = dropdown.FindElements(By.TagName("div"));

            foreach (IWebElement item in dropoptions)
            {
                if (item.GetAttribute("innerText").Trim().ToUpper() == valuetoselect.ToUpper())
                {
                    item.Click();
                    break;
                }

            }

            inputtextbox = DriverContext.elements.FindElementByNameWithDisplayCondition(inputname);
            inputtextbox.SendKeys(Keys.Tab);
            if (inputtextbox.GetAttribute("title").Trim().ToUpper() == valuetoselect.ToUpper())
                return true;

            return false;

        }

        public bool SelectComboboxValueFromDropdownNameContains(string inputname, string valuetoselect, IWebElement element = null)
        {

            IWebElement dropdown = null;
            IWebElement dropdownbutton = null;
            IWebElement inputtextbox = null;
            if (element == null)
            {
                dropdownbutton = DriverContext.elements.FindElementByXpath("//input[contains(@name,'" + inputname + "')]/following-sibling::span");
            }
            else
            {
                try
                {
                    dropdownbutton = element.FindElement(By.XPath("//input[contains(@name,'" + inputname + "')]/following-sibling::span"));
                }
                catch (Exception)
                {
                    element.Click();
                    dropdownbutton = element.FindElement(By.XPath("//input[contains(@name,'" + inputname + "')]/following-sibling::span"));
                }
            }


            dropdown = ClickOnDropdown(dropdownbutton);

            ReadOnlyCollection<IWebElement> dropoptions = dropdown.FindElements(By.TagName("div"));

            foreach (IWebElement item in dropoptions)
            {
                if (item.GetAttribute("innerText").Trim().ToUpper() == valuetoselect.ToUpper())
                {
                    item.Click();
                    break;
                }

            }

            if (element == null)
                inputtextbox = DriverContext.elements.FindElementByNameWithDisplayCondition(inputname, true);
            else
                inputtextbox = element.FindElement(By.XPath("//input[contains(@name,'" + inputname + "')]"));

            inputtextbox.SendKeys(Keys.Tab);

            if (inputtextbox.GetAttribute("title").Trim().ToUpper() == valuetoselect.ToUpper())
                return true;

            return false;

        }


        private IWebElement ClickOnDropdown(IWebElement button)
        {
            IWebElement dropdown = null;

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    button.Click();

                }
                catch (Exception)
                {

                }

                ReadOnlyCollection<IWebElement> dropdownlist = DriverContext.elements.FindElementsByClasName("dropdownDiv");
                if (dropdownlist.Count == 0)
                    return null;
                if (dropdownlist.Count > 1)
                {
                    foreach (IWebElement item in dropdownlist)
                    {
                        if (item.Displayed)
                        {
                            dropdown = item;
                            return dropdown;
                        }
                    }
                }
                else
                {
                    dropdown = dropdownlist[0];
                    return dropdown;
                }
            }


            return dropdown;
        }

        public bool SelectValueInDropdownListBox(string inputname, string valuetoselect)
        {
            IWebElement dropdown = null;
            IWebElement dropdownTextbox = null;
            var dropdowns = DriverContext.Driver.FindElements(By.XPath("//input[@name='" + inputname + "']"));
            foreach (var item in dropdowns)
            {
                if (item.Displayed)
                {
                    dropdownTextbox = item;
                    dropdownTextbox.Click();
                }
            }
            ReadOnlyCollection<IWebElement> dropdownlist = DriverContext.elements.FindElementsByClasName("dropdownDiv");
            if (dropdownlist.Count == 0)
                return false;
            if (dropdownlist.Count > 1)
            {
                foreach (IWebElement item in dropdownlist)
                {
                    if (item.Displayed)
                    {
                        dropdown = item;
                        break;
                    }
                }
            }
            else
            {
                dropdown = dropdownlist[0];
            }

            ReadOnlyCollection<IWebElement> dropoptions = dropdown.FindElements(By.TagName("div"));

            foreach (IWebElement item in dropoptions)
            {
                if (item.GetAttribute("innerText") == valuetoselect)
                {
                    item.Click();
                    break;
                }

            }
            dropdownTextbox.SendKeys(Keys.Tab);
            if (dropdownTextbox.GetAttribute("title") == valuetoselect)
                return true;

            return false;
        }

        public bool SelectComboboxValueFromlist(string inputid, string valuetoset, IWebElement obj = null, bool contains = false)
        {
            IWebElement _combobox = null;
            IWebElement input = null;
            ReadOnlyCollection<IWebElement> _listofcombox = null;

            if (obj == null)
            {
                if (!contains)
                    input = DriverContext.elements.FindElementById(inputid);
                else
                    input = DriverContext.elements.FindElementByIDContains(inputid);
            }
            else
            {
                if (!contains)
                    input = obj.FindElement(By.Id(inputid));
                else
                    input = FindelementbyTagnamewithDisplayCondition("input", obj);
            }


            if (string.IsNullOrEmpty(valuetoset))
            {
                input.Click();
                input.Clear();
                input.SendKeys(Keys.Tab);
                if (input.GetAttribute("value") == valuetoset)
                    return true;
                else
                    return false;
            }


            input.Click();
            input.Clear();
            input.SendKeys(valuetoset);
            input.SendKeys(Keys.Tab);

            try
            {
                WebDriverWait wait = new WebDriverWait(DriverContext.Driver, TimeSpan.FromSeconds(25));
              //  wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("uir-popup-select-content")));
                _listofcombox = DriverContext.elements.FindElementsByClasName("uir-popup-select-content");
            }

            catch (UnhandledAlertException ex)
            {
                IAlert alert = DriverContext.Driver.SwitchTo().Alert();
                alert.Accept();

                return true;
            }
            catch (System.Exception)
            {
                if (input.GetAttribute("value") == valuetoset)
                {
                    //     input.SendKeys(Keys.Tab);
                    return true;
                }

            }

            foreach (IWebElement item in _listofcombox)
            {
                if (item.Displayed)
                    _combobox = item;
                break;
            }

            ReadOnlyCollection<IWebElement> listofvalue = _combobox.FindElements(By.XPath(".//tr/td[2]"));

            foreach (IWebElement item in listofvalue)
            {

                if (item.Text == valuetoset)
                {
                    item.Click();
                    if (input.GetAttribute("value") == valuetoset)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public string GetValueFromCombobox(string inputName, string attribute = "value")
        {
            return DriverContext.elements.FindElementByName(inputName).GetAttribute(attribute);
        }
        /// <summary>
        /// This method is used to verify combobox Or Textbox is enabled or not
        /// </summary>
        /// <param name="inputName">true:combobox Or Textbox is enabled</param>
        /// <returns></returns>
        public bool IsComboboxEnabled(string inputName)
        {
            return DriverContext.elements.FindElementByName(inputName).Enabled;
        }
        /// <summary>
        /// This function is used mainly for customer and other controls like customer.
        /// </summary>
        /// <param name="inputid">Id locator</param>
        /// <param name="valuetoset">value to Set in combobox</param>
        /// <returns></returns>
        public bool SelectEntityFromComboboxlist(string inputid, string valuetoset)
        {
            IWebElement _combobox = null;
            ReadOnlyCollection<IWebElement> _listofcombox = null;

            IWebElement input = DriverContext.elements.FindElementById(inputid);

            if (string.IsNullOrEmpty(valuetoset))
            {
                input.Click();
                input.Clear();
                input.SendKeys(Keys.Tab);
                if (input.GetAttribute("value") == valuetoset)
                    return true;
                else
                    return false;
            }


            input.Click();
            input.Clear();
            string newString = valuetoset.Remove(valuetoset.ToCharArray().Length / 2); // Last charector of the string is deleted so that we can get list in Search
            input.SendKeys(newString);
            input.SendKeys(Keys.Tab);

            try
            {
                WebDriverWait wait = new WebDriverWait(DriverContext.Driver, TimeSpan.FromSeconds(35));
                //   wait.Until(ExpectedConditions.TitleContains("CCH® SureTax® Configuration - NetSuite (Wolters Kluwer - SuiteTax QA 2)"));

               // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("uir-popup-select-content")));
                _listofcombox = DriverContext.elements.FindElementsByClasName("uir-popup-select-content");
            }
            catch (System.Exception)
            {
                if (input.GetAttribute("value") == valuetoset)
                {
                    //     input.SendKeys(Keys.Tab);
                    return true;
                }

            }

            foreach (IWebElement item in _listofcombox)
            {
                if (item.Displayed)
                    _combobox = item;
                break;
            }

            ReadOnlyCollection<IWebElement> listofvalue = _combobox.FindElements(By.XPath(".//tr"));

            foreach (IWebElement item in listofvalue)
            {

                if (item.Text == valuetoset)
                {
                    item.Click();
                    if (input.GetAttribute("value") == valuetoset)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public IWebElement FindelementbyTagnamewithDisplayCondition(string tagname, IWebElement obj = null)
        {
            ReadOnlyCollection<IWebElement> itemlist = null;
            if (obj == null)
                itemlist = DriverContext.Driver.FindElements(By.TagName(tagname));
            else
                itemlist = obj.FindElements(By.TagName(tagname));

            foreach (var item in itemlist)
            {
                if (item.Displayed)
                    return item;
            }

            return null;
        }

    }

    public class Checkbox
    {

        public void SetCheckboxwithID(string elementid, bool setup)
        {
            IWebElement checkbox = DriverContext.elements.FindElementById(elementid);
            SetCheckboxwithID(checkbox, setup);
        }

        public void SetCheckboxwithID(IWebElement element, bool setup)
        {


            if (setup)
            {
                if (element.GetAttribute("class").ToString().Equals("checkbox_unck"))
                {
                    element.Click();
                    Actions builder = new Actions(DriverContext.Driver);
                    builder.MoveToElement(element).SendKeys(Keys.Tab).Build().Perform();
                    Assert.AreEqual("checkbox_ck", element.GetAttribute("class").ToString());
                }
            }
            else
            {
                if (element.GetAttribute("class").ToString().Equals("checkbox_ck"))
                {
                    element.Click();
                    Actions builder = new Actions(DriverContext.Driver);
                    builder.MoveToElement(element).SendKeys(Keys.Tab).Build().Perform();
                    Assert.AreEqual("checkbox_unck", element.GetAttribute("class").ToString());
                }
            }
        }

        /// <summary>
        /// This method verifies Checkbox is selected or not
        /// </summary>
        /// <param name="inputName">name identifier for checkbox</param>
        /// <returns>true: Checkbox checked, false: Checkbox uncheked</returns>
        public bool IsCheckboxSelected(string inputId)
        {
            return DriverContext.elements.FindElementById(inputId).GetAttribute("class").ToString().Equals("checkbox_ck");
        }
        public bool IsReadOnlyCheckboxSelected(string inputId)
        {
            return DriverContext.elements.FindElementById(inputId).GetAttribute("class").ToString().Equals("checkbox_read_ck");
        }
    }
}