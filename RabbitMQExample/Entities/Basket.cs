using System.ComponentModel.DataAnnotations;

namespace RabbitMQExample.Entities
{
    public class Basket : BaseMessage
    {
        [Key]
        public int BasketId { get; set; }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
