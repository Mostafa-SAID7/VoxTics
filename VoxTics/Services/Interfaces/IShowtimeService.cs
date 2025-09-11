namespace VoxTics.Services.Interfaces
{
    public interface IShowtimeService
    {
        Task<IEnumerable<Showtime>> GetAllAsync();
        Task<Showtime?> GetByIdAsync(int id);
        Task<IEnumerable<Showtime>> GetByMovieAsync(int movieId);
        Task<IEnumerable<Showtime>> GetByCinemaAsync(int cinemaId);
        Task CreateAsync(Showtime showtime);
        Task UpdateAsync(Showtime showtime);
        Task DeleteAsync(int id);
    }

}
