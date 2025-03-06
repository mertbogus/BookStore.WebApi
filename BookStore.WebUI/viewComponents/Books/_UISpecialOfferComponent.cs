using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.viewComponents.Books
{
    public class _UISpecialOfferComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
