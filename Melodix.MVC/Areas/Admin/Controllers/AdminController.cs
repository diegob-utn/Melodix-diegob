using Microsoft.AspNetCore.Mvc;

namespace Melodix.MVC.Areas.Admin.Controllers
{
    public class AdminController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
