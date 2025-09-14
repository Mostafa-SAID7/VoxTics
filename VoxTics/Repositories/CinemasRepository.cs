using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Repositories
{
    /// <summary>
    /// Repository for handling cinema operations with advanced queries, caching, and logging.
    /// </summary>
    public class CinemasRepository : BaseRepository<Cinema>, ICinemasRepository
    {
        private readonly MovieDbContext _context;
        private readonly ILogger<CinemasRepository> _logger;
        private readonly IMemoryCache? _cache;

        private static readonly string ActiveCinemasCacheKey = "ActiveCinemas";
        private static readonly string CinemaStatsCacheKey = "CinemaStats";

        public CinemasRepository(
            MovieDbContext context,
            ILogger<CinemasRepository> logger,
            IMemoryCache? cache = null) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _cache = cache;
        }

        public async Task<IEnumerable<Cinema>> GetActiveCinemasAsync(
            bool useCache = true,
            CancellationToken cancellationToken = default)
        {
            if (useCache && _cache != null && _cache.TryGetValue(ActiveCinemasCacheKey, out IEnumerable<Cinema> cached))
            {
                _logger.LogDebug("Returning active cinemas from cache.");
                return cached;
            }

            var cinemas = await _context.Cinemas
                .AsNoTracking()
                .Where(c => c.IsActive)
                .OrderBy(c => c.Name)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            if (useCache && _cache != null)
            {
                _cache.Set(ActiveCinemasCacheKey, cinemas, TimeSpan.FromMinutes(5));
            }

            _logger.LogInformation("Fetched {Count} active cinemas from database.", cinemas.Count);
            return cinemas;
        }

        public async Task<(IEnumerable<Cinema> Cinemas, int TotalCount)> SearchCinemasAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            string? city = null,
            CancellationToken cancellationToken = default)
        {
            if (pageIndex < 0) pageIndex = 0;
            if (pageSize <= 0) pageSize = 10;

            IQueryable<Cinema> query = _context.Cinemas.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                string term = searchTerm.Trim().ToLower();
                query = query.Where(c => c.Name.ToLower().Contains(term));
            }

            if (!string.IsNullOrWhiteSpace(city))
            {
                string cityFilter = city.Trim().ToLower();
                query = query.Where(c => c.City.ToLower().Contains(cityFilter));
            }

            int totalCount = await query.CountAsync(cancellationToken).ConfigureAwait(false);

            var cinemas = await query
                .OrderBy(c => c.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            _logger.LogInformation("Searched cinemas: {SearchTerm}, {City}, Page {PageIndex}", searchTerm, city, pageIndex);
            return (cinemas, totalCount);
        }

        public async Task<Cinema?> GetCinemaDetailsAsync(
            int cinemaId,
            bool useCache = true,
            CancellationToken cancellationToken = default)
        {
            string cacheKey = $"CinemaDetails_{cinemaId}";

            if (useCache && _cache != null && _cache.TryGetValue(cacheKey, out Cinema cached))
            {
                _logger.LogDebug("Returning cinema details from cache for ID {CinemaId}", cinemaId);
                return cached;
            }

            var cinema = await _context.Cinemas
                .AsNoTracking()
                .Include(c => c.Showtimes)
                    .ThenInclude(s => s.Movie)
                .FirstOrDefaultAsync(c => c.Id == cinemaId, cancellationToken)
                .ConfigureAwait(false);

            if (cinema != null && useCache && _cache != null)
            {
                _cache.Set(cacheKey, cinema, TimeSpan.FromMinutes(10));
            }

            return cinema;
        }

        public async Task<bool> CinemaNameExistsAsync(
            string name,
            int? excludeId = null,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Cinema name cannot be empty.", nameof(name));

            string normalized = name.Trim().ToLower();
            bool exists = await _context.Cinemas
                .AnyAsync(c =>
                    c.Name.ToLower() == normalized &&
                    (!excludeId.HasValue || c.Id != excludeId.Value),
                    cancellationToken)
                .ConfigureAwait(false);

            if (exists)
                _logger.LogWarning("Cinema name '{Name}' already exists.", name);

            return exists;
        }

        public async Task<(int Total, int Active, int WithUpcomingShowtimes)> GetCinemaStatsAsync(
            bool useCache = true,
            CancellationToken cancellationToken = default)
        {
            if (useCache && _cache != null && _cache.TryGetValue(CinemaStatsCacheKey, out (int, int, int) cachedStats))
            {
                _logger.LogDebug("Returning cinema stats from cache.");
                return cachedStats;
            }

            int total = await _context.Cinemas.CountAsync(cancellationToken).ConfigureAwait(false);
            int active = await _context.Cinemas.CountAsync(c => c.IsActive, cancellationToken).ConfigureAwait(false);
            var now = DateTime.UtcNow;
            int withUpcoming = await _context.Cinemas
                .Include(c => c.Showtimes)
                .CountAsync(c => c.Showtimes.Any(s => s.StartTime > now), cancellationToken)
                .ConfigureAwait(false);

            var stats = (total, active, withUpcoming);

            if (useCache && _cache != null)
            {
                _cache.Set(CinemaStatsCacheKey, stats, TimeSpan.FromMinutes(3));
            }

            _logger.LogInformation("Fetched cinema stats: Total={Total}, Active={Active}, Upcoming={Upcoming}", total, active, withUpcoming);
            return stats;
        }
    }
}
