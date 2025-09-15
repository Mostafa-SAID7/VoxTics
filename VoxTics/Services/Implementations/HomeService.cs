using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Data;
using VoxTics.Models.Entities;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{
    public class HomeService : IHomeService
    {
        private readonly MovieDbContext _context;

        public HomeService(MovieDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Movies that are currently showing (start time <= now and not cancelled)
        /// </summary>
        public async Task<IEnumerable<Movie>> GetNowShowingAsync()
        {
            var now = DateTime.UtcNow;

            return await _context.Movies
                .Include(m => m.Showtimes)
                    .ThenInclude(s => s.Cinema)
                .Where(m => m.Showtimes.Any(s => !s.IsCancelled && s.StartTime <= now))
                .OrderByDescending(m => m.Showtimes.Min(s => s.StartTime)) // soonest first
                .ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Movies that will be released in the future (start time > now)
        /// </summary>
        public async Task<IEnumerable<Movie>> GetComingSoonAsync()
        {
            var now = DateTime.UtcNow;

            return await _context.Movies
                .Include(m => m.Showtimes)
                    .ThenInclude(s => s.Cinema)
                .Where(m => m.Showtimes.Any(s => !s.IsCancelled && s.StartTime > now))
                .OrderBy(m => m.Showtimes.Min(s => s.StartTime)) // earliest upcoming
                .ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// List of cinemas
        /// </summary>
        public async Task<IEnumerable<Cinema>> GetCinemasAsync()
        {
            return await _context.Cinemas
                .Include(c => c.Halls)
                .OrderBy(c => c.Name)
                .ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Featured movies (example: top rated or top booked)
        /// Here we use number of bookings as a simple metric
        /// </summary>
        public async Task<IEnumerable<Movie>> GetFeaturedMoviesAsync()
        {
            return await _context.Movies
                .Include(m => m.Showtimes)
                .Include(m => m.MovieImages)
                .OrderByDescending(m => m.Bookings.Count) // most booked first
                .Take(10)
                .ToListAsync().ConfigureAwait(false);
        }
    }
}
