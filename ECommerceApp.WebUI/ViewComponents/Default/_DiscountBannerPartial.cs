using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.WebUI.ViewComponents.Default
{
    public class _DiscountBannerPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
