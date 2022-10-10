using DemoProject.Services.Models;
using DemoProject.Services.Models.ViewModels;
using DemoProject.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    public class DatabaseController : Controller
    {
        private const string PersonStr = "Person";

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

        public IActionResult AddContact(DatabaseDetailModel model)
        {
            _databaseServices.AddContact(model);
            return RedirectToAction("Detail", new { personId = model.Person.Id });
        }

        public IActionResult Delete(string type, int id, int? personId)
        {
            var success = _databaseServices.Delete(type, id);
            if (type == PersonStr)
            {
                return RedirectToAction("Index");
            }
            else
            {               
                return RedirectToAction("Detail", new { personId = personId });
            }
        }
    }
}
