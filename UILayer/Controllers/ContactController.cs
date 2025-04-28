using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UILayer.Models;
using UILayer.Services.EmailServices;

namespace UILayer.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IEmailService _emailService;

        public ContactController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(ContactModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            try
            {
                await _emailService.SendEmailAsync(model.Name, model.Email, model.Subject, model.Message);
                TempData["Message"] = "Mesajınız başarıyla iletildi.";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["Message"] = $"Hata oluştu: {ex.Message}";
            }

            return View("Index");
        }

    }
}
