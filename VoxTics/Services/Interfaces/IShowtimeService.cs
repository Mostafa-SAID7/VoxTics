namespace VoxTics.Services.Interfaces
{
    public interface IShowtimeService
    {
        Task<IEnumerable<Showtime>> GetAllAsync();
        Task<IEnumerable<Showtime>> GetWithDetailsAsync();
        Task<Showtime?> GetByIdAsync(int id);
        Task<Showtime?> GetWithMovieAsync(int id);
        Task CreateAsync(Showtime showtime);
        Task UpdateAsync(Showtime showtime);
        Task DeleteAsync(int id);
    }

}
