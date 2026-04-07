using Microsoft.AspNetCore.SignalR;
using MultiShopMicroservices.SignalRRealTimeApi.Services;
using MultiShopMicroservices.SignalRRealTimeApi.Services.SignalRCommentServices;
using MultiShopMicroservices.SignalRRealTimeApi.Services.SignalRMessageServices;

namespace MultiShopMicroservices.SignalRRealTimeApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ISignalRCommentService _signalRCommentService;
        private readonly ISignalRMessageServices _signalRMessageServices;

        public SignalRHub(ISignalRCommentService signalRCommentService, ISignalRMessageServices signalRMessageServices)
        {
            _signalRCommentService = signalRCommentService;
            _signalRMessageServices = signalRMessageServices;
        }

        public async Task SendStatisticCount(string id)
        {
            var getTotalCommentCount =_signalRCommentService.GetTotalCommentCount();
            await Clients.All.SendAsync("ReceiveCommentCount", getTotalCommentCount);

            var getTotalMessageCount = _signalRMessageServices.GetTotalMessageCountByReceiverId(id);
            await Clients.All.SendAsync("ReceiveMessageCount", getTotalMessageCount);
        }
    }
}
