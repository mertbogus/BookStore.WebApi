using AutoMapper;
using BookStore.BusinessLayer.Abstract;
using BookStore.EnttityLayer.Concrete;
using BookStore.WebApi.Dtos.CategoryDto;
using BookStore.WebApi.Dtos.ProductDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }


        [HttpGet]

        public IActionResult ProductList()
        {
            var product = _productService.GetAll();
            var productdto=_mapper.Map<List<ResultProduct>>(product);
            return Ok(productdto);
        }

        [HttpPost]

        public IActionResult CreateProduct(CreateProduct createProduct)
        {
            var product = _mapper.Map<Product>(createProduct);
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


        [HttpPut]
        public IActionResult UpdateProduct(UpdateProduct updateProduct)
        {
            var product = _mapper.Map<Product>(updateProduct);
            _productService.Update(product);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpGet("random")]
        public async Task<IActionResult> GetRandomProduct()
        {
            var randomProduct = await _productService.GetRandomProductAsync();
            if (randomProduct == null)
                return NotFound("Veritabanında rastgele kitap bulunamadı.");

            return Ok(randomProduct);
        }
    }
}

