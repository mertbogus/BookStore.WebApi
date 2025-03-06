using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
