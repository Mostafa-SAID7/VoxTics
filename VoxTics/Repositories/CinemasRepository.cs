using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Models.Entities;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Repositories
{
    public class CinemasRepository : BaseRepository<Cinema>, ICinemasRepository
    {
        private readonly ILogger<CinemasRepository> _logger;
        private readonly IMemoryCache? _cache;

        private const string ActiveCinemasCacheKey = "ActiveCinemas";
        private const string CinemaStatsCacheKey = "CinemaStats";

        public CinemasRepository(
            MovieDbContext context,
            ILogger<CinemasRepository> logger,
            IMemoryCache? cache = null) : base(context)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _cache = cache;
        }

        // Optional parameterless constructor if needed
        public CinemasRepository(MovieDbContext context) : base(context)
        {
        }

        // --- Custom Methods ---

        /// <summary>
        /// Get all active cinemas with caching
        /// </summary>
        public async Task<IEnumerable<Cinema>> GetActiveCinemasAsync(CancellationToken cancellationToken = default)
        {
            if (_cache != null && _cache.TryGetValue(ActiveCinemasCacheKey, out IEnumerable<Cinema> cachedCinemas))
            {
                return cachedCinemas;
            }

            try
            {
                var cinemas = await Query()
                    .Where(c => c.IsActive)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                _cache?.Set(ActiveCinemasCacheKey, cinemas, TimeSpan.FromMinutes(10));

                return cinemas;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching active cinemas");
                return Enumerable.Empty<Cinema>();
            }
        }

        /// <summary>
        /// Get paged cinemas for browse pages
        /// </summary>
        public async Task<(IEnumerable<Cinema> Items, int TotalCount)> GetPagedCinemasAsync(
            int page,
            int pageSize,
            string? search = null,
            string? sort = null,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var query = Query().AsNoTracking().Where(c => c.IsActive);

                if (!string.IsNullOrWhiteSpace(search))
                    query = query.Where(c => c.Name.Contains(search));

                if (!string.IsNullOrWhiteSpace(sort))
                {
                    query = sort.ToLower() switch
                    {
                        "name" => query.OrderBy(c => c.Name),
                        "name_desc" => query.OrderByDescending(c => c.Name),
                        _ => query
                    };
                }

                var totalCount = await query.CountAsync(cancellationToken);

                var items = await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(cancellationToken);

                return (items, totalCount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching paged cinemas");
                return (Enumerable.Empty<Cinema>(), 0);
            }
        }

        /// <summary>
        /// Get cinema by id including halls, showtimes, and social links
        /// </summary>
        public async Task<Cinema?> GetCinemaDetailsAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await Query()
                    .Include(c => c.Halls)
                        .ThenInclude(h => h.Seats)
                    .Include(c => c.Showtimes)
                    .Include(c => c.SocialMediaLinks)
                    .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching cinema details for Id {CinemaId}", id);
                return null;
            }
        }
    }
}
