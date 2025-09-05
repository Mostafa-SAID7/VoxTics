using Microsoft.AspNetCore.Mvc;

namespace VoxTics.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
