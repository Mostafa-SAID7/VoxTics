using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Data;               // MovieDbContext
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Repositories.Interfaces;
using VoxTics.Models.ViewModels;         // BasePaginatedFilterVM

namespace VoxTics.Repositories.Implementations
{
    public class CinemaRepository : BaseRepository<Cinema>, ICinemaRepository
    {
        public CinemaRepository(MovieDbContext context) : base(context)
        {
        }

        // Helper to include halls & seats/showtimes consistently
        private IQueryable<Cinema> ApplyCinemaIncludes(IQueryable<Cinema> query, bool includeHalls = false, bool includeShowtimes = false)
        {
            if (includeHalls)
            {
                query = query.Include(c => c.Halls!)
                             .ThenInclude(h => h.Seats);
            }

            if (includeShowtimes)
            {
                query = query.Include(c => c.Halls!)
                             .ThenInclude(h => h.Showtimes)
                                 .ThenInclude(s => s.Movie);
            }

            return query;
        }

        // -------------------------
        // Basic listing & details
        // -------------------------
        public async Task<IEnumerable<Cinema>> GetActiveCinemasAsync()
        {
            return await _dbSet
                .Where(c => c.IsActive)
                .OrderBy(c => c.Name)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Cinema?> GetCinemaWithHallsAsync(int cinemaId)
        {
            return await _dbSet
                .Where(c => c.Id == cinemaId)
                .Include(c => c.Halls!)
                    .ThenInclude(h => h.Seats)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Cinema?> GetCinemaWithShowtimesAsync(int cinemaId)
        {
            return await _dbSet
                .Where(c => c.Id == cinemaId)
                .Include(c => c.Halls!)
                    .ThenInclude(h => h.Showtimes)
                        .ThenInclude(s => s.Movie)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cinema>> GetCinemasWithHallCountAsync()
        {
            // Return cinemas including halls; counts can be derived in consumers or here if preferred
            return await _dbSet
                .Include(c => c.Halls)
                .OrderBy(c => c.Name)
                .AsNoTracking()
                .ToListAsync();
        }

        // -------------------------
        // Halls & seats
        // -------------------------
        public async Task<IEnumerable<Hall>> GetCinemaHallsAsync(int cinemaId)
        {
            return await _context.Halls
                .Where(h => h.CinemaId == cinemaId)
                .Include(h => h.Seats)
                .OrderBy(h => h.Name)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> GetHallCountByCinemaAsync(int cinemaId)
        {
            return await _context.Halls.CountAsync(h => h.CinemaId == cinemaId);
        }

        public async Task<int> GetTotalSeatsByCinemaAsync(int cinemaId)
        {
            return await _context.Seats
                .CountAsync(s => s.Hall.CinemaId == cinemaId);
        }

        // -------------------------
        // Movies & showtimes
        // -------------------------
        public async Task<IEnumerable<Movie>> GetCinemaMoviesAsync(int cinemaId)
        {
            var today = DateTime.UtcNow.Date;

            var query = _context.Movies
                .Where(m => m.Showtimes.Any(s => s.Hall.CinemaId == cinemaId && s.StartTime.Date >= today))
                .Include(m => m.MovieImages)
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .AsNoTracking()
                .Distinct();

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Showtime>> GetCinemaShowtimesAsync(int cinemaId)
        {
            return await _context.Showtimes
                .Where(s => s.Hall.CinemaId == cinemaId && s.StartTime >= DateTime.UtcNow)
                .Include(s => s.Movie)
                .Include(s => s.Hall)
                .OrderBy(s => s.StartTime)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Showtime>> GetCinemaShowtimesAsync(int cinemaId, DateTime date)
        {
            var startOfDay = date.Date;
            var endOfDay = startOfDay.AddDays(1);

            return await _context.Showtimes
                .Where(s => s.Hall.CinemaId == cinemaId &&
                            s.StartTime >= startOfDay &&
                            s.StartTime < endOfDay)
                .Include(s => s.Movie)
                .Include(s => s.Hall)
                .OrderBy(s => s.StartTime)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Showtime>> GetCinemaMovieShowtimesAsync(int cinemaId, int movieId)
        {
            return await _context.Showtimes
                .Where(s => s.Hall.CinemaId == cinemaId &&
                            s.MovieId == movieId &&
                            s.StartTime >= DateTime.UtcNow)
                .Include(s => s.Movie)
                .Include(s => s.Hall)
                .OrderBy(s => s.StartTime)
                .AsNoTracking()
                .ToListAsync();
        }

        // -------------------------
        // Location & search
        // -------------------------
        public async Task<IEnumerable<Cinema>> GetCinemasByLocationAsync(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                return await GetActiveCinemasAsync();

            var lower = location.ToLower();

            return await _dbSet
                .Where(c => c.IsActive &&
                           (EF.Functions.Like(c.City.ToLower(), $"%{lower}%") ||
                            EF.Functions.Like(c.Address.ToLower(), $"%{lower}%") ||
                            EF.Functions.Like(c.State.ToLower(), $"%{lower}%")))
                .OrderBy(c => c.City).ThenBy(c => c.Name)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Cinema>> GetNearbyCinemasAsync(double latitude, double longitude, double radiusKm)
        {
            // Fetch candidates from DB with coords, then apply Haversine in memory
            var candidates = await _dbSet
                .Where(c => c.IsActive && c.Latitude.HasValue && c.Longitude.HasValue)
                .AsNoTracking()
                .ToListAsync();

            var result = candidates
                .Select(c => new { Cinema = c, Distance = CalculateDistance(latitude, longitude, c.Latitude!.Value, c.Longitude!.Value) })
                .Where(x => x.Distance <= radiusKm)
                .OrderBy(x => x.Distance)
                .Select(x => x.Cinema)
                .ToList();

            return result;
        }

        // -------------------------
        // Search & paging
        // -------------------------
        public async Task<IEnumerable<Cinema>> SearchCinemasAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await GetActiveCinemasAsync();

            var lower = searchTerm.ToLower();

            return await _dbSet
                .Where(c => c.IsActive &&
                           (EF.Functions.Like(c.Name.ToLower(), $"%{lower}%") ||
                            EF.Functions.Like(c.Address.ToLower(), $"%{lower}%") ||
                            EF.Functions.Like(c.City.ToLower(), $"%{lower}%") ||
                            EF.Functions.Like(c.State.ToLower(), $"%{lower}%")))
                .OrderBy(c => c.Name)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<(IEnumerable<Cinema> cinemas, int totalCount)> GetPagedCinemasAsync(BasePaginatedFilterVM filter)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter));
            if (filter.PageNumber <= 0) filter.PageNumber = 1;
            if (filter.PageSize <= 0) filter.PageSize = 10;

            var baseQuery = _dbSet.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
            {
                var s = filter.SearchTerm.ToLower();
                baseQuery = baseQuery.Where(c => c.Name.ToLower().Contains(s) ||
                                                 c.Address.ToLower().Contains(s) ||
                                                 c.City.ToLower().Contains(s) ||
                                                 c.State.ToLower().Contains(s));
            }

            var totalCount = await baseQuery.CountAsync();

            baseQuery = filter.SortBy?.ToLower() switch
            {
                "name" => filter.SortOrder == SortOrder.Desc ? baseQuery.OrderByDescending(c => c.Name) : baseQuery.OrderBy(c => c.Name),
                "city" => filter.SortOrder == SortOrder.Desc ? baseQuery.OrderByDescending(c => c.City) : baseQuery.OrderBy(c => c.City),
                "hallcount" => filter.SortOrder == SortOrder.Desc ? baseQuery.OrderByDescending(c => c.Halls.Count) : baseQuery.OrderBy(c => c.Halls.Count),
                "createddate" => filter.SortOrder == SortOrder.Desc ? baseQuery.OrderByDescending(c => c.CreatedDate) : baseQuery.OrderBy(c => c.CreatedDate),
                _ => baseQuery.OrderBy(c => c.Name)
            };

            // safe paging: select ids then include
            var ids = await baseQuery
                .Select(c => c.Id)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            var cinemas = await _dbSet
                .Where(c => ids.Contains(c.Id))
                .Include(c => c.Halls)
                .AsNoTracking()
                .ToListAsync();

            // preserve original order
            var ordered = ids.Select(id => cinemas.First(c => c.Id == id)).ToList();

            return (ordered, totalCount);
        }

        // -------------------------
        // Statistics & analytics
        // -------------------------
        public async Task<int> GetTotalBookingsByCinemaAsync(int cinemaId)
        {
            return await _context.Bookings
                .CountAsync(b => b.Showtime.Hall.CinemaId == cinemaId);
        }

        public async Task<decimal> GetAverageOccupancyRateAsync(int cinemaId)
        {
            var showtimes = await _context.Showtimes
                .Where(s => s.Hall.CinemaId == cinemaId && s.StartTime < DateTime.UtcNow)
                .Include(s => s.Bookings)
                    .ThenInclude(b => b.BookingSeats)
                .Include(s => s.Hall).ThenInclude(h => h.Seats)
                .AsNoTracking()
                .ToListAsync();

            if (!showtimes.Any()) return 0m;

            decimal totalOccupancy = 0m;
            foreach (var s in showtimes)
            {
                var totalSeats = s.Hall.Seats.Count;
                var bookedSeats = s.Bookings.SelectMany(b => b.BookingSeats).Count();
                if (totalSeats > 0)
                    totalOccupancy += (decimal)bookedSeats / totalSeats * 100m;
            }

            return totalOccupancy / showtimes.Count;
        }

        public async Task<Dictionary<string, int>> GetCinemaLocationStats()
        {
            return await _dbSet
                .Where(c => c.IsActive)
                .GroupBy(c => c.City)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }

        // -------------------------
        // Validation & lifecycle
        // -------------------------
        public async Task<bool> IsCinemaNameUniqueAsync(string name, int? excludeId = null)
        {
            var q = _dbSet.Where(c => c.Name.ToLower() == name.ToLower());
            if (excludeId.HasValue) q = q.Where(c => c.Id != excludeId.Value);
            return !await q.AnyAsync();
        }

        public async Task<bool> CanDeleteCinemaAsync(int cinemaId)
        {
            var hasBookings = await _context.Bookings.AnyAsync(b => b.Showtime.Hall.CinemaId == cinemaId);
            var hasActiveShowtimes = await HasActiveShowtimesAsync(cinemaId);
            return !hasBookings && !hasActiveShowtimes;
        }

        public async Task<bool> HasActiveShowtimesAsync(int cinemaId)
        {
            return await _context.Showtimes.AnyAsync(s => s.Hall.CinemaId == cinemaId && s.StartTime > DateTime.UtcNow);
        }

        public async Task<bool> HasHallsAsync(int cinemaId)
        {
            return await _context.Halls.AnyAsync(h => h.CinemaId == cinemaId);
        }

        // -------------------------
        // Popular & admin
        // -------------------------
        public async Task<IEnumerable<Cinema>> GetPopularCinemasAsync(int count = 5)
        {
            // Efficient DB-side aggregation: count bookings by cinema, order desc
            var q = from b in _context.Bookings
                    where b.Status == BookingStatus.Confirmed
                    group b by b.Showtime.Hall.CinemaId into g
                    join c in _dbSet.AsNoTracking() on g.Key equals c.Id
                    orderby g.Count() descending
                    select new { Cinema = c, Count = g.Count() };

            var list = await q.Take(count).ToListAsync();
            return list.Select(x => x.Cinema);
        }

        public async Task<IEnumerable<Cinema>> GetCinemasForAdminAsync()
        {
            return await _dbSet
                .Include(c => c.Halls)
                .OrderByDescending(c => c.CreatedDate)
                .AsNoTracking()
                .ToListAsync();
        }

        // -------------------------
        // Overrides for add/update/delete safe checks
        // -------------------------
        public override async Task<Cinema> AddAsync(Cinema entity)
        {
            if (!await IsCinemaNameUniqueAsync(entity.Name))
                throw new InvalidOperationException($"Cinema with name '{entity.Name}' already exists.");

            entity.IsActive = true;
            return await base.AddAsync(entity);
        }

        public override async Task<Cinema> UpdateAsync(Cinema entity)
        {
            if (!await IsCinemaNameUniqueAsync(entity.Name, entity.Id))
                throw new InvalidOperationException($"Cinema with name '{entity.Name}' already exists.");

            return await base.UpdateAsync(entity);
        }

        public override async Task DeleteAsync(int id)
        {
            if (!await CanDeleteCinemaAsync(id))
                throw new InvalidOperationException("Cannot delete cinema that has bookings or active showtimes.");

            await base.DeleteAsync(id);
        }

        public override async Task DeleteAsync(Cinema entity)
        {
            if (!await CanDeleteCinemaAsync(entity.Id))
                throw new InvalidOperationException("Cannot delete cinema that has bookings or active showtimes.");

            await base.DeleteAsync(entity);
        }

        // -------------------------
        // Utilities
        // -------------------------
        public async Task<IEnumerable<Cinema>> GetCinemasForDropdownAsync()
        {
            return await _dbSet
                .Where(c => c.IsActive)
                .Select(c => new Cinema { Id = c.Id, Name = c.Name, City = c.City })
                .OrderBy(c => c.City).ThenBy(c => c.Name)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> ToggleCinemaStatusAsync(int cinemaId)
        {
            var cinema = await _dbSet.FindAsync(cinemaId);
            if (cinema == null) return false;

            cinema.IsActive = !cinema.IsActive;
            cinema.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<string>> GetUniqueCitiesAsync()
        {
            return await _dbSet
                .Where(c => c.IsActive)
                .Select(c => c.City)
                .Distinct()
                .OrderBy(city => city)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetUniqueStatesAsync()
        {
            return await _dbSet
                .Where(c => c.IsActive)
                .Select(c => c.State)
                .Distinct()
                .OrderBy(state => state)
                .ToListAsync();
        }

        // -------------------------
        // Distance helper (Haversine)
        // -------------------------
        private static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371; // Earth's radius in km
            var dLat = ToRadians(lat2 - lat1);
            var dLon = ToRadians(lon2 - lon1);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }

        private static double ToRadians(double degrees) => degrees * Math.PI / 180.0;
    }
}
