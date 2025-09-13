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
    public interface IMoviesRepository : IBaseRepository<Movie>
    {
        Task<Movie?> GetByTitleAsync(string title);
        Task<IEnumerable<Movie>> GetWithCategoriesAsync();
    }

}
