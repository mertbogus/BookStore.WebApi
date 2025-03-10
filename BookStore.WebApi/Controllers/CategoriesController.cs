using AutoMapper;
using BookStore.BusinessLayer.Abstract;
using BookStore.EnttityLayer.Concrete;
using BookStore.WebApi.Dtos.CategoryDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var value = _categoryService.GetAll();
            var categorydtos=_mapper.Map<List<ResultCategory>>(value);
            return Ok(categorydtos);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategory category)
        {
            var categories=_mapper.Map<Category>(category);
            _categoryService.Add(categories);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.Delete(id);
            return Ok("Silme işlemi başarılı");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategory category)
        {
            var categories= _mapper.Map<Category>(category);
            _categoryService.Update(categories);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            return Ok(_categoryService.GetById(id));
        }

    }
}
