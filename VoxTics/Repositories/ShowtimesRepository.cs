using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoxTics.Data;                // MovieDbContext
using VoxTics.Models.Entities;
using VoxTics.Models.Enums.Sorting;
using VoxTics.Models.Enums.TimeRange;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Repositories
{
    public class ShowtimesRepository : BaseRepository<Showtime>, IShowtimesRepository
    {
        public ShowtimesRepository(MovieDbContext context) : base(context) { }

        public async Task<IEnumerable<Showtime>> GetShowtimesForMovieAsync(int movieId)
        {
            return await _context.Showtimes
                .Where(s => s.MovieId == movieId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Showtime>> GetShowtimesByCinemaAsync(int cinemaId)
        {
            return await _context.Showtimes
                .Where(s => s.CinemaId == cinemaId)
                .ToListAsync();
        }
    }

}
