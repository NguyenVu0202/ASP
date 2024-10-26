using Microsoft.AspNetCore.Mvc;

namespace DoAnNhom3.Areas.Admin.Controllers
{

	[Area("admin")]
	[Route("admin")]
	public class HomeAdminController : Controller
	{
		[Route("")]
		[Route("Index")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
