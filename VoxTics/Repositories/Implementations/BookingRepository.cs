using VoxTics.Data;
using VoxTics.Models.Entities;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Repositories.Implementations
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(MovieDbContext context) : base(context)
        {
        }

        // Example of a booking-specific method
        // Get all bookings for a given user with movie + cinema details
        public IQueryable<Booking> GetUserBookings(int userId)
        {
            return Query("Showtime.Movie,Showtime.Cinema,User")
                .Where(b => b.UserId == userId);
        }
    }
}
