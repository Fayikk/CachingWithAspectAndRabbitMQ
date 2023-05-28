using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQExample.Entities;
using RabbitMQExample.Services;
using RabbitMQExample.Services.Abstract;
using System.Text;
using System.Threading.Channels;

namespace RabbitMQExample.Messaging
{
    public class RabbitMQConsumer : BackgroundService
    {
        private readonly OrderService _orderService;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        public RabbitMQConsumer( OrderService orderService)
        {
            _orderService = orderService;

            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "checkoutqueue", false, false, false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
           stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                Basket basket = JsonConvert.DeserializeObject<Basket>(content);
                HandleMessage(basket).GetAwaiter().GetResult();
                _channel.BasicAck(ea.DeliveryTag, false);
            };
            _channel.BasicConsume("checkoutqueue", false, consumer);
            return Task.CompletedTask;  
        }

        //public int ProductId { get; set; }
        //public int BasketId { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public double Price { get; set; }

        private async Task HandleMessage(Basket basket)
        {
            Order order = new()
            {
                ProductId = basket.ProductId,
                BasketId = basket.Id,
                Name = basket.Name,
                Description = basket.Description,
                Price = basket.Price,
            };
            await _orderService.CreateOrder(order);
            try
            {
                //_messageSender.SendMessage(order, "succesProcessTopic");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
