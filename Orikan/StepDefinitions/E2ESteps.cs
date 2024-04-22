using OpenQA.Selenium;
using Orikan.PageObjects;
using OrikanUIAutomationTests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace Orikan.StepDefinitions
{
    public class E2eSteps
    {
        private IWebDriver driver;
        private RegistrationFormPage registrationPage;
        private ContactFormPage contactFormPage;
        private PaymentFormPage paymentFormPage;
        public E2eSteps(IWebDriver driver) {
            
            this.driver = driver;
            this.registrationPage = new RegistrationFormPage(driver);
            this.paymentFormPage = new PaymentFormPage(driver);
            this.contactFormPage = new ContactFormPage(driver);

        }

        [Given(@"I should navigate to Contact form")]
        public void WhenIShouldNavigateToContactForm()
        {
            contactFormPage.VerifyContactTabDisplayed();
        }

        [When(@"I enter details on Contact form")]
        public void WhenIEnterDetailsOnContactForm()
        {
            contactFormPage.EnterContactDetails("Sai","Jandhyala","WindsorPark","0632","Auckland");
        }

        [When(@"i'm on Payment form")]
        public void WhenImOnPaymentForm()
        {
           paymentFormPage.VerifyPaymentTabDisplayed();
        }

        [When(@"I enter Card holder details")]
        public void WhenIEnterCardHolderDetails()
        {
            paymentFormPage.EnterCardHolderDetails("12345678", "999", "March", "2030");
        }

        [When(@"I agree the terms and conditions")]
        public void WhenIAgreeTheTermsAndConditions()
        {
            IWebElement checkbox = driver.FindElement(By.Id("agreedToTerms"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", checkbox);
            checkbox.Click();
        }

        [When(@"I click on sumbit button")]
        public void WhenIClickOnSumbitButton()
        {
            IWebElement submitButton = driver.FindElement(By.XPath("//button[@class='wizard-button primary']"));
            submitButton.Click();
        }

        [Then(@"I should see sucessfully register message\")]
        public void ThenIShouldSeeSucessfullyRegisterIserMessage_()
        {
            IWebElement sucessfulToastMsg = driver.FindElement(By.XPath("//div[@class='toast-message success active']"));
            Assert.IsTrue(sucessfulToastMsg.Displayed);
            Assert.That(sucessfulToastMsg.Text, Is.EqualTo("Successfully registered user"));
        }


    }
}
