namespace VoxTics.Services.Interfaces
{
    public interface IHomeService
    {
        Task<IEnumerable<Movie>> GetNowShowingAsync();
        Task<IEnumerable<Movie>> GetComingSoonAsync();
        Task<IEnumerable<Cinema>> GetCinemasAsync();
        Task<IEnumerable<Movie>> GetFeaturedMoviesAsync();
    }
}
