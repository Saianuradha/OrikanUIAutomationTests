Feature: Contact Form Validation
    As a user
    I want to fill out the contact form
    So that I can submit my inquiry
    Background: 
    Given I'm on the Registration form
	When I enter registration details "sai@orikan.com","123123","123123"
	And I click on next button
@run
Scenario: Text input fields should not allow null values
    Given I am on the contact form page
    When I leave the text input fields empty with spacebar
    Then I should see error messages indicating that the text is required
