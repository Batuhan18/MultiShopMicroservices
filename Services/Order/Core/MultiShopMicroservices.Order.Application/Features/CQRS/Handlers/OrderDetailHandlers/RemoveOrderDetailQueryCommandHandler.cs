using MultiShopMicroservices.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShopMicroservices.Order.Application.Interfaces;
using MultiShopMicroservices.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopMicroservices.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class RemoveOrderDetailQueryCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public RemoveOrderDetailQueryCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderDetailCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
