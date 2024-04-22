using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace OrikanUIAutomationTests.PageObjects
{
    [Binding]
    public class RegistrationFormPage : BasePage
    {
        private IWebDriver driver;

        public RegistrationFormPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
        #region Locators
        public By RegistrationTabBy = By.XPath("//div[text()='Registration']");
        public By nextButtonBy = By.XPath("//button[text()='Next']");
       
        #endregion Locators

        #region Elements
        #endregion Elements
        public void VerifyRegistrationTabDisplayed()
        {
            IWebElement registrationTab = driver.FindElement(RegistrationTabBy);
            Assert.IsTrue(registrationTab.Displayed, "Registration tab is not displayed.");
        }

        public void EnterRegistrationDetails(string email, string password, string confirmPassword)
        {
            driver.FindElement(By.Id("emailAddress")).SendKeys(email);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("confirmPassword")).SendKeys(confirmPassword);
        }

        public void ClickOnNextButton()
        {
            IWebElement nextButton = driver.FindElement(nextButtonBy);
            nextButton.Click();
        }

        public void VerifyValidationErrorMesgDisplayed()
        {
            IWebElement errorMessage = driver.FindElement(By.CssSelector(".error-message"));
            Assert.IsTrue(errorMessage.Displayed);
            Assert.That(errorMessage.Text, Is.EqualTo("Email address is already in use. Please choose a different one."));
        }

        public void PasswordValidationMsgDisplayed()
        {
            IWebElement validationMessage = driver.FindElement(By.XPath(".password-validation-message"));
            Assert.IsTrue(validationMessage.Displayed);
            Assert.That(validationMessage.Text, Is.EqualTo("Password does not meet the password policy requirements."));
        }
    }
}
