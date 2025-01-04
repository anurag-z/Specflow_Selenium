Feature: APIs

A short summary of the feature

@API @owner:Anurag
Scenario: Tests
	Given I get Auth Token
	Then I verify Status code "200" 
	And I get booking list
	Then I verify Booking ID's


