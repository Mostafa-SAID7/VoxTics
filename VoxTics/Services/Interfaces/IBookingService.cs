namespace VoxTics.Services.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<Booking?> GetByIdAsync(int id);
        Task CreateAsync(Booking booking);
        Task UpdateAsync(Booking booking);
        Task DeleteAsync(int id);
        Task UpdateStatusAsync(int id, BookingStatus status);
        Task CancelAsync(int id, string reason);
    }


}
