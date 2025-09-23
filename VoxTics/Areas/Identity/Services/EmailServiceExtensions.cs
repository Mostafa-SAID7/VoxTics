using Microsoft.CodeAnalysis.Emit;

namespace VoxTics.Areas.Identity.Services
{
    public static class EmailServiceExtensions
    {
        public static Task<EmailResult> SendAsync(
            this IEmailService service,
            string email, string subject, string message, object? templateData = null) =>
            service.SendEmailAsync(email, subject, message, templateData);
        public static Task<EmailResult> SendEmailAsync(
            this IEmailService service,
            string email, string subject, string message, object? templateData)
        {
            // Optionally process templateData here
            return (Task<EmailResult>)service.SendEmailAsync(email, subject, message);
        }
    }

}
