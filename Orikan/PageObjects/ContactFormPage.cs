﻿using OpenQA.Selenium;
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
    public class ContactFormPage : BasePage
    {
        private IWebDriver driver;

        public ContactFormPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
        #region Locators
        public By contactTabBy =  By.XPath("//div[text()='Contact']");
        public By nextButtonBy = By.XPath("//button[text()='Next']");
        public By FirstNameBy = By.Id("firstName");
        public By LastNameBy = By.Id("lastName");
        public By AddressLine1 = By.Id("addressLine1");
        public By PostcodeBy = By.Id("postcode");
        public By CityBy = By.Id("city");
        public By StateBy = By.Id("state");

        #endregion Locators

        public void VerifyContactTabDisplayed()
        {
            IWebElement contactTab = driver.FindElement(contactTabBy);
            Assert.IsTrue(contactTab.Displayed, "Contact tab is not displayed.");
        }

        public void EnterContactDetails()
        {
            driver.FindElement(FirstNameBy).SendKeys(Keys.Tab);
            driver.FindElement(LastNameBy).SendKeys(Keys.Tab);
            driver.FindElement(AddressLine1).SendKeys(Keys.Tab);
            driver.FindElement(PostcodeBy).SendKeys(Keys.Tab);
            driver.FindElement(CityBy).SendKeys(Keys.Tab);
           
        }

        public void VerifyTextFieldValidationMsgDisplayed()
        {
            IWebElement validationMessage = driver.FindElement(By.XPath(".password-validation-message"));
            Assert.IsTrue(validationMessage.Displayed);
            Assert.That(validationMessage.Text, Is.EqualTo("Input text is required"));
        }
    }
}
