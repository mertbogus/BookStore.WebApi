using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.Areas.Admin.ViewComponents.AdminHeader
{
    public class _AdminLayoutHeaderComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
