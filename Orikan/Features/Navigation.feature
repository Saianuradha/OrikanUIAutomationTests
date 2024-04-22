Feature: Navigation to Orikan Home Page

A short summary of the feature

@tag1
Scenario Outline: Sucessfull navigation
	Given I'm on the Registration form
	When I enter registration details <Email>,<Password>,<ConfirmPassword>
	#And I click on next button
	#Then I should navigate to Contact form

	Examples: 
	| Email | Password | ConfirmPassword |
	| "sai@orikan.com"     |  "123123"       |    "123123"  |
	