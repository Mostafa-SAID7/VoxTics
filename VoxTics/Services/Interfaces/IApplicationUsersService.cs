using Microsoft.AspNetCore.Identity;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Models.ViewModels;

namespace VoxTics.Services.Interfaces
{
    public interface IApplicationUsersService
    {
        Task<IdentityResultWrapper> RegisterAsync(RegisterVM model, string callbackScheme, string confirmActionName = "ConfirmEmail");
        Task<(bool Succeeded, string Message)> ConfirmEmailAsync(string userId, string token);
        Task<(bool Succeeded, string Message)> LoginAsync(LoginVM model);
        Task LogoutAsync();
        Task<(bool Succeeded, string Message)> ResendEmailConfirmationAsync(ResendEmailConfirmationVM model, string confirmActionName = "ConfirmEmail");
        Task<(bool Succeeded, string Message)> ForgetPasswordSendOtpAsync(ForgetPasswordVM model);
        Task<(bool Succeeded, string Message)> ConfirmOtpAsync(ConfirmOTPVM model);
        Task<(bool Succeeded, string Message)> ResetPasswordAsync(NewPasswordVM model);
        Task<ApplicationUser?> FindByExternalProviderAsync(ExternalLoginInfoStub info);
        Task<ApplicationUser?> GetByIdAsync(string id);
        Task<(bool Succeeded, string Message)> UpdateProfileAsync(string userId, PersonalInfoVM vm);
    }
    // small helper wrapper types
    public record IdentityResultWrapper(bool Succeeded, string Message);
    public record ExternalLoginInfoStub(string LoginProvider, string ProviderKey, System.Security.Claims.ClaimsPrincipal Principal);

}
