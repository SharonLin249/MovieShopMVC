using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MovieShop.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            //asp. net MVC Routing
            //2 kinds of routing
            //1.  ---- this -----Convention based Routing
            //2. Attribute based Rounting  introduced in MVC 5 ----prefered-----
            //Routing in MVC is a pattern matching technique
            //{} braces are place holder, they will be use for incoming Url
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
