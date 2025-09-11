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
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        IQueryable<Movie> QueryWithIncludes(bool asNoTracking = true);
        Task<Movie?> GetByIdWithDetailsAsync(int id);
        Task<PaginatedList<Movie>> GetPagedAsync(MovieFilterVM filter);
    }
}
