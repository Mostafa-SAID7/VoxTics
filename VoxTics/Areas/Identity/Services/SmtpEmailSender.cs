using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace VoxTics.Areas.Identity.Services
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly SmtpOptions _options;

        public SmtpEmailSender(IOptions<SmtpOptions> options)
        {
            _options = options.Value;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Basic SMTP using System.Net.Mail.SmtpClient (not recommended for heavy / async workloads).
            // For production use MailKit or a dedicated provider.
            using var client = new SmtpClient(_options.Host, _options.Port)
            {
                EnableSsl = _options.EnableSsl,
                Credentials = new NetworkCredential(_options.Username, _options.Password)
            };

            var mail = new MailMessage
            {
                From = new MailAddress(_options.From),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };
            mail.To.Add(email);

            // SmtpClient.SendMailAsync exists; wrap in Task.
            return client.SendMailAsync(mail);
        }
    }
}
