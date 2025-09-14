using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Data;               // MovieDbContext
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;
using VoxTics.Models.Enums.Sorting;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Repositories
{
    public class CinemasRepository : BaseRepository<Cinema>, ICinemasRepository
    {
        public CinemasRepository(MovieDbContext context) : base(context) { }

        public async Task<Cinema?> GetByNameAsync(string name)
        {
            return await _context.Cinemas
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
        }
        public async Task<Cinema?> GetCinemaWithDetailsAsync(int id)
        {
            return await _context.Cinemas.AsNoTracking()
                .Include(c => c.Halls)
                .Include(c => c.Showtimes)
                .Include(c => c.SocialMediaLinks)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Cinema>> GetAllWithDetailsAsync()
        {
            return await _context.Cinemas
                .Include(c => c.Halls)
                .Include(c => c.Showtimes)
                .Include(c => c.SocialMediaLinks)
                .ToListAsync();
        }
    }

}
