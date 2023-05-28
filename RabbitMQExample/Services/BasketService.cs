using RabbitMQExample.DatabaseContext;
using RabbitMQExample.Entities;
using RabbitMQExample.RabbitMQSender;
using RabbitMQExample.Services.Abstract;

namespace RabbitMQExample.Services
{
    public class BasketService : IBasketService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRabbitMQCartMessageSender _messageSender;

        public BasketService(ApplicationDbContext context, IRabbitMQCartMessageSender messageSender)
        {
            _context = context;
            _messageSender = messageSender;
        }

        public Basket Add(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            Basket basket = new Basket();
            basket.ProductId = id;
            basket.Name = product.Name;
            basket.Description = product.Description;
            basket.Price = product.Price;
            _context.Baskets.Add(basket);
            _messageSender.SendMessage(basket, "checkoutqueue");
            _context.SaveChanges();
            return basket;
        }
    }
}
