using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShopMicroservices.Mikorservis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeatureSliderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çkan Görseller";
            ViewBag.v3 = "Slider Öne Çkan Görsel  Listesi";
            ViewBag.v0 = "Öne Çkan Görsel İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7110/api/FeatureSliders");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        [Route("CreateFeatureSlider")]
        [HttpGet]
        public IActionResult CreateFeatureSlider()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çkan Görseller";
            ViewBag.v3 = "Slider Öne Çkan Görsel  Listesi";
            ViewBag.v0 = "Öne Çkan Görsel İşlemleri";
            return View();
        }
        [Route("CreateFeatureSlider")]
        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            createFeatureSliderDto.Status = false;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFeatureSliderDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:7110/api/FeatureSliders", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            return View();
        }
        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("http://localhost:7110/api/FeatureSliders/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateFeatureSlider/{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çkan Görseller";
            ViewBag.v3 = "Slider Öne Çkan Görsel  Listesi";
            ViewBag.v0 = "Öne Çkan Görsel İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var responseMessgae = await client.GetAsync("http://localhost:7110/api/FeatureSliders/" + id);
            if (responseMessgae.IsSuccessStatusCode)
            {
                var jsonData = await responseMessgae.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateFeatureSliderDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateFeatureSlider/{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateFeatureSliderDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessgae = await client.PutAsync("http://localhost:7110/api/FeatureSliders/", stringContent);
            if (responseMessgae.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            return View();
        }
    }
}
