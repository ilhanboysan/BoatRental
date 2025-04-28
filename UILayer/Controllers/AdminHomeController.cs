using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
