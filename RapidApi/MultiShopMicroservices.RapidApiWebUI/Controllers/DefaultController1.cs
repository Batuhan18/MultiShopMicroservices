using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.RapidApiWebUI.Models;
using Newtonsoft.Json;

namespace MultiShopMicroservices.RapidApiWebUI.Controllers
{
    public class DefaultController1 : Controller
    {
        public async Task<IActionResult> WeatherDetail()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://open-weather13.p.rapidapi.com/city?city=new%20york&lang=EN"),
                Headers =
    {
        { "x-rapidapi-key", "d4a58d4634mshef481a542f465a0p11b614jsn299da005958a" },
        { "x-rapidapi-host", "open-weather13.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<WeatherViewModel>(body);
                ViewBag.cityTemp = values.temp.ToString();
                return View(values);
            }

        }

        public async Task<IActionResult> Exchange()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&to_symbol=TRY&language=en"),
                Headers =
    {
        { "x-rapidapi-key", "d4a58d4634mshef481a542f465a0p11b614jsn299da005958a" },
        { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                ViewBag.cityTemp = values.temp.ToString();
                return View();
            }
        }
    }
}
