using Microsoft.AspNetCore.Mvc;

namespace MultiShopMicroservices.Mikorservis.WebUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
