using OpenQA.Selenium;
using OrikanUIAutomationTests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Orikan.PageObjects
{
    [Binding]
    public class PaymentFormPage : BasePage
    {
        private IWebDriver driver;
        public PaymentFormPage(IWebDriver driver) : base(driver)
        { 
            this.driver = driver;
        }

            #region Locators
        public By paymentTabBy = By.XPath("//div[text()='Payment']");
        public By nextButtonBy = By.XPath("//button[text()='Next']");
        public By CardHolderNameBy = By.Id("cardHolderName");
        public By LastNameBy = By.Id("lastName");
        public By AddressLine1 = By.Id("addressLine1");
        public By PostcodeBy = By.Id("postcode");
        public By CityBy = By.Id("city");
        public By CardExpiryYear = By.Id("cardExpiryYear");

        #endregion Locators

        public void VerifyPaymentTabDisplayed()
        {
            IWebElement paymentTab = driver.FindElement(paymentTabBy);
            Assert.IsTrue(paymentTab.Displayed, "Payment tab is not displayed.");
        }

        public void EnterCardHolderDetails(string NonNuemericInput)
        {
            driver.FindElement(CardHolderNameBy).SendKeys(NonNuemericInput);
        }

        public void VerifyInputTextValidationMsgDisplayed()
        {
            Assert.IsTrue(driver.FindElement(By.XPath(".error-message")).Displayed);
        }

        public void EnterExpiryDetails(string pastYear)
        {
            driver.FindElement(CardHolderNameBy).SendKeys(pastYear);
        }
    }
}
