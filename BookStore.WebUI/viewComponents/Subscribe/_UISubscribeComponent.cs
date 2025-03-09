using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.viewComponents.Subscribe
{
    public class _UISubscribeComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
