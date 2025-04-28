using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class AdminLayoutController : Controller
    {
        public async Task<IActionResult> _AdminLayout()
        {
            return View();
        }
    }
}
