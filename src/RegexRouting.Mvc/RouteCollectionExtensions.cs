using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Magurany.Web.Routing.RegularExpressions;

namespace Magurany.Web.Mvc.RegularExpressions
{
	public static class RouteCollectionExtensions
	{
		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern)
		{
			return MapRegexRoute(routes, name, url, pattern, null, null, null);
		}

		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern, object defaults)
		{
            return MapRegexRoute(routes, name, url, pattern, defaults, null, null);
		}

		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern, string[] namespaces)
		{
            return MapRegexRoute(routes, name, url, pattern, null, null, namespaces);
		}

		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern, object defaults, object constraints)
		{
            return MapRegexRoute(routes, name, url, pattern, defaults, constraints, null);
		}

		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern, object defaults, string[] namespaces)
		{
            return MapRegexRoute(routes, name, url, pattern, defaults, null, namespaces);
		}

		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern, object defaults, object constraints, string[] namespaces)
		{
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
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

            if (namespaces != null && namespaces.Length > 0)
            {
                route.DataTokens["Namespaces"] = namespaces;
            }

            routes.Add(name, route);

            return route;
		}
	}
}
