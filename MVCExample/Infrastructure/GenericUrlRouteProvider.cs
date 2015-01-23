using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.FrameWork.Mvc.Routes;
using System.Web.Mvc;
namespace RipeTangerines.Infrastructure
{
    public partial class GenericUrlRouteProvider : IRouteProvider
    {

        public void RegisterRoutes(System.Web.Routing.RouteCollection routes)
        {
            routes.MapRoute("Category",
                            "{SeName}",
                            new { controller = "Catalog", action = "Category" },
                            new[] { "MVCExample.Controllers" });
        }

        public int Priority
        {
            get
            {
                //it should be the last route
                //we do not set it to -int.MaxValue so it could be overriden (if required)
                return -1000000;
            }
        }
    }
}