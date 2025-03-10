using BookStore.WebUI.Dtos.CategoryDtos;
using BookStore.WebUI.Dtos.SubscribeDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BookStore.WebUI.Controllers
{
    [AllowAnonymous]
    [Route("UISubscribe")]
    public class UISubscribeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UISubscribeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateSubscribeAsync")]
        public async Task<IActionResult> CreateSubscribeAsync([FromBody] CreateSubscribeDto model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var client = _httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(model);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    var responseMessage = await client.PostAsync("https://localhost:7292/api/Subscribe", content);

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        // Başarılı yanıt döndür
                        return Json(new { success = true, message = "Aboneliğiniz başarıyla oluşturuldu." });
                    }
                    else
                    {
                        // Başarısız yanıt döndür
                        return Json(new { success = false, message = "Bir hata oluştu. Lütfen tekrar deneyin." });
                    }
                }
                catch (Exception ex)
                {
                    // Hata durumunda geri bildirim
                    return Json(new { success = false, message = "Bir hata oluştu: " + ex.Message });
                }
            }

            // Validasyon hatası durumunda geri bildirim
            return Json(new { success = false, message = "Geçersiz veri." });
        }
    }
}
