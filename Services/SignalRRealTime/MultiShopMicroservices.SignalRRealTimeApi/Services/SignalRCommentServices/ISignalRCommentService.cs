namespace MultiShopMicroservices.SignalRRealTimeApi.Services.SignalRCommentServices
{
    public interface ISignalRCommentService
    {
        Task<int> GetTotalCommentCount();
    }
}
