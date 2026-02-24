using MultiShopMicroservices.Mikorservis.WebUI.Models;

namespace MultiShopMicroservices.Mikorservis.WebUI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
    }
}
