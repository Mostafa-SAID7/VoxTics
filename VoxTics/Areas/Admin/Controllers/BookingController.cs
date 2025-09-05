using Microsoft.AspNetCore.Mvc;

namespace VoxTics.Areas.Admin.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
