using BookStore.BusinessLayer.Abstract;
using BookStore.EnttityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var value = _categoryService.GetAll();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _categoryService.Add(category);
            return Ok("Ekleme İşlemi Başarılı");
        }

        [HttpDelete]

        public IActionResult DeleteCategory(int id)
        {
            _categoryService.Delete(id);
            return Ok("Silme İşlemi Başarılı");

        }

        [HttpPut]

        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.Update(category);
            return Ok("Güncelleme İşlemi Başarılı");

        }
    }
}
