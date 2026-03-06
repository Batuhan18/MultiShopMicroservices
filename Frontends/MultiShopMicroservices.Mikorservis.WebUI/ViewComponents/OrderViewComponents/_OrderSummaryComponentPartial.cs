using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.Mikorservis.WebUI.Services.BasketService;

namespace MultiShopMicroservices.Mikorservis.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderSummaryComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _OrderSummaryComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basketTotal = await _basketService.GetBasket();
            var basketItems = basketTotal.BasketItems;
            return View(basketItems);
        }
    }
}
