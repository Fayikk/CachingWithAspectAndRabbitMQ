using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQExample.DatabaseContext;
using RabbitMQExample.Entities;
using RabbitMQExample.RabbitMQSender;

namespace RabbitMQExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IRabbitMQCartMessageSender _rabbitMQCartMessageSender;
        public OrderController(ApplicationDbContext context,IRabbitMQCartMessageSender rabbitMQCartMessageSender)
        {
            _context = context;
            _rabbitMQCartMessageSender = rabbitMQCartMessageSender; 
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return Ok();
        }
    }
}
