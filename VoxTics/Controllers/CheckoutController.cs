using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Services.Interfaces;

namespace VoxTics.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IPaymentService _paymentService;

        public CheckoutController(ICartService cartService, IPaymentService paymentService)
        {
            _cartService = cartService;
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;
            var checkoutVm = await _cartService.GetCheckoutDetailsAsync(userId);
            return View(checkoutVm);
        }
        public async Task<IActionResult> Checkout()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;
            var checkoutVm = await _cartService.GetCheckoutDetailsAsync(userId);

            if (checkoutVm.Items == null || !checkoutVm.Items.Any())
            {
                TempData["Error"] = "Your cart is empty!";
                return RedirectToAction("Index", "Carts");
            }

            return View(checkoutVm); // Views/Payment/Checkout.cshtml
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Process(PaymentMethod method)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;

            // Place booking first
            var bookingId = await _cartService.PlaceBookingAsync(userId);
            if (bookingId == 0)
            {
                TempData["Error"] = "Failed to place booking. Please try again.";
                return RedirectToAction("Checkout");
            }

            // Get total from the cart/checkout
            var checkoutVm = await _cartService.GetCheckoutDetailsAsync(userId);

            // Create payment record
            var payment = await _paymentService.CreatePaymentAsync(
                bookingId,
                userId,
                checkoutVm.FinalTotal,
                method
            );

            // Redirect to payment gateway page (simulated here)
            TempData["Success"] = "Booking created. Complete payment to confirm.";
            return RedirectToAction("Details", new { id = payment.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Pay(PaymentMethod method)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;
            var bookingId = await _cartService.PlaceBookingAsync(userId);

            if (bookingId == 0)
            {
                TempData["Error"] = "Booking failed, please try again.";
                return RedirectToAction("Index");
            }

            var checkoutVm = await _cartService.GetCheckoutDetailsAsync(userId);
            var payment = await _paymentService.CreatePaymentAsync(bookingId, userId, checkoutVm.FinalTotal, method);

            TempData["Success"] = "Booking placed. Complete payment to confirm.";
            return RedirectToAction("Details", "Bookings", new { id = bookingId });
        }
        public async Task<IActionResult> Details(int id)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;
            var payment = await _paymentService.GetPaymentByIdAsync(id);

            if (payment == null || payment.UserId != userId)
                return NotFound();

            return View(payment); // Views/Payment/Details.cshtml
        }

        // -----------------------------
        // POST: /Payment/Confirm/5
        // Confirm payment after gateway success
        // -----------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Confirm(int paymentId, string transactionId)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;
            var payment = await _paymentService.GetPaymentByIdAsync(paymentId);

            if (payment == null || payment.UserId != userId)
                return NotFound();

            var success = await _paymentService.ConfirmPaymentAsync(paymentId, transactionId);

            TempData["Success"] = success ? "Payment completed successfully!" : "Payment failed.";
            return RedirectToAction("Details", new { id = paymentId });
        }

        // -----------------------------
        // GET: /Payment/UserPayments
        // List all payments for the logged-in user
        // -----------------------------
        public async Task<IActionResult> UserPayments()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;
            var payments = await _paymentService.GetUserPaymentsAsync(userId);
            return View(payments); // Views/Payment/UserPayments.cshtml
        }
    }

}
