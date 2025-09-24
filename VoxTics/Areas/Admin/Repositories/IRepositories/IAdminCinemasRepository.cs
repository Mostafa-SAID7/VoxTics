using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels.Cinema;

namespace VoxTics.Areas.Admin.Repositories.IRepositories
{
    public interface IAdminCinemasRepository
    {
        Task<PaginatedList<Cinema>> GetPagedAsync(int pageIndex, int pageSize, string? search, string? sortColumn, bool sortDescending, CancellationToken cancellationToken = default);
        Task<Cinema?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddAsync(Cinema entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(Cinema entity, CancellationToken cancellationToken = default);
        Task RemoveAsync(Cinema entity, CancellationToken cancellationToken = default);
        Task CommitAsync();
        Task<bool> SlugExistsAsync(string slug, int? excludeId = null, CancellationToken cancellationToken = default);
    }
}
