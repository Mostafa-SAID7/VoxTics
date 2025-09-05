using Microsoft.AspNetCore.Mvc;

namespace VoxTics.Areas.Admin.Controllers
{
    public class ShowtimesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
