using DemoProject.Services.Models.ViewModels;
using DemoProject.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Controllers
{
    public class ApiController : Controller
    {

        private readonly ApiServices _apiServices;

        public ApiController(ApiServices apiServices)
        {
            _apiServices = apiServices;
        }

        public IActionResult Index(string city = "", int page = 1, string orderBy = "lastUpdated")
        {
            var model = _apiServices.Setup(city, page, orderBy);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(APIIndexModel apiIndexModel)
        {
            var model = _apiServices.Setup(apiIndexModel.SelectedCity);
            return View(model);
        }

        public IActionResult Detail(int locationId)
        {
            var model = _apiServices.DetailSetup(locationId);
            return View(model);
        }

        public IActionResult AutoCompleteCity(string term)
        {
            return Json(_apiServices.AutoCompleteCity(term));
        }
    }
}
