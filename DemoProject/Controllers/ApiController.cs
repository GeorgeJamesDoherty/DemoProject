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

        public IActionResult Index()
        {
            _apiServices.Setup();
            return View();
        }
    }
}
