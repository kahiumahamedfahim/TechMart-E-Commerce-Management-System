using Microsoft.EntityFrameworkCore;
using TechMart_E_Commerce_Management_System.Data;
using TechMart_E_Commerce_Management_System.Data.Entities;
using TechMart_E_Commerce_Management_System.Repositories.Interfaces;

namespace TechMart_E_Commerce_Management_System.Repositories.Implementations
{
    public class EmailVerificationRepository :
        GenericRepository<EmailVerification>
        , IEmailVerificationRepository
    {
        public EmailVerificationRepository(AppDbcontext context)
            : base(context)
        {

        }

        public async Task<EmailVerification?> GetLatestCodeAsync(Guid userId)
        {
            var result =
                await _dbSet
               .Where(e => e.UserId == userId)
               .OrderByDescending(x => x.ExpiryTime)
               .FirstOrDefaultAsync();
            return result;

        }

        public async Task<EmailVerification?> GetValidCodeAsync(Guid userId, string code)
        {
            var result =
                await
                _dbSet.FirstOrDefaultAsync(x => x.UserId == userId
                && x.VerificationCode == code &&
                !x.IsUsed &&
                x.ExpiryTime > DateTime.UtcNow);
            return result;

        }
    }
}
