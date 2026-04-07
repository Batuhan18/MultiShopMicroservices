using Microsoft.AspNetCore.SignalR;
using MultiShopMicroservices.SignalRRealTimeApi.Services;
using MultiShopMicroservices.SignalRRealTimeApi.Services.SignalRCommentServices;
using MultiShopMicroservices.SignalRRealTimeApi.Services.SignalRMessageServices;

namespace MultiShopMicroservices.SignalRRealTimeApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ISignalRCommentService _signalRCommentService;
       // private readonly ISignalRMessageServices _signalRMessageServices;

        public SignalRHub(ISignalRCommentService signalRCommentService)
        {
            _signalRCommentService = signalRCommentService;
        }

        public async Task SendStatisticCount()
        {
            var getTotalCommentCount =await _signalRCommentService.GetTotalCommentCount();
            await Clients.All.SendAsync("ReceiveCommentCount", getTotalCommentCount);
        }
    }
}
