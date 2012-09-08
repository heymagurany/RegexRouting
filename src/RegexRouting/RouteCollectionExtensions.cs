using System.Web.Routing;

namespace Magurany.Web.Routing.RegularExpressions
{
	public static class RouteCollectionExtensions
	{
		public static RegexRoute MapRegexRoute(this RouteCollection routeTable, string name, string pattern, object defaults)
		{
			RouteValueDictionary defaultDictionary = new RouteValueDictionary(defaults);
			RegexRoute route = new RegexRoute(pattern, defaultDictionary);

			routeTable.Add(name, route);

			return route;
		}
	}
}