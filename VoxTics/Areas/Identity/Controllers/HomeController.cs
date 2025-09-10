using Microsoft.AspNetCore.Mvc;

namespace VoxTics.Areas.Identity.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
