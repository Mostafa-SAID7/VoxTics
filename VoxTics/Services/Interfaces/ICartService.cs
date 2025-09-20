using VoxTics.Models.ViewModels.Cart;

namespace VoxTics.Services.Interfaces
{
    public interface ICartService
    {
        Task<CartVM> GetCartAsync(string userId);
        Task<bool> AddTicketsAsync(string userId, int movieId, int showtimeId, List<int> seatIds);
        Task RemoveItemAsync(string userId, int cartItemId);
        Task ClearCartAsync(string userId);
        Task<CheckoutVM> GetCheckoutDetailsAsync(string userId);
        Task<int> PlaceBookingAsync(string userId);
        // New methods
        Task<bool> IncreaseQuantityAsync(string userId, int cartItemId, int quantity);
        Task<bool> DecreaseQuantityAsync(string userId, int cartItemId, int quantity);
    }
}
