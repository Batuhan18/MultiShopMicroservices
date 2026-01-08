using Microsoft.AspNetCore.Mvc;

namespace MultiShopMicroservices.Mikorservis.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _HeadUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
