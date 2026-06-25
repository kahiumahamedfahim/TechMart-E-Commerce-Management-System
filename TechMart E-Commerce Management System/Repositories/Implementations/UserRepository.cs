using Microsoft.EntityFrameworkCore;
using TechMart_E_Commerce_Management_System.Data;
using TechMart_E_Commerce_Management_System.Data.Entities;
using TechMart_E_Commerce_Management_System.Data.Enums;
using TechMart_E_Commerce_Management_System.Repositories.Interfaces;

namespace TechMart_E_Commerce_Management_System.Repositories.Implementations
{
    public class UserRepository
        : GenericRepository<User>
        , IUserRepository
    {
        public UserRepository(AppDbcontext context)
            : base(context)
        {

        }

        public async Task<bool> AnySuperAdminExistsAsync()
        {
            var result =
                 await _dbSet.AnyAsync(x => x.Role == Role.SuperAdmin);
            return result;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            var result =
                await _dbSet.AnyAsync(x => x.Email == email);
            return result;
        }

        public async Task<List<User>> GetAdminsAsync(
     string? search)
        {
            var query =
                _dbSet.Where(x => x.Role == Role.Admin);

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                query = query.Where(x =>
                    x.Name!.Contains(search) ||
                    x.Email!.Contains(search) ||
                    x.UserId!.Contains(search));
            }

            return await query
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)

        {
            var result =
                 await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
            return result;
        }

        public async Task<User?> GetByUserIdAsync(string userId)
        {
            var result =
                  await _dbSet.FirstOrDefaultAsync(x => x.UserId == userId);
            return result;


        }

        public async Task<int> GetRoleCountAsync(Role role)
        {
            var result =
                 await _dbSet.CountAsync(x => x.Role == role);
            return result;
        }
    }
}
