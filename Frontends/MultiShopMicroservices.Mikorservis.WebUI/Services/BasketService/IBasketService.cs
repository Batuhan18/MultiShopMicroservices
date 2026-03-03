using MultiShopMicroservices.DtoLayer.BasketDtos;

namespace MultiShopMicroservices.Mikorservis.WebUI.Services.BasketService
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket();
        Task SaveBasket(BasketTotalDto basketTotalDto);
        Task DeleteBasket(string userId);
        Task AddBasketItem(BasketItemDto basketItemDto);
        Task<bool> RemoveBasketItem(string productId);
    }
}
