Feature: RegistrationForm
As a user
    I want to register with a unique email address
    So that I can create a new account

    @run
Scenario: Application correctly validates the uniqueness of Email Address during registration
    Given I'm on the Registration form
    When I enter registration details with an existing email address
    And I click on next button
    Then I should see an error message indicating that the email address is already in use

    @run
    Scenario Outline: Attempt to set passwords that violate the password policy
    Given I'm on the Registration form
    When I attempt to set the password with "<Password>"
    Then I should see a validation message indicating that the password does not meet the password policy requirements

    Examples:
    | Password   |
    | 123456     |  # Too short
    | password   |  # Lacks special characters
    | too_long_password_123456789012345|  # Too long