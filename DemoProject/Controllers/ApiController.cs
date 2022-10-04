using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Controllers
{
    public class ApiController : Controller
    {

        public ApiController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
