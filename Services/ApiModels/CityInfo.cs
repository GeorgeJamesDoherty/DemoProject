using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProject.Services.ApiModels
{
    public class CityInfo
    {
            public string country { get; set; }
             
            public string city { get; set; }
             
            public int count { get; set; }
             
            public int locations { get; set; }
             
            public DateTime firstUpdated { get; set; }
             
            public DateTime lastUpdated { get; set; }
             
            public List<string> parameters { get; set; }
    }
}
