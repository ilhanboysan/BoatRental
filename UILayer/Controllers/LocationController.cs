using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UILayer.Services.LocationServices;

namespace UILayer.Controllers
{
	[AllowAnonymous]
	public class LocationController : Controller
	{
		private readonly ILocationService _LocationService;

		public LocationController(ILocationService LocationService)
		{
			_LocationService = LocationService;
		}

		public async Task<IActionResult> Index()
		{
			var LocationList = await _LocationService.GetAllLocationAsync();
			return View(LocationList);
		}
		public async Task<IActionResult> Detail(int id)
		{
			var Location = await _LocationService.GetByIdAForContentsync(id);
			if (Location == null)
			{
				return NotFound();
			}
			return View(Location);
		}
	}
}
