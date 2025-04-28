using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class DefaultLayoutController : Controller
    {
        public async Task<IActionResult> _DefaultLayout()
        {
            return View();
        }
    }
}
