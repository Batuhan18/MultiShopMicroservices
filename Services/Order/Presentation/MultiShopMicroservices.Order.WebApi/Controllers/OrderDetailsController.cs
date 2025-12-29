using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShopMicroservices.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShopMicroservices.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace MultiShopMicroservices.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
        private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly RemoveOrderDetailQueryCommandHandler _removeOrderDetailQueryCommandHandler;
        private readonly UpdateOrderDetailQueryCommandHandler _updateOrderDetailQueryCommandHandler;

        public OrderDetailsController(GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, GetOrderDetailQueryHandler getOrderDetailQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, RemoveOrderDetailQueryCommandHandler removeOrderDetailQueryCommandHandler, UpdateOrderDetailQueryCommandHandler updateOrderDetailQueryCommandHandler)
        {
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _removeOrderDetailQueryCommandHandler = removeOrderDetailQueryCommandHandler;
            _updateOrderDetailQueryCommandHandler = updateOrderDetailQueryCommandHandler;
        }

        public async Task<IActionResult> OrderDetailList()
        {
            var value = await _getOrderDetailQueryHandler.Handle();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var value = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await _createOrderDetailCommandHandler.Handle(command);
            return Ok("Sipariş detayı başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrderDetail(int id)
        {
            await _removeOrderDetailQueryCommandHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok("Sipariş detayı başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailQueryCommandHandler.Handle(command);
            return Ok("Sipariş detayı başarıyla güncellendi");
        }
    }
}
