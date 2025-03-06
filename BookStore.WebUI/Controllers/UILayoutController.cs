using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
