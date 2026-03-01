using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShopMicroservices.Mikorservis.WebUI.Services.CatalogServices.ProductDetailServices;
using Newtonsoft.Json;

namespace MultiShopMicroservices.Mikorservis.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailDescriptionComponentPartial : ViewComponent
    {
        private readonly IProductDetailService _productDetailService;

        public _ProductDetailDescriptionComponentPartial(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productDetailService.GetByProductIdProductDetailAsync(id);
            return View(values);
            //var client = _httpClientFactory.CreateClient();
            //var responseMessgae = await client.GetAsync($"http://localhost:7110/api/ProductDetails/GetProductDetailByProductId?id=" + id);
            //if (responseMessgae.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessgae.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
            //    return View(values);
            //}
            //return View();
        }
    }
}
