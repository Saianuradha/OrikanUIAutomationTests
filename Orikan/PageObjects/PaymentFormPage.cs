using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
        public By CardNumberBy = By.Id("cardNumber");
        public By CardCVVBy = By.Id("cardCVV");
        public By CardExpiryMonthBy = By.Id("cardExpiryMonth");
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

        public void EnterCardHolderDetails(string v1, string v2, string v3, string v4)
        {
            driver.FindElement(CardHolderNameBy).SendKeys("Sai");

            IWebElement checkbox = driver.FindElement(By.Id("cardTypeVISA"));
            checkbox.Click();

            driver.FindElement(CardNumberBy).SendKeys(v1);
            driver.FindElement(CardCVVBy).SendKeys(v2);
            IWebElement CardExpiryMonth = driver.FindElement(CardExpiryMonthBy);
            SelectElement selectElement = new SelectElement(CardExpiryMonth);
            selectElement.SelectByText("March");
            driver.FindElement(CardExpiryYear).SendKeys(v4);
        }
    }
}
