using BookStore.WebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace BookStore.WebUI.viewComponents.Books
{
    public class _UIFeatureBooksComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _UIFeatureBooksComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7292/api/Products");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<UIResultProductFeatureDto>>(jsonData);
            return View(values);
        }
    }
}
