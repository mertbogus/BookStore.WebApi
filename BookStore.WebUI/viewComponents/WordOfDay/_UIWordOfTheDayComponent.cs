using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.viewComponents.WordOfDay
{
    public class _UIWordOfTheDayComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
