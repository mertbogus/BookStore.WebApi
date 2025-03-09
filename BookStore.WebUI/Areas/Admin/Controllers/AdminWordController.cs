using BookStore.WebUI.Dtos.CategoryDtos;
using BookStore.WebUI.Dtos.ProductDtos;
using BookStore.WebUI.Dtos.WordDto;
using BookStore.WebUI.Dtos.WordDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BookStore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminWordController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminWordController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> WordList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7292/api/Words");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultWordDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateWord()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWord(CreateWordDto createWordDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createWordDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7292/api/Words", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("WordList", "AdminWord", new { area = "Admin" });
            }
            return View();
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7292/api/Words/GetWord?id=" + id);
            return RedirectToAction("WordList", "AdminWord", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateWord(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7292/api/Words/GetWord?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetByIdWordDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWord(UpdateWordDto updateWordDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateWordDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7292/api/Words", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("WordList", "AdminWord", new { area = "Admin" });
            }
            return View();
        }
    }
}
