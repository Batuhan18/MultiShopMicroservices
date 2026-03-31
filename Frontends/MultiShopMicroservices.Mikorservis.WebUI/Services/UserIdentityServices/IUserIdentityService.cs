using MultiShopMicroservices.DtoLayer.IdentityDtos.UserDtos;

namespace MultiShopMicroservices.Mikorservis.WebUI.Services.UserIdentityServices
{
    public interface IUserIdentityService
    {
        Task<List<ResultUserDto>> GetAllUserListAsync();
    }
}
