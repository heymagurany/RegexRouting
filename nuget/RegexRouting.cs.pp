using System;
using WebActivator;

[assembly: PreApplicationStartMethod(typeof($rootnamespace$.App_Start.RegexRouting), "PreStart")]

namespace $rootnamespace$.App_Start
{
    public static class RegexRouting
	{
        public static void PreStart()
		{
			RegexRouteConfig.EnableRegexHttpRoutes(GlobalConfiguration.Configuration);
			RegexRouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}