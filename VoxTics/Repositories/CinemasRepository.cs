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
    }

}
