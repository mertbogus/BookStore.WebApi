using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.viewComponents.Books
{
    public class _UIBestSellingComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
