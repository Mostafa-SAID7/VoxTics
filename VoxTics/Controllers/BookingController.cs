using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VoxTics.Areas.Admin.ViewModels; // BookingViewModel (for admin usages) - optional
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.IRepositories; // BookingVM

namespace VoxTics.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IShowtimeRepository _showtimeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BookingController> _logger;

        public BookingController(
            IBookingRepository bookingRepository,
            IShowtimeRepository showtimeRepository,
            IUserRepository userRepository,
            IMapper mapper,
            ILogger<BookingController> logger)
        {
            _bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
            _showtimeRepository = showtimeRepository ?? throw new ArgumentNullException(nameof(showtimeRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper;
            _logger = logger;
        }

        // Helper to extract current user id (int). Returns null if not found or not an int.
        private int? CurrentUserId()
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrWhiteSpace(idClaim)) return null;
            return int.TryParse(idClaim, out var id) ? id : (int?)null;
        }

        // GET: /Booking
        public async Task<IActionResult> Index()
        {
            var userId = CurrentUserId();
            if (!userId.HasValue) return RedirectToAction("Login", "Account", new { area = "" });

            try
            {
                var bookings = await _bookingRepository.GetUserBookingsAsync(userId.Value);

                var vms = bookings.Select(b => MapToBookingVM(b)).ToList();

                return View(vms);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading bookings for user {UserId}", userId);
                TempData["Error"] = "Unable to load your bookings at this time.";
                return View(new List<BookingVM>());
            }
        }

        // GET: /Booking/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var userId = CurrentUserId();
            if (!userId.HasValue) return RedirectToAction("Login", "Account");

            try
            {
                var booking = await _bookingRepository.GetBookingWithDetailsAsync(id);
                if (booking == null) return NotFound();

                // Ensure user can view (owner or admin) - assuming you have role check, otherwise only owner:
                if (booking.UserId != userId.Value && !User.IsInRole("Admin"))
                    return Forbid();

                var vm = MapToBookingVM(booking);
                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading booking details for id {BookingId}", id);
                TempData["Error"] = "Unable to load booking details.";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: /Booking/Create?showtimeId=123
        // Shows simple checkout page with showtime details and available seats
        public async Task<IActionResult> Create(int showtimeId)
        {
            var userId = CurrentUserId();
            if (!userId.HasValue) return RedirectToAction("Login", "Account");

            var showtime = await _showtimeRepository.GetShowtimeWithDetailsAsync(showtimeId);
            if (showtime == null) return NotFound();

            var availableSeats = await _bookingRepository.GetAvailableSeatsAsync(showtimeId);

            // Prepare a minimal viewmodel (you can create a dedicated VM for checkout; here we reuse BookingVM partially)
            var vm = new BookingVM
            {
                ShowtimeId = showtime.Id,
                ShowtimeStart = showtime.StartTime,
                MovieTitle = showtime.Movie?.Title ?? string.Empty,
                MoviePoster = showtime.Movie?.ImageUrl,
                CinemaName = showtime.Hall?.Cinema?.Name ?? string.Empty,
                HallName = showtime.Hall?.Name ?? string.Empty,
                // SeatNumbers left empty; front-end will post selected seats ids/numbers
            };

            ViewData["AvailableSeats"] = availableSeats.Select(s => new { s.Id, Number = SeatToString(s) }).ToList();

            return View(vm);
        }

        // POST: /Booking/Create
        // body: showtimeId, selectedSeatIds[], paymentMethod (optional)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBooking(int showtimeId, List<int> selectedSeatIds, string? paymentMethod)
        {
            var userId = CurrentUserId();
            if (!userId.HasValue) return Json(new { success = false, message = "Not authenticated" });

            if (selectedSeatIds == null || !selectedSeatIds.Any())
                return Json(new { success = false, message = "No seats selected" });

            try
            {
                // check seat availability
                var areAvailable = await _bookingRepository.AreSeatsAvailableAsync(showtimeId, selectedSeatIds);
                if (!areAvailable)
                    return Json(new { success = false, message = "One or more selected seats are no longer available" });

                // load showtime
                var showtime = await _showtimeRepository.GetShowtimeWithDetailsAsync(showtimeId);
                if (showtime == null) return Json(new { success = false, message = "Showtime not found" });

                // compute price (simple base price * seats). Customize if you have per-seat pricing, discounts, etc.
                // Use showtime.Price if available, otherwise fallback to movie.BasePrice
                var seatCount = selectedSeatIds.Count;
                var pricePerSeat = showtime.Price > 0 ? showtime.Price : (showtime.Movie?.Price ?? 0m);
                var totalPrice = pricePerSeat * seatCount;

                // create booking entity
                var booking = new Booking
                {
                    BookingNumber = await _bookingRepository.GenerateBookingNumberAsync(),
                    UserId = userId.Value,
                    ShowtimeId = showtimeId,
                    NumberOfTickets = seatCount,
                    BookingDate = DateTime.UtcNow,
                    TotalAmount = totalPrice,
                    DiscountAmount = 0m, // apply discount logic if any
                    FinalAmount = totalPrice,
                    Status = Models.Enums.BookingStatus.Pending,
                    PaymentStatus = Models.Enums.PaymentStatus.Pending,
                    TransactionId = null,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                // add booking seats
                booking.BookingSeats = selectedSeatIds.Select(sid => new BookingSeat
                {
                    SeatId = sid,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }).ToList();

                // persist
                var added = await _bookingRepository.AddAsync(booking);
                await _bookingRepository.SaveChangesAsync();

                // return success and booking id for redirect/payment
                return Json(new { success = true, bookingId = added.Id, bookingNumber = added.BookingNumber });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating booking for user {UserId} showtime {ShowtimeId}", userId, showtimeId);
                return Json(new { success = false, message = "Error creating booking" });
            }
        }

        // POST: /Booking/Cancel/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            var userId = CurrentUserId();
            if (!userId.HasValue) return Json(new { success = false, message = "Not authenticated" });

            try
            {
                var booking = await _bookingRepository.GetByIdWithIncludesAsync(id, b => b.Showtime);
                if (booking == null) return Json(new { success = false, message = "Booking not found" });

                // Only owner or admin can cancel
                if (booking.UserId != userId.Value && !User.IsInRole("Admin"))
                    return Json(new { success = false, message = "Not allowed to cancel this booking" });

                var ok = await _bookingRepository.CancelBookingAsync(id);
                if (!ok) return Json(new { success = false, message = "Cannot cancel this booking" });

                return Json(new { success = true, message = "Booking cancelled" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error cancelling booking {BookingId}", id);
                return Json(new { success = false, message = "Error cancelling booking" });
            }
        }

        // POST: /Booking/MarkPaymentCompleted
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkPaymentCompleted(int bookingId, string paymentReference)
        {
            var userId = CurrentUserId();
            if (!userId.HasValue) return Json(new { success = false, message = "Not authenticated" });

            try
            {
                var booking = await _bookingRepository.GetByIdAsync(bookingId);
                if (booking == null) return Json(new { success = false, message = "Booking not found" });

                if (booking.UserId != userId.Value && !User.IsInRole("Admin"))
                    return Json(new { success = false, message = "Not authorized" });

                var ok = await _bookingRepository.MarkPaymentCompletedAsync(bookingId, paymentReference);
                if (!ok) return Json(new { success = false, message = "Error marking payment complete" });

                return Json(new { success = true, message = "Payment recorded" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error marking payment completed for booking {BookingId}", bookingId);
                return Json(new { success = false, message = "Error recording payment" });
            }
        }

        // GET: /Booking/AvailableSeatsJson?showtimeId=123
        [AllowAnonymous]
        public async Task<IActionResult> AvailableSeatsJson(int showtimeId)
        {
            try
            {
                var seats = await _bookingRepository.GetAvailableSeatsAsync(showtimeId);
                var mapped = seats.Select(s => new
                {
                    id = s.Id,
                    number = SeatToString(s),
                    row = s.RowNumber,
                    seatNumber = s.SeatNumber
                });
                return Json(new { success = true, seats = mapped });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching available seats for showtime {ShowtimeId}", showtimeId);
                return Json(new { success = false, message = "Error fetching seats" });
            }
        }

        // Utility: maps Booking entity -> BookingVM
        private BookingVM MapToBookingVM(Booking booking)
        {
            if (booking == null) return new BookingVM();

            var seatNumbers = (booking.BookingSeats ?? Enumerable.Empty<BookingSeat>())
                .Select(bs => bs.Seat != null ? SeatToString(bs.Seat) : bs.SeatId.ToString())
                .ToList();

            var vm = new BookingVM
            {
                Id = booking.Id,
                BookingNumber = booking.BookingNumber,
                SeatNumbers = seatNumbers,
                TotalPrice = booking.TotalAmount,
                DiscountAmount = booking.DiscountAmount,
                Status = booking.Status,
                PaymentStatus = booking.PaymentStatus,
                PaymentMethod = booking.PaymentMethod,
                CanBeCancelled = booking.CanBeCancelled,
                BookingDate = booking.BookingDate,
                PaymentDate = booking.PaymentDate,
                MovieTitle = booking.Showtime?.Movie?.Title ?? string.Empty,
                MoviePoster = booking.Showtime?.Movie?.ImageUrl,
                CinemaName = booking.Showtime?.Hall?.Cinema?.Name ?? string.Empty,
                HallName = booking.Showtime?.Hall?.Name ?? string.Empty,
                ShowtimeStart = booking.Showtime?.StartTime ?? default,
                ShowtimeId = booking.ShowtimeId
            };

            return vm;
        }

        // Utility: convert seat entity to a friendly display string.
        private string SeatToString(Seat s)
        {
            if (s == null) return string.Empty;

            // Try to produce "A-12" or fallback to Id
            if (!string.IsNullOrWhiteSpace(s.SeatNumber) && !string.IsNullOrWhiteSpace(s.Row))
                return $"{s.Row}-{s.SeatNumber}";

            // fallback if you have RowNumber + SeatNumber
            try
            {
                if (s.RowNumber != null && s.SeatNumber != null)
                {
                    return $"{s.RowNumber}{s.SeatNumber}";
                }
            }
            catch { /* ignore */ }

            if (!string.IsNullOrWhiteSpace(s.SeatNumber))
                return s.SeatNumber;

            return s.Id.ToString();
        }
    }
}
