using Microsoft.AspNetCore.Identity;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Models.Enums;
using VoxTics.Areas.Identity.Models.ViewModels;
using VoxTics.Repositories.IRepositories;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{
    public class ApplicationUsersService : IApplicationUsersService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBaseRepository<UserOTP> _userOTP;

        public ApplicationUsersService(UserManager<ApplicationUser> userManager, IBaseRepository<UserOTP> userOTP)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _userOTP = userOTP ?? throw new ArgumentNullException(nameof(userOTP));
        }

        #region User Registration & Email
        public async Task<IdentityResult> CreateUserAsync(RegisterVM registerVM)
        {
            if (registerVM == null) throw new ArgumentNullException(nameof(registerVM));

            var user = new ApplicationUser
            {
                UserName = registerVM.UserName,
                Name = registerVM.Name,
                Email = registerVM.Email,
                Gender = Gender.Male // default
            };

            return await _userManager.CreateAsync(user, registerVM.Password).ConfigureAwait(false);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            return await _userManager.GenerateEmailConfirmationTokenAsync(user).ConfigureAwait(false);
        }

        public async Task<IdentityResult> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId).ConfigureAwait(false);
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = "User not found" });

            return await _userManager.ConfirmEmailAsync(user, token).ConfigureAwait(false);
        }
        #endregion

        #region Login / Password
        public async Task<ApplicationUser?> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email).ConfigureAwait(false);
        }

        public async Task<ApplicationUser?> FindByUsernameOrEmailAsync(string emailOrUsername)
        {
            var user = await _userManager.FindByNameAsync(emailOrUsername).ConfigureAwait(false);
            if (user != null) return user;

            return await _userManager.FindByEmailAsync(emailOrUsername).ConfigureAwait(false);
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            return await _userManager.CheckPasswordAsync(user, password).ConfigureAwait(false);
        }
        #endregion

        #region OTP
        public async Task<string> SendOTPAsync(ApplicationUser user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            var otpNumber = new Random().Next(1000, 9999).ToString(CultureInfo.InvariantCulture);

            await _userOTP.CreateAsync(new UserOTP
            {
                ApplicationUserId = user.Id,
                OTPNumber = otpNumber,
                ValidTo = DateTime.UtcNow.AddMinutes(15)
            }).ConfigureAwait(false);

            await _userOTP.CommitAsync().ConfigureAwait(false);
            return otpNumber;
        }

        public async Task<bool> ValidateOTPAsync(string userId, string otpNumber)
        {
            var lastOtp = (await _userOTP.GetAsync(e => e.ApplicationUserId == userId).ConfigureAwait(false))
                            .OrderByDescending(e => e.Id)
                            .FirstOrDefault();

            if (lastOtp == null) return false;
            return lastOtp.OTPNumber == otpNumber && lastOtp.ValidTo > DateTime.UtcNow;
        }
        #endregion

        #region Password Reset
        public async Task<IdentityResult> ResetPasswordAsync(string userId, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId).ConfigureAwait(false);
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = "User not found" });

            var token = await _userManager.GeneratePasswordResetTokenAsync(user).ConfigureAwait(false);
            return await _userManager.ResetPasswordAsync(user, token, newPassword).ConfigureAwait(false);
        }
        #endregion

        #region External Login
        public async Task<ApplicationUser?> ExternalLoginSignInAsync(Microsoft.AspNetCore.Identity.ExternalLoginInfo info)
        {
            if (info == null) throw new ArgumentNullException(nameof(info));

            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey).ConfigureAwait(false);
            if (user != null) return user;

            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            var name = info.Principal.FindFirstValue(ClaimTypes.Name);

            if (email == null) return null;

            user = await _userManager.FindByEmailAsync(email).ConfigureAwait(false);
            if (user == null)
            {
                string username = $"{name?.Replace(" ", "")}{new Random().Next(1000, 9999).ToString(CultureInfo.InvariantCulture)}";
                user = new ApplicationUser
                {
                    UserName = username,
                    Email = email,
                    Name = name ?? username
                };

                var result = await _userManager.CreateAsync(user).ConfigureAwait(false);
                if (!result.Succeeded) return null;
            }

            var addLoginResult = await _userManager.AddLoginAsync(user, info).ConfigureAwait(false);
            if (!addLoginResult.Succeeded) return null;

            return user;
        }
        #endregion
    }
}
