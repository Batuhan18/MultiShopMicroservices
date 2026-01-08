using Microsoft.AspNetCore.Mvc;

namespace MultiShopMicroservices.Mikorservis.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
