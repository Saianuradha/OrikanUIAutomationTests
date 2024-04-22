using OpenQA.Selenium;
using OrikanUIAutomationTests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace OrikanUIAutomationTests.StepDefinitions
{
    [Binding]
    public class RegistrationFormSteps
    {
        private IWebDriver driver;
        private RegistrationFormPage registrationFormPage;
        public RegistrationFormSteps(IWebDriver driver)
        {
            this.driver = driver;
            this.registrationFormPage = new RegistrationFormPage(driver);
        }

        [Given(@"I'm on the Registration form")]
        public void GivenImOnTheRegistrationForm()
        {
            registrationFormPage.NavigateToOrikanUIAutomationPage();
            registrationFormPage.VerifyRegistrationTabDisplayed();
        }

        [When(@"I enter registration details ""([^""]*)"",""([^""]*)"",""([^""]*)""")]
        public void WhenIEnterRegistrationDetails(string p0, string p1, string p2)
        {
            registrationFormPage.EnterRegistrationDetails(p0, p1, p2);
        }


        [When(@"I click on next button")]
        public void WhenIClickOnNextButton()
        {
            registrationFormPage.ClickOnNextButton();
        }

        [Then(@"I should navigate to Contact form")]
        public void ThenIShouldNavigateToContactForm()
        {
            throw new PendingStepException();
        }
        [When(@"I enter registration details with an existing email address")]
        public void WhenIEnterRegistrationDetailsWithAnExistingEmailAddress()
        {
            registrationFormPage.EnterRegistrationDetails("sai@okran.com", "password", "password");
            
        }

       
        [Then(@"I should see an error message indicating that the email address is already in use")]
        public void ThenIShouldSeeAnErrorMessageIndicatingThatTheEmailAddressIsAlreadyInUse()
        {
            registrationFormPage.VerifyValidationErrorMesgDisplayed();
        }

        [When(@"I attempt to set the password with ""([^""]*)""")]
        public void WhenIAttemptToSetThePasswordWith(string password)
        {
            driver.FindElement(By.Id("password")).SendKeys(password);
        }

        [Then(@"I should see a validation message indicating that the password does not meet the password policy requirements")]
        public void ThenIShouldSeeAValidationMessageIndicatingThatThePasswordDoesNotMeetThePasswordPolicyRequirements()
        {
            registrationFormPage.PasswordValidationMsgDisplayed();
        }


    }

}
