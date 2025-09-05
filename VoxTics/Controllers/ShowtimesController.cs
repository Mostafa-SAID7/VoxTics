using Microsoft.AspNetCore.Mvc;

namespace VoxTics.Controllers
{
    public class ShowtimesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
