using DemoProject.Services.Models;
using DemoProject.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Controllers
{
    public class DatabaseController : Controller
    {

        private readonly DatabaseServices _databaseServices;

        public DatabaseController(DatabaseServices databaseServices)
        {
            _databaseServices = databaseServices;
        }

        public IActionResult Index()
        {
            var model = _databaseServices.Setup();
            return View(model);
        }

        public IActionResult Detail(int personId)
        {
            var model = _databaseServices.DetailSetup(personId);
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(DatabaseDetailModel model)
        {
            if (_databaseServices.AddPerson(model))
            {
                TempData["SuccessMessage"] = "New Person Added Succesfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed To Add Person, Please Try Again";
            }
            return RedirectToAction("Index"); 
        }
    }
}
