using System.Web.Mvc;

namespace RegexRoutingExample.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Define templates with a regular expression.";

			return View();
		}
	}
}