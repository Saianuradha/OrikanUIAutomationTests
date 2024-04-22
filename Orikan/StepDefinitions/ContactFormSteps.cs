using OpenQA.Selenium;
using Orikan.PageObjects;
using OrikanUIAutomationTests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Orikan.StepDefinitions
{
    [Binding]
    public class ContactFormSteps
    {
        private IWebDriver driver;
        private ContactFormPage contactFormPage;
        public ContactFormSteps(IWebDriver driver)
        {
            this.driver = driver;
            this.contactFormPage = new ContactFormPage(driver);
        }

        [Given(@"I am on the contact form page")]
        public void GivenIAmOnTheContactFormPage()
        {
            contactFormPage.VerifyContactTabDisplayed();
        }

        [When(@"I leave the text input fields empty with spacebar")]
        public void WhenILeaveTheTextInputFieldsEmptyWithSpacebar()
        {
            contactFormPage.EnterContactDetails();
        }

        [Then(@"I should see error messages indicating that the text is required")]
        public void ThenIShouldSeeErrorMessagesIndicatingThatTheTextIsRequired()
        {
            contactFormPage.VerifyTextFieldValidationMsgDisplayed();
        }

    }
}
