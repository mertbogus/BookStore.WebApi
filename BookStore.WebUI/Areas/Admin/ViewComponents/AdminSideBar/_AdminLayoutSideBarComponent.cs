using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;

namespace BookStore.WebUI.Areas.Admin.ViewComponents.AdminSideBar
{
    public class _AdminLayoutSideBarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // HttpContext'in null olup olmadığını kontrol edelim
            var cultureName = HttpContext?.Request.Query["culture"].ToString();

            if (string.IsNullOrEmpty(cultureName))
            {
                cultureName = "tr-TR"; // Varsayılan dil
            }
            Console.WriteLine($"Final Culture Name: {cultureName}");

            var translations = GetTranslations(cultureName);

            Console.WriteLine("Çeviriler:");
            foreach (var item in translations)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

            return View(translations);
        }

        private Dictionary<string, string> GetTranslations(string cultureName)
        {
            var result = new Dictionary<string, string>();

            if (cultureName == "en-US")
            {
                result.Add("Dashboard", "Dashboard");
                result.Add("Words", "Words");
                result.Add("Books", "Books");
                result.Add("Categories", "Categories");
                result.Add("Subscribers", "Subscribers");
            }
            else // tr-TR varsayılan
            {
                result.Add("Dashboard", "Kontrol Paneli");
                result.Add("Words", "Sözler");
                result.Add("Books", "Kitaplar");
                result.Add("Categories", "Kategoriler");
                result.Add("Subscribers", "Aboneler");
            }

            return result;
        }
    }
}

