using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProject.Services.Models.JsonModels
{
    public class LocationInfo
    {
        public int id { get; set; }

        public string city { get; set; }

        public string name { get; set; }


        public List<LocationParams> parameters { get; set; }

        public Coordinates coordinates { get; set; }

        public class LocationParams
        {
            public string unit { get; set; }

            public int count { get; set; }

            public double? average { get; set; }
            public double? lastValue { get; set; }

            public string parameter { get; set; }

            public string displayName { get; set; }

            public DateTime? lastUpdated { get; set; }

            public DateTime? firstUpdated { get; set; }

        }

        public class Coordinates
        {
            public double? latitude { get; set; }

            public double? longitude { get; set; }
        }
    }
}
