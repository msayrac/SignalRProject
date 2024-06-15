using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
	public class SettingController : Controller
	{
		
		public IActionResult Index()
		{
			return View();
		}
	}
}
