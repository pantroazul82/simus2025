using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebSImus
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.ashx/{*pathInfo}");
            routes.IgnoreRoute("api/{*pathInfo}"); // Ignorar rutas que comienzan con 'api/' para Web API
         
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "FailWhale",
              url: "FailWhale/{action}/{id}",
              defaults: new { controller = "Error", action = "FailWhale", id = UrlParameter.Optional }
          );
        }
    }
}
