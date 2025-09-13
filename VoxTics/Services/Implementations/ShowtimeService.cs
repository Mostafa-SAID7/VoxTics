using VoxTics.Data.UoW;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{
    public class ShowtimeService : IShowtimeService
    {
        private readonly IUnitOfWork _uow;
        public ShowtimeService(IUnitOfWork uow) => _uow = uow;

        public async Task<IEnumerable<Showtime>> GetAllAsync() => await _uow.Showtimes.GetAllAsync();
        public async Task<IEnumerable<Showtime>> GetWithDetailsAsync() => await _uow.Showtimes.GetWithDetailsAsync();
        public async Task<Showtime?> GetByIdAsync(int id) => await _uow.Showtimes.GetByIdAsync(id);
        public async Task<Showtime?> GetWithMovieAsync(int id) => await _uow.Showtimes.GetWithMovieAsync(id);

        public async Task CreateAsync(Showtime showtime)
        {
            await _uow.Showtimes.AddAsync(showtime);
            await _uow.SaveAsync();
        }

        public async Task UpdateAsync(Showtime showtime)
        {
            _uow.Showtimes.Update(showtime);
            await _uow.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var showtime = await _uow.Showtimes.GetByIdAsync(id);
            if (showtime == null) return;
            _uow.Showtimes.DeleteAsync(showtime);
            await _uow.SaveAsync();
        }
    }
}
