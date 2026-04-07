
namespace MultiShopMicroservices.SignalRRealTimeApi.Services.SignalRMessageServices
{
    public class SignalRMessageService : ISignalRMessageServices
    {
        private readonly HttpClient _httpClient;

        public SignalRMessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalMessageCountByReceiverId(string id)
        {
            var responseMessage = await _httpClient.GetAsync("comments/GetTotalMessageCountByReceiverId?=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
