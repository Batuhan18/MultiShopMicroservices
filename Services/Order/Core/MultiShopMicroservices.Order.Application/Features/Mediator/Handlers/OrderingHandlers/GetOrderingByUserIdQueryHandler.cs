using MediatR;
using MultiShopMicroservices.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShopMicroservices.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShopMicroservices.Order.Application.Interfaces;
using MultiShopMicroservices.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopMicroservices.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByUserIdQueryHandler : IRequestHandler<GetOrderingByUserIdQuery, GetOrderingByUserIdQueryResult>
    {
        public Task<GetOrderingByUserIdQueryResult> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
        {
            //var values = await _repository.GetByIdAsync(request.Id);
            //return new GetOrderingByIdQueryResult
            //{
            //    OrderDate = values.OrderDate,
            //    OrderingId = values.OrderingId,
            //    TotalPrice = values.TotalPrice,
            //    UserId = values.UserId
            //};
            throw new NotImplementedException();
        }
    }


}
