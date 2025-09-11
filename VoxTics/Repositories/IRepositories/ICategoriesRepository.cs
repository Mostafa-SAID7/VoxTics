using System.Collections.Generic;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories;

namespace VoxTics.Repositories.IRepositories
{
    public interface ICategoriesRepository : IBaseRepository<Category>
    {
        Task<Category?> GetCategoryWithMoviesAsync(int categoryId);
    }

}
