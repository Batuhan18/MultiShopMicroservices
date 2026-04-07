using MultiShopMicroservices.DtoLayer.MessageDtos;

namespace MultiShopMicroservices.Mikorservis.WebUI.Services.MessageServices
{
    public interface IMessageService
    {
        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id);
        Task<List<ResultSendboxMessageDto>> GetSendBoxMessageAsync(string id);
        Task<int> GetTotalMessageCountByReceiverId(string id);
    }
}
