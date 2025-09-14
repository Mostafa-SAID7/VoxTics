using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Repositories.UserArea
{
    public class MoviesRepository : BaseRepository<Movie>, IMoviesRepository
    {
        private readonly MovieDbContext _context;

        public MoviesRepository(MovieDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Movie>> GetCurrentlyShowingAsync(CancellationToken cancellationToken = default) =>
            await _context.Movies
                .AsNoTracking()
                .Where(m => m.ReleaseDate <= DateTime.UtcNow && m.IsFeatured)
                .OrderByDescending(m => m.Rating)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

        public async Task<IEnumerable<Movie>> GetUpcomingMoviesAsync(DateTime nowUtc, CancellationToken cancellationToken = default) =>
            await _context.Movies
                .AsNoTracking()
                .Where(m => m.ReleaseDate > nowUtc && m.IsFeatured)
                .OrderBy(m => m.ReleaseDate)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

        public async Task<IEnumerable<Movie>> GetTopRatedMoviesAsync(int count, CancellationToken cancellationToken = default) =>
            await _context.Movies
                .AsNoTracking()
                .OrderByDescending(m => m.Rating)
                .Take(count)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

        public async Task<IEnumerable<Movie>> SearchMoviesAsync(string keyword, CancellationToken cancellationToken = default) =>
            await _context.Movies
                .AsNoTracking()
                .Where(m => m.Title.Contains(keyword) || m.Description.Contains(keyword))
                .OrderByDescending(m => m.Rating)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

        public async Task<IEnumerable<Movie>> GetRecommendedMoviesAsync(string userId, CancellationToken cancellationToken = default)
        {
            return await _context.Movies
                .AsNoTracking()
                .OrderByDescending(m => m.Rating)
                .Take(5)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
