using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MultiShopMicroservices.Mikorservis.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpecialOfferDefaultComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _SpecialOfferDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]

        public async Task<IViewComponentResult> InvokeAsync()
        {
           

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7110/api/SpecialOffer");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData)
                             ?? new List<ResultSpecialOfferDto>();

                return View(values);
            }

            // başarısız olursa bile view NULL gitmesin
            return View();
        }
    }
}
