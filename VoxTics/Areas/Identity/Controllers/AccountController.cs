using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Models.Enums;
using VoxTics.Areas.Identity.Models.ViewModels;
using VoxTics.Services.Interfaces;
using VoxTics.Utility;

namespace VoxTics.Areas.Identity.Controllers
{
    [Area(SD.IdentityArea)]
    public class AccountController : Controller
    {
        private readonly IApplicationUsersService _usersService;
        private readonly IMapper _mapper;
        public AccountController(IApplicationUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated == true)
                return RedirectToAction("Index", "Home", new { area = "Customer" });

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var result = await _usersService.RegisterAsync(registerVM, Request.Scheme);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(registerVM);
            }

            TempData["success-notification"] = result.Message;
            return RedirectToAction("Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                TempData["error-notification"] = "Missing parameters.";
                return RedirectToAction("Login");
            }

            var (succeeded, message) = await _usersService.ConfirmEmailAsync(userId, token);
            if (succeeded)
                TempData["success-notification"] = message;
            else
                TempData["error-notification"] = message;

            return RedirectToAction("Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated == true)
                return RedirectToAction("Index", "Home", new { area = "Customer" });

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var (succeeded, message) = await _usersService.LoginAsync(loginVM);
            if (!succeeded)
            {
                TempData["error-notification"] = message;
                return View(loginVM);
            }

            TempData["success-notification"] = message;
            return RedirectToAction("Index", "Home", new { area = "Customer" });
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _usersService.LogoutAsync();
            TempData["success-notification"] = "Logout Successfully";
            return RedirectToAction("Index", "Home", new { area = "Customer" });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResendEmailConfirmation() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResendEmailConfirmation(ResendEmailConfirmationVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var (succeeded, message) = await _usersService.ResendEmailConfirmationAsync(vm);
            if (!succeeded)
            {
                TempData["error-notification"] = message;
                return View(vm);
            }

            TempData["success-notification"] = message;
            return RedirectToAction("Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgetPassword() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var (succeeded, message) = await _usersService.ForgetPasswordSendOtpAsync(vm);
            if (!succeeded)
            {
                TempData["error-notification"] = message;
                return View(vm);
            }

            TempData["success-notification"] = message;
            // redirect to confirm OTP page (expected to accept userId)
            var user = await _usersService.GetByIdAsync((await _usersService.GetByIdAsync(vm.EmailORUserName))?.Id ?? string.Empty);
            // simpler approach: after sending OTP you normally know user id - but to avoid extra DB roundtrip we can search
            var possibleUser = await _usersService.GetByIdAsync(vm.EmailORUserName);
            return RedirectToAction("ConfirmOTP", "Account", new { area = "Identity", userId = possibleUser?.Id });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ConfirmOTP(string userId)
        {
            return View(new ConfirmOTPVM { ApplicationUserId = userId });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmOTP(ConfirmOTPVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var (succeeded, message) = await _usersService.ConfirmOtpAsync(vm);
            if (!succeeded)
            {
                TempData["error-notification"] = message;
                return RedirectToAction("ConfirmOTP", new { area = "Identity", userId = vm.ApplicationUserId });
            }

            TempData["success-notification"] = message;
            return RedirectToAction("NewPassword", new { area = "Identity", userId = vm.ApplicationUserId });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult NewPassword(string userId)
        {
            return View(new NewPasswordVM { ApplicationUserId = userId });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> NewPassword(NewPasswordVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var (succeeded, message) = await _usersService.ResetPasswordAsync(vm);
            if (!succeeded)
            {
                TempData["error-notification"] = message;
                foreach (var err in message.Split('|'))
                {
                    ModelState.AddModelError(string.Empty, err.Trim());
                }
                return View(vm);
            }

            TempData["success-notification"] = message;
            return RedirectToAction("Login");
        }

        // External login endpoints can still be implemented similarly by injecting SignInManager in the service
    }
}
