using BookStore.BusinessLayer.Abstract;
using BookStore.EnttityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]

        public IActionResult ProductList()
        {
            return Ok(_productService.GetAll());
        }

        [HttpPost]

        public IActionResult CreateProduct(Product product)
        {
            _productService.Add(product);
            return Ok("Ekleme İşlemi Başarılı");
        }

        [HttpDelete]

        public IActionResult DeleteProduct(int id)
        {

            _productService.Delete(id);
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpGet("GetProduct")]

        public IActionResult GetProduct(int id)
        {
            return Ok(_productService.GetById(id));
        }

        [HttpGet("ProductCount")]

        public IActionResult ProductCount(int id)
        {
            return Ok(_productService.TGetProductCount());
        }
    }
}

