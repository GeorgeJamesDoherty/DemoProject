using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProject.Services.Misc
{
    public static class APIConstants
    {
        //API Constants to avoid 'magic strings'

        public const string BaseUrl = "https://api.openaq.org/v2/";

        public const string RouteCities = "cities";

        public const string RouteParams = "parameters";

        public const string RouteLocations = "locations";

        public const string Limit = "limit";

        public const string OrderBy = "order_by";

        public const string CountryId = "country_id";

        public const string Page = "page";
    }
}
