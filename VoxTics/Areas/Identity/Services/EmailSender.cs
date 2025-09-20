using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace VoxTics.Areas.Identity.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(IConfiguration config, ILogger<EmailSender> logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var host = _config["Email:Smtp:Host"] ?? "smtp.gmail.com";
            var port = int.TryParse(_config["Email:Smtp:Port"], out var p) ? p : 587;
            var user = _config["Email:Smtp:User"];
            var pass = _config["Email:Smtp:Pass"];
            var from = _config["Email:From"] ?? user;

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                _logger.LogError("Email credentials are not configured (Email:Smtp:User or Email:Smtp:Pass).");
                throw new InvalidOperationException("SMTP credentials are not configured.");
            }

            using var client = new SmtpClient(host, port)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(user, pass)
            };

            var message = new MailMessage(from, email, subject, htmlMessage)
            {
                IsBodyHtml = true
            };

            try
            {
                await client.SendMailAsync(message).ConfigureAwait(false);
                _logger.LogInformation("Email sent to {Email} (subject: {Subject})", email, subject);
            }
            catch (SmtpException ex)
            {
                _logger.LogError(ex, "Failed to send email to {Email}", email);
                throw; // or swallow depending on your app policy
            }
        }
    }
}
