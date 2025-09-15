using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace VoxTics.Helpers
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string htmlContent);
        Task SendBookingConfirmationAsync(string to, string userName, string movieTitle, DateTime showTimeUtc, string seatNumbers, decimal totalAmount);
        Task SendPasswordResetAsync(string to, string resetLink);
        Task SendWelcomeEmailAsync(string to, string userName);
    }

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public virtual async Task SendEmailAsync(string to, string subject, string body)
        {
            // Placeholder: integrate SMTP, SendGrid, etc.
            await Task.CompletedTask;
        }

        private string FormatHtml(string content)
        {
            return $"<div style='font-family: Arial, sans-serif; line-height: 1.4;'>{content}</div>";
        }

        public async Task SendBookingConfirmationAsync(string to, string userName, string movieTitle, DateTime showTimeUtc, string seatNumbers, decimal totalAmount)
        {
            var subject = "Booking Confirmation - Cinema Booking System";
            var bodyContent = $@"
                <h2>Booking Confirmation</h2>
                <p>Dear {userName},</p>
                <p>Your booking has been confirmed!</p>
                <div style='background-color: #f5f5f5; padding: 15px; margin: 10px 0;'>
                    <h3>Booking Details:</h3>
                    <p><strong>Movie:</strong> {movieTitle}</p>
                    <p><strong>Show Time (UTC):</strong> {showTimeUtc:MMM dd, yyyy HH:mm} UTC</p>
                    <p><strong>Seats:</strong> {seatNumbers}</p>
                    <p><strong>Total Amount:</strong> ${totalAmount:F2}</p>
                </div>
                <p>Please arrive at the cinema at least 15 minutes before the show time.</p>
                <p>Thank you for choosing our cinema!</p>";

            await SendEmailAsync(to, subject, FormatHtml(bodyContent));
        }

        public async Task SendPasswordResetAsync(string to, string resetLink)
        {
            var subject = "Password Reset - Cinema Booking System";
            var bodyContent = $@"
                <h2>Password Reset</h2>
                <p>You requested a password reset. Click the link below to reset your password:</p>
                <p><a href='{resetLink}' style='background-color: #007bff; color: white; padding: 10px 15px; text-decoration: none; border-radius: 5px;'>Reset Password</a></p>
                <p>If you didn't request this, please ignore this email.</p>
                <p>This link will expire in 24 hours.</p>";

            await SendEmailAsync(to, subject, FormatHtml(bodyContent));
        }

        public async Task SendWelcomeEmailAsync(string to, string userName)
        {
            var subject = "Welcome to Cinema Booking System";
            var bodyContent = $@"
                <h2>Welcome to Our Cinema!</h2>
                <p>Dear {userName},</p>
                <p>Thank you for registering with our cinema booking system.</p>
                <p>You can now browse movies, check showtimes, and book tickets online.</p>
                <p>Enjoy the movies!</p>";

            await SendEmailAsync(to, subject, FormatHtml(bodyContent));
        }
    }
}
