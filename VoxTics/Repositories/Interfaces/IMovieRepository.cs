using System.Linq;
using VoxTics.Models.Entities;

namespace VoxTics.Repositories.Interfaces
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        /// <summary>
        /// Return an IQueryable<Movie> allowing further filtering; includes navigation properties according to includeProperties CSV.
        /// </summary>
        IQueryable<Movie> Query(string includeProperties = "");

        /// <summary>
        /// Return all movies including related navigation properties.
        /// </summary>
        Task<List<Movie>> GetAllWithIncludesAsync();

        /// <summary>
        /// Return a movie by id including related navigation properties.
        /// </summary>
        Task<Movie?> GetByIdWithIncludesAsync(int id);
    }
}
