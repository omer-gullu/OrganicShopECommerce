using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.WebUI.ViewComponents.Default
{
    public class _HeroPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
