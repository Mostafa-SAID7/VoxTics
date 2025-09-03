using VoxTics.Models.Entities;

namespace VoxTics.Repositories.Interfaces
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        // add movie-specific methods here if you need (e.g. Task<IEnumerable<Movie>> GetNowShowingAsync();)
    }
}
