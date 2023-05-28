using RabbitMQExample.Entities;

namespace RabbitMQExample.Services.Abstract
{
    public interface ICategoryService
    {
        public Category CreateCategory(Category category);
        public Category UpdateCategory(Category category);
        public Category DeleteCategory(int categoryId);
        public List<Category> GetAllCategories();
    }
}
