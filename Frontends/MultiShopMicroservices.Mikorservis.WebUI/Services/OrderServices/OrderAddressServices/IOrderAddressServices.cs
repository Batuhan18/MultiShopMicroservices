using MultiShopMicroservices.DtoLayer.OrderDtos.AddressesDtos;

namespace MultiShopMicroservices.Mikorservis.WebUI.Services.OrderServices.OrderAddressServices
{
    public interface IOrderAddressServices
    {
        //Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto);
        //Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        //Task DeleteAboutAsync(string id);
        //Task<UpdateAboutDto> GetByIdAboutAsync(string id);
    }
}
