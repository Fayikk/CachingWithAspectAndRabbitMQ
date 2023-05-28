using Newtonsoft.Json.Bson;
using RabbitMQExample.Entities;

namespace RabbitMQExample.Services.Abstract
{
    public interface IBasketService
    {
        public Basket Add(int id);
    }
}
