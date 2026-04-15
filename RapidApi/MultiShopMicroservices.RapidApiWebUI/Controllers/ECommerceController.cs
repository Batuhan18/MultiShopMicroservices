using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.RapidApiWebUI.Models;
using Newtonsoft.Json;
using NuGet.Protocol;

namespace MultiShopMicroservices.RapidApiWebUI.Controllers
{
    public class ECommerceController : Controller
    {
        public async Task<IActionResult> ECommerceList()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-product-search.p.rapidapi.com/search-v2?q=logitech%20fare&country=tr&language=en&page=1&limit=10&sort_by=BEST_MATCH&product_condition=ANY&return_filters=true"),
                Headers =
    {
        { "x-rapidapi-key", "d4a58d4634mshef481a542f465a0p11b614jsn299da005958a" },
        { "x-rapidapi-host", "real-time-product-search.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ECommerceViewModel>(body);
                return View(values.data.products.ToList());
            }          
        }
    }
}