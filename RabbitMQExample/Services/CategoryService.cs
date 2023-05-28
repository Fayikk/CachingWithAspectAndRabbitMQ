using RabbitMQExample.CrossCuttingConcerns;
using RabbitMQExample.DatabaseContext;
using RabbitMQExample.Entities;
using RabbitMQExample.Services.Abstract;

namespace RabbitMQExample.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Category CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public Category DeleteCategory(int categoryId)
        {
            var result = _context.Categories.Find(categoryId);
            _context.Categories.Remove(result);
            _context.SaveChanges();
            return result;
        }
        [CacheAspect]
        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Category UpdateCategory(Category category)
        {
            var result = _context.Categories.Find(category.Id);
            Category model = new Category
            {
                CategoryDescription = result.CategoryDescription,
                CategoryName = result.CategoryName,
               
            };
            _context.Categories.Update(model);
            _context.SaveChanges();
            return result;  
        }
    }
}
