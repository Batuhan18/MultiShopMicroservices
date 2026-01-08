using Microsoft.AspNetCore.Mvc;

namespace MultiShopMicroservices.Mikorservis.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _TapbarUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
