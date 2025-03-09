using AutoMapper;
using BookStore.EntityLayer.Concrete;
using BookStore.WebApi.Dtos.WordDto;

namespace BookStore.WebApi.Mapping
{
    public class WordMapping : Profile
    {
        public WordMapping()
        {

            CreateMap<Word,ResultWord>().ReverseMap();
            CreateMap<Word,CreateWord>().ReverseMap();
            CreateMap<Word,UpdateWord>().ReverseMap();

        }
    }
}
