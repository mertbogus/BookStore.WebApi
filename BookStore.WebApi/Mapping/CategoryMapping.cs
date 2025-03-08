using AutoMapper;
using BookStore.EnttityLayer.Concrete;
using BookStore.WebApi.Dtos.CategoryDto;

namespace BookStore.WebApi.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {

            CreateMap<Category, ResultCategory>().ReverseMap();
            CreateMap<Category, CreateCategory>().ReverseMap();
            CreateMap<Category, UpdateCategory>().ReverseMap();
          

        }
    }
}
