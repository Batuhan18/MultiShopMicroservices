using MediatR;

namespace MultiShopMicroservices.Order.Application.Features.Mediator.Comamnds.OrderingCommands
{
    public class UpdateOrderingCommand : IRequest
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
