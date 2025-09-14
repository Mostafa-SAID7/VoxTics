using VoxTics.Areas.Identity.Models.Entities;

namespace VoxTics.Repositories.IRepositories
{
    /// <summary>
    /// Repository interface for the public home page and browsing features.
    /// Provides trending movies, featured content, and recommendations.
    /// </summary>
    public interface IHomeRepository
    {
        #region Featured & Trending Content

        /// <summary>
        /// Gets featured movies for the home page slider/banner.
        /// </summary>
        Task<IEnumerable<Movie>> GetFeaturedMoviesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets trending movies based on recent bookings or ratings.
        /// </summary>
        Task<IEnumerable<Movie>> GetTrendingMoviesAsync(int count = 5,
                                                        CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets upcoming movies (future releases).
        /// </summary>
        Task<IEnumerable<Movie>> GetUpcomingMoviesAsync(DateTime fromDate, int count = 10,
                                                        CancellationToken cancellationToken = default);

        #endregion

        #region Personalized Suggestions

        /// <summary>
        /// Gets personalized recommendations for a user based on their history or preferences.
        /// </summary>
        Task<IEnumerable<Movie>> GetRecommendedMoviesForUserAsync(
            string userId, int count = 5, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a list of categories with top movies in each for browsing.
        /// </summary>
        Task<IDictionary<Category, IEnumerable<Movie>>>
            GetCategoriesWithTopMoviesAsync(int topPerCategory = 5,
                                            CancellationToken cancellationToken = default);

        #endregion

        #region Search & Discovery

        /// <summary>
        /// Searches movies by title, description, or category.
        /// </summary>
        Task<IEnumerable<Movie>> SearchMoviesAsync(
            string searchTerm, int maxResults = 20,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
