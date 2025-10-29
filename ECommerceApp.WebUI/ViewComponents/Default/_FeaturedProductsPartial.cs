using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.WebUI.ViewComponents.Default
{
    public class _FeaturedProductsPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
