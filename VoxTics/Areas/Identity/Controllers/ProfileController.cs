// Areas/Identity/Controllers/ProfileController.cs
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Models.ViewModels;
using VoxTics.Utitlity;

namespace VoxTics.Areas.Identity.Controllers
{
    [Area(SD.IdentityArea)]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Welcome()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user is null)
                return NotFound();

            PersonalInfoVM personalInfoVM = user.Adapt<PersonalInfoVM>();

            return View(personalInfoVM);
        }

        public async Task<IActionResult> UpdateInfo(PersonalInfoVM personalInfoVM)
        {
            if (!ModelState.IsValid)
            {
                return View(personalInfoVM);
            }

            var user = await _userManager.GetUserAsync(User);

            if (user is null)
                return NotFound();

            user.Name = personalInfoVM.Name;
            user.Email = personalInfoVM.Email;
            user.PhoneNumber = personalInfoVM.PhoneNumber;
            user.Street = personalInfoVM.Street;
            user.City = personalInfoVM.City;
            user.State = personalInfoVM.State;
            user.ZipCode = personalInfoVM.ZipCode;

            await _userManager.UpdateAsync(user);

            TempData["success-notification"] = "Update Info Successfully";
            return RedirectToAction("Welcome");
        }

        public async Task<IActionResult> ChangePassword(ChangePasswordVM changePasswordVM)
        {
            if (!ModelState.IsValid)
            {
                return View(changePasswordVM);
            }

            var user = await _userManager.GetUserAsync(User);

            if (user is null)
                return NotFound();

            var result = await _userManager.ChangePasswordAsync(user, changePasswordVM.CurrentPassword, changePasswordVM.NewPassword);

            if (!result.Succeeded)
            {
                TempData["error-notification"] = String.Join(", ", result.Errors.Select(e => e.Description));
            }
            else
            {
                TempData["success-notification"] = "Update Password Successfully";
            }

            return RedirectToAction("Welcome");
        }

    }
}