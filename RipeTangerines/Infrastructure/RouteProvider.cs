using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Web.FrameWork.Mvc;
using System.Web.Mvc;
using Web.FrameWork.Mvc.Routes;
namespace RipeTangerines.Infrastructure
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
          
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute("HomePage",
                            "",
                            new { controller = "Home", action = "Index" },
                            new[] { "MVCExample.Controllers" });


            //customer
            routes.MapRoute("CustomerInfo",
                         "customer/info",
                         new { controller = "Customer", action = "Info" },
                         new[] { "MVCExample.Controllers" });

            routes.MapRoute("Logout",
                          "logout/",
                          new { controller = "Customer", action = "Logout" },
                          new[] { "MVCExample.Controllers" });

            routes.MapRoute("Register",
                          "register/",
                          new { controller = "Customer", action = "Register" },
                          new[] { "MVCExample.Controllers" });
            routes.MapRoute("Login",
                           "login/",
                           new { controller = "Customer", action = "Login" },
                           new[] { "MVCExample.Controllers" });

            //product search
            routes.MapRoute("ProductSearch",
                            "search/",
                            new { controller = "Catalog", action = "Search" },
                            new[] { "MVCExample.Controllers" });
            routes.MapRoute("ProductSearchAutoComplete",
                            "catalog/searchtermautocomplete",
                            new { controller = "Catalog", action = "SearchTermAutoComplete" },
                            new[] { "MVCExample.Controllers" });
        }

        public int Priority
        {
            get 
            { 
                return 0; 
            }
        }
    }
}