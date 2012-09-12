using System.Web.Mvc;

namespace RegexRoutingExample.Controllers
{
	public class ThingController : Controller
	{
		public ActionResult Index(string thingUri)
		{
			ViewBag.ThingUri = thingUri;

			return View();
		}

		public ActionResult Stuff(string thingUri, string stuffID)
		{
			ViewBag.ThingUri = thingUri;
			ViewBag.SelectedStuff = stuffID;

			string[] stuff = { "a", "b", "c" };

			return View(stuff);
		}
	}
}