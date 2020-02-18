using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooliesXAPI.API_Classes
{
    /*
     * These classes are used to define the properties of the Response class. This class is then used in the Deserilisation process, which in turn is used
     * verify the data in the response.
     * */
    public class WeatherForecastResponse
    {
        public string Cod { get; set; }
        public string Message { get; set; }
        public string Cnt { get; set; }
        public Locations City { get; set; }
        public List<WeatherDetails> List { get; set; }
    }

    public class WeatherDetails
    {
        public string dt_txt { set; get; }
        public Temprature main { set; get; }
    }

    public class Temprature
    {
        public string temp { set; get; }
        public string feels_like { set; get; }
        public string temp_min { set; get; }
        public string temp_max { set; get; }
    }

    public class Locations
    {
        public string id { get; set; }
        public string name { get; set; }
        public string Country { get; set; }
        public string Population { get; set; }
        public string timezone { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
    }
}
