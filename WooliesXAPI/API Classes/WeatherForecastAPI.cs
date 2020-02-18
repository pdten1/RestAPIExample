using Newtonsoft.Json;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace WooliesXAPI.API_Classes
{
    /*
     * This class contains all functions pertaining to teh Weather Forecast API.
     * This includes the request call and verification
     * */
    public class WeatherForecastAPI :
        BaseAPI
    {
        public WeatherForecastResponse response { get; set; }
        public WeatherForecastAPI():
                base("WeatherForecastAPI", "Get")
        {
            response = new WeatherForecastResponse();
        }

        /*
         * This function add parameters to the API request and calls the API.
         * It also Deserialize the response to a instance of WeatherForecastResponse 
         * which can then be used for verification.
         * */
        public void CallRequest(string city, string country, string tempUnits)
        {
            Console.WriteLine("\t Sending a GET request to the WeatherForecast API");
            APIrequest.AddParameter("q", (city + "," + country));
            APIrequest.AddParameter("APPID", AppID);
            APIrequest.AddParameter("units", tempUnits);
            
            string res = APIclient.Execute(APIrequest).Content;
            response = JsonConvert.DeserializeObject<WeatherForecastResponse>(res);
        }

        //Verifies that the city in the request matches the city in the response
        public void VerifyCity(string city)
        {
            Console.WriteLine("\t Verifying the city name in the reponse matches what was entered");
            Assert.AreEqual(city, response.City.name, "The city in the reposnse does not match the city in the API request");
        }

        /*
         * This function is used to verify that the temparture for a given date (there are 8 reading for each full date)
         * is never under the value passed in the temp parameter.
         * The parameters passed are:
         * The function iterates through the weather list in the response and checks to see whether the date from the response contains the date value returned from 
         * the GetValidDate function. 
         * If a match is found then a secondary check is done to make sure that the temparature read from the response is greater than the value in temp parameter.
         * This check is done for all temparutre entries for the date specified. 
         * */
        public void VerifyDateAndTemparature(string day, double temp)
        {
            int count = 0;
            double TempFromResposne;
            string DateFromResponse;
            string Date = GetValidDate(day);
            if(!string.IsNullOrEmpty(Date))
            {
                foreach (WeatherDetails item in response.List)
                {
                    TempFromResposne = Convert.ToDouble(item.main.temp);
                    DateFromResponse = item.dt_txt;
                    if (DateFromResponse.Contains(Date))
                    {
                        count++;
                        Console.WriteLine("\t Verifying that the temparture is lower than amount specified for entry# " + count.ToString());
                        Assert.That(TempFromResposne > temp, "The temparature is lower than expected. Expected: " + temp.ToString() + " Actual: " + TempFromResposne.ToString());
                    }
                }
            }
            else
            {
                Assert.Fail("The date that you requested the weather for cannot be retrieved. Try using a day that falls within 5 days of today");
            }

        }

        /*
         * This function is used to determine the date to compare against the Results from the API call.
         * @value paramter contains the DAY of the week in string format.
         * The function checks to see whether the speified  day of the week appears within 5 days of the current date.
         * So for example, if thursday is passed and today Wednesday, a valid date would be returned to the calling fucntion. The reason is
         * becasue Thursday falls within 5 days of the current date
         * */
        public string GetValidDate(string value)
        {
            string Day, Date;
            for (int i = 0; i < 5; i++)
            {
                Day = DateTime.Today.AddDays(i).DayOfWeek.ToString();
                if (Day.ToLower() == value.ToLower())
                {
                    Date = DateTime.Today.AddDays(i).ToString("yyyy-MM-dd");
                    return Date;
                }
            }
            return "";
        }

    }
}
