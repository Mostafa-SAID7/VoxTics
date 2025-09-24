namespace VoxTics.Services.Interfaces
{
    public interface IHallService
    {
        Task<IEnumerable<Hall>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<Hall?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task AddHallAsync(Hall hall, CancellationToken cancellationToken = default);

        Task UpdateHallAsync(Hall hall, CancellationToken cancellationToken = default);

        Task RemoveHallAsync(int id, CancellationToken cancellationToken = default);

        Task<bool> HallExistsAsync(int id, CancellationToken cancellationToken = default);
    }
}
