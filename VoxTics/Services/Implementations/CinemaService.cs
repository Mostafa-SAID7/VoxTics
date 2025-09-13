using VoxTics.Data.UoW;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{
    public class CinemaService : ICinemaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CinemaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Cinema>> GetAllAsync() =>
            await _unitOfWork.Cinemas.GetAllAsync();

        public async Task<Cinema?> GetByIdAsync(int id) =>
            await _unitOfWork.Cinemas.GetByIdAsync(id);

        public async Task<IEnumerable<Cinema>> GetByCityAsync(string city) =>
            await _unitOfWork.Cinemas.GetCinemasByCityAsync(city);

        public async Task CreateAsync(Cinema cinema)
        {
            await _unitOfWork.Cinemas.AddAsync(cinema);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(Cinema cinema)
        {
            _unitOfWork.Cinemas.Update(cinema);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cinema = await _unitOfWork.Cinemas.GetByIdAsync(id);
            if (cinema != null)
            {
                _unitOfWork.Cinemas.DeleteAsync(cinema);
                await _unitOfWork.CompleteAsync();
            }
        }
    }

}
