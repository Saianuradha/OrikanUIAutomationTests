Feature: Contact Form Validation
    As a user
    I want to fill out the contact form
    So that I can submit my inquiry
@run
Scenario: Text input fields should not allow null values
    Given I am on the contact form page
    When I leave the text input fields empty with spacebar
    And I click on next button
    Then I should see error messages indicating that the text input fields are required
