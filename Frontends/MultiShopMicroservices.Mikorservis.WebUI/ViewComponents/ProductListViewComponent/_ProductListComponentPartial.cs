using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShopMicroservices.Mikorservis.WebUI.ViewComponents.ProductListViewComponent
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            id = "6964f1e35540a33794c3d88e";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7110/api/Products/GetProductsWithCategoryByCategoryId?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
