using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Areas.Identity.Repositories.IRepositories
{
    public interface IApplicationUsersRepository : IBaseRepository<ApplicationUser>
    {
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<bool> IsEmailUniqueAsync(string email, string excludeUserId = null);
        Task<IEnumerable<ApplicationUser>> GetUsersWithBookingsAsync();
        Task<ApplicationUser> GetByIdAsync(string userId);
    }
}
