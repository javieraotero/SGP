using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SSO.SGP.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "SolicitarLicencia",
                url: "solicitar/licencia/{token}",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{cod}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, cod = UrlParameter.Optional }
            );
        }
    }
}