using Microsoft.EntityFrameworkCore;
using MultiShopMicroservices.Message.DAL.Entities;

namespace MultiShopMicroservices.Message.DAL.Context
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options) : base(options)
        {
        }

        public DbSet<UserMessage> UserMessages { get; set; }
    }
}
