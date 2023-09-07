using Microsoft.AspNetCore.Mvc;

namespace ShyaWeb.Areas.Customer.Controllers
{
	[Area("customer")]
	public class CartController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
