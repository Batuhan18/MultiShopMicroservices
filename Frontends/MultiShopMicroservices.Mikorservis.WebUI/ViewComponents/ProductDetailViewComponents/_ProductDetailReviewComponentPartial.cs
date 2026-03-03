using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.DtoLayer.CommentDtos;
using MultiShopMicroservices.Mikorservis.WebUI.Services.CommentServices;
using Newtonsoft.Json;

namespace MultiShopMicroservices.Mikorservis.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReviewComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICommentService _commentService;

        public _ProductDetailReviewComponentPartial(IHttpClientFactory httpClientFactory, ICommentService commentService)
        {
            _httpClientFactory = httpClientFactory;
            _commentService = commentService;
        }


        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            //var values = await _commentService.CommentListByProductId(id);
            //return View(values);
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
