using System;
using System.Web.Http.WebHost;
using System.Web.Mvc;
using System.Web.Routing;

namespace Magurany.Web.Routing.RegularExpressions
{
	public static class RouteCollectionExtensions
	{
		public static RegexRoute MapRegexHttpRoute(this RouteCollection routes, string name, string url, string pattern)
		{
			return MapRegexRoute(routes, name, url, pattern, null);
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

		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern, object defaults, IRouteHandler routeHandler)
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
			route.Constraints = new RouteValueDictionary();
			route.DataTokens = new RouteValueDictionary();
			route.Defaults = new RouteValueDictionary(defaults);

			routes.Add(name, route);

			return route;
		}
	}
}