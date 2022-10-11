using DemoProject.Services.Models.JsonModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace DemoProject.Services.Models.ViewModels
{
    public class APIDetailModel
    {
        public List<LocationInfo> LocationInfo { get; set; }

        public string SelectedCity { get; set; }
    }
}
