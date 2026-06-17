namespace TechMart_E_Commerce_Management_System.Services.Auth.interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail,
            string subject,
            string body);
    }
}
