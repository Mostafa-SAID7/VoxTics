namespace VoxTics.Services.Interfaces
{
    public interface ICinemaService
    {
        Task<IEnumerable<Cinema>> GetAllAsync();
        Task<Cinema?> GetByIdAsync(int id);
        Task<Cinema?> GetByNameAsync(string name);
        Task CreateAsync(Cinema cinema);
        Task UpdateAsync(Cinema cinema);
        Task DeleteAsync(int id);
    }

}
