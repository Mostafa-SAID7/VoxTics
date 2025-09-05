using Microsoft.EntityFrameworkCore;
using VoxTics.Data;
using VoxTics.Models.Entities;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Repositories.Implementations
{
    public class CinemaRepository : BaseRepository<Cinema>, ICinemaRepository
    {
        public CinemaRepository(MovieDbContext context) : base(context) { }

        public Task<IQueryable<Cinema>> QueryAllAsync()
        {
            IQueryable<Cinema> q = _dbSet.AsNoTracking().OrderBy(c => c.Name);
            return Task.FromResult(q);
        }

        public async Task<int> CountAsync(IQueryable<Cinema> query)
        {
            return await query.CountAsync();
        }

        public async Task<List<Cinema>> PagedAsync(IQueryable<Cinema> query, int page, int pageSize)
        {
            return await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
