Feature: PaymentForm

@run
Scenario: Card Holder Inputs Text should not allow Non-Numeric Characters
Given I'm on Payment page
When the card holder is prompted to input text for a card transaction
And the card holder inputs text containing non-numeric characters
Then the system should reject the input and display an error message, indicating that only numbers are allowed for the card number.

Scenario: Payment with a Card Expiry Date in the Past Year should not allow
    Given I'm on Payment page
    When I enter a card expiry date of the past year
    Then I should see an error message indicating the expiry date is invalid
