using MultiShopMicroservices.DtoLayer.OrderDtos.OrderingDtos;

namespace MultiShopMicroservices.Mikorservis.WebUI.Services.OrderServices.OrderOrderingServices
{
    public interface IOrderOrderingService
    {
        Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id);
    }
}
