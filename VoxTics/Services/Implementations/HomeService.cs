using VoxTics.Data.UoW;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{
    public class HomeService : IHomeService
    {
        private readonly IUnitOfWork _uow;
        public HomeService(IUnitOfWork uow) => _uow = uow;

        public Task<IEnumerable<Movie>> GetNowShowingAsync() => _uow.Home.GetNowShowingAsync();
        public Task<IEnumerable<Movie>> GetComingSoonAsync() => _uow.Home.GetComingSoonAsync();
        public Task<IEnumerable<Cinema>> GetCinemasAsync() => _uow.Home.GetCinemasAsync();
    }
}
