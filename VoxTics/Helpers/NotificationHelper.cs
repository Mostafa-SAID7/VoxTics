using System.Threading.Tasks;

namespace VoxTics.Helpers
{
    public static class NotificationHelper
    {
        public static Task SendBookingConfirmationAsync(string email, string message)
        {
            // Integrate with email service here
            Console.WriteLine($"Sending confirmation to {email}: {message}");
            return Task.CompletedTask;
        }

        public static Task SendCancellationNotificationAsync(string email, string message)
        {
            Console.WriteLine($"Sending cancellation to {email}: {message}");
            return Task.CompletedTask;
        }
    }
}
