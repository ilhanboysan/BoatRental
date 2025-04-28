using Microsoft.AspNetCore.Mvc;
using UILayer.Dtos.PartnerDtos;
using UILayer.Services.PatnerServices;

namespace UILayer.Controllers
{
    public class AdminPartnerController : Controller
    {
        private readonly IPartnerService _PartnerService;

        public AdminPartnerController(IPartnerService PartnerService)
        {
            _PartnerService = PartnerService;
        }

        public async Task<IActionResult> Index()
        {
            var PartnerList = await _PartnerService.GetAllPartnerAsync();
            return View(PartnerList);
        }
        [HttpGet]
        public IActionResult CreatePartner()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePartner(CreatePartnerDto createPartnerDto)
        {
            var responseMessage = await _PartnerService.CreatePartnerAsync(createPartnerDto);

            if (responseMessage == "Blog Yazısı Başarıyla Eklendi")
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public async Task<IActionResult> DeletePartner(int id)
        {
            var message = await _PartnerService.DeletePartnerAsync(id);
            TempData["DeleteMessage"] = message;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdatePartner(int id)
        {
            var Partner = await _PartnerService.GetByIdAsync(id);
            if (Partner == null)
            {
                return NotFound();
            }
            return View(Partner);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePartner(UpdatePartnerDto updatePartnerDto)
        {

            var result = await _PartnerService.UpdatePartnerAsync(updatePartnerDto);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View(updatePartnerDto);
        }

    }
}
