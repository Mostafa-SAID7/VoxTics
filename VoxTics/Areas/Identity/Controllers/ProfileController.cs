// Areas/Identity/Controllers/ProfileController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Models.ViewModels;
using VoxTics.Areas.Identity.Services.Interfaces;

namespace VoxTics.Areas.Identity.Controllers
{
    [Area("Identity")]
    [Route("[area]/[controller]/[action]")]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(
            IAccountService accountService,
            UserManager<ApplicationUser> userManager)
        {
            _accountService = accountService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var user = await _accountService.GetUserProfileAsync(userId);

            var model = new ManageProfileVM
            {
                PersonalInfo = new PersonalInfoVM
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    DateOfBirth = user.DateOfBirth,
                    PhoneNumber = user.PhoneNumber
                },
                CurrentProfilePicture = user.ProfilePicture
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ManageProfileVM model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var result = await _accountService.UpdateUserProfileAsync(userId, model);

                if (result.success)
                {
                    TempData["Message"] = "Profile updated successfully.";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, result.errorMessage);
            }

            // Reload current profile picture if update fails
            var user = await _accountService.GetUserProfileAsync(_userManager.GetUserId(User));
            model.CurrentProfilePicture = user.ProfilePicture;

            return View(model);
        }
    }
}