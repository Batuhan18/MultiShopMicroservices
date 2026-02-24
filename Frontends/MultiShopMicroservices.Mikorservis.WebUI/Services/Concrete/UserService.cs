using MultiShopMicroservices.Mikorservis.WebUI.Models;
using MultiShopMicroservices.Mikorservis.WebUI.Services.Interfaces;

namespace MultiShopMicroservices.Mikorservis.WebUI.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDetailViewModel> GetUserInfo()
        {
            return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/user/getuser");
        }
    }
}
