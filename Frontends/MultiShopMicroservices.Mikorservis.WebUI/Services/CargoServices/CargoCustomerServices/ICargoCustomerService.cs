using MultiShopMicroservices.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace MultiShopMicroservices.Mikorservis.WebUI.Services.CargoServices.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<GetCargoCustomerByIdDto> GetByIdCargoCustomerInfoAsync(string id);
    }
}
