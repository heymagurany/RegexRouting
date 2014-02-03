using System;
using System.Web.Mvc;
using System.Web.Routing;
using Magurany.Web.Routing.RegularExpressions;

namespace Magurany.Web.Mvc.RegularExpressions
{
    public static class AreaRegistrationContextExtensions
    {
        public static RegexRoute MapRegexRoute(this AreaRegistrationContext context, string name, string url, string pattern)
        {
            return MapRegexRoute(context, name, url, pattern, null, null, null);
        }

        public static RegexRoute MapRegexRoute(this AreaRegistrationContext context, string name, string url, string pattern, object defaults)
        {
            return MapRegexRoute(context, name, url, pattern, defaults, null, null);
        }

        public static RegexRoute MapRegexRoute(this AreaRegistrationContext context, string name, string url, string pattern, string[] namespaces)
        {
            return MapRegexRoute(context, name, url, pattern, null, null, namespaces);
        }

        public static RegexRoute MapRegexRoute(this AreaRegistrationContext context, string name, string url, string pattern, object defaults, object constraints)
        {
            return MapRegexRoute(context, name, url, pattern, defaults, constraints, null);
        }

        public static RegexRoute MapRegexRoute(this AreaRegistrationContext context, string name, string url, string pattern, object defaults, string[] namespaces)
        {
            return MapRegexRoute(context, name, url, pattern, defaults, null, namespaces);
        }

        public static RegexRoute MapRegexRoute(this AreaRegistrationContext context, string name, string url, string pattern, object defaults, object constraints, string[] namespaces)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            if (pattern == null)
            {
                throw new ArgumentNullException("pattern");
            }

            var route = new RegexRoute(url, pattern, constraints, new MvcRouteHandler())
            {
                DataTokens = new RouteValueDictionary(),
                Defaults = new RouteValueDictionary(defaults)
            };

            route.DataTokens.Add("Area", context.AreaName);

            if (namespaces != null && namespaces.Length > 0)
            {
                route.DataTokens["Namespaces"] = namespaces;
            }

            context.Routes.Add(name, route);

            return route;
        }
    }
}
