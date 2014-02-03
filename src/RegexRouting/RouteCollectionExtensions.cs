using System;
using System.Web.Routing;

namespace Magurany.Web.Routing.RegularExpressions
{
	public static class RouteCollectionExtensions
	{
		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern, IRouteHandler routeHandler)
		{
			return MapRegexRoute(routes, name, url, pattern, null, null, null, routeHandler);
		}

		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern, object defaults, IRouteHandler routeHandler)
		{
			return MapRegexRoute(routes, name, url, pattern, defaults, null, null, routeHandler);
		}

		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern, string[] namespaces, IRouteHandler routeHandler)
		{
			return MapRegexRoute(routes, name, url, pattern, null, null, namespaces, routeHandler);
		}

		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern, object defaults, object constraints, IRouteHandler routeHandler)
		{
			return MapRegexRoute(routes, name, url, pattern, defaults, constraints, null, routeHandler);
		}

		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern, object defaults, string[] namespaces, IRouteHandler routeHandler)
		{
			return MapRegexRoute(routes, name, url, pattern, defaults, null, namespaces, routeHandler);
		}

		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern, object defaults, object constraints, string[] namespaces, IRouteHandler routeHandler)
		{
			if(routes == null)
			{
				throw new ArgumentNullException("routes");
			}

			if(url == null)
			{
				throw new ArgumentNullException("url");
			}

			if(pattern == null)
			{
				throw new ArgumentNullException("pattern");
			}

			var route = new RegexRoute(url, pattern, constraints, routeHandler)
			{
			    Defaults = new RouteValueDictionary(defaults),
                DataTokens = new RouteValueDictionary()
			};

		    if(route.Defaults.ContainsKey("Area"))
			{
				route.DataTokens["Area"] = route.Defaults["Area"];
			}

			if(namespaces != null && namespaces.Length > 0)
			{
				route.DataTokens["Namespaces"] = namespaces;
			}

			routes.Add(name, route);

			return route;
		}
	}
}
