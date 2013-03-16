using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http.WebHost;

namespace Magurany.Web.Routing.RegularExpressions
{
	public static class RouteCollectionExtensions
	{
		public static RegexRoute MapRegexHttpRoute(this RouteCollection routes, string name, string url, string pattern)
		{
			return MapRegexHttpRoute(routes, name, url, pattern, null);
		}

		public static RegexRoute MapRegexHttpRoute(this RouteCollection routes, string name, string url, string pattern, object defaults)
		{
			return MapRegexRoute(routes, name, url, pattern, defaults, HttpControllerRouteHandler.Instance);
		}

		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern)
		{
			return MapRegexRoute(routes, name, url, pattern, null);
		}

		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern, object defaults)
		{
			return MapRegexRoute(routes, name, url, pattern, defaults, new MvcRouteHandler());
		}

		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern, string[] namespaces)
		{
			return MapRegexRoute(routes, name, url, pattern, namespaces, new MvcRouteHandler());
		}

		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern, object defaults, object constraints)
		{
			return MapRegexRoute(routes, name, url, pattern, defaults, new MvcRouteHandler());
		}

		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern, object defaults, string[] namespaces)
		{
			return MapRegexRoute(routes, name, url, pattern, defaults, null, namespaces, new MvcRouteHandler());
		}
		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern, object defaults, object constraints, string[] namespaces)
		{
			return MapRegexRoute(routes, name, url, pattern, defaults, constraints, null, new MvcRouteHandler());
		}

		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern, object defaults, IRouteHandler routeHandler)
		{
			return MapRegexRoute(routes, name, url, pattern, defaults, null, null, routeHandler);
		}

		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern, string[] namespaces, IRouteHandler routeHandler)
		{
			return MapRegexRoute(routes, name, url, pattern, null, null, namespaces, routeHandler);
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

			RegexRoute route = new RegexRoute(url, pattern, routeHandler);
			route.Defaults = new RouteValueDictionary(defaults);
			route.Constraints = new RouteValueDictionary(constraints);
			route.DataTokens = new RouteValueDictionary();

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
