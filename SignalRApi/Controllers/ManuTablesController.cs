using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ManuTablesController : ControllerBase
	{
		private readonly IMenuTableService _menuTableService;

		public ManuTablesController(IMenuTableService menuTableService)
		{
			_menuTableService = menuTableService;
		}

		[HttpGet("MenuTableCount")]
		public IActionResult MenuTableCount()
		{
			return Ok(_menuTableService.TMenuTableCount());

		}


	}
}
