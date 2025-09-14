using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Repositories;

namespace VoxTics.Areas.Admin.Repositories
{
    /// <summary>
    /// Admin-specific repository for managing cinemas with advanced functionality.
    /// </summary>
    public class AdminCinemasRepository : BaseRepository<Cinema>, IAdminCinemasRepository
    {
        private readonly MovieDbContext _context;
        private readonly ILogger<AdminCinemasRepository> _logger;

        public AdminCinemasRepository(MovieDbContext context, ILogger<AdminCinemasRepository> logger) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<(IEnumerable<Cinema> Cinemas, int TotalCount)> GetPagedCinemasAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            string? city = null,
            bool? isActive = null,
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
                string cityTerm = city.Trim().ToLower();
                query = query.Where(c => c.City.ToLower().Contains(cityTerm));
            }

            if (isActive.HasValue)
            {
                query = query.Where(c => c.IsActive == isActive.Value);
            }

            int totalCount = await query.CountAsync(cancellationToken).ConfigureAwait(false);

            var cinemas = await query
                .OrderBy(c => c.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            _logger.LogInformation("Fetched {Count} cinemas for admin paging (Search: {SearchTerm}, City: {City}, Active: {Active})",
                cinemas.Count, searchTerm, city, isActive);

            return (cinemas, totalCount);
        }

        public async Task<bool> SetCinemaStatusAsync(
            int cinemaId,
            bool isActive,
            CancellationToken cancellationToken = default)
        {
            var cinema = await _context.Cinemas.FirstOrDefaultAsync(c => c.Id == cinemaId, cancellationToken)
                .ConfigureAwait(false);

            if (cinema == null)
            {
                _logger.LogWarning("Cinema ID {Id} not found for status change.", cinemaId);
                return false;
            }

            cinema.IsActive = isActive;
            _context.Cinemas.Update(cinema);

            _logger.LogInformation("Cinema ID {Id} status set to {Status}.", cinemaId, isActive);
            return true; // SaveChanges handled by UnitOfWork
        }

        public async Task<(int TotalShowtimes, int UpcomingMovies, decimal Revenue)> GetCinemaDetailsStatsAsync(
            int cinemaId,
            CancellationToken cancellationToken = default)
        {
            var totalShowtimes = await _context.Showtimes
                .CountAsync(s => s.CinemaId == cinemaId, cancellationToken)
                .ConfigureAwait(false);

            var upcomingMovies = await _context.Showtimes
                .Include(s => s.Movie)
                .Where(s => s.CinemaId == cinemaId && s.StartTime > DateTime.UtcNow)
                .Select(s => s.MovieId)
                .Distinct()
                .CountAsync(cancellationToken)
                .ConfigureAwait(false);

            var revenue = await _context.Bookings
                .Where(b => b.Showtime.CinemaId == cinemaId)
                .SumAsync(b => b.TotalPrice, cancellationToken)
                .ConfigureAwait(false);

            _logger.LogInformation("Fetched stats for Cinema ID {Id}: Showtimes={Total}, Movies={Movies}, Revenue={Revenue}",
                cinemaId, totalShowtimes, upcomingMovies, revenue);

            return (totalShowtimes, upcomingMovies, revenue);
        }

        public async Task<(DateTime CreatedAt, DateTime? UpdatedAt, DateTime? LastShowtime)> GetCinemaAuditInfoAsync(
            int cinemaId,
            CancellationToken cancellationToken = default)
        {
            var cinema = await _context.Cinemas
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == cinemaId, cancellationToken)
                .ConfigureAwait(false);

            if (cinema == null)
                throw new InvalidOperationException($"Cinema ID {cinemaId} not found.");

            var lastShowtime = await _context.Showtimes
                .Where(s => s.CinemaId == cinemaId)
                .OrderByDescending(s => s.StartTime)
                .Select(s => s.StartTime)
                .FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);

            return (cinema.CreatedAt, cinema.UpdatedAt, lastShowtime == default ? null : lastShowtime);
        }

        public async Task<bool> HardDeleteCinemaAsync(
            int cinemaId,
            CancellationToken cancellationToken = default)
        {
            var cinema = await _context.Cinemas
                .Include(c => c.Showtimes)
                    .ThenInclude(s => s.Bookings)
                .FirstOrDefaultAsync(c => c.Id == cinemaId, cancellationToken)
                .ConfigureAwait(false);

            if (cinema == null)
            {
                _logger.LogWarning("Cinema ID {Id} not found for hard delete.", cinemaId);
                return false;
            }

            _context.Bookings.RemoveRange(cinema.Showtimes.SelectMany(s => s.Bookings));
            _context.Showtimes.RemoveRange(cinema.Showtimes);
            _context.Cinemas.Remove(cinema);

            _logger.LogCritical("Cinema ID {Id} and all related data were permanently deleted.", cinemaId);
            return true; // Commit handled by UnitOfWork
        }
    }
}
