using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Magurany.Web.Routing.RegularExpressions.Example.App_Start
{
	public class RegexHttpRouteConfig
	{
		public static void EnableRegexHttpRoutes(HttpConfiguration configuration)
		{
			//RegexRouteHandler messageHandler = new RegexRouteHandler(configuration);

			//configuration.MessageHandlers.Add(messageHandler);

			//configuration.Routes.MapRegexHttpRoute(
			//    name: "Thing",
			//    url: "{thingUri}/{action}/{stuffID}",
			//    pattern: @"^~(?<thingUri>(/thing/\d+)+){1}(/(?<action>[a-z]+)(/(?<stuffID>[a-z0-9_\-]+))?)?",
			//    defaults: new { controller = "Thing", action = "Index", stuffID = RouteParameter.Optional }
			//);
		}
	}
}