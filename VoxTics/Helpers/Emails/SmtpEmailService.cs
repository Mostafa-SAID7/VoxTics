namespace VoxTics.Helpers.Emails
{
    public class SmtpEmailService : IEmailService
    {
        public Task SendBookingConfirmationAsync(string to, string userName, string movieTitle, DateTime showTimeUtc, string seatNumbers, decimal totalAmount)
        {
            throw new NotImplementedException();
        }

        public Task SendEmailAsync(string to, string subject, string htmlContent)
        {
            // Replace with real SMTP or provider integration.
            Console.WriteLine($"[Email] To:{to} Subject:{subject}");
            return Task.CompletedTask;
        }

        public Task SendPasswordResetAsync(string to, string resetLink)
        {
            throw new NotImplementedException();
        }

        public Task SendWelcomeEmailAsync(string to, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
