using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooliesXAPI
{
    /*
     * This is the base class for the APIs. All API classes created should inherit this class.
     * This class conatians all the setup and functions common across APIs
     * */
    public class BaseAPI
    {
        public RestClient APIclient;
        public RestRequest APIrequest;
        public RestResponse APIresponse;
        public static string AppID = "c27ec57d62b6e2262f1deea539ad8b14";

        //Constructor is used to read the URL from APP config file and to also select the request method based on the parameter value passed
        public BaseAPI(string apiName, string method)
        {
            APIclient = new RestClient(Libraries.GetAppSettingValue(apiName));

            switch (method.Trim().ToLower())
            {
                case "post":
                    APIrequest = new RestRequest(Method.POST);
                    break;
                case "get":
                    APIrequest = new RestRequest(Method.GET);
                    break;
                case "put":
                    APIrequest = new RestRequest(Method.PUT);
                    break;
            }
        }

    }
}
