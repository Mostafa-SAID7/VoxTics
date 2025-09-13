using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Models.Enums;
using VoxTics.Areas.Identity.Models.ViewModels;
using VoxTics.Data.UoW;
using VoxTics.Repositories.IRepositories;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{
    public class ApplicationUsersService : IApplicationUsersService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUnitOfWork _uow;
        private readonly IEmailSender _emailSender;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationUsersService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IUnitOfWork uow,
            IEmailSender emailSender,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _uow = uow;
            _emailSender = emailSender;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IdentityResultWrapper> RegisterAsync(RegisterVM model, string callbackScheme, string confirmActionName = "ConfirmEmail")
        {
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                Name = model.Name,
            };

            var createResult = await _userManager.CreateAsync(user, model.Password);
            if (!createResult.Succeeded)
            {
                var errs = string.Join(" | ", createResult.Errors.Select(e => e.Description));
                return new IdentityResultWrapper(false, errs);
            }

            // Generate email confirmation token and send email
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            // encode token for Url safety
            var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

            var url = GenerateCallbackUrl(confirmActionName, user.Id, encodedToken);
            await _emailSender.SendEmailAsync(user.Email!, "Confirm your account", $"<p>Click <a href='{url}'>here</a> to confirm your account</p>");

            return new IdentityResultWrapper(true, "User created. Confirmation email sent.");
        }

        public async Task<(bool Succeeded, string Message)> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null) return (false, "User not found");

            // decode token
            var decodedBytes = WebEncoders.Base64UrlDecode(token);
            var decodedToken = Encoding.UTF8.GetString(decodedBytes);

            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);
            return result.Succeeded ? (true, "Email confirmed") : (false, string.Join(" | ", result.Errors.Select(e => e.Description)));
        }

        public async Task<(bool Succeeded, string Message)> LoginAsync(LoginVM model)
        {
            var user = await _userManager.FindByNameAsync(model.EmailORUserName) ?? await _userManager.FindByEmailAsync(model.EmailORUserName);
            if (user is null) return (false, "Invalid user or password.");

            var passwordOk = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordOk) return (false, "Invalid user or password.");

            if (!user.EmailConfirmed) return (false, "Confirm your email first.");

            // check lockout
            if (user.LockoutEnd.HasValue && user.LockoutEnd.Value > DateTimeOffset.UtcNow)
            {
                return (false, $"You are locked out until {user.LockoutEnd.Value}.");
            }

            await _signInManager.SignInAsync(user, model.RememberMe);
            return (true, "Logged in.");
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<(bool Succeeded, string Message)> ResendEmailConfirmationAsync(ResendEmailConfirmationVM model, string confirmActionName = "ConfirmEmail")
        {
            var user = await _userManager.FindByNameAsync(model.EmailORUserName) ?? await _userManager.FindByEmailAsync(model.EmailORUserName);
            if (user is null) return (false, "User not found.");

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            var url = GenerateCallbackUrl(confirmActionName, user.Id, encodedToken);
            await _emailSender.SendEmailAsync(user.Email!, "Confirm your account", $"<p>Click <a href='{url}'>here</a> to confirm your account</p>");

            return (true, "Confirmation email resent.");
        }

        public async Task<(bool Succeeded, string Message)> ForgetPasswordSendOtpAsync(ForgetPasswordVM model)
        {
            var user = await _userManager.FindByNameAsync(model.EmailORUserName) ?? await _userManager.FindByEmailAsync(model.EmailORUserName);
            if (user is null) return (false, "User not found.");

            var otp = new Random().Next(1000, 9999).ToString();

            await _emailSender.SendEmailAsync(user.Email!, "Reset OTP", $"Use this OTP: <b>{otp}</b>. It expires in 24 hours.");

            var userOtp = new UserOTP
            {
                ApplicationUserId = user.Id,
                OTPNumber = otp,
                ValidTo = DateTime.UtcNow.AddDays(1),
                IsUsed = false
            };

            await _uow.UserOTPs.CreateAsync(userOtp); // assuming IRepository has CreateAsync
            await _uow.CommitAsync();

            return (true, "OTP sent.");
        }

        public async Task<(bool Succeeded, string Message)> ConfirmOtpAsync(ConfirmOTPVM model)
        {
            var user = await _userManager.FindByIdAsync(model.ApplicationUserId);
            if (user is null) return (false, "User not found.");

            var otpList = await _uow.UserOTPs.GetAsync(e => e.ApplicationUserId == model.ApplicationUserId);
            var latest = otpList.OrderBy(e => e.Id).LastOrDefault();

            if (latest is null || latest.IsUsed || latest.ValidTo <= DateTime.UtcNow) return (false, "Invalid or expired OTP.");

            if (latest.OTPNumber != model.OTPNumber) return (false, "Invalid OTP.");

            // mark used
            latest.IsUsed = true;
            _uow.UserOTPs.Update(latest);
            await _uow.CommitAsync();

            return (true, "OTP confirmed.");
        }

        public async Task<(bool Succeeded, string Message)> ResetPasswordAsync(NewPasswordVM model)
        {
            var user = await _userManager.FindByIdAsync(model.ApplicationUserId);
            if (user is null) return (false, "User not found.");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, model.Password);

            return result.Succeeded ?
                (true, "Password reset successful.") :
                (false, string.Join(" | ", result.Errors.Select(e => e.Description)));
        }

        public async Task<ApplicationUser?> FindByExternalProviderAsync(ExternalLoginInfoStub ext)
        {
            // try to find by login info
            var signInInfo = await _signInManager.GetExternalLoginInfoAsync();
            // If the caller passed an ExternalLoginInfoStub, we can still map it — but here we'll attempt to use real SignInManager's info if available.
            var provider = ext?.LoginProvider;
            var providerKey = ext?.ProviderKey;

            if (provider is null || providerKey is null)
            {
                return null;
            }

            // find user login mapping
            var user = await _userManager.FindByLoginAsync(provider, providerKey);
            if (user != null) return user;

            // fallback: try to get email from external principal
            var email = ext.Principal?.FindFirstValue(ClaimTypes.Email);
            if (!string.IsNullOrEmpty(email))
            {
                user = await _userManager.FindByEmailAsync(email);
                if (user != null)
                {
                    var addResult = await _userManager.AddLoginAsync(user, new UserLoginInfo(provider, providerKey, provider));
                    if (!addResult.Succeeded)
                    {
                        // ignore linking failure here — caller can decide
                    }
                    return user;
                }
            }

            // not found
            return null;
        }

        public async Task<ApplicationUser?> GetByIdAsync(string id)
        {
            return await _uow.ApplicationUsers.GetByIdAsync(id);
        }

        public async Task<(bool Succeeded, string Message)> UpdateProfileAsync(string userId, PersonalInfoVM vm)
        {
            var user = await _uow.ApplicationUsers.GetByIdAsync(userId);
            if (user is null) return (false, "User not found.");

            user.Name = vm.Name;
            user.DateOfBirth = vm.DateOfBirth;
            user.Gender = vm.Gender;
            user.Address = vm.Address;
            user.State = vm.State;
            user.City = vm.City;
            user.Street = vm.Street;
            user.ZipCode = vm.ZipCode;
            // update skills: clear & add
            user.Skills.Clear();
            foreach (var s in vm.Skills.Distinct())
                user.Skills.Add(s);

            if (!string.IsNullOrWhiteSpace(vm.AvatarUrl))
            {
                if (Uri.TryCreate(vm.AvatarUrl, UriKind.Absolute, out var uri))
                    user.AvatarUrl = uri;
            }

            _uow.ApplicationUsers.Update(user);
            await _uow.CommitAsync();

            return (true, "Profile updated.");
        }

        private string GenerateCallbackUrl(string action, string userId, string encodedToken)
        {
            var req = _httpContextAccessor.HttpContext?.Request;
            var scheme = req?.Scheme ?? "https";
            var host = req?.Host.Value ?? "localhost";

            return $"{scheme}://{host}/Identity/Account/{action}?userId={Uri.EscapeDataString(userId)}&token={Uri.EscapeDataString(encodedToken)}";
        }
    }
}
