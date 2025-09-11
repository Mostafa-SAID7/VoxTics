using VoxTics.Data.UoW;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{
    public class ShowtimeService : IShowtimeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShowtimeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Showtime>> GetAllAsync() =>
            await _unitOfWork.Showtimes.GetAllAsync();

        public async Task<Showtime?> GetByIdAsync(int id) =>
            await _unitOfWork.Showtimes.GetByIdAsync(id);

        public async Task<IEnumerable<Showtime>> GetByMovieAsync(int movieId) =>
            await _unitOfWork.Showtimes.GetShowtimesForMovieAsync(movieId);

        public async Task<IEnumerable<Showtime>> GetByCinemaAsync(int cinemaId) =>
            await _unitOfWork.Showtimes.GetShowtimesByCinemaAsync(cinemaId);

        public async Task CreateAsync(Showtime showtime)
        {
            await _unitOfWork.Showtimes.AddAsync(showtime);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(Showtime showtime)
        {
            _unitOfWork.Showtimes.Update(showtime);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var showtime = await _unitOfWork.Showtimes.GetByIdAsync(id);
            if (showtime != null)
            {
                _unitOfWork.Showtimes.Remove(showtime);
                await _unitOfWork.CompleteAsync();
            }
        }
    }

}
