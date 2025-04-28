using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UILayer.Services.BoatServices;


namespace UILayer.Controllers
{
    [AllowAnonymous]
    public class BoatController : Controller
    {
        private readonly IBoatService _boatService;

        public BoatController(IBoatService boatService)
        {
            _boatService = boatService;
        }

        public async Task<IActionResult> Index()
        {
            var boatList = await _boatService.GetAllBoatAsync();
            return View(boatList);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var boatList = await _boatService.GetByIdAForContentsync(id);
            if (boatList == null)
            {
                return NotFound();
            }
            return View(boatList);
        }
    }
}
