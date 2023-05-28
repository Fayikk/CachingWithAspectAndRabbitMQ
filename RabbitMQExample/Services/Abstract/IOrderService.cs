using RabbitMQExample.Entities;

namespace RabbitMQExample.Services.Abstract
{
    public interface IOrderService
    {
        public Task<bool> CreateOrder(Order order);  
    }
}
