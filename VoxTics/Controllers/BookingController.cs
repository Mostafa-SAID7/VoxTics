using Microsoft.AspNetCore.Mvc;

namespace VoxTics.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
