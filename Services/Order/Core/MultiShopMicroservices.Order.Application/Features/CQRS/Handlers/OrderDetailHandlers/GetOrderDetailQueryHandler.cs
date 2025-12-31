using MultiShopMicroservices.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShopMicroservices.Order.Application.Interfaces;
using MultiShopMicroservices.Order.Domain.Entities;

namespace MultiShopMicroservices.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderDetailQueryResult
            {
                OrderDetailId = x.OrderDetailId,
                ProductAmount = x.ProductAmount,
                ProductId = x.ProductId,
                OrderingId = x.OrderingId,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductTotalPrice = x.ProductTotalPrice
            }).ToList();
        }
    }
}
