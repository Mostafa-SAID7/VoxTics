using VoxTics.Models.Entities;

namespace VoxTics.Repositories.IRepositories
{
    public interface IMoviesRepository : IBaseRepository<Movie>
    {
      

        // Optional: Movie-specific queries
        Task<Movie?> GetBySlugAsync(string slug);
    }
}
