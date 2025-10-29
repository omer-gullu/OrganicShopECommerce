using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.WebUI.ViewComponents.Default
{
    public class _ServiceFeaturesPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
