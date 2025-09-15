// Areas/Identity/Services/Interfaces/IAccountService.cs
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Models.ViewModels;

namespace VoxTics.Areas.Identity.Services.Interfaces
{
    public interface IAccountService
    {
        Task<(bool success, string errorMessage, ApplicationUser user)> RegisterUserAsync(RegisterVM model);
        Task<(bool success, string errorMessage)> LoginUserAsync(LoginVM model);
        Task<bool> ConfirmEmailAsync(string userId, string token);
        Task<(bool success, string errorMessage)> ForgotPasswordAsync(string email);
        Task<(bool success, string errorMessage)> ResetPasswordAsync(NewPasswordVM model);
        Task<bool> ResendEmailConfirmationAsync(string email);
        Task<ApplicationUser> GetUserProfileAsync(string userId);
        Task<(bool success, string errorMessage)> UpdateUserProfileAsync(string userId, ManageProfileVM model);
        Task<bool> VerifyOTPAsync(string userId, string otpCode, UserOTP type);
        Task<string> GenerateOTPAsync(string userId, UserOTP type);
    }
}