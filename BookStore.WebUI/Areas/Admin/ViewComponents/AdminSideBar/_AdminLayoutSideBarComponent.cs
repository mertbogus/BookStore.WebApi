using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.Areas.Admin.ViewComponents.AdminSideBar
{
    public class _AdminLayoutSideBarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
               return View();
        }
    }
}
