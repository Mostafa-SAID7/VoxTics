namespace VoxTics.Services.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<IEnumerable<Booking>> GetBookingsByUserAsync(string userId); // ✅ updated for Identity
        Task<Booking?> GetBookingByIdAsync(int id);
        Task CreateBookingAsync(Booking booking, string userId);          // ✅ pass userId on creation
        Task UpdateBookingAsync(Booking booking, string userId);          // ✅ ensure ownership check
        Task DeleteBookingAsync(int id, string userId);                   // ✅ ensure ownership check
    }


}
