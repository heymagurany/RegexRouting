using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Routing;

namespace Magurany.Web.Routing.RegularExpressions
{
	public sealed class RegexRoute : Route
	{
		private readonly Regex m_Pattern;

		public RegexRoute(string url, string pattern, IRouteHandler routeHandler) : base(url, routeHandler)
		{
			if(pattern == null)
			{
				throw new ArgumentNullException("pattern");
			}

			m_Pattern = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
		}

		public override RouteData GetRouteData(HttpContextBase httpContext)
		{
			if(httpContext == null)
			{
				throw new ArgumentNullException("httpContext");
			}

			Match match = m_Pattern.Match(httpContext.Request.AppRelativeCurrentExecutionFilePath);

			if(match.Success)
			{
				RouteData data = new RouteData(this, RouteHandler);

				foreach(string groupName in m_Pattern.GetGroupNames())
				{
					if(!data.Values.ContainsKey(groupName))
					{
						Group group = match.Groups[groupName];

						if((group != null) && group.Success)
						{
							data.Values.Add(groupName, group.Value);
						}
					}
				}

				foreach(KeyValuePair<string, object> pair in Defaults)
				{
					if(!data.Values.ContainsKey(pair.Key))
					{
						data.Values.Add(pair.Key, pair.Value);
					}
				}

				return data;
			}

			return null;
		}
	}
}