using Microsoft.AspNetCore.Identity;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Models.ViewModels;

namespace VoxTics.Services.Interfaces
{
    public interface IApplicationUsersService
    {
        Task<ManageProfileVM> GetUserProfileAsync(string userId);
        Task UpdateUserProfileAsync(string userId, ManageProfileVM profile);
    }
}
