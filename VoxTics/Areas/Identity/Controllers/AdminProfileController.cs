using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Models.ViewModels;
using VoxTics.Utitlity;

namespace VoxTics.Areas.Identity.Controllers
{
    [Area(SD.IdentityArea)]
    [Authorize(Roles = "Admin")] // Only Admins can access
    public class AdminProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // List all users (optional)
        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users); // You can create a view with a table of users
        }

        // View user profile by Id
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            var personalInfoVM = user.Adapt<PersonalInfoVM>();
            return View(personalInfoVM);
        }

        // Update user info by Admin
        public async Task<IActionResult> UpdateInfo(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            var personalInfoVM = user.Adapt<PersonalInfoVM>();
            return View(personalInfoVM);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInfo(string id, PersonalInfoVM personalInfoVM)
        {
            if (!ModelState.IsValid)
            {
                return View(personalInfoVM);
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            user.Name = personalInfoVM.Name;
            user.Email = personalInfoVM.Email;
            user.PhoneNumber = personalInfoVM.PhoneNumber;
            user.Street = personalInfoVM.Street;
            user.City = personalInfoVM.City;
            user.State = personalInfoVM.State;
            user.ZipCode = personalInfoVM.ZipCode;

            await _userManager.UpdateAsync(user);

            TempData["success-notification"] = "User Info Updated Successfully";
            return RedirectToAction("Details", new { id = id });
        }

        // Reset password by Admin
        public async Task<IActionResult> ResetPassword(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            var changePasswordVM = new ChangePasswordVM { UserId = id };
            return View(changePasswordVM);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ChangePasswordVM changePasswordVM)
        {
            var user = await _userManager.FindByIdAsync(changePasswordVM.UserId);
            if (user == null)
                return NotFound();

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, changePasswordVM.NewPassword);

            if (!result.Succeeded)
            {
                TempData["error-notification"] = string.Join(", ", result.Errors.Select(e => e.Description));
            }
            else
            {
                TempData["success-notification"] = "Password Reset Successfully";
            }

            return RedirectToAction("Details", new { id = changePasswordVM.UserId });
        }
    }
}
