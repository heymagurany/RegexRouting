using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Magurany.Web.Routing.RegularExpressions;

namespace RegexRoutingExample
{
	public class RegexRouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			//routes.MapRegexRoute(
			//    name: "Thing",
			//    url: "{thingUri}/{action}/{stuffID}",
			//    pattern: @"^~(?<thingUri>(/thing/\d+)+){1}(/(?<action>[a-z]+)(/(?<stuffID>[a-z0-9_\-]+))?)?",
			//    defaults: new { controller = "Thing", action = "Index", stuffID = RouteParameter.Optional }
			//);
			routes.MapRoute(
				name: "Default",
				url: "",
				defaults: new { controller = "Home", action = "Index" }
			);
		}
	}
}