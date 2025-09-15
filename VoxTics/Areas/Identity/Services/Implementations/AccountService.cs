// Areas/Identity/Services/AccountService.cs
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Models.ViewModels;
using VoxTics.Areas.Identity.Services.Interfaces;
using VoxTics.Data;
using VoxTics.Helpers;

namespace VoxTics.Areas.Identity.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailService _emailService;
        private readonly MovieDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public AccountService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailService emailService,
            MovieDbContext context,
            IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _context = context;
            _environment = environment;
        }

        public async Task<(bool success, string errorMessage, ApplicationUser user)> RegisterUserAsync(RegisterVM model)
        {
            // Check if email already exists
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                return (false, "Email is already registered.", null);
            }

            // Create new user
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                EmailConfirmed = false // Will confirm via OTP
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return (false, string.Join(", ", result.Errors.Select(e => e.Description)), null);
            }

            // Generate OTP for email confirmation
            var otpCode = await GenerateOTPAsync(user.Id, OTPType.EmailConfirmation);

            // Send confirmation email
            await SendConfirmationEmail(user, otpCode);

            return (true, null, user);
        }

        public async Task<(bool success, string errorMessage)> LoginUserAsync(LoginVM model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return (false, "Invalid login attempt.");
            }

            if (!user.EmailConfirmed)
            {
                return (false, "Email not confirmed. Please check your email for confirmation instructions.");
            }

            var result = await _signInManager.PasswordSignInAsync(
                model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return (true, null);
            }

            return (false, "Invalid login attempt.");
        }

        public async Task<bool> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            // Verify OTP
            if (!await VerifyOTPAsync(userId, token, OTPType.EmailConfirmation))
            {
                return false;
            }

            user.EmailConfirmed = true;
            await _userManager.UpdateAsync(user);

            // Mark OTP as used
            var otp = await _context.UserOTPs
                .FirstOrDefaultAsync(o => o.ApplicationUserId == userId && o.OTPCode == token && o.Type == OTPType.EmailConfirmation);

            if (otp != null)
            {
                otp.IsUsed = true;
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<(bool success, string errorMessage)> ForgotPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || !user.EmailConfirmed)
            {
                // Don't reveal that the user does not exist or is not confirmed
                return (true, "If your email is registered, you will receive a password reset link.");
            }

            // Generate OTP for password reset
            var otpCode = await GenerateOTPAsync(user.Id, OTPType.PasswordReset);

            // Send password reset email
            await SendPasswordResetEmail(user, otpCode);

            return (true, null);
        }

        public async Task<(bool success, string errorMessage)> ResetPasswordAsync(NewPasswordVM model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return (false, "Invalid request.");
            }

            // Verify OTP
            if (!await VerifyOTPAsync(model.UserId, model.Token, OTPType.PasswordReset))
            {
                return (false, "Invalid or expired reset token.");
            }

            // Reset password
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, resetToken, model.NewPassword);

            if (!result.Succeeded)
            {
                return (false, string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            // Mark OTP as used
            var otp = await _context.UserOTPs
                .FirstOrDefaultAsync(o => o.ApplicationUserId == model.UserId && o.OTPCode == model.Token && o.Type == OTPType.PasswordReset);

            if (otp != null)
            {
                otp.IsUsed = true;
                await _context.SaveChangesAsync();
            }

            return (true, null);
        }

        public async Task<bool> ResendEmailConfirmationAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || user.EmailConfirmed)
            {
                return false;
            }

            // Generate new OTP
            var otpCode = await GenerateOTPAsync(user.Id, OTPType.EmailConfirmation);

            // Resend confirmation email
            await SendConfirmationEmail(user, otpCode);

            return true;
        }

        public async Task<ApplicationUser> GetUserProfileAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<(bool success, string errorMessage)> UpdateUserProfileAsync(string userId, ManageProfileVM model)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return (false, "User not found.");
            }

            // Update basic info
            user.FirstName = model.PersonalInfo.FirstName;
            user.LastName = model.PersonalInfo.LastName;
            user.DateOfBirth = model.PersonalInfo.DateOfBirth;
            user.PhoneNumber = model.PersonalInfo.PhoneNumber;

            // Handle profile picture upload
            if (model.ProfilePicture != null)
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", "profile-pictures");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var uniqueFileName = $"{userId}_{DateTime.Now:yyyyMMddHHmmss}{Path.GetExtension(model.ProfilePicture.FileName)}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ProfilePicture.CopyToAsync(fileStream);
                }

                // Delete old profile picture if exists
                if (!string.IsNullOrEmpty(user.ProfilePicture))
                {
                    var oldFilePath = Path.Combine(_environment.WebRootPath, user.ProfilePicture.TrimStart('~', '/').Replace("/", "\\"));
                    if (File.Exists(oldFilePath))
                    {
                        File.Delete(oldFilePath);
                    }
                }

                user.ProfilePicture = $"/uploads/profile-pictures/{uniqueFileName}";
            }

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return (false, string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            return (true, null);
        }

        public async Task<bool> VerifyOTPAsync(string userId, string otpCode, OTPType type)
        {
            var otp = await _context.UserOTPs
                .FirstOrDefaultAsync(o => o.ApplicationUserId == userId &&
                                         o.OTPCode == otpCode &&
                                         o.Type == type &&
                                         !o.IsUsed &&
                                         o.ExpiryDate > DateTime.Now);

            return otp != null;
        }

        public async Task<string> GenerateOTPAsync(string userId, OTPType type)
        {
            // Generate a 6-digit OTP
            var random = new Random();
            var otpCode = random.Next(100000, 999999).ToString();

            // Save OTP to database
            var userOtp = new UserOTP
            {
                ApplicationUserId = userId,
                OTPCode = otpCode,
                ExpiryDate = DateTime.Now.AddMinutes(30), // OTP valid for 30 minutes
                IsUsed = false,
                Type = type
            };

            _context.UserOTPs.Add(userOtp);
            await _context.SaveChangesAsync();

            return otpCode;
        }

        private async Task SendConfirmationEmail(ApplicationUser user, string otpCode)
        {
            var emailTemplatePath = Path.Combine(_environment.ContentRootPath, "TempHtml", "EmailTemplates", "WelcomeEmail.html");
            var emailTemplate = await File.ReadAllTextAsync(emailTemplatePath);

            var emailBody = emailTemplate
                .Replace("{{UserName}}", $"{user.FirstName} {user.LastName}")
                .Replace("{{OTPCode}}", otpCode);

            await _emailService.SendEmailAsync(user.Email, "Confirm Your Email", emailBody);
        }

        private async Task SendPasswordResetEmail(ApplicationUser user, string otpCode)
        {
            var emailTemplatePath = Path.Combine(_environment.ContentRootPath, "TempHtml", "EmailTemplates", "PasswordReset.html");
            var emailTemplate = await File.ReadAllTextAsync(emailTemplatePath);

            var emailBody = emailTemplate
                .Replace("{{UserName}}", $"{user.FirstName} {user.LastName}")
                .Replace("{{OTPCode}}", otpCode);

            await _emailService.SendEmailAsync(user.Email, "Password Reset Request", emailBody);
        }
    }
}