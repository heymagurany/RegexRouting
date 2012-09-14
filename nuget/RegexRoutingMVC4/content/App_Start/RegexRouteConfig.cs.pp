using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Magurany.Web.Routing.RegularExpressions;

namespace $rootnamespace$
{
	public class RegexRouteConfig
	{
		public static void EnableRegexHttpRoutes(HttpConfiguration configuration)
		{
			RegexRouteHandler messageHandler = new RegexRouteHandler(configuration);

			configuration.MessageHandlers.Add(messageHandler);
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}