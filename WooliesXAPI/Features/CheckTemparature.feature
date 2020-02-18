Feature: CheckTemparature
	As a traveler I would like to be able 
	to check the temparture in a given city and country

@CheckTemparature
Scenario Outline: Check that temparture is lower for given city
	Given I like to holiday on <DayOfWeek>
	When I lookup the 5 day weather forecast using <City>, <CountryCode>, <UnitSpeified>
	Then I recieve the weather forecast
	And the temperature on DayOfWeek is less than <Temperature>

	
	Examples:
	| Testcase | City   | CountryCode | DayOfWeek | UnitSpeified | Temperature |
	| 1        | Sydney | AU          | Thursday  |    metric    |     12      |
 	| 2        | Sydney | AU          | Friday    |    metric    |     18      |
  