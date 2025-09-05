using VoxTics.Models.Entities;

namespace VoxTics.Repositories.Interfaces
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        // You can extend with booking-specific queries later, for now BaseRepository covers CRUD
    }
}
