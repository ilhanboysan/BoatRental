using Microsoft.AspNetCore.Mvc;
using UILayer.Dtos.BoatDtos;
using UILayer.Services.BoatServices;

namespace UILayer.Controllers
{
    public class AdminBoatController : Controller
    {
        private readonly IBoatService _boatService;

        public AdminBoatController(IBoatService boatService)
        {
            _boatService = boatService;
        }

        public async Task<IActionResult> Index()
        {
            var boatList = await _boatService.GetAllBoatAsync();
            return View(boatList);
        }
        [HttpGet]
        public IActionResult CreateBoat()
        {
            var model = new CreateBoatDto
            {
                Equipment = new List<string>(),
                Images = new List<string>()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBoat(CreateBoatDto createBoatDto, string EquipmentInput, string ImagesInput)
        {
            createBoatDto.Equipment = EquipmentInput?.Split(',').Select(x => x.Trim()).ToList() ?? new List<string>();
            createBoatDto.Images = ImagesInput?.Split(',').Select(x => x.Trim()).ToList() ?? new List<string>();
            var responseMessage = await _boatService.CreateBoatAsync(createBoatDto);

            if (responseMessage == "Tekne Başarıyla Eklendi")
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public async Task<IActionResult> DeleteBoat(int id)
        {
            var message = await _boatService.DeleteBoatAsync(id);
            TempData["DeleteMessage"] = message;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBoat(int id)
        {
            var boat = await _boatService.GetByIdAsync(id);
            if (boat == null)
            {
                return NotFound();
            }
            return View(boat);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBoat(UpdateBoatDto updateBoatDto, string EquipmentInput, string ImagesInput)
        {
            updateBoatDto.Equipment = EquipmentInput?.Split(',').Select(x => x.Trim()).ToList() ?? new List<string>();
            updateBoatDto.Images = ImagesInput?.Split(',').Select(x => x.Trim()).ToList() ?? new List<string>();
            var result = await _boatService.UpdateBoatAsync(updateBoatDto);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View(updateBoatDto);
        }

    }
}
