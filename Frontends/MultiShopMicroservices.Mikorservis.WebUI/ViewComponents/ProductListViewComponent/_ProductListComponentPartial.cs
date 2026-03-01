using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.DtoLayer.CatalogDtos.ProductDtos;
using MultiShopMicroservices.Mikorservis.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace MultiShopMicroservices.Mikorservis.WebUI.ViewComponents.ProductListViewComponent
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductListComponentPartial(IProductService productService)
        {
            _productService = productService;
        }
        [Route("Index")]

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productService.GetProductsWithCategoryByCategoryIdAsync(id);
            return View(values);
        }
    }
}
