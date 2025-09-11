using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace VoxTics.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(IdentityUser model)
        {
            var user = await _userManager.GetUserAsync(User);
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Email;
            await _userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Profile));
        }
    }

}
