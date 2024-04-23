Feature: Sucessfull Registration

for successfully registering an account

@tag1
Scenario Outline: Create account sucessfully
	Given I'm on the Registration form
	When I enter registration details <Email>,<Password>,<ConfirmPassword>
	And I click on next button
	And I am on the contact form page
	And I enter details on Contact form
	And I click on next button
	And i'm on Payment form
	And I enter Card holder details 
	And I click on next button
	And I agree the terms and conditions
	And I click on sumbit button
	Then I should see sucessfully register message


	Examples: 
	| Email | Password | ConfirmPassword |
	| "sai@orikan.com"     |  "Orikan@1234"       |    "Orikan@1234"  |
	