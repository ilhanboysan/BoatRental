using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.AdminLayoutComponent
{
    public class _AdminLayoutJavaScriptComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
