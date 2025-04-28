using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UILayer.Models;
using UILayer.Services.BoatServices;
using UILayer.Services.LocationServices;

namespace UILayer.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {

        private readonly IBoatService _boatService;
        private readonly ILocationService _locationService;

        public HomeController(IBoatService boatService, ILocationService locationService)
        {
            _boatService = boatService;
            _locationService = locationService;
        }

        public async Task<IActionResult> Index()
        {
            var boatList = await _boatService.GetFeaturedBoatAsync();
            var loacitonlist = await _locationService.GetAllLocationAsync();
            var model = new HomeViewModel
            {
                Boats = boatList,
                Locations = loacitonlist
            };
            return View(model);
        }
    }
}
