namespace VoxTics.Services.Implementations
{
    public class HallService : IHallService
    {
        private readonly IBaseRepository<Hall> _hallRepository;

        public HallService(IBaseRepository<Hall> hallRepository)
        {
            _hallRepository = hallRepository;
        }

        public async Task<IEnumerable<Hall>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _hallRepository.GetAllAsync(cancellationToken);
        }

        public async Task<Hall?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _hallRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task AddHallAsync(Hall hall, CancellationToken cancellationToken = default)
        {
            await _hallRepository.AddAsync(hall, cancellationToken);
            await _hallRepository.CommitAsync();
        }

        public async Task UpdateHallAsync(Hall hall, CancellationToken cancellationToken = default)
        {
            await _hallRepository.UpdateAsync(hall, cancellationToken);
            await _hallRepository.CommitAsync();
        }

        public async Task RemoveHallAsync(int id, CancellationToken cancellationToken = default)
        {
            var hall = await _hallRepository.GetByIdAsync(id, cancellationToken);
            if (hall != null)
            {
                await _hallRepository.RemoveAsync(hall, cancellationToken);
                await _hallRepository.CommitAsync();
            }
        }

        public async Task<bool> HallExistsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _hallRepository.AnyAsync(h => h.Id == id, cancellationToken);
        }
    }
}
