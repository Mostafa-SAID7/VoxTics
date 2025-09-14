using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Areas.Identity.Repositories.IRepositories
{
    public interface IApplicationUsersRepository : IBaseRepository<ApplicationUser>
    {

        Task<ApplicationUser?> GetByEmailAsync(string email);


        Task<ApplicationUser?> GetByIdAsync(string id);

        Task<ApplicationUser?> GetByUserNameAsync(string userName);
        Task<ApplicationUser?> GetByUserNameOrEmailAsync(string emailOrUserName);

        void Update(ApplicationUser entity);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        Task<IEnumerable<ApplicationUser>> GetAllAsync();
    }
}
