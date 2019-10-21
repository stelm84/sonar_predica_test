
Feature: Predica Task
	As a candidate for Test Automation Engineer position at Predica
	I want to open the Chrome browser 
	And search for Predica on Google
	And check whether Predica site is on top of search results
	And Predica Warsaw address is correct
	And Predica LinkedIn and Facebook profiles are among 5 top search results

Scenario Outline: Search for predica on google and check few things
	Given I have Chrome browser opened
	When I put <google_url> into the address bar and hit Enter
	Then I will see the empty search input
	When I put <predica_keyword> into Google's search and hit Enter
	Then I should see the <predica_site> as the first search result
	And I should see the proper Predica <warsaw_address> within Predica google's details
	And Within 5 top search results I can see Predica's both <linkedin> and <facebook> profiles

	Examples:
	| google_url             | predica_keyword | predica_site        | warsaw_address            | linkedin | facebook |
	| https://www.google.com/ | Predica         | https://predica.pl/ | Altowa 2, 02-386 Warszawa | LinkedIn | Facebook |