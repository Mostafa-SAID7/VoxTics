using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;

namespace VoxTics.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<MovieDbContext> _userManager;
        private readonly SignInManager<MovieDbContext> _signInManager;
        private readonly ILogger<UsersController> _logger;

        public UsersController(
            UserManager<MovieDbContext> userManager,
            SignInManager<MovieDbContext> signInManager,
            ILogger<UsersController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        // -----------------------
        // Register
        // -----------------------
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var user = new MovieDbContext.User
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.Phone,
                    CreatedAt = DateTime.UtcNow
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("New user registered: {Email}", model.Email);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during registration for {Email}", model.Email);
                ModelState.AddModelError("", "An unexpected error occurred.");
            }

            return View(model);
        }

        // -----------------------
        // Login
        // -----------------------
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginVM model, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in: {Email}", model.Email);
                    return RedirectToLocal(returnUrl);
                }

                ModelState.AddModelError("", "Invalid login attempt.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login for {Email}", model.Email);
                ModelState.AddModelError("", "An unexpected error occurred.");
            }

            return View(model);
        }

        // -----------------------
        // Logout
        // -----------------------
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction("Index", "Home");
        }

        // -----------------------
        // Profile
        // -----------------------
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login");

            var vm = new UserVM
            {
                Id = user.Id,
                FirstName = user.FirstName ?? "",
                LastName = user.LastName ?? "",
                Email = user.Email ?? "",
                Phone = user.PhoneNumber,
                DateOfBirth = user.DateOfBirth,
                Role = user.Role,
                IsActive = user.IsActive,
                IsEmailConfirmed = user.EmailConfirmed,
                RegistrationDate = user.CreatedAt,
                LastLoginDate = user.LastLoginDate
            };

            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditProfile(UserEditVM model)
        {
            if (!ModelState.IsValid)
                return View("Profile", model);

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login");

            user.FullName = model.FullName;
            user.PhoneNumber = model.Phone;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                TempData["Success"] = "Profile updated successfully.";
                return RedirectToAction("Profile");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View("Profile", model);
        }

        // -----------------------
        // Helpers
        // -----------------------
        private IActionResult RedirectToLocal(string? returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }
    }
}
