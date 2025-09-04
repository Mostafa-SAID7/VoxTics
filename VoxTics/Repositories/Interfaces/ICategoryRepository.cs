using VoxTics.Models.Entities;

namespace VoxTics.Repositories.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        // category-specific methods (if any)
        Task<Category?> GetByIdWithMoviesAsync(int id);
    }
}
