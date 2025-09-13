using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Data;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums.Sorting;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Repositories
{
    public class BookingsRepository : BaseRepository<Booking>, IBookingsRepository
    {
        private readonly MovieDbContext _context;
        public BookingsRepository(MovieDbContext context) : base(context) => _context = context;

        public async Task<IEnumerable<Booking>> GetAllWithDetailsAsync()
        {
            return await _context.Bookings
                .Include(b => b.Showtime)
                .Include(b => b.Movie)
                .Include(b => b.User)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Booking?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Bookings
                .Include(b => b.Showtime)
                .Include(b => b.Movie)
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }

}
