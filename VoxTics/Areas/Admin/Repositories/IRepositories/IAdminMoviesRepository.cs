using VoxTics.Repositories.IRepositories;

namespace VoxTics.Areas.Admin.Repositories.IRepositories
{
    public interface IAdminMoviesRepository : IBaseRepository<Movie>
    {
        Task<(IEnumerable<Movie> Movies, int TotalCount)> GetPagedMoviesAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            CancellationToken cancellationToken = default);

        Task<(int Total, int Active, int Upcoming)> GetMovieStatsAsync(CancellationToken cancellationToken = default);

        Task<bool> FeatureMovieAsync(int movieId, CancellationToken cancellationToken = default);

        Task<bool> ToggleMovieVisibilityAsync(int movieId, bool isVisible, CancellationToken cancellationToken = default);
    }
}
