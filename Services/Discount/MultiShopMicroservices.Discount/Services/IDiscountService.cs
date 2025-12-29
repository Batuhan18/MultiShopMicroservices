using MultiShopMicroservices.Discount.Dtos;

namespace MultiShopMicroservices.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllCouponAsync();
        Task CreateCouponDto(CreateCouponDto createCouponDto);
        Task UpdateCouponDto(UpdateCouponDto updateCouponDto);
        Task DeleteCouponDto(int id);
        Task<GetByIdCouponDto> GetByIdCouponAsync(int id);

    }
}
