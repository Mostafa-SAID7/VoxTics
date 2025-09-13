using Microsoft.AspNetCore.Identity;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Models.ViewModels;

namespace VoxTics.Services.Interfaces
{
    public interface IApplicationUsersService
    {
        Task<IdentityResult> CreateUserAsync(RegisterVM registerVM);
        Task<ApplicationUser?> FindByEmailAsync(string email);
        Task<ApplicationUser?> FindByUsernameOrEmailAsync(string emailOrUsername);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        Task<IdentityResult> ConfirmEmailAsync(string userId, string token);
        Task<string> SendOTPAsync(ApplicationUser user);
        Task<bool> ValidateOTPAsync(string userId, string otpNumber);
        Task<IdentityResult> ResetPasswordAsync(string userId, string newPassword);
        Task<ApplicationUser?> ExternalLoginSignInAsync(Microsoft.AspNetCore.Identity.ExternalLoginInfo info);
    }
}
