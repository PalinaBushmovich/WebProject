Feature: DeleteEmail
	

Background: 
	Given I login with the following credentials:
	| username  | password  |
	| tiommikot@gmail.com | a1123581321 |

Scenario Outline: Delete email verification
	Given I sent an email to <recipient> with text <text>
	And I sign out
	And I log in to the email box with <recipient> and <password>
	When I move the email from <sender> to Trash
	Then Email with recipient <sender> is in Trash
	Examples: 
	 | text        | sender       | recipient              | password  |
	| hello world | Eduard Tumas | dxvcdescfsdc@gmail.com |a1123581321 |