using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.DefaultLayoutComponent
{
    public class _DefaultLayoutNavbarComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
