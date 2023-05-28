using System.ComponentModel.DataAnnotations;

namespace RabbitMQExample.Entities
{
    public class Order : BaseMessage
    {
        [Key]
        public int OrderId { get; set; }
        public int ProductId { get; set; }  
        public int BasketId { get; set; }   
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

    }
}
