using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.Mikorservis.WebUI.Services.Interfaces;
using MultiShopMicroservices.Mikorservis.WebUI.Services.OrderServices.OrderOrderingServices;

namespace MultiShopMicroservices.Mikorservis.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrdersController : Controller
    {
        private readonly IOrderOrderingService _orderOrderingService;
        private readonly IUserService _userService;
        public MyOrdersController(IOrderOrderingService orderOrderingService, IUserService userService)
        {
            _orderOrderingService = orderOrderingService;
            _userService = userService;
        }

        public async Task<IActionResult> MyOrderList()
        {
            var user = await _userService.GetUserInfo();
            var values =await _orderOrderingService.GetOrderingByUserId(user.Id);
            return View(values);
        }
    }
}
