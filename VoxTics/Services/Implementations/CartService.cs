using Microsoft.EntityFrameworkCore;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels.Cart;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services
{
    public class CartService : ICartService
    {
        private readonly MovieDbContext _context;

        public CartService(MovieDbContext context)
        {
            _context = context;
        }

        // -----------------------------
        // Retrieve or create a cart
        // -----------------------------
        public async Task<CartVM> GetCartAsync(string userId)
        {
            var cart = await _context.Carts
                .Include(c => c.CartItems).ThenInclude(ci => ci.Showtime)
                .FirstOrDefaultAsync(c => c.UserId == userId)
                ?? await CreateCartAsync(userId);

            return new CartVM
            {
                Items = cart.CartItems.Select(ci => new CartItemVM
                {
                    CartItemId = ci.Id,
                    Showtime = ci.Showtime.StartTime.ToString("g"),
                    SeatLabels = ci.SeatLabels?.Split(',').ToList() ?? new(),
                }).ToList(),
                TotalPrice = cart.TotalAmount
            };
        }

        private async Task<Cart> CreateCartAsync(string userId)
        {
            var cart = new Cart { UserId = userId };
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        // -----------------------------
        // Add tickets to the cart
        // -----------------------------
        public async Task<bool> AddTicketsAsync(string userId, int movieId, int showtimeId, List<int> seatIds)
        {
            var movie = await _context.Movies.Include(m => m.Showtimes)
                                             .FirstOrDefaultAsync(m => m.Id == movieId);
            var showtime = await _context.Showtimes.FirstOrDefaultAsync(s => s.Id == showtimeId);
            if (movie == null || showtime == null) return false;

            // Validate seat availability
            var seatLabels = await _context.Seats
                .Where(s => seatIds.Contains(s.Id) && s.HallId == showtime.HallId && s.IsAvailable)
                .Select(s => s.SeatNumber)
                .ToListAsync();

            if (seatLabels.Count != seatIds.Count) return false;

            // Reserve seats
            var seatsToReserve = await _context.Seats.Where(s => seatIds.Contains(s.Id)).ToListAsync();
            foreach (var seat in seatsToReserve) seat.IsAvailable = false;

            var cart = await _context.Carts.Include(c => c.CartItems)
                                           .FirstOrDefaultAsync(c => c.UserId == userId)
                       ?? await CreateCartAsync(userId);

            var cartItem = new CartItem
            {
                CartId = cart.Id,
                ShowtimeId = showtimeId,
                Quantity = seatLabels.Count,

            };

            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();
            return true;
        }

        // -----------------------------
        // Remove an item
        // -----------------------------
        public async Task RemoveItemAsync(string userId, int cartItemId)
        {
            var item = await _context.CartItems
                .Include(ci => ci.Cart)
                .FirstOrDefaultAsync(ci => ci.Id == cartItemId && ci.Cart.UserId == userId);

            if (item == null) return;

            // Free reserved seats
            var seatLabels = item.SeatLabels.Split(',');
            var seats = await _context.Seats
                .Where(s => seatLabels.Contains(s.SeatNumber) && s.HallId == item.Showtime.HallId)
                .ToListAsync();
            foreach (var seat in seats) seat.IsAvailable = true;

            _context.CartItems.Remove(item);
            await _context.SaveChangesAsync();
        }

        // -----------------------------
        // Clear the cart
        // -----------------------------
        public async Task ClearCartAsync(string userId)
        {
            var cart = await _context.Carts.Include(c => c.CartItems)
                                           .ThenInclude(ci => ci.Showtime)
                                           .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null) return;

            foreach (var ci in cart.CartItems)
            {
                var seatLabels = ci.SeatLabels.Split(',');
                var seats = await _context.Seats
                    .Where(s => seatLabels.Contains(s.SeatNumber) && s.HallId == ci.Showtime.HallId)
                    .ToListAsync();
                foreach (var seat in seats) seat.IsAvailable = true;
            }

            _context.CartItems.RemoveRange(cart.CartItems);
            await _context.SaveChangesAsync();
        }

        // -----------------------------
        // Checkout details
        // -----------------------------
        public async Task<CheckoutVM> GetCheckoutDetailsAsync(string userId)
        {
            var cart = await _context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Showtime)
                                           .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null || !cart.CartItems.Any())
                return new CheckoutVM { UserId = userId };

            var items = cart.CartItems.Select(ci => new CheckoutItemVM
            {
        
                ShowtimeId = ci.ShowtimeId,
                Showtime = ci.Showtime.StartTime,
                SeatLabels = ci.SeatLabels.Split(',').ToList(),
            }).ToList();

            var subtotal = items.Sum(i => i.TotalPrice);

            return new CheckoutVM
            {
                UserId = userId,
                Items = items,
                Subtotal = subtotal,
                DiscountAmount = 0,
                TaxAmount = 0,
                FinalTotal = subtotal
            };
        }

        // -----------------------------
        // Place booking
        // -----------------------------
        public async Task<int> PlaceBookingAsync(string userId)
        {
            var cart = await _context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Showtime)
                                           .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null || !cart.CartItems.Any()) return 0;

            var booking = new Booking
            {
                UserId = userId,

                BookingDate = DateTime.UtcNow,
                TotalAmount = cart.TotalAmount
            };
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            foreach (var ci in cart.CartItems)
            {
                var seatLabels = ci.SeatLabels.Split(',');
                foreach (var label in seatLabels)
                {
                    var seat = await _context.Seats
                        .FirstOrDefaultAsync(s => s.SeatNumber == label && s.HallId == ci.Showtime.HallId);

                    if (seat != null)
                    {
                        _context.BookingSeats.Add(new BookingSeat
                        {
                            BookingId = booking.Id,
                            SeatId = seat.Id,
                        });
                    }
                }
            }

            _context.CartItems.RemoveRange(cart.CartItems);
            await _context.SaveChangesAsync();
            return booking.Id;
        }
        public async Task<bool> IncreaseQuantityAsync(string userId, int cartItemId, int quantity)
        {
            var cartItem = await _context.CartItems
                .Include(ci => ci.Cart)
                .Include(ci => ci.Showtime)
                .FirstOrDefaultAsync(ci => ci.Id == cartItemId && ci.Cart.UserId == userId);

            if (cartItem == null) return false;

            // Check if seats are available
            var availableSeats = await _context.Seats
                .Where(s => s.HallId == cartItem.Showtime.HallId && s.IsAvailable)
                .Take(quantity)
                .ToListAsync();

            if (availableSeats.Count < quantity) return false;

            // Reserve seats and add to cart item
            foreach (var seat in availableSeats) seat.IsAvailable = false;
            cartItem.Quantity += quantity;

            _context.CartItems.Update(cartItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DecreaseQuantityAsync(string userId, int cartItemId, int quantity)
        {
            var cartItem = await _context.CartItems
                .Include(ci => ci.Cart)
                .Include(ci => ci.Showtime)
                .FirstOrDefaultAsync(ci => ci.Id == cartItemId && ci.Cart.UserId == userId);

            if (cartItem == null || cartItem.Quantity < quantity) return false;

            // Release seats
            var seatLabels = cartItem.SeatLabels.Split(',').ToList();
            var seatsToRelease = seatLabels.TakeLast(quantity).ToList();

            var seats = await _context.Seats
                .Where(s => seatsToRelease.Contains(s.SeatNumber) && s.HallId == cartItem.Showtime.HallId)
                .ToListAsync();

            foreach (var seat in seats) seat.IsAvailable = true;

            // Update cart item
            cartItem.Quantity -= quantity;

            _context.CartItems.Update(cartItem);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
