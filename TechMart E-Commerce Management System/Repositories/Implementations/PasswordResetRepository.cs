using Microsoft.EntityFrameworkCore;
using TechMart_E_Commerce_Management_System.Data;
using TechMart_E_Commerce_Management_System.Data.Entities.User;
using TechMart_E_Commerce_Management_System.Repositories.Interfaces;

namespace TechMart_E_Commerce_Management_System.Repositories.Implementations
{
    public class PasswordResetRepository
        : GenericRepository<PasswordResetCode>
        , IPasswordResetRepository

    {
        public PasswordResetRepository(AppDbcontext
            context) : base(context)
        {

        }

        public async Task<PasswordResetCode?> GetLatestCodeAsync(Guid userId)
        {
            var result =
                  await _dbSet.Where(x => x.UserId == userId).
                  OrderByDescending(x => x.ExpiryTime)
                  .FirstOrDefaultAsync();
            return result;
        }

        public async Task<PasswordResetCode?> GetValidCodeAsync(Guid userId, string resetCode)
        {
            var result =
              await _dbSet.FirstOrDefaultAsync(x => x.UserId == userId

                 && x.ResetCode == resetCode && !x.IsUsed &&
                 x.ExpiryTime > DateTime.UtcNow);

            return result;





        }
    }
}
