using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopMicroservices.Order.Application.Features.CQRS.Commands.OrderDetailCommands
{
    public class OrderDetailCommand
    {
        public int Id { get; set; }

        public OrderDetailCommand(int id)
        {
            Id = id;
        }
    }
}
