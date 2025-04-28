using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UILayer.Services.PatnerServices;

namespace UILayer.Controllers
{
	[AllowAnonymous]
	public class PartnerController : Controller
	{
		private readonly IPartnerService _PartnerService;

		public PartnerController(IPartnerService PartnerService)
		{
			_PartnerService = PartnerService;
		}

		public async Task<IActionResult> Index()
		{
			var PartnerList = await _PartnerService.GetAllPartnerAsync();
			return View(PartnerList);
		}
	}
}
