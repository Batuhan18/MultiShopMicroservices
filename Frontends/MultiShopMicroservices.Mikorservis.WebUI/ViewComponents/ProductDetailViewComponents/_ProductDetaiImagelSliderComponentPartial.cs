using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.DtoLayer.CatalogDtos.ProductDtos;
using MultiShopMicroservices.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShopMicroservices.Mikorservis.WebUI.Services.CatalogServices.ProductImageServices;
using Newtonsoft.Json;

namespace MultiShopMicroservices.Mikorservis.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetaiImagelSliderComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductImageService _productImageService;
        public _ProductDetaiImagelSliderComponentPartial(IHttpClientFactory httpClientFactory, IProductImageService productImageService)
        {
            _httpClientFactory = httpClientFactory;
            _productImageService = productImageService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productImageService.GetByProductIdProductImageAsync(id);
            return View(values);
        }

    }
}
