namespace VoxTics.Services.Interfaces
{
    public interface ICinemaService
    {
        Task<IEnumerable<Cinema>> GetAllAsync();
        Task<Cinema?> GetByIdAsync(int id);
        Task<IEnumerable<Cinema>> GetByCityAsync(string city);
        Task CreateAsync(Cinema cinema);
        Task UpdateAsync(Cinema cinema);
        Task DeleteAsync(int id);
    }

}
