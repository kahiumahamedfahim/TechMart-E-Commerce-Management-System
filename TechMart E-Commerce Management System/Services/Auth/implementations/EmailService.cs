using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using TechMart_E_Commerce_Management_System.Services.Auth.interfaces;
using TechMart_E_Commerce_Management_System.Services.Email;

namespace TechMart_E_Commerce_Management_System.Services.Auth.implementations
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly ILogger<EmailService> _logger;
        public EmailService(
            IOptions<EmailSettings> options,
            ILogger<EmailService> logger)
        {
            _emailSettings = options.Value;
            _logger = logger;

        }
        public async Task SendEmailAsync(string toEmail,
            string subject,
            string body)
        {
            try
            {
                using var smtpClient =
                    new SmtpClient(
                    _emailSettings.Host,
                    _emailSettings.Port);
                smtpClient.Credentials =
                     new NetworkCredential(
                         _emailSettings.SenderEmail,
                         _emailSettings.Password);
                smtpClient.EnableSsl = true;

                var mailMessage =
                    new MailMessage
                    {
                        From = new MailAddress(_emailSettings.SenderEmail,
                        _emailSettings.SenderName),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true
                    };
                mailMessage.To.Add(toEmail);
                await smtpClient.SendMailAsync(mailMessage);

                _logger.LogInformation(
                    "Email sent successfully to {Email}",
                    toEmail);

            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Failed to send email to {Email}",
                    toEmail);

                throw;
            }
        }
    }
}
