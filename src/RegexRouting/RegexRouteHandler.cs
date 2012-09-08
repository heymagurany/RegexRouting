using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Magurany.Web.Routing.RegularExpressions
{
	/// <summary>
	/// This class is a workaround for a bug in ASP.NET Web API. A <see cref="NullReferenceException"/> is thrown because 
	/// the <see cref="RegexRoute"/> class doesn't inherit from <see cref="System.Web.Http.WebHost.Routing.HttpWebRoute"/>,
	/// which is internal.
	/// </summary>
	internal class RegexRouteHandler : DelegatingHandler
	{
		private readonly HttpMessageInvoker m_DefaultInvoker;

		public RegexRouteHandler(HttpConfiguration configuration)
		{
			//ThrowHelper.CheckArgumentNull(configuration, "configuration");

			m_DefaultInvoker = new HttpMessageInvoker(new HttpControllerDispatcher(configuration));
		}

		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			HttpMessageInvoker invoker = m_DefaultInvoker;
			
			return invoker.SendAsync(request, cancellationToken);
		}
	}
}