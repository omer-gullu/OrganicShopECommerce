using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.WebUI.ViewComponents.Default
{
    public class _IconPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
