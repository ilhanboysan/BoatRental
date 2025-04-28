using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.AdminLayoutComponent
{
    public class _AdminLayoutFooterComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
