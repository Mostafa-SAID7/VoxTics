using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VoxTics.Areas.Admin.Controllers
{
    [Authorize(Roles = $"{SD.SuperAdminRole}")]
    [Area(SD.AdminArea)]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //Logs
        //Settings
        //Roles
        //Reports
        //Analytics
    }
}
