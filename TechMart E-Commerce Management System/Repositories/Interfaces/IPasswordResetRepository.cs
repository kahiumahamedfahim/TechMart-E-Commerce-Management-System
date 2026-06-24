using TechMart_E_Commerce_Management_System.Data.Entities;

namespace TechMart_E_Commerce_Management_System.Repositories.Interfaces
{
    public interface IPasswordResetRepository :
        IGenericeRepository<PasswordResetCode>
    {
        Task<PasswordResetCode?> GetValidCodeAsync(Guid userId, string resetCode);
        Task<PasswordResetCode?> GetLatestCodeAsync(Guid userId);
    }
}
