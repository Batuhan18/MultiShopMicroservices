using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.Mikorservis.WebUI.Services.StatisticServices.CatalogStatisticServices;

namespace MultiShopMicroservices.Mikorservis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;

        public StatisticController(ICatalogStatisticService catalogStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            var getBrandCount = await _catalogStatisticService.GetBrandCount();
            var getProductCount = await _catalogStatisticService.GetProductCount();
            var getCategoryCount = await _catalogStatisticService.GetCategoryCount();
            var getMaxPriceProductName = await _catalogStatisticService.GetMaxPriceProductName();
            var getMinPriceProductName = await _catalogStatisticService.GetMinPriceProductName();
            var getProductAvgPrice = await _catalogStatisticService.GetProductAvgPrice();
            ViewBag.v = getBrandCount;
            ViewBag.v1 = getProductCount;
            ViewBag.v2 = getCategoryCount;
            ViewBag.v3 = getMaxPriceProductName;
            ViewBag.v4 = getMinPriceProductName;
            ViewBag.v5 = getProductAvgPrice;
            return View();
        }
    }
}
