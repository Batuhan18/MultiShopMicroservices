using MediatR;
using MultiShopMicroservices.Order.Application.Features.Mediator.Comamnds.OrderingCommands;
using MultiShopMicroservices.Order.Application.Interfaces;
using MultiShopMicroservices.Order.Domain.Entities;

namespace MultiShopMicroservices.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public CreateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Ordering
            {
                UserId = request.UserId,
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice
            });
        }
    }
}
