using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HolidayPlanner
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute("GetStatesByCountryId",
                            "home/getstatesbycountryid/",
                            new { controller = "Home", action = "GetStatesByCountryId" },
                            new[] { "HolidayPlanner.Controllers" });
            routes.MapRoute("GetCitysByStateId",
                            "home/getcitysbystateid/",
                            new { controller = "Home", action = "GetCitysByStateId" },
                            new[] { "HolidayPlanner.Controllers" });
        }
    }
}
