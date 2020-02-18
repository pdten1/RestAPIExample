using System;
using TechTalk.SpecFlow;
using WooliesXAPI.API_Classes;

namespace WooliesXAPI.Feature_Definitions
{
    [Binding]
    public class CheckTemparatureSteps
    {
        string dayOfTheWeek, cityName;
        WeatherForecastAPI weatherForecastAPI;

        [Given(@"I like to holiday on (.*)")]
        public void GivenILikeToHolidayOnThursday(string day)
        {
            dayOfTheWeek = day;
            weatherForecastAPI = new WeatherForecastAPI();
        }

        [When(@"I lookup the 5 day weather forecast using (.*), (.*) (.*)")]
        public void WhenILookupTheDayWeatherForecastUsingSydneyAUMetric(string city, string country, string metric)
        {
            cityName = city;
            weatherForecastAPI.CallRequest(city, country, metric);
        }

        
        [Then(@"I recieve the weather forecast")]
        public void ThenIRecieveTheWeatherForecast()
        {
            weatherForecastAPI.VerifyCity(cityName);
        }
        
        [Then(@"the temperature on DayOfWeek is less than (.*)")]
        public void ThenTheTemperatureOnDayOfWeekIsLessThan(int temparature)
        {
            weatherForecastAPI.VerifyDateAndTemparature(dayOfTheWeek, temparature);
        }
    }
}
