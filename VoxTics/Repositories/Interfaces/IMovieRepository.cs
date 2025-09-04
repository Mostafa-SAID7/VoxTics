using VoxTics.Models.Entities;

namespace VoxTics.Repositories.Interfaces
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetAllWithIncludesAsync();
        Task<Movie?> GetByIdWithIncludesAsync(int id);
    }
}
