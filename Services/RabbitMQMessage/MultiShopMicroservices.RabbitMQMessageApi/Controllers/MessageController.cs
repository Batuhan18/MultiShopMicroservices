using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MultiShopMicroservices.RabbitMQMessageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateMessage()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            var connection = await connectionFactory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();
            channel.QueueDeclareAsync("Kuyruk2", false, false, false, arguments: null);
            var messageContent = "Merhaba bugün hava çok sıcak.";
            var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);
            var properties = new BasicProperties();
            channel.BasicPublishAsync(exchange: "", routingKey: "Kuyruk2", mandatory: false, basicProperties: properties, body: byteMessageContent);
            return Ok("Mesajınız kuyruğa alınmıştır");
        }

        private static string message;

        [HttpGet]
        public async Task<IActionResult> ReadMessage()
        {
            var factory = new ConnectionFactory();
            factory.HostName = "localhost";
            var connection = await factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();
            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += (model, x) =>
            {
                var byteMessage = x.Body.ToArray();
                var message = Encoding.UTF8.GetString(byteMessage);
                return Task.CompletedTask;
            };
            channel.BasicConsumeAsync(queue: "Kuyruk2", autoAck: false, consumer: consumer);
            if (string.IsNullOrEmpty(message))
            {
                return NoContent();
            }
            else
            {
                return Ok(message);
            }

        }
    }
}
