using System.ComponentModel.DataAnnotations;

namespace RabbitMQExample.Entities
{
    public class Product :BaseMessage
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
