using Microsoft.AspNetCore.Mvc;

namespace VoxTics.Areas.Admin.Controllers
{
    public class CinemasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
