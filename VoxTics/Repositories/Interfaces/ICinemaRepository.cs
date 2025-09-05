using VoxTics.Models.Entities;

namespace VoxTics.Repositories.Interfaces
{
    public interface ICinemaRepository : IBaseRepository<Cinema>
    {
        // cinema-specific methods (if any)
        Task<IQueryable<Cinema>> QueryAllAsync();
        Task<int> CountAsync(IQueryable<Cinema> query);
        Task<List<Cinema>> PagedAsync(IQueryable<Cinema> query, int page, int pageSize);
    }
}
