namespace VoxTics.Repositories.IRepositories
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Movie>> GetNowShowingMoviesAsync(int count);
        Task<IEnumerable<Movie>> GetUpcomingMoviesAsync(int count);
    }
}
