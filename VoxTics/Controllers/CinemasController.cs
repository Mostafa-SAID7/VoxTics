using Microsoft.AspNetCore.Mvc;

namespace VoxTics.Controllers
{
    public class CinemasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
