using Microsoft.AspNetCore.Mvc;

namespace MultiShopMicroservices.Mikorservis.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CategoryDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
