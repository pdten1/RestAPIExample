using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace WooliesXAPI
{
    //This class includes all common functions that are reused across test cases.
    public static class Libraries
    {
        //This functions looks for a value in the app config file based on th key parameter
        public static string GetAppSettingValue(string key)
        {
            string appSettingVal = "";
            try
            {
                appSettingVal = ConfigurationManager.AppSettings.Get(key);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred at GetAppSettingValue function: " + e.Message);
            }
            return appSettingVal;
        }

    }
}
