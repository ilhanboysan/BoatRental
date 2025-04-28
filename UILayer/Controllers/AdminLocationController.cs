using Microsoft.AspNetCore.Mvc;
using UILayer.Dtos.LocationDtos;
using UILayer.Services.LocationServices;

namespace UILayer.Controllers
{
    public class AdminLocationController : Controller
    {
        private readonly ILocationService _LocationService;

        public AdminLocationController(ILocationService LocationService)
        {
            _LocationService = LocationService;
        }

        public async Task<IActionResult> Index()
        {
            var LocationList = await _LocationService.GetAllLocationAsync();
            return View(LocationList);
        }
        [HttpGet]
        public IActionResult CreateLocation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
        {
            var responseMessage = await _LocationService.CreateLocationAsync(createLocationDto);

            if (responseMessage == "Konum Başarıyla Eklendi")
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var message = await _LocationService.DeleteLocationAsync(id);
            TempData["DeleteMessage"] = message;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateLocation(int id)
        {
            var Location = await _LocationService.GetByIdAsync(id);
            if (Location == null)
            {
                return NotFound();
            }
            return View(Location);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
        {

            var result = await _LocationService.UpdateLocationAsync(updateLocationDto);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View(updateLocationDto);
        }

    }
}
