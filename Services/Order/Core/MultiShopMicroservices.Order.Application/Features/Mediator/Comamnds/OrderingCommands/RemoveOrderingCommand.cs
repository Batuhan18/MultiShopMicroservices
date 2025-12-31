using MediatR;

namespace MultiShopMicroservices.Order.Application.Features.Mediator.Comamnds.OrderingCommands
{
    public class RemoveOrderingCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveOrderingCommand(int id)
        {
            Id = id;
        }
    }
}
