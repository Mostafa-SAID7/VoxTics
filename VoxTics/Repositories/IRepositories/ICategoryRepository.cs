using System.Collections.Generic;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories;

namespace VoxTics.Repositories.IRepositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        // Get category by slug (SEO friendly)
        Task<Category?> GetBySlugAsync(string slug);

        // Get a category with its movies (full details)
        Task<Category?> GetCategoryWithMoviesAsync(int categoryId);

        // Search categories by name/description/slug
        Task<IEnumerable<Category>> SearchAsync(string term);

        // Get categories with their movie counts (for admin dashboard)
        Task<IEnumerable<(Category category, int movieCount)>> GetAllWithMovieCountsAsync();

        // Paging with total count (safe paging)
        Task<(IEnumerable<Category> categories, int totalCount)> GetPagedAsync(BasePaginatedFilterVM filter);
        Task<IEnumerable<Category>> GetByParentIdAsync(int parentId);

        // Top categories by number of movies
        Task<IEnumerable<(Category category, int movieCount)>> GetTopCategoriesByMoviesAsync(int count = 10);
    }
}
