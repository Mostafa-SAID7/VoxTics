using VoxTics.Areas.Identity.Models.Entities;

namespace VoxTics.Repositories.IRepositories
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Movie>> GetNowShowingAsync();
        Task<IEnumerable<Movie>> GetComingSoonAsync();
        Task<IEnumerable<Cinema>> GetCinemasAsync();
        Task<IEnumerable<Movie>> GetFeaturedMoviesAsync();
    }
}
