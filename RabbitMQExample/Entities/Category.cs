using System.ComponentModel.DataAnnotations;

namespace RabbitMQExample.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; } 
        public string CategoryName { get; set; }    
        public string CategoryDescription { get; set; } = string.Empty;

    }
}
