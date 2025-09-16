using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoxTics.Models.Entities;
using VoxTics.Data;
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

        public async Task<IEnumerable<Movie>> GetNowShowingAsync()
        {
            var now = DateTime.UtcNow;

            return await _context.Movies
                .Include(m => m.Showtimes).ThenInclude(s => s.Cinema)
                .Where(m => m.Showtimes.Any(s => !s.IsCancelled && s.StartTime <= now))
                .OrderByDescending(m => m.Showtimes.Min(s => s.StartTime))
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetComingSoonAsync()
        {
            var now = DateTime.UtcNow;

            return await _context.Movies
                .Include(m => m.Showtimes).ThenInclude(s => s.Cinema)
                .Where(m => m.Showtimes.Any(s => !s.IsCancelled && s.StartTime > now))
                .OrderBy(m => m.Showtimes.Min(s => s.StartTime))
                .ToListAsync();
        }

        public async Task<IEnumerable<Cinema>> GetCinemasAsync()
        {
            return await _context.Cinemas
                .Include(c => c.Halls)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetFeaturedMoviesAsync()
        {
            return await _context.Movies
                .Include(m => m.Showtimes)
                .Include(m => m.MovieImages)
                .OrderByDescending(m => m.Bookings.Count)
                .Take(10)
                .ToListAsync();
        }
    }
}
