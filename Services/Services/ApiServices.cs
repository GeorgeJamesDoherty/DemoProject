using DemoProject.Services.Data;
using DemoProject.Services.Models.JsonModels;
using DemoProject.Services.Models.ViewModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Linq;
using System.Web.Mvc;
using DemoProject.Services.Misc;

namespace DemoProject.Services.Services
{
    public class ApiServices
    {
        //https://docs.openaq.org/v2/ <-- test api used

        //Static list to 'store' values as not to repeat API calls
        public static List<string> cities;

        public ApiServices()
        {
        }

        private T HttpRequest<T>(string resource, List<(string, string)> requestParamters)
        {
            var client = new RestClient(APIConstants.BaseUrl);
            var request = new RestRequest(resource, Method.Get);
            foreach (var parameter in requestParamters)
            {
                request.AddParameter(parameter.Item1, parameter.Item2);
            }
            request.AddHeader("accept", "application/json");
            var response = client.Execute(request).Content;
            var responseAsVar = JsonSerializer.Deserialize<T>(response);
            return responseAsVar;
        }

        public APIIndexModel Setup(string city = "", int page = 1, string orderBy = "random")
        {
            var apiIndexModel = new APIIndexModel();
            var requestParamters = new List<(string, string)>()
            {
                (APIConstants.OrderBy, "id")
            };
            var foundParams = HttpRequest<ParametersList>(APIConstants.RouteParams, requestParamters).results;

            requestParamters = new List<(string, string)>()
            {
                (APIConstants.CountryId, "GB"),
                (APIConstants.Limit, "20"),
                (APIConstants.OrderBy, orderBy),
                (APIConstants.Page, page.ToString())
            };

            if (!String.IsNullOrEmpty(city))
            {
                //Get city formatted correctly
                var FormattedCity = cities.FirstOrDefault(x => x.ToLower().Trim() == city.ToLower());
                if (!String.IsNullOrEmpty(FormattedCity))
                {
                    apiIndexModel.SelectedCity = FormattedCity;
                    requestParamters.Add(("city", FormattedCity.Trim()));
                }
            }
            apiIndexModel.Locations = HttpRequest<LocationsList>(APIConstants.RouteLocations, requestParamters).results;
            var locationParams = apiIndexModel.Locations.SelectMany(x => x.parameters.Select(y => y.parameter)).Distinct().ToList();
            apiIndexModel.Parameters = foundParams.Where(x => locationParams.Contains(x.name)).ToList();
            apiIndexModel.CurrentPage = page;
            return apiIndexModel;
        }

        public APIDetailModel DetailSetup(int locationId)
        {
            var apiDetailModel = new APIDetailModel();
            var requestParamters = new List<(string, string)>()
            {
                (APIConstants.Limit, "20")
            };
            apiDetailModel.LocationInfo = HttpRequest<LocationsList>(APIConstants.RouteLocations + $"/{locationId}", requestParamters).results;
            return apiDetailModel;
        }

        public List<string> AutoCompleteCity(string term)
        {
            if (cities == null || cities.Count == 0)
            {
                var requestParamters = new List<(string, string)>()
                {
                    (APIConstants.CountryId, "GB"),
                    (APIConstants.Limit, "200")
                };
                var cityInfo = HttpRequest<CityInfoList>(APIConstants.RouteCities, requestParamters).results;
                cities = cityInfo.Select(x => x.city).ToList();
            }
            return cities.Where(x => x.ToLower().Contains(term.ToLower().Trim())).OrderBy(x => x.ToLower().StartsWith(term.ToLower().Trim()) ? 0 : 1).Take(5).ToList();
        }


        //classes to deserialize Json for cities
        private class CityInfoList
        {
            public List<CityInfo> results { get; set; }
        }

        private class ParametersList
        {
            public List<Parameters> results { get; set; }
        }

        private class LocationsList
        {
            public List<LocationInfo> results { get; set; }
        }
    }
}
