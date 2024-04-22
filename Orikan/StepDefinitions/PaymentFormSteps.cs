using OpenQA.Selenium;
using Orikan.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Orikan.StepDefinitions
{
    [Binding]

    public class PaymentFormSteps
    {
        private IWebDriver driver;
        private PaymentFormPage paymentFormPage;
        public PaymentFormSteps(IWebDriver driver)
        {
            this.driver = driver;
            this.paymentFormPage = new PaymentFormPage(driver);
        }


        [Given(@"I'm on Payment page")]
        public void GivenImOnPaymentPage()
        {
            paymentFormPage.VerifyPaymentTabDisplayed();
        }

        [When(@"the card holder is prompted to input text for a card transaction")]
        public void WhenTheCardHolderIsPromptedToInputTextForACardTransaction()
        {
            paymentFormPage.EnterCardHolderDetails("123abcd");
        }

        [When(@"the card holder inputs text containing non-numeric characters")]
        public void WhenTheCardHolderInputsTextContainingNon_NumericCharacters()
        {
            
        }

        [Then(@"the system should reject the input and display an error message, indicating that only numbers are allowed for the card number\.")]
        public void ThenTheSystemShouldRejectTheInputAndDisplayAnErrorMessageIndicatingThatOnlyNumbersAreAllowedForTheCardNumber_()
        {
            paymentFormPage.VerifyInputTextValidationMsgDisplayed();
        }
        [When(@"I enter a card expiry date of the past year")]
        public void WhenIEnterACardExpiryDateOfThePastYear()
        {
            paymentFormPage.EnterExpiryDetails("2010");
        }

        [Then(@"I should see an error message indicating the expiry date is invalid")]
        public void ThenIShouldSeeAnErrorMessageIndicatingTheExpiryDateIsInvalid()
        {
            paymentFormPage.VerifyInputTextValidationMsgDisplayed();
        }

    }

}
