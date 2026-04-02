using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.Mikorservis.WebUI.Services.CommentServices;
using MultiShopMicroservices.Mikorservis.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShopMicroservices.Mikorservis.WebUI.Services.StatisticServices.DiscountStatisticServices;
using MultiShopMicroservices.Mikorservis.WebUI.Services.StatisticServices.MessageStatisticServices;
using MultiShopMicroservices.Mikorservis.WebUI.Services.StatisticServices.UserStatisticServices;

namespace MultiShopMicroservices.Mikorservis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly ICommentService _commentService;
        private readonly IDiscountStatisticService _discountStatisticService;
        private readonly IMessageStatisticService _messageStatisticService;

        public StatisticController(ICatalogStatisticService catalogStatisticService, IUserStatisticService userStatisticService, ICommentService commentService, IDiscountStatisticService discountStatisticService, IMessageStatisticService messageStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticService = userStatisticService;
            _commentService = commentService;
            _discountStatisticService = discountStatisticService;
            _messageStatisticService = messageStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            var getBrandCount = await _catalogStatisticService.GetBrandCount();
            var getProductCount = await _catalogStatisticService.GetProductCount();
            var getCategoryCount = await _catalogStatisticService.GetCategoryCount();
            var getMaxPriceProductName = await _catalogStatisticService.GetMaxPriceProductName();
            var getMinPriceProductName = await _catalogStatisticService.GetMinPriceProductName();
            var getProductAvgPrice = await _catalogStatisticService.GetProductAvgPrice();
            var getUserCount = await _userStatisticService.GetUserCount();
            //var getTotalCommentCount = await _commentService.GetTotalCommentCount();
            //var getActiveCommentCount = await _commentService.GetActiveCommentCount();
            //var getPassiveCommentCount = await _commentService.GetPassiveCommentCount();
            var getDiscountCount = await _discountStatisticService.GetDiscountCouponCount();
            var getTotalMessageCount = await _messageStatisticService.GetTotalMessageCount();
            ViewBag.v = getBrandCount;
            ViewBag.v1 = getProductCount;
            ViewBag.v2 = getCategoryCount;
            ViewBag.v3 = getMaxPriceProductName;
            ViewBag.v4 = getMinPriceProductName;
            ViewBag.v5 = getProductAvgPrice;
            ViewBag.v6 = getUserCount;
            //ViewBag.v7 = getTotalCommentCount;
            //ViewBag.v8 = getActiveCommentCount;
            //ViewBag.v9 = getPassiveCommentCount;
            ViewBag.v10 = getDiscountCount;
            ViewBag.v11 = getTotalMessageCount;
            return View();
        }
    }
}
