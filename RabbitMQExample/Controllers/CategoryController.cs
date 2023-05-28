using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQExample.Entities;
using RabbitMQExample.Services.Abstract;

namespace RabbitMQExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("Create")]  
        public IActionResult Add(Category category)
        {
            _categoryService.CreateCategory(category);
            return Ok();
        }
        [HttpPost("Update")]
        public IActionResult Update(Category category)
        {
            _categoryService.UpdateCategory(category);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id) 
        { 
            _categoryService?.DeleteCategory(id);
            return Ok();
        }

        [HttpGet]   
        public IActionResult Get()
        {
            var result = _categoryService.GetAllCategories();
            return Ok(result);
        }
    }

}

//public Category CreateCategory(Category category);
//public Category UpdateCategory(Category category);
//public Category DeleteCategory(int categoryId);
//public List<Category> GetAllCategories();