using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.viewComponents.Books
{
    public class _UIPopularBooksComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
