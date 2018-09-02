Feature: LogInTests
	In order to check log in with valid and invalid credantials 

@login
Scenario Outline: Log in with invalid credantials 
	Given I navigate to Login form	
	When I log in with invalid <username> <password> credantials 
	Then Error message should be displayed 
	Examples:
	| username               | password       |
	| tiommot@gmail.com      | a1123581321    |
	| tiommikotgmail.com     | a1123581321    |
	| tiommikot@gmail.com    | a11235821      |
