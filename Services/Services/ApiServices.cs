using DemoProject.Services.ApiModels;
using DemoProject.Services.Data;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace DemoProject.Services.Services
{
    public class ApiServices
    {
        //https://docs.openaq.org/v2/ <-- test api used

        private const string BaseUrl = "https://api.openaq.org/v2/";
        private readonly DemoContext _demoContext;
        public ApiServices(DemoContext demoContext)
        {
            _demoContext = demoContext;
        }

        private T HttpRequest<T>(string resource, List<(string, string)> parameters )
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest(resource, Method.Get);
            foreach (var parameter in parameters) 
            {
                request.AddParameter(parameter.Item1, parameter.Item2);
            }
            request.AddHeader("accept", "application/json");
            var response = client.Execute(request).Content;
            var responseAsVar = JsonSerializer.Deserialize<T>(response);
            return responseAsVar;
        }

        public void Setup()
        {
            var paramters = new List<(string, string)>()
            {
                ("limit", "2"),
                ("page", "1")
            };
            var cityList = HttpRequest<CityInfoList>("cities", paramters);
        }


        //class to deserialize Json for cities
        private class CityInfoList
        {
            public List<CityInfo> results { get; set; }
        }
    }
}
