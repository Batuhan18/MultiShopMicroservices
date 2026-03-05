using MultiShopMicroservices.DtoLayer.DiscountDtos;

namespace MultiShopMicroservices.Mikorservis.WebUI.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code);
        Task<int> GetDiscountCouponRate(string code);
    }
}
