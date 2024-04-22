using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrikanUIAutomationTests.PageObjects
{
    public class BasePage
    {
        private IWebDriver driver;
        private string OrikanUIAutomationURL = "https://orikan-ui-automation-test.azurewebsites.net/";

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToOrikanUIAutomationPage()
        {
            driver.Navigate().GoToUrl(OrikanUIAutomationURL);
        }

    }
}
