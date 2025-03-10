using AutoMapper;
using BookStore.EntityLayer.Concrete;
using BookStore.WebApi.Dtos.SubscribeDto;

namespace BookStore.WebApi.Mapping
{
    public class SubscribeMapping : Profile
    {
        public SubscribeMapping()
        {

            CreateMap<Subscribe, ResultSubscribeDto>().ReverseMap();
            CreateMap<Subscribe, CreateSubscribeDto>().ReverseMap();

        }
    }
}
