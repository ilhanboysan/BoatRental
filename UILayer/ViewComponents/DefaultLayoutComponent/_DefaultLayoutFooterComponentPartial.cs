using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.DefaultLayoutComponent
{
    public class _DefaultLayoutFooterComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
