using VoxTics.Services.Interfaces;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Services.Implementations
{
    public class HomeService : IHomeService
    {
        private readonly IHomeRepository _homeRepository;

        public HomeService(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public Task<IEnumerable<Movie>> GetNowShowingAsync() => _homeRepository.GetNowShowingAsync();
        public Task<IEnumerable<Movie>> GetComingSoonAsync() => _homeRepository.GetComingSoonAsync();
        public Task<IEnumerable<Cinema>> GetCinemasAsync() => _homeRepository.GetCinemasAsync();
        public Task<IEnumerable<Movie>> GetFeaturedMoviesAsync() => _homeRepository.GetFeaturedMoviesAsync();
    }
}
