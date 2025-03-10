using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.viewComponents.Subscribe
{
    public class _UISubscribeComponent :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }


    }
}
