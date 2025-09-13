using VoxTics.Data.UoW;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{
    public class CinemaService : ICinemaService
    {
        private readonly IUnitOfWork _uow;
        public CinemaService(IUnitOfWork uow) => _uow = uow;

        public async Task<IEnumerable<Cinema>> GetAllAsync() => await _uow.Cinemas.GetAllAsync();
        public async Task<Cinema?> GetByIdAsync(int id) => await _uow.Cinemas.GetByIdAsync(id);
        public async Task<Cinema?> GetByNameAsync(string name) => await _uow.Cinemas.GetByNameAsync(name);

        public async Task CreateAsync(Cinema cinema)
        {
            await _uow.Cinemas.AddAsync(cinema);
            await _uow.SaveAsync();
        }

        public async Task UpdateAsync(Cinema cinema)
        {
            _uow.Cinemas.Update(cinema);
            await _uow.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cinema = await _uow.Cinemas.GetByIdAsync(id);
            if (cinema == null) return;
            _uow.Cinemas.DeleteAsync(cinema);
            await _uow.SaveAsync();
        }
    }

}
