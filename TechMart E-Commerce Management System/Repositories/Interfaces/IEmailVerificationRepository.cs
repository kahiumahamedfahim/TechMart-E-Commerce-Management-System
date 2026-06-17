using TechMart_E_Commerce_Management_System.Data.Entities.User;

namespace TechMart_E_Commerce_Management_System.Repositories.Interfaces
{
    public interface IEmailVerificationRepository
        : IGenericeRepository<EmailVerification>
    {
        Task<EmailVerification?> GetLatestCodeAsync(Guid userId);
        Task<EmailVerification?> GetValidCodeAsync(Guid userId,
            string code);
    }
}
