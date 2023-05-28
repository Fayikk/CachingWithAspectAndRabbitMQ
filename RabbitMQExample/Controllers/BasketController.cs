using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using RabbitMQExample.DatabaseContext;
using RabbitMQExample.Entities;
using RabbitMQExample.RabbitMQSender;
using RabbitMQExample.Services.Abstract;

namespace RabbitMQExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost("{id}")]
        public IActionResult AddBasketItem([FromRoute]int id) 
        {
            var result = _basketService.Add(id);
          
            return Ok(result);

        }
    }
}