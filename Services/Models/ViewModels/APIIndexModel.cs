using DemoProject.Services.Models.JsonModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace DemoProject.Services.Models.ViewModels
{
    public class APIIndexModel
    {
        public List<Parameters> Parameters { get; set; }

        public List<LocationInfo> Locations { get; set; }

        public List<string> Cities { get; set; }

        public string SelectedCity { get; set; }
    }
}
