using AutoMapper;
using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using BookStore.EnttityLayer.Concrete;
using BookStore.WebApi.Dtos.CategoryDto;
using BookStore.WebApi.Dtos.MailSendingDto;
using BookStore.WebApi.Dtos.ProductDto;
using BookStore.WebApi.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public SubscribeController(ISubscribeService subscribeService, IMapper mapper, IEmailService emailService)
        {
            _subscribeService = subscribeService;
            _mapper = mapper;
             _emailService = emailService;
        }


        [HttpGet]

        public IActionResult SubscribeList()
        {
            var value = _subscribeService.GetAll();
            var values = _mapper.Map<List<ResultSubscribeDto>>(value);
            return Ok(values);
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmailToSubscribers([FromBody] EmailRequest request)
        {
            // Abonelere ait e-posta adreslerini alıyoruz
            var subscribers = _subscribeService.GetAll();

            if (subscribers == null || !subscribers.Any())
            {
                return NotFound(new { message = "Abone bulunamadı." });
            }

            foreach (var subscriber in subscribers)
            {
                // Her aboneye mesaj gönderiyoruz
                await _emailService.SendEmailAsync(subscriber.SubscribeMail, request.Subject, request.Body);
            }

            return Ok(new { message = "E-posta başarıyla gönderildi." });
        }

        [HttpPost]
        public IActionResult CreateSubscribe(CreateSubscribeDto createSubscribeDto)
        {
            var sub = _mapper.Map<Subscribe>(createSubscribeDto);
            _subscribeService.Add(sub);
            return Ok("Ekleme işlemi başarılı");
        }
    }
}
