using Microsoft.AspNetCore.Mvc;

namespace VoxTics.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
