Project title - API Automation - Automation project

Tools and packages
- VisualStudio 2019
- Latest version of Specflow, Specflow tools
- NUnit and NUnit Adapter
- RestSharp, Newtonsoft.Json

Test details

The test will send a GET request to the URL specified in the APP config file with values specified in the Specflow feature file. This means that the request can be customised by changing the values on the data table in the feature file. The request is then Deserialized in to WeatherForecastResponse object. This object is used to verify JSON for the correct city is returned. Also verifies whether the temperature is available for the specified DAY of the week and if it is, then whether it is lower than the value specified in the feature file. The temperature check is done for all occurrences for the specified date(there can be a maximum of 8 entries per the same day). This is to make sure that the temperature is never lower than the specified value throughout the day

Design Features

- Use of BaseAPI class to define key properties and functions that can then be reused  for every API call
- Specflow feature and FeatureDefinition(FD)
- Use of data needed to build the request and also the data needed for verification is all managed via the data tables in the Specflow feature file
- Used Asserts for verifications
- Read the URL from APP config file

Possible Improvements

- Better Reporting
- More validation around time to pick the correct date.
