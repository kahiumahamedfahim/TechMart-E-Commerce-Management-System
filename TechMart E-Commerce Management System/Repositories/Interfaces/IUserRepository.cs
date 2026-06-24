using TechMart_E_Commerce_Management_System.Data.Entities;
using TechMart_E_Commerce_Management_System.Data.Enums;

namespace TechMart_E_Commerce_Management_System.Repositories.Interfaces
{
    public interface IUserRepository
        : IGenericeRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByUserIdAsync(string userId);
        Task<bool> EmailExistsAsync(string email);
        Task<bool> AnySuperAdminExistsAsync();

        Task<int> GetRoleCountAsync(Role role);
    }
}
