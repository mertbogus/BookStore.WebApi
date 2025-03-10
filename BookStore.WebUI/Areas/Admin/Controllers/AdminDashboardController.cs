using BookStore.WebUI.Dtos.CategoryDtos;
using BookStore.WebUI.Dtos.ProductDtos;
using BookStore.WebUI.Dtos.SubscribeDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace BookStore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminDashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7292/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                ViewBag.TotalCategories = values.Count();
            }


            var clientbook = _httpClientFactory.CreateClient();
            var responseMessagebook = await client.GetAsync("https://localhost:7292/api/Products");
            var jsonDatabook = await responseMessagebook.Content.ReadAsStringAsync();
            var valuesbook = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonDatabook);
            ViewBag.TotalBooks = valuesbook.Count();
            // Yazar adına göre gruplama yaparak sadece benzersiz yazarları alıyoruz
            var uniqueWriters = valuesbook
                                 .GroupBy(p => p.ProductWriterName)  // Yazar adına göre grupla
                                 .Select(g => g.FirstOrDefault())   // Her grup için sadece ilk öğeyi seç
                                 .ToList();                         // Listeyi al


            var clientsub = _httpClientFactory.CreateClient();
            var responseMessagesub = await client.GetAsync("https://localhost:7292/api/Subscribe");
            var jsonDatasub = await responseMessagesub.Content.ReadAsStringAsync();
            var valuessub = JsonConvert.DeserializeObject<List<ResultSubscribeDto>>(jsonDatasub);
            ViewBag.TotalSub = valuessub.Count();

            var clientbooktheexpensive = _httpClientFactory.CreateClient();
            var responseMessagebooktheexpensive = await client.GetAsync("https://localhost:7292/api/Products");
            var jsonDatabooktheexpensive = await responseMessagebooktheexpensive.Content.ReadAsStringAsync();
            var valuesbooks = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonDatabooktheexpensive);

            ViewBag.TheExpensiveBook = valuesbooks.OrderByDescending(x => x.ProductPrice).Select(x => x.ProductName).FirstOrDefault();
            ViewBag.TheCheaperBook = valuesbooks.OrderBy(x => x.ProductPrice).Select(x => x.ProductName).FirstOrDefault();
            ViewBag.WriterBook = valuesbooks.OrderByDescending(x => x.ProductWriterName).Select(x => x.ProductWriterName).FirstOrDefault();


            var clientcategoryandproduct = _httpClientFactory.CreateClient();
            var responseMessagecategoryandproduct = await clientcategoryandproduct.GetAsync("https://localhost:7292/api/Products/GetCategoryAndProduct");
            var jsonDatacategoryandproduct = await responseMessagecategoryandproduct.Content.ReadAsStringAsync();
            var valuescategoryandproduct = JsonConvert.DeserializeObject<List<UIResultProductWithCategory>>(jsonDatacategoryandproduct);
            ViewBag.Categorywiththemostbooks = valuescategoryandproduct.OrderByDescending(x => x.CategoryId).Select(x => x.CategoryName).Distinct().FirstOrDefault();
            ViewBag.Categorywiththefewestbooks = valuescategoryandproduct.GroupBy(x => x.CategoryName)  // Kategorilere göre grupla
            .OrderBy(g => g.Count())  // Kitap sayısına göre artan sırada sıralan
            .Select(g => g.Key)  // Kategorinin adını al
            .FirstOrDefault();

            return View(uniqueWriters);
        }


    }
}
