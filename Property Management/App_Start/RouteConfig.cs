﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Property_Management
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


         /*   routes.MapRoute(
                name: "News",
                url: "News/{action}/{id}",
                defaults: new { controller = "News", action = "NewsList", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "NewsToUsers",
                url: "News/{id}",
                defaults: new { controller = "News", action = "NewsList", id = UrlParameter.Optional }
            );
            */
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
