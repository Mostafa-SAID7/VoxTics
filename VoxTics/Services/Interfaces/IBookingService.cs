using System.Collections.Generic;
using System.Threading.Tasks;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Models.ViewModels.Booking;

namespace VoxTics.Services.Interfaces
{
    public interface IBookingService
    {

        Task<IEnumerable<BookingVM>> GetAllAsync();

        Task<BookingVM?> GetByIdAsync(int id);

        Task CreateAsync(BookingCreateVM createVM);

        Task UpdateAsync(BookingVM bookingVM);

        Task DeleteAsync(int id);

        Task UpdateStatusAsync(int id, BookingStatus status);

    
        Task CancelAsync(int id, string reason);
        Task UpdateAsync(Booking booking);
    }
}
