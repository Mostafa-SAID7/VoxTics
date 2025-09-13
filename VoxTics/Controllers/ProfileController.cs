using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace VoxTics.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileController(UserManager<IdentityUser> userManager)
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
