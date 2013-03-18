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

		public static bool UseLegacy { get; set; }

		public static bool AutoConstraints { get; set; }

		public RegexRoute(string url, string pattern, IRouteHandler routeHandler) : this(url, pattern, null, routeHandler) { }

		public RegexRoute(string url, string pattern, object constraints, IRouteHandler routeHandler) : base(url, routeHandler)
		{
			if(pattern == null)
			{
				throw new ArgumentNullException("pattern");
			}

			m_Pattern = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
			Constraints = new RouteValueDictionary(constraints);

			if(AutoConstraints)
			{
				GenerateConstraintsFromPattern(pattern);
			}
		}

		public override RouteData GetRouteData(HttpContextBase httpContext)
		{
			if(httpContext == null)
			{
				throw new ArgumentNullException("httpContext");
			}

			string url = httpContext.Request.AppRelativeCurrentExecutionFilePath;
			if(!UseLegacy)
			{
				url = url.Substring(1) + httpContext.Request.PathInfo;
			}
			Match match = m_Pattern.Match(url);

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

				if(DataTokens != null)
				{
					foreach(KeyValuePair<string, object> pair in DataTokens)
					{
						data.DataTokens[pair.Key] = pair.Value;
					}
				}

				return data;
			}

			return null;
		}

		private void GenerateConstraintsFromPattern(string pattern)
		{
			Regex names = new Regex(@"{(\w+)}");
			MatchCollection matches = names.Matches(Url);

			foreach(Match match in matches)
			{
				if(match.Groups.Count > 1)
				{
					string key = match.Groups[1].Value;
					if(!Constraints.ContainsKey(key))
					{
						// Using the amazing pattern found here: http://blogs.msdn.com/b/bclteam/archive/2005/03/15/396452.aspx
						Regex r = new Regex(String.Format(@"\(\?<{0}>([^\(\)]*(((?<Open>\()[^\(\)]*)+((?<Close-Open>\))[^\(\)]*)+)*(?(Open)(?!)))\)", key));
						MatchCollection constraint = r.Matches(pattern);
						if(constraint.Count == 1)
						{
							if(constraint[0].Groups.Count > 1)
							{
								Constraints[key] = constraint[0].Groups[1].ToString();
							}
						}
						else
						{
							throw new InvalidOperationException("constraints");
						}
					}
				}
			}
		}
	}
}