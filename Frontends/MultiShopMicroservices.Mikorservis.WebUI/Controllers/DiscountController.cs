using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.Mikorservis.WebUI.Services.BasketService;
using MultiShopMicroservices.Mikorservis.WebUI.Services.DiscountServices;

namespace MultiShopMicroservices.Mikorservis.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;
        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }
        [HttpGet]
        public PartialViewResult ConfirmDicountCoupon()
        {         
            return PartialView();
        }

        [HttpPost]
        public IActionResult ConfirmDicountCoupon(string code)
        {
            var values = _discountService.GetDiscountCode(code);
            return View(values);
        }
    }
}
