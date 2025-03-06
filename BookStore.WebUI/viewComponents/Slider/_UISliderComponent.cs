using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.viewComponents.Slider
{
    public class _UISliderComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
