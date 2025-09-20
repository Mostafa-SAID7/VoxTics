using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly MovieDbContext _context;

        public PaymentService(MovieDbContext context)
        {
            _context = context;
        }

        // Create a payment record
        public async Task<Payment> CreatePaymentAsync(int bookingId, string userId, decimal amount, PaymentMethod method)
        {
            var payment = new Payment
            {
                BookingId = bookingId,
                UserId = userId,
                Amount = amount,
                Method = method,
                Status = PaymentStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        // Confirm payment after transaction
        public async Task<bool> ConfirmPaymentAsync(int paymentId, string transactionId)
        {
            var payment = await _context.Payments.FirstOrDefaultAsync(p => p.Id == paymentId);
            if (payment == null) return false;

            payment.Status = PaymentStatus.Completed;
            payment.TransactionId = transactionId;
            payment.PaidAt = DateTime.UtcNow;

            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
            return true;
        }

        // Get payment by ID
        public async Task<Payment?> GetPaymentByIdAsync(int paymentId)
        {
            return await _context.Payments
                .Include(p => p.Booking)
                .ThenInclude(b => b.BookingSeats)
                .FirstOrDefaultAsync(p => p.Id == paymentId);
        }

        // Get all payments for a user
        public async Task<IEnumerable<Payment>> GetUserPaymentsAsync(string userId)
        {
            return await _context.Payments
                .Include(p => p.Booking)
                .Where(p => p.UserId == userId && !p.IsDeleted)
                .ToListAsync();
        }
    }
 }
