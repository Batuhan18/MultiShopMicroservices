using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.DtoLayer.CommentDtos;
using Newtonsoft.Json;

namespace MultiShopMicroservices.Mikorservis.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReviewComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailReviewComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"https://localhost:7214/api/Comments/CommentListByProductId?id={id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                    return View(values ?? new List<ResultCommentDto>());
                }

                return View(new List<ResultCommentDto>());

            }
            catch (Exception ex)
            {

                Console.WriteLine($"ERROR: {ex.Message}");
                Console.WriteLine($"STACK: {ex.StackTrace}");
                return View(new List<ResultCommentDto>());
            }
        
        }
    }
}
