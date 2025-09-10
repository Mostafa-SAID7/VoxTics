using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Data;                // MovieDbContext
using VoxTics.Models.Entities;
using VoxTics.Models.Enums.Sorting;
using VoxTics.Models.Enums.TimeRange;
using VoxTics.Models.ViewModels;   // BasePaginatedFilterVM, ShowtimeFilterVM

namespace VoxTics.Areas.Admin.Repositories
{
    public class ShowtimeRepository : BaseRepository<Showtime>, IShowtimeRepository
    {
        public ShowtimeRepository(MovieDbContext context) : base(context)
        {
        }

        // -------------------------
        // Simple retrievals
        // -------------------------
        public async Task<IEnumerable<Showtime>> GetShowtimesByMovieAsync(int movieId)
        {
            return await _dbSet
                .Where(s => s.MovieId == movieId && s.StartTime >= DateTime.UtcNow)
                .Include(s => s.Movie)
                .Include(s => s.Hall).ThenInclude(h => h.Cinema)
                .OrderBy(s => s.StartTime)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Showtime>> GetShowtimesByCinemaAsync(int cinemaId)
        {
            return await _dbSet
                .Where(s => s.Hall.CinemaId == cinemaId && s.StartTime >= DateTime.UtcNow)
                .Include(s => s.Movie)
                .Include(s => s.Hall)
                .OrderBy(s => s.StartTime)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Showtime>> GetShowtimesByHallAsync(int hallId)
        {
            return await _dbSet
                .Where(s => s.HallId == hallId)
                .Include(s => s.Movie)
                .Include(s => s.Hall)
                .OrderBy(s => s.StartTime)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Showtime?> GetShowtimeWithDetailsAsync(int showtimeId)
        {
            return await _dbSet
                .Where(s => s.Id == showtimeId)
                .Include(s => s.Movie)
                .Include(s => s.Hall).ThenInclude(h => h.Cinema)
                .Include(s => s.Hall).ThenInclude(h => h.Seats)
                .Include(s => s.Bookings).ThenInclude(b => b.BookingSeats)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Showtime>> GetActiveShowtimesAsync()
        {
            return await _dbSet
                .Where(s => s.Status == ShowtimeStatus.Active && s.StartTime >= DateTime.UtcNow)
                .Include(s => s.Movie)
                .Include(s => s.Hall).ThenInclude(h => h.Cinema)
                .OrderBy(s => s.StartTime)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Showtime>> GetShowtimesByStatusAsync(ShowtimeStatus status)
        {
            return await _dbSet
                .Where(s => s.Status == status)
                .Include(s => s.Movie)
                .Include(s => s.Hall).ThenInclude(h => h.Cinema)
                .OrderBy(s => s.StartTime)
                .AsNoTracking()
                .ToListAsync();
        }

        // -------------------------
        // Date/time queries
        // -------------------------
        public async Task<IEnumerable<Showtime>> GetShowtimesByDateAsync(DateTime date)
        {
            var startOfDay = date.Date;
            var endOfDay = startOfDay.AddDays(1);

            return await _dbSet
                .Where(s => s.StartTime >= startOfDay && s.StartTime < endOfDay)
                .Include(s => s.Movie)
                .Include(s => s.Hall).ThenInclude(h => h.Cinema)
                .OrderBy(s => s.StartTime)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Showtime>> GetShowtimesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(s => s.StartTime >= startDate && s.StartTime <= endDate)
                .Include(s => s.Movie)
                .Include(s => s.Hall).ThenInclude(h => h.Cinema)
                .OrderBy(s => s.StartTime)
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<IEnumerable<Showtime>> GetTodaysShowtimesAsync() => GetShowtimesByDateAsync(DateTime.UtcNow.Date);

        public async Task<IEnumerable<Showtime>> GetUpcomingShowtimesAsync(int days = 7)
        {
            var endDate = DateTime.UtcNow.AddDays(days);
            return await _dbSet
                .Where(s => s.StartTime >= DateTime.UtcNow && s.StartTime <= endDate)
                .Include(s => s.Movie)
                .Include(s => s.Hall).ThenInclude(h => h.Cinema)
                .OrderBy(s => s.StartTime)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Showtime>> GetShowtimesAfterTimeAsync(DateTime afterTime)
        {
            return await _dbSet
                .Where(s => s.StartTime >= afterTime)
                .Include(s => s.Movie)
                .Include(s => s.Hall).ThenInclude(h => h.Cinema)
                .OrderBy(s => s.StartTime)
                .AsNoTracking()
                .ToListAsync();
        }

        // -------------------------
        // Combinations
        // -------------------------
        public async Task<IEnumerable<Showtime>> GetShowtimesByMovieAndCinemaAsync(int movieId, int cinemaId)
        {
            return await _dbSet
                .Where(s => s.MovieId == movieId && s.Hall.CinemaId == cinemaId && s.StartTime >= DateTime.UtcNow)
                .Include(s => s.Movie)
                .Include(s => s.Hall)
                .OrderBy(s => s.StartTime)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Showtime>> GetShowtimesByMovieAndDateAsync(int movieId, DateTime date)
        {
            var startOfDay = date.Date;
            var endOfDay = startOfDay.AddDays(1);

            return await _dbSet
                .Where(s => s.MovieId == movieId && s.StartTime >= startOfDay && s.StartTime < endOfDay)
                .Include(s => s.Movie)
                .Include(s => s.Hall).ThenInclude(h => h.Cinema)
                .OrderBy(s => s.StartTime)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Showtime>> GetShowtimesByCinemaAndDateAsync(int cinemaId, DateTime date)
        {
            var startOfDay = date.Date;
            var endOfDay = startOfDay.AddDays(1);

            return await _dbSet
                .Where(s => s.Hall.CinemaId == cinemaId && s.StartTime >= startOfDay && s.StartTime < endOfDay)
                .Include(s => s.Movie)
                .Include(s => s.Hall)
                .OrderBy(s => s.StartTime)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Showtime>> GetShowtimesByMovieCinemaAndDateAsync(int movieId, int cinemaId, DateTime date)
        {
            var startOfDay = date.Date;
            var endOfDay = startOfDay.AddDays(1);

            return await _dbSet
                .Where(s => s.MovieId == movieId &&
                            s.Hall.CinemaId == cinemaId &&
                            s.StartTime >= startOfDay &&
                            s.StartTime < endOfDay)
                .Include(s => s.Movie)
                .Include(s => s.Hall)
                .OrderBy(s => s.StartTime)
                .AsNoTracking()
                .ToListAsync();
        }

        // -------------------------
        // Availability & seating
        // -------------------------
        public async Task<int> GetAvailableSeatsCountAsync(int showtimeId)
        {
            var showtime = await _dbSet
                .Include(s => s.Hall).ThenInclude(h => h.Seats)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == showtimeId);

            if (showtime == null) return 0;

            var totalSeats = showtime.Hall.Seats.Count;
            var bookedSeats = await _context.BookingSeats
                .CountAsync(bs => bs.Booking.ShowtimeId == showtimeId && bs.Booking.Status != BookingStatus.Cancelled);

            return Math.Max(0, totalSeats - bookedSeats);
        }

        public async Task<int> GetBookedSeatsCountAsync(int showtimeId)
        {
            return await _context.BookingSeats
                .CountAsync(bs => bs.Booking.ShowtimeId == showtimeId && bs.Booking.Status != BookingStatus.Cancelled);
        }

        public async Task<double> GetOccupancyRateAsync(int showtimeId)
        {
            var showtime = await _dbSet
                .Include(s => s.Hall).ThenInclude(h => h.Seats)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == showtimeId);

            if (showtime == null) return 0.0;

            var totalSeats = showtime.Hall.Seats.Count;
            if (totalSeats == 0) return 0.0;

            var bookedSeats = await GetBookedSeatsCountAsync(showtimeId);
            return (double)bookedSeats / totalSeats * 100.0;
        }

        public async Task<bool> HasAvailableSeatsAsync(int showtimeId)
        {
            var available = await GetAvailableSeatsCountAsync(showtimeId);
            return available > 0;
        }

        public async Task<IEnumerable<Seat>> GetAvailableSeatsAsync(int showtimeId)
        {
            var bookedSeatIds = await _context.BookingSeats
                .Where(bs => bs.Booking.ShowtimeId == showtimeId && bs.Booking.Status != BookingStatus.Cancelled)
                .Select(bs => bs.SeatId)
                .ToListAsync();

            var showtime = await _dbSet
                .Where(s => s.Id == showtimeId)
                .Include(s => s.Hall)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (showtime == null) return new List<Seat>();

            return await _context.Seats
                .Where(s => s.HallId == showtime.HallId && !bookedSeatIds.Contains(s.Id))
                .OrderBy(s => s.RowNumber).ThenBy(s => s.SeatNumber)
                .AsNoTracking()
                .ToListAsync();
        }

        // -------------------------
        // Search & paging
        // -------------------------
        public async Task<IEnumerable<Showtime>> SearchShowtimesAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await GetActiveShowtimesAsync();

            var lower = searchTerm.ToLower();

            return await _dbSet
                .Where(s => EF.Functions.Like(s.Movie.Title.ToLower(), $"%{lower}%") ||
                            EF.Functions.Like(s.Hall.Cinema.Name.ToLower(), $"%{lower}%") ||
                            EF.Functions.Like(s.Hall.Name.ToLower(), $"%{lower}%"))
                .Include(s => s.Movie)
                .Include(s => s.Hall).ThenInclude(h => h.Cinema)
                .OrderBy(s => s.StartTime)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<(IEnumerable<Showtime> showtimes, int totalCount)> GetPagedShowtimesAsync(BasePaginatedFilterVM filter)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter));
            if (filter.PageNumber <= 0) filter.PageNumber = 1;
            if (filter.PageSize <= 0) filter.PageSize = 10;

            var baseQuery = _dbSet.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
            {
                var s = filter.SearchTerm.ToLower();
                baseQuery = baseQuery.Where(x =>
                    x.Movie.Title.ToLower().Contains(s) ||
                    x.Hall.Cinema.Name.ToLower().Contains(s) ||
                    x.Hall.Name.ToLower().Contains(s));
            }

            var totalCount = await baseQuery.CountAsync();

            baseQuery = filter.SortBy?.ToLower() switch
            {
                "movie" => filter.SortOrder == SortOrder.Desc ? baseQuery.OrderByDescending(x => x.Movie.Title) : baseQuery.OrderBy(x => x.Movie.Title),
                "cinema" => filter.SortOrder == SortOrder.Desc ? baseQuery.OrderByDescending(x => x.Hall.Cinema.Name) : baseQuery.OrderBy(x => x.Hall.Cinema.Name),
                "hall" => filter.SortOrder == SortOrder.Desc ? baseQuery.OrderByDescending(x => x.Hall.Name) : baseQuery.OrderBy(x => x.Hall.Name),
                "starttime" => filter.SortOrder == SortOrder.Desc ? baseQuery.OrderByDescending(x => x.StartTime) : baseQuery.OrderBy(x => x.StartTime),
                "price" => filter.SortOrder == SortOrder.Desc ? baseQuery.OrderByDescending(x => x.Price) : baseQuery.OrderBy(x => x.Price),
                _ => baseQuery.OrderBy(x => x.StartTime)
            };

            // safe paging: select ids then include
            var ids = await baseQuery
                .Select(x => x.Id)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            var showtimes = await _dbSet
                .Where(s => ids.Contains(s.Id))
                .Include(s => s.Movie)
                .Include(s => s.Hall).ThenInclude(h => h.Cinema)
                .AsNoTracking()
                .ToListAsync();

            var ordered = ids.Select(id => showtimes.First(s => s.Id == id)).ToList();
            return (ordered, totalCount);
        }

        public async Task<IEnumerable<Showtime>> GetFilteredShowtimesAsync(ShowtimeFilterVM filter)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter));
            var query = _dbSet.AsQueryable();

            if (filter.MovieId.HasValue) query = query.Where(s => s.MovieId == filter.MovieId.Value);
            if (filter.CinemaId.HasValue) query = query.Where(s => s.Hall.CinemaId == filter.CinemaId.Value);
            if (filter.HallId.HasValue) query = query.Where(s => s.HallId == filter.HallId.Value);

            if (filter.StartDate.HasValue)
            {
                var start = filter.StartDate.Value.Date;
                var end = start.AddDays(1);
                query = query.Where(s => s.StartTime >= start && s.StartTime < end);
            }

            if (filter.StartDate.HasValue && filter.EndDate.HasValue)
            {
                query = query.Where(s => s.StartTime >= filter.StartDate.Value && s.StartTime <= filter.EndDate.Value);
            }

            if (filter.Status.HasValue) query = query.Where(s => s.Status == filter.Status.Value);

            if (filter.TimeOfDayRange.HasValue)
            {
                query = filter.TimeOfDayRange.Value switch
                {
                    TimeOfDayRange.Morning => query.Where(s => s.StartTime.Hour >= 6 && s.StartTime.Hour < 12),
                    TimeOfDayRange.Afternoon => query.Where(s => s.StartTime.Hour >= 12 && s.StartTime.Hour < 18),
                    TimeOfDayRange.Evening => query.Where(s => s.StartTime.Hour >= 18 && s.StartTime.Hour < 24),
                    TimeOfDayRange.Night => query.Where(s => s.StartTime.Hour >= 0 && s.StartTime.Hour < 6),
                    _ => query
                };
            }

            if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
            {
                var s = filter.SearchTerm.ToLower();
                query = query.Where(x => x.Movie.Title.ToLower().Contains(s) || x.Hall.Cinema.Name.ToLower().Contains(s));
            }

            // If HasAvailableSeats is requested do the heavier in-memory evaluation after includes
            if (filter.HasAvailableSeats.HasValue && filter.HasAvailableSeats.Value)
            {
                var showtimes = await query
                    .Include(s => s.Movie)
                    .Include(s => s.Hall).ThenInclude(h => h.Cinema)
                    .Include(s => s.Hall).ThenInclude(h => h.Seats)
                    .Include(s => s.Bookings).ThenInclude(b => b.BookingSeats)
                    .AsNoTracking()
                    .ToListAsync();

                return showtimes.Where(s =>
                {
                    var totalSeats = s.Hall.Seats.Count;
                    var bookedSeats = s.Bookings.Where(b => b.Status != BookingStatus.Cancelled).SelectMany(b => b.BookingSeats).Count();
                    return totalSeats > bookedSeats;
                });
            }

            // Sorting
            query = filter.SortBy?.ToLower() switch
            {
                "movie" => filter.SortOrder == SortOrder.Desc ? query.OrderByDescending(x => x.Movie.Title) : query.OrderBy(x => x.Movie.Title),
                "starttime" => filter.SortOrder == SortOrder.Desc ? query.OrderByDescending(x => x.StartTime) : query.OrderBy(x => x.StartTime),
                "price" => filter.SortOrder == SortOrder.Desc ? query.OrderByDescending(x => x.Price) : query.OrderBy(x => x.Price),
                _ => query.OrderBy(x => x.StartTime)
            };

            return await query
                .Include(s => s.Movie)
                .Include(s => s.Hall).ThenInclude(h => h.Cinema)
                .AsNoTracking()
                .ToListAsync();
        }

        // -------------------------
        // Time slot management
        // -------------------------
        public async Task<bool> IsTimeSlotAvailableAsync(int hallId, DateTime startTime, DateTime endTime, int? excludeShowtimeId = null)
        {
            var q = _dbSet.Where(s => s.HallId == hallId && s.StartTime < endTime && s.EndTime > startTime);
            if (excludeShowtimeId.HasValue) q = q.Where(s => s.Id != excludeShowtimeId.Value);
            return !await q.AnyAsync();
        }

        public async Task<IEnumerable<Showtime>> GetConflictingShowtimesAsync(int hallId, DateTime startTime, DateTime endTime, int? excludeShowtimeId = null)
        {
            var q = _dbSet.Where(s => s.HallId == hallId && s.StartTime < endTime && s.EndTime > startTime);
            if (excludeShowtimeId.HasValue) q = q.Where(s => s.Id != excludeShowtimeId.Value);

            return await q.Include(s => s.Movie).Include(s => s.Hall).AsNoTracking().ToListAsync();
        }

        public async Task<TimeSpan> GetNextAvailableTimeSlotAsync(int hallId, DateTime preferredTime, TimeSpan duration)
        {
            var existing = await _dbSet
                .Where(s => s.HallId == hallId && s.StartTime.Date == preferredTime.Date)
                .OrderBy(s => s.StartTime)
                .Select(s => new { s.StartTime, s.EndTime })
                .AsNoTracking()
                .ToListAsync();

            var preferredEnd = preferredTime.Add(duration);
            bool conflictAtPreferred = existing.Any(s => preferredTime < s.EndTime && preferredEnd > s.StartTime);
            if (!conflictAtPreferred) return preferredTime.TimeOfDay;

            var current = preferredTime;
            var endOfDay = preferredTime.Date.AddDays(1);
            while (current < endOfDay)
            {
                var currentEnd = current.Add(duration);
                var conflict = existing.Any(s => current < s.EndTime && currentEnd > s.StartTime);
                if (!conflict) return current.TimeOfDay;
                current = current.AddMinutes(15);
            }

            // fallback first slot next day
            return new TimeSpan(9, 0, 0);
        }

        // -------------------------
        // Statistics & analytics
        // -------------------------
        public async Task<int> GetTotalBookingsAsync(int showtimeId)
        {
            return await _context.Bookings.CountAsync(b => b.ShowtimeId == showtimeId && b.Status != BookingStatus.Cancelled);
        }

        public async Task<decimal> GetTotalRevenueAsync(int showtimeId)
        {
            return await _context.Bookings
                .Where(b => b.ShowtimeId == showtimeId && b.Status == BookingStatus.Confirmed)
                .SumAsync(b => b.TotalAmount);
        }

        public async Task<Dictionary<DateTime, int>> GetShowtimeCountByDateAsync(int days = 30)
        {
            var startDate = DateTime.UtcNow.Date;
            var endDate = startDate.AddDays(days);

            var counts = await _dbSet
                .Where(s => s.StartTime >= startDate && s.StartTime < endDate)
                .GroupBy(s => s.StartTime.Date)
                .Select(g => new { Date = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.Date, x => x.Count);

            var result = new Dictionary<DateTime, int>();
            for (var d = startDate; d < endDate; d = d.AddDays(1))
                result[d] = counts.GetValueOrDefault(d, 0);

            return result;
        }

        public async Task<Dictionary<string, int>> GetShowtimeCountByTimeRangeAsync()
        {
            var hours = await _dbSet.Where(s => s.StartTime >= DateTime.UtcNow.Date).Select(s => s.StartTime.Hour).ToListAsync();
            return new Dictionary<string, int>
            {
                ["Morning (6-12)"] = hours.Count(h => h >= 6 && h < 12),
                ["Afternoon (12-18)"] = hours.Count(h => h >= 12 && h < 18),
                ["Evening (18-24)"] = hours.Count(h => h >= 18 && h < 24),
                ["Night (0-6)"] = hours.Count(h => h >= 0 && h < 6)
            };
        }

        public async Task<IEnumerable<(Showtime showtime, int bookingCount)>> GetPopularShowtimesAsync(int count = 10)
        {
            var q = _dbSet
                .Where(s => s.Bookings.Any())
                .Select(s => new { Showtime = s, BookingCount = s.Bookings.Count(b => b.Status != BookingStatus.Cancelled) });

            var list = await q.OrderByDescending(x => x.BookingCount).Take(count).ToListAsync();
            return list.Select(x => (x.Showtime, x.BookingCount));
        }

        // -------------------------
        // Revenue & top movies
        // -------------------------
        public async Task<decimal> GetShowtimeRevenueAsync(int showtimeId) => await GetTotalRevenueAsync(showtimeId);

        public async Task<decimal> GetMovieRevenueByDateAsync(int movieId, DateTime date)
        {
            var start = date.Date;
            var end = start.AddDays(1);

            return await _context.Bookings
                .Where(b => b.Showtime.MovieId == movieId && b.Showtime.StartTime >= start && b.Showtime.StartTime < end && b.Status == BookingStatus.Confirmed)
                .SumAsync(b => b.TotalAmount);
        }

        public async Task<decimal> GetCinemaRevenueByDateAsync(int cinemaId, DateTime date)
        {
            var start = date.Date;
            var end = start.AddDays(1);

            return await _context.Bookings
                .Where(b => b.Showtime.Hall.CinemaId == cinemaId && b.Showtime.StartTime >= start && b.Showtime.StartTime < end && b.Status == BookingStatus.Confirmed)
                .SumAsync(b => b.TotalAmount);
        }

        public async Task<IEnumerable<(Movie movie, decimal revenue)>> GetTopMoviesByRevenueAsync(DateTime startDate, DateTime endDate, int count = 10)
        {
            // group by movie id, then join to movies to get entity
            var grouped = await _context.Bookings
                .Where(b => b.Showtime.StartTime >= startDate && b.Showtime.StartTime <= endDate && b.Status == BookingStatus.Confirmed)
                .GroupBy(b => b.Showtime.MovieId)
                .Select(g => new { MovieId = g.Key, Revenue = g.Sum(b => b.TotalAmount) })
                .OrderByDescending(x => x.Revenue)
                .Take(count)
                .ToListAsync();

            var movieIds = grouped.Select(g => g.MovieId).ToList();

            var movies = await _context.Movies
                .Where(m => movieIds.Contains(m.Id))
                .AsNoTracking()
                .ToListAsync();

            // preserve order of revenue
            var result = grouped.Select(g => (movies.First(m => m.Id == g.MovieId), g.Revenue)).ToList();
            return result;
        }

        // -------------------------
        // Management
        // -------------------------
        public async Task<bool> CanCancelShowtimeAsync(int showtimeId)
        {
            var showtime = await _dbSet.FindAsync(showtimeId);
            if (showtime == null) return false;

            var hasBookings = await _context.Bookings.AnyAsync(b => b.ShowtimeId == showtimeId && b.Status != BookingStatus.Cancelled);

            // allow cancel if >24h away or no bookings exist
            return showtime.StartTime > DateTime.UtcNow.AddHours(24) || !hasBookings;
        }

        public async Task<bool> CancelShowtimeAsync(int showtimeId)
        {
            if (!await CanCancelShowtimeAsync(showtimeId)) return false;

            var showtime = await _dbSet.FindAsync(showtimeId);
            if (showtime == null) return false;

            showtime.Status = ShowtimeStatus.Cancelled;
            // update timestamp property name according to your BaseEntity (CreatedAt/UpdatedAt or CreatedDate/UpdatedDate)
            // trying both places: prefer UpdatedAt if exists
            try
            {
                // If you use UpdatedAt
                showtime.GetType().GetProperty("UpdatedAt")?.SetValue(showtime, DateTime.UtcNow);
            }
            catch { /* ignore reflection fallback */ }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
