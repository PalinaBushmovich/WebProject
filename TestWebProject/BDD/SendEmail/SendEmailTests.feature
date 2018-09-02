Feature: SentEmailTest
	In order to check whether we send an email
	As registered user
	I want to log in

	@sendEmail
	Scenario Outline: Send email verification  
	Given I navigate to login form 
	And I log in to the email box with <username> and <password>
	When I sent an email to <email> with text <text>
	Then  the email to <email> is present in Sent folder 
	Examples: 
	| username               | password       | text        | email			         |
	| tiommikot@gmail.com    | a1123581321    | hello world |dxvcdescfsdc@gmail.com  |
	| dxvcdescfsdc@gmail.com | a1123581321    |   hi Jake   |  tiommikot@gmail.com   |
