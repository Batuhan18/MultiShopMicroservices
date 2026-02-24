using MultiShopMicroservices.DtoLayer.IdentityDtos.LoginDtos;

namespace MultiShopMicroservices.Mikorservis.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDto signInDto);
        Task<bool> GetRefreshToken();
    }
}
