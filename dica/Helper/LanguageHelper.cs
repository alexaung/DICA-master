using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace dica.Helper
{
    public static class LanguageHelper
    {
        public static MvcHtmlString LangSwitcher(this UrlHelper url, string Name, RouteData routeData, string lang)
        {
            var liTagBuilder = new TagBuilder("li");
            var aTagBuilder = new TagBuilder("a");
            var routeValueDictionary = new RouteValueDictionary(routeData.Values);
            if (routeValueDictionary.ContainsKey("lang"))
            {
                if (routeData.Values["lang"] as string == lang)
                {
                    liTagBuilder.AddCssClass("active");
                }
                else
                {
                    routeValueDictionary["lang"] = lang;
                }
            }
            aTagBuilder.MergeAttribute("href", url.RouteUrl(routeValueDictionary));
            aTagBuilder.SetInnerText(Name);
            liTagBuilder.InnerHtml = aTagBuilder.ToString();
            return new MvcHtmlString(liTagBuilder.ToString());
        }

        public static string LangRoute(this UrlHelper url, RouteData routeData, string lang)
        {
            var routeValueDictionary = new RouteValueDictionary(routeData.Values);
            routeValueDictionary["lang"] = lang;

            return url.RouteUrl(routeValueDictionary);
        }
    }
}