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

        public async Task<IEnumerable<Showtime>> GetWithDetailsAsync()
        {
            return await _context.Showtimes
                .Include(s => s.Movie)
                .Include(s => s.Cinema)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Showtime?> GetWithMovieAsync(int id)
        {
            return await _context.Showtimes
                .Include(s => s.Movie)
                .Include(s => s.Cinema)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }

}
