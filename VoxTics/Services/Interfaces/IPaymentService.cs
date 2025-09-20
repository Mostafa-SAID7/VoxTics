namespace VoxTics.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<Payment> CreatePaymentAsync(int bookingId, string userId, decimal amount, PaymentMethod method);
        Task<bool> ConfirmPaymentAsync(int paymentId, string transactionId);
        Task<Payment?> GetPaymentByIdAsync(int paymentId);
        Task<IEnumerable<Payment>> GetUserPaymentsAsync(string userId);
    }
}
