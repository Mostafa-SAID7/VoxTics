using Microsoft.AspNetCore.Identity;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
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
        private readonly IUnitOfWork _uow;
        public ApplicationUsersService(IUnitOfWork uow) => _uow = uow;

        public async Task<ManageProfileVM> GetUserProfileAsync(string userId)
        {
            var user = await _uow.ApplicationUsers.GetByIdAsync(userId);
            return new ManageProfileVM
            {
                Email = user.Email,
                FullName = user.FullName
            };
        }

        public async Task UpdateUserProfileAsync(string userId, ManageProfileVM profile)
        {
            var user = await _uow.ApplicationUsers.GetByIdAsync(userId);
            user.FullName = profile.FullName;
            await _uow.CompleteAsync();
        }
    }
}
