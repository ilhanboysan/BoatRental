using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.AdminLayoutComponent
{
    public class _AdminLayoutSidebarComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
