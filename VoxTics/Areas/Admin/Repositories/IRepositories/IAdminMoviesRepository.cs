using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Models.Entities;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Areas.Admin.Repositories.IRepositories
{
    public interface IAdminMoviesRepository : IBaseRepository<Movie>
    {
        IQueryable<Movie> GetMoviesWithCategory();
        Task<Movie?> GetMovieWithDetailsAsync(int id);
        Task<IEnumerable<Movie>> GetAllWithCategoryAsync();
        Task<bool> MovieExistsBySlugAsync(string slug, int? excludeId = null);
    }
}
