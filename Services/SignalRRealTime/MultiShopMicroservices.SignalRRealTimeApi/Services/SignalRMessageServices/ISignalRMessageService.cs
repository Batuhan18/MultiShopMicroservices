namespace MultiShopMicroservices.SignalRRealTimeApi.Services.SignalRMessageServices
{
    public interface ISignalRMessageServices
    {
        Task<int> GetTotalMessageCountByReceiverId(string id);
    }
}
