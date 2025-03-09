using BookStore.WebUI.Dtos.ProductDtos;
using BookStore.WebUI.Dtos.WordDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookStore.WebUI.viewComponents.WordOfDay
{
    public class _UIWordOfTheDayComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UIWordOfTheDayComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7292/api/Words/GetLastWord");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetLastWordDto>(jsonData);
            return View(values);
        }
    }
}
