using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProject.Services.Models.JsonModels
{
    public class LocationInfo
    {
        public string name { get; set; }

        public List<LocationParams> parameters { get; set; }

        public Coordinates coordinates { get; set; }

        public class LocationParams
        {
            public double? average { get; set; }

            public string parameter { get; set; }
        }

        public class Coordinates
        {
            public double? latitude { get; set; }

            public double? longitude { get; set; }
        }
    }
}
