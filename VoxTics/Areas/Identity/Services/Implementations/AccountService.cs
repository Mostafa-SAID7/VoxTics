using Microsoft.AspNetCore.Identity;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Models.Enums;
using VoxTics.Areas.Identity.Models.ViewModels;
using VoxTics.Areas.Identity.Repositories.IRepositories;
using VoxTics.Areas.Identity.Services.Interfaces;
using VoxTics.Helpers;

namespace VoxTics.Areas.Identity.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IApplicationUsersRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;

        public AccountService(
            IApplicationUsersRepository userRepository,
            UserManager<ApplicationUser> userManager,
            IEmailService emailService)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _emailService = emailService;
        }

        #region User Registration & Login

        public async Task<(bool success, string errorMessage, ApplicationUser user)> RegisterUserAsync(RegisterVM model)
        {
            if (!ValidationHelpers.IsValidEmail(model.Email))
                return (false, "Invalid email format.", null);

            if (!ValidationHelpers.IsValidPassword(model.Password))
                return (false, "Password does not meet requirements.", null);

            if (!await _userRepository.IsEmailUniqueAsync(model.Email).ConfigureAwait(false))
                return (false, "Email is already in use.", null);

            var user = new ApplicationUser
            {
                UserName = model.Name,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password).ConfigureAwait(false);
            if (!result.Succeeded)
                return (false, string.Join(", ", result.Errors.Select(e => e.Description)), null);

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user).ConfigureAwait(false);
            await SendEmailAsync(user.Email, "Welcome to VoxTics!", "WelcomeEmail.html", new { UserName = user.UserName, ConfirmationToken = token }).ConfigureAwait(false);

            return (true, string.Empty, user);
        }

        public async Task<(bool success, string errorMessage)> LoginUserAsync(LoginVM model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email).ConfigureAwait(false);
            if (user == null) return (false, "Invalid credentials.");

            if (!await _userManager.CheckPasswordAsync(user, model.Password).ConfigureAwait(false))
                return (false, "Invalid credentials.");

            if (!await _userManager.IsEmailConfirmedAsync(user).ConfigureAwait(false))
                return (false, "Email is not confirmed.");

            return (true, string.Empty);
        }

        #endregion

        #region Email Confirmation & Password

        public async Task<bool> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId).ConfigureAwait(false);
            if (user == null) return false;

            var result = await _userManager.ConfirmEmailAsync(user, token).ConfigureAwait(false);
            return result.Succeeded;
        }

        public async Task<(bool success, string errorMessage)> ForgotPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email).ConfigureAwait(false);
            if (user == null) return (false, "User not found.");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user).ConfigureAwait(false);
            await SendEmailAsync(user.Email, "Reset your password", "PasswordReset.html", new { UserName = user.UserName, ResetToken = token }).ConfigureAwait(false);

            return (true, string.Empty);
        }

        public async Task<(bool success, string errorMessage)> ResetPasswordAsync(NewPasswordVM model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email).ConfigureAwait(false);
            if (user == null) return (false, "User not found.");

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword).ConfigureAwait(false);
            if (!result.Succeeded) return (false, string.Join(", ", result.Errors.Select(e => e.Description)));

            return (true, string.Empty);
        }

        public async Task<bool> ResendEmailConfirmationAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email).ConfigureAwait(false);
            if (user == null) return false;

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user).ConfigureAwait(false);
            await SendEmailAsync(user.Email, "Confirm your email", "WelcomeEmail.html", new { UserName = user.UserName, ConfirmationToken = token }).ConfigureAwait(false);

            return true;
        }

        #endregion

        #region Profile Management

        public async Task<ApplicationUser> GetUserProfileAsync(string userId)
        {
            return await _userRepository.GetByIdAsync(userId).ConfigureAwait(false);
        }

        public async Task<(bool success, string errorMessage)> UpdateUserProfileAsync(string userId, ManageProfileVM model)
        {
            var user = await _userRepository.GetByIdAsync(userId).ConfigureAwait(false);
            if (user == null) return (false, "User not found.");

            user.UserName = model.Name;
            user.Email = model.Email;

            try
            {
                await _userManager.UpdateAsync(user).ConfigureAwait(false);
                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        #endregion

        #region OTP Management

        public async Task<string> GenerateOTPAsync(string userId, UserOTP type)
        {
            var user = await _userRepository.GetByIdAsync(userId).ConfigureAwait(false);
            if (user == null) throw new ArgumentException("User not found.");

            var otp = new Random().Next(100000, 999999).ToString();
            string templateFile = type.OTPType == OTPType.Login ? "OTPConfirmation.html" : "PasswordReset.html";

            await SendEmailAsync(user.Email, "Your OTP Code", templateFile, new { UserName = user.UserName, OTPCode = otp }).ConfigureAwait(false);

            return otp;
        }

        public Task<bool> VerifyOTPAsync(string userId, string otpCode, UserOTP type)
        {
            // TODO: Implement OTP verification logic (DB comparison)
            return Task.FromResult(true);
        }

        #endregion

        #region Helper Methods

        private async Task SendEmailAsync(string email, string subject, string templateFile, object placeholders)
        {
            var templateContent = await EmailTemplateHelper.LoadTemplateAsync(templateFile).ConfigureAwait(false);
            var emailBody = EmailTemplateHelper.ReplacePlaceholders(templateContent, placeholders);
            await _emailService.SendEmailAsync(email, subject, emailBody).ConfigureAwait(false);
        }

      

        #endregion
    }

  
}
