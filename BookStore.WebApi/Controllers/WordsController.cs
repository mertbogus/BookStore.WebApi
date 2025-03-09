using AutoMapper;
using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using BookStore.EnttityLayer.Concrete;
using BookStore.WebApi.Dtos.CategoryDto;
using BookStore.WebApi.Dtos.WordDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly IWordService _wordService;
        private readonly IMapper _mapper;

        public WordsController(IWordService wordService, IMapper mapper)
        {
            _wordService = wordService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult WordList()
        {
            var value = _wordService.GetAll();
            var worddtos = _mapper.Map<List<ResultWord>>(value);
            return Ok(worddtos);
        }

        [HttpPost]
        public IActionResult CreateWord(CreateWord createWord)
        {
            var words = _mapper.Map<Word>(createWord);
            _wordService.Add(words);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteWord(int id)
        {
            _wordService.Delete(id);
            return Ok("Silme işlemi başarılı");
        }

        [HttpPut]
        public IActionResult UpdateWord(UpdateWord updateWord)
        {
            var words = _mapper.Map<Word>(updateWord);
            _wordService.Update(words);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpGet("GetWord")]
        public IActionResult GetWord(int id)
        {
            return Ok(_wordService.GetById(id));
        }

        [HttpGet("GetLastWord")]
        public IActionResult GetLastWord()
        {
            return Ok( _wordService.GetLastWord());
        }
    }
}
