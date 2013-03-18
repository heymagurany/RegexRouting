using System.Web.Mvc;
using System.Web.Routing;
using Magurany.Web.Routing.RegularExpressions;

namespace Magurany.Web.Mvc.RegularExpressions
{
	public static class RouteCollectionExtensions
	{
		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern)
		{
			return routes.MapRegexRoute(name, url, pattern, null, null, null, new MvcRouteHandler());
		}

		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern, object defaults)
		{
			return routes.MapRegexRoute(name, url, pattern, defaults, null, null, new MvcRouteHandler());
		}

		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern, string[] namespaces)
		{
			return routes.MapRegexRoute(name, url, pattern, null, null, namespaces, new MvcRouteHandler());
		}

		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern, object defaults, object constraints)
		{
			return routes.MapRegexRoute(name, url, pattern, defaults, null, null, new MvcRouteHandler());
		}

		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern, object defaults, string[] namespaces)
		{
			return routes.MapRegexRoute(name, url, pattern, defaults, null, namespaces, new MvcRouteHandler());
		}

		public static RegexRoute MapRegexRoute(this RouteCollection routes, string name, string url, string pattern, object defaults, object constraints, string[] namespaces)
		{
			return routes.MapRegexRoute(name, url, pattern, defaults, constraints, namespaces, new MvcRouteHandler());
		}
	}
}
