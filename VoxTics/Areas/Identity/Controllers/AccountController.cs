using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Models.ViewModels;
using VoxTics.Areas.Identity.Services.Interfaces;

namespace VoxTics.Areas.Identity.Controllers
{
    [Area("Identity")]
    [Route("identity/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            IAccountService accountService,
            SignInManager<ApplicationUser> signInManager)
        {
            _accountService = accountService;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid) return View(model);

            var (success, errorMessage, user) = await _accountService.RegisterUserAsync(model);
            if (!success)
            {
                ModelState.AddModelError(string.Empty, errorMessage);
                return View(model);
            }

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid) return View(model);

            var (success, errorMessage) = await _accountService.LoginUserAsync(model);
            if (!success)
            {
                ModelState.AddModelError(string.Empty, errorMessage);
                return View(model);
            }

            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var result = await _accountService.ConfirmEmailAsync(userId, token);
            return View(result ? "ConfirmEmailSuccess" : "Error");
        }

        [HttpGet]
        public IActionResult ForgotPassword() => View();

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgetPasswordVM model)
        {
            if (!ModelState.IsValid) return View(model);

            var (success, errorMessage) = await _accountService.ForgotPasswordAsync(model.EmailORUserName);
            if (!success)
            {
                ModelState.AddModelError(string.Empty, errorMessage);
                return View(model);
            }

            return View("ForgotPasswordConfirmation");
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            return View(new NewPasswordVM { Token = token, Email = email });
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(NewPasswordVM model)
        {
            if (!ModelState.IsValid) return View(model);

            var (success, errorMessage) = await _accountService.ResetPasswordAsync(model);
            if (!success)
            {
                ModelState.AddModelError(string.Empty, errorMessage);
                return View(model);
            }

            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var userId = _signInManager.UserManager.GetUserId(User);
            var profile = await _accountService.GetUserProfileAsync(userId);
            return View(profile);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(ManageProfileVM model)
        {
            if (!ModelState.IsValid) return View(model);

            var userId = _signInManager.UserManager.GetUserId(User);
            var (success, errorMessage) = await _accountService.UpdateUserProfileAsync(userId, model);
            if (!success)
            {
                ModelState.AddModelError(string.Empty, errorMessage);
                return View(model);
            }

            return RedirectToAction("Profile");
        }
    }
}
