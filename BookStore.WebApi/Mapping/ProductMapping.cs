using AutoMapper;
using BookStore.EnttityLayer.Concrete;
using BookStore.WebApi.Dtos.CategoryDto;
using BookStore.WebApi.Dtos.ProductDto;
using System.Security.Cryptography.X509Certificates;

namespace BookStore.WebApi.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ResultProduct>().ReverseMap();
            CreateMap<Product, UpdateProduct>().ReverseMap();
            CreateMap<Product, CreateProduct>().ReverseMap();
          
        }

    }
}
