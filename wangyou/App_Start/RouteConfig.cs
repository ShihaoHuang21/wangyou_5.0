using System.Web.Mvc;
using System.Web.Routing;

namespace wangyou
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
               name: "login1",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Account", action = "login", id = UrlParameter.Optional }
           );

        }
    }
}