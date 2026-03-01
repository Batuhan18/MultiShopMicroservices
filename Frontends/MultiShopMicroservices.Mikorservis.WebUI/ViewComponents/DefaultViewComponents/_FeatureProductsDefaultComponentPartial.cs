using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.DtoLayer.CatalogDtos.ProductDtos;
using MultiShopMicroservices.Mikorservis.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace MultiShopMicroservices.Mikorservis.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureProductsDefaultComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _FeatureProductsDefaultComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllProductAsync();
            return View(values);
        }
    }
}
