using Microsoft.EntityFrameworkCore;
using RabbitMQExample.DatabaseContext;
using RabbitMQExample.Entities;
using RabbitMQExample.Services.Abstract;

namespace RabbitMQExample.Services
{
    public class OrderService : IOrderService
    {
        //private readonly ApplicationDbContext _context;
        DbContextOptions<ApplicationDbContext> _dbContext;
        public OrderService(DbContextOptions<ApplicationDbContext> dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateOrder(Order order)
        {
            await using var _db = new ApplicationDbContext(_dbContext);
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
