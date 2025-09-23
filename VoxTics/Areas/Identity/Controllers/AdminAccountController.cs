using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Models.ViewModels;
using VoxTics.Utitlity;

namespace VoxTics.Areas.Identity.Controllers
{
    [Area(SD.IdentityArea)]
    [Authorize(Roles = "Admin")]
    public class AdminAccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AdminAccountController(
            UserManager<ApplicationUser> userManager, 
            IEmailSender emailSender, 
            SignInManager<ApplicationUser> signInManager
            )
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _signInManager = signInManager;

        }

        // List all users
        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users); // Create a view listing all users
        }

        // Admin creates a new user
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = new ApplicationUser
            {
                UserName = registerVM.Email,
                Name = registerVM.Name,
                Email = registerVM.Email
            };

            var result = await _userManager.CreateAsync(user, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                return View(registerVM);
            }

            // Optionally send email confirmation
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var link = Url.Action(nameof(ConfirmEmail), "AdminAccount", new { area = "Identity", userId = user.Id, token }, Request.Scheme);
            await _emailSender.SendEmailAsync(user.Email, "Confirm Your Account!", $"Click <a href='{link}'>here</a> to confirm your account.");

            TempData["success-notification"] = "User created successfully, email confirmation sent.";
            return RedirectToAction("Index");
        }

        // Admin confirms email manually
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            var result = await _userManager.ConfirmEmailAsync(user, token);
            TempData["success-notification"] = result.Succeeded ? "Email confirmed successfully." : "Email confirmation failed.";
            return RedirectToAction("Index");
        }

        // Admin resets password for any user
        [HttpGet]
        public IActionResult ResetPassword(string id)
        {
            return View(new NewPasswordVM { ApplicationUserId = id });
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(NewPasswordVM newPasswordVM)
        {
            if (!ModelState.IsValid) return View(newPasswordVM);

            var user = await _userManager.FindByIdAsync(newPasswordVM.ApplicationUserId);
            if (user == null) return NotFound();

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, newPasswordVM.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                return View(newPasswordVM);
            }

            TempData["success-notification"] = "Password reset successfully.";
            return RedirectToAction("Index");
        }

        // Optional: Block/Unblock user
        public async Task<IActionResult> ToggleLockout(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            if (user.LockoutEnd == null || user.LockoutEnd <= DateTimeOffset.Now)
            {
                user.LockoutEnd = DateTimeOffset.Now.AddYears(100); // Lock user indefinitely
                TempData["success-notification"] = "User blocked successfully.";
            }
            else
            {
                user.LockoutEnd = null; // Unlock user
                TempData["success-notification"] = "User unblocked successfully.";
            }

            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM, string? returnUrl = null)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailORUserName);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(loginVM);
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Email not confirmed.");
                return View(loginVM);
            }

            var result = await _signInManager.PasswordSignInAsync(
                user.UserName,
                loginVM.Password,
                loginVM.RememberMe,
                lockoutOnFailure: true);

            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Account locked out.");
                return View(loginVM);
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(loginVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "AdminAccount", new { area = "Identity" });
        }

        // Helper method
        private IActionResult RedirectToLocal(string? returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }
}
