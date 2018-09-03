Feature: LogInTests
	In order to check log in with valid and invalid credentials 

@login
Scenario Outline: Log in with invalid credentials 
	Given I navigate to Login form	
	When I log in with invalid <username> <password> credentials 
	Then Error message should be displayed 
	Examples:
	| username               | password       |
	| tiommikot@gmail.com    | a1123582       |
