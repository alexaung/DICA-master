using System.Web.Mvc;
using System.Web.Routing;

namespace dica
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Language",
                url: "{lang}/{controller}/{action}/{id}",
                defaults: new { controller = "Investment", action = "Index", id = UrlParameter.Optional },
                constraints: new { lang = @"en|my" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Investment", action = "Index", id = UrlParameter.Optional, lang = "en" }
            );
        }
    }
}
