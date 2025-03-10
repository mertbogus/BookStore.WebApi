using BookStore.WebUI.Dtos.CategoryDtos;
using BookStore.WebUI.Dtos.ProductDtos;
using BookStore.WebUI.Dtos.SubscribeDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BookStore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSubscriberController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminSubscriberController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7292/api/Subscribe");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSubscribeDto>>(jsonData);
            return View(values);
        }


        public async Task<IActionResult> SendEmail(EmailRequestDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7292/api/Subscribe/send", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return NoContent();
            }
            return NoContent();
        }
    }
}
