using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Models.ViewModels.Cart;
using VoxTics.Services.Interfaces;

namespace VoxTics.Controllers
{
    [Authorize]
    public class CartsController : Controller
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();

            var cart = await _cartService.GetCartAsync(userId);
            return View(cart); // View: Views/Carts/Index.cshtml
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int movieId, int showtimeId, List<int> seatIds)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();

            var success = await _cartService.AddTicketsAsync(userId, movieId, showtimeId, seatIds);
            if (!success)
            {
                TempData["Error"] = "Some selected seats are no longer available.";
                return RedirectToAction("Details", "Showtimes", new { id = showtimeId });
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int cartItemId)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();

            await _cartService.RemoveItemAsync(userId, cartItemId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Clear()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();

            await _cartService.ClearCartAsync(userId);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Checkout()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();

            var checkoutVm = await _cartService.GetCheckoutDetailsAsync(userId);
            return View(checkoutVm); // View: Views/Carts/Checkout.cshtml
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceBooking()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();

            var bookingId = await _cartService.PlaceBookingAsync(userId);
            if (bookingId == 0)
            {
                TempData["Error"] = "Failed to place booking. Your cart may be empty or seats unavailable.";
                return RedirectToAction(nameof(Index));
            }

            TempData["Success"] = "Booking placed successfully!";
            return RedirectToAction("Details", "Bookings", new { id = bookingId });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Increase(int cartItemId, int quantity = 1)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;
            await _cartService.IncreaseQuantityAsync(userId, cartItemId, quantity);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Decrease(int cartItemId, int quantity = 1)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;
            await _cartService.DecreaseQuantityAsync(userId, cartItemId, quantity);
            return RedirectToAction(nameof(Index));
        }
    }
}
