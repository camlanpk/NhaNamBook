using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NhaNam
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

            routes.MapRoute(
                name: "ProductDetails",
                url: "Home/ProDetail/{id}",
                defaults: new { controller = "Home", action = "ProDetail" }
            );

            routes.MapRoute(
                name: "TrangChu",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Home", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ProductCategory",
                url: "Home/MenuProductCategory/{id}",
                defaults: new { controller = "Home", action = "MenuProductCategory" }

            );
            routes.MapRoute(
    name: "ProCate",
    url: "{controller}/{action}/{id}",
    defaults: new { controller = "Home", action = "Home", id = UrlParameter.Optional }
);

        }

    }
}
