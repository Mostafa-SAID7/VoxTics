using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.UI.Services;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Models.ViewModels;
using VoxTics.Repositories.IRepositories;
using VoxTics.Utitlity;

namespace VoxTics.Areas.Identity.Controllers
{
    [Area(SD.IdentityArea)]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IBaseRepository<UserOTP> _userOTP;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            IEmailSender emailSender,
            SignInManager<ApplicationUser> signInManager,
            IBaseRepository<UserOTP> userOTP)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _signInManager = signInManager;
            _userOTP = userOTP;
        }

        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity is not null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                // Open register modal if layout uses modal approach
                TempData["ShowRegisterModal"] = "true";
                return View(registerVM);
            }

            var applicationUser = new ApplicationUser
            {
                UserName = registerVM.Name,
                Name = registerVM.Name,
                Email = registerVM.Email,
            };

            var result = await _userManager.CreateAsync(applicationUser, registerVM.Password);

            if (!result.Succeeded)
            {
                TempData["ShowRegisterModal"] = "true";
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }
                return View(registerVM);
            }

            // Generate email confirmation token and send email
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
            var link = Url.Action(nameof(ConfirmEmail), "Account",
                new { area = SD.IdentityArea, userId = applicationUser.Id, token = token }, Request.Scheme);

            await _emailSender.SendEmailAsync(applicationUser.Email,
                "Confirm Your Account!",
                $"<h1>Confirm Your Account By Clicking <a href='{link}'>here</a></h1>");

            TempData["success-notification"] = "Add User successfully, Please Confirm Your Account";
            return RedirectToAction("Login");
        }
        #endregion

        #region Confirm Email
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
                return NotFound();

            var user = await _userManager.FindByIdAsync(userId);
            if (user is null) return NotFound();

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
                TempData["error-notification"] = "Invalid Token, Resend Email Confirmation";
            }
            else
            {
                TempData["success-notification"] = "Activate Account Successfully";
            }

            return RedirectToAction("Login");
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity is not null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                TempData["ShowLoginModal"] = "true";
                return View(loginVM);
            }

            var usernameOrEmail = loginVM.EmailORUserName;
            var user = await _userManager.Users
                                         .Where(u => u.UserName == usernameOrEmail || u.Email == usernameOrEmail)
                                         .FirstOrDefaultAsync();
            if (user is null)
            {
                TempData["ShowLoginModal"] = "true";
                TempData["error-notification"] = "Invalid User Name/Email Or Password";
                return View(loginVM);
            }

            // check lockout
            if (await _userManager.IsLockedOutAsync(user))
            {
                TempData["ShowLoginModal"] = "true";
                TempData["error-notification"] = $"Your account is locked until {user.LockoutEnd?.ToLocalTime():f}";
                return View(loginVM);
            }

            // verify password
            var passwordOk = await _userManager.CheckPasswordAsync(user, loginVM.Password);
            if (!passwordOk)
            {
                // Optionally increment access failed count
                await _userManager.AccessFailedAsync(user);

                TempData["ShowLoginModal"] = "true";
                TempData["error-notification"] = "Invalid User Name/Email Or Password";
                return View(loginVM);
            }

            // check email confirmed
            if (!user.EmailConfirmed)
            {
                TempData["ShowLoginModal"] = "true";
                TempData["error-notification"] = "Confirm Your Account!";
                return View(loginVM);
            }

            // reset access failed count on successful login
            await _userManager.ResetAccessFailedCountAsync(user);

            // sign in
            await _signInManager.SignInAsync(user, loginVM.RememberMe);
            TempData["success-notification"] = "Login Successfully";
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        #endregion

        #region Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData["success-notification"] = "Logout Successfully";
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        #endregion

        #region Resend Email Confirmation
        [HttpGet]
        public IActionResult ResendEmailConfirmation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResendEmailConfirmation(ResendEmailConfirmationVM resendEmailConfirmationVM)
        {
            if (!ModelState.IsValid)
            {
                TempData["ShowResendEmailModal"] = "true";
                return View(resendEmailConfirmationVM);
            }

            var user = await _userManager.FindByNameAsync(resendEmailConfirmationVM.EmailORUserName)
                       ?? await _userManager.FindByEmailAsync(resendEmailConfirmationVM.EmailORUserName);

            if (user is null)
            {
                TempData["ShowResendEmailModal"] = "true";
                TempData["error-notification"] = "Invalid User Name/Email";
                return View(resendEmailConfirmationVM);
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var link = Url.Action(nameof(ConfirmEmail), "Account", new { area = SD.IdentityArea, userId = user.Id, token = token }, Request.Scheme);

            await _emailSender.SendEmailAsync(user.Email!, "Confirm Your Account!", $"<h1>Confirm Your Account By Clicking <a href='{link}'>here</a></h1>");
            TempData["success-notification"] = "Send Email successfully, Please Confirm Your Account";
            return RedirectToAction("Login");
        }
        #endregion

        #region Forget Password -> OTP flow
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM forgetPasswordVM)
        {
            if (!ModelState.IsValid)
            {
                TempData["ShowForgetPasswordModal"] = "true";
                return View(forgetPasswordVM);
            }

            var user = await _userManager.FindByNameAsync(forgetPasswordVM.EmailORUserName)
                       ?? await _userManager.FindByEmailAsync(forgetPasswordVM.EmailORUserName);

            if (user is null)
            {
                TempData["ShowForgetPasswordModal"] = "true";
                TempData["error-notification"] = "Invalid User Name/Email";
                return View(forgetPasswordVM);
            }

            // generate numeric OTP
            var OTPNumber = new Random().Next(1000, 9999);

            await _emailSender.SendEmailAsync(user.Email!, "Reset Your Account!", $"Use this OTP Number: <b>{OTPNumber}</b> to reset your account. Don't share it.");

            await _userOTP.AddAsync(new UserOTP()
            {
                ApplicationUserId = user.Id,
                OTPNumber = OTPNumber.ToString(),
                ValidTo = DateTime.UtcNow.AddDays(1)
            });
            await _userOTP.CommitAsync();

            TempData["success-notification"] = "OTP sent to your email";
            return RedirectToAction("ConfirmOTP", new { area = SD.IdentityArea, userId = user.Id });
        }
        #endregion

        #region Confirm OTP
        [HttpGet]
        public IActionResult ConfirmOTP(string userId)
        {
            return View(new ConfirmOTPVM()
            {
                ApplicationUserId = userId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmOTP(ConfirmOTPVM confirmOTPVM)
        {
            if (!ModelState.IsValid)
            {
                TempData["ShowConfirmOTPModal"] = "true";
                return View(confirmOTPVM);
            }

            var user = await _userManager.FindByIdAsync(confirmOTPVM.ApplicationUserId);
            if (user is null)
                return NotFound();

            var lstOTP = (await _userOTP.FindAsync(e => e.ApplicationUserId == confirmOTPVM.ApplicationUserId))
                         .OrderBy(e => e.Id).LastOrDefault();

            if (lstOTP is null)
                return NotFound();

            if (lstOTP.OTPNumber == confirmOTPVM.OTPNumber && lstOTP.ValidTo > DateTime.UtcNow)
            {
                return RedirectToAction("NewPassword", new { area = SD.IdentityArea, userId = user.Id });
            }

            TempData["error-notification"] = "Invalid OTP Number";
            return RedirectToAction("ConfirmOTP", new { area = SD.IdentityArea, userId = confirmOTPVM.ApplicationUserId });
        }
        #endregion

        #region New Password
        [HttpGet]
        public IActionResult NewPassword(string userId, string token, string email)
        {
            return View(new NewPasswordVM()
            {
                ApplicationUserId = userId,
                Token = token,
                Email = email
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewPassword(NewPasswordVM newPasswordVM)
        {
            if (!ModelState.IsValid)
            {
                TempData["ShowNewPasswordModal"] = "true";
                return View(newPasswordVM);
            }

            var user = await _userManager.FindByEmailAsync(newPasswordVM.Email);
            if (user == null)
                return NotFound();

            var result = await _userManager.ResetPasswordAsync(user, newPasswordVM.Token, newPasswordVM.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }
                TempData["ShowNewPasswordModal"] = "true";
                return View(newPasswordVM);
            }

            TempData["success-notification"] = "Password updated successfully.";
            return RedirectToAction("Login");
        }

        #endregion
    }
}
