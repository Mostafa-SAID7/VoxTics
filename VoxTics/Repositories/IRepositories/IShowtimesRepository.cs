using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories;

namespace VoxTics.Repositories.IRepositories
{
    public interface IShowtimesRepository : IBaseRepository<Showtime>
    {
        Task<IEnumerable<Showtime>> GetWithDetailsAsync();
        Task<Showtime?> GetWithMovieAsync(int id);
    }

}
