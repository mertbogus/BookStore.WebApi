using BookStore.WebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookStore.WebUI.viewComponents.Books
{
    public class _UIPopularBooksComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UIPopularBooksComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7292/api/Products/GetCategoryAndProduct");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<UIResultProductWithCategory>>(jsonData);
            return View(values);
            
        }
    }
}
