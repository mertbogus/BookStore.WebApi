using BookStore.WebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookStore.WebUI.viewComponents.Books
{
    public class _UIBestSellingComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UIBestSellingComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7292/api/Products/random");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UIResultProductRandom>(jsonData);
            return View(values);
            
        }
    }
}
