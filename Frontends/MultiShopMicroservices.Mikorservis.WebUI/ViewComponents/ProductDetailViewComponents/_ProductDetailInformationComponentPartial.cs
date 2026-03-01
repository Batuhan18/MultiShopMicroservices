using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShopMicroservices.Mikorservis.WebUI.Services.CatalogServices.ProductDetailServices;
using Newtonsoft.Json;

namespace MultiShopMicroservices.Mikorservis.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailInformationComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductDetailService _productDetailService;

        public _ProductDetailInformationComponentPartial(IHttpClientFactory httpClientFactory, IProductDetailService productDetailService)
        {
            _httpClientFactory = httpClientFactory;
            _productDetailService = productDetailService;
        }
        [HttpGet]

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productDetailService.GetByProductIdProductDetailAsync(id);
            return View(values);
        }
    }
}
