using TechMart_E_Commerce_Management_System.Data.Enums;
using TechMart_E_Commerce_Management_System.Repositories.Interfaces;
using TechMart_E_Commerce_Management_System.Services.Admin.Interfaces;
using TechMart_E_Commerce_Management_System.Services.Auth.interfaces;
using TechMart_E_Commerce_Management_System.Services.Common;
using TechMart_E_Commerce_Management_System.ViewModels;

namespace TechMart_E_Commerce_Management_System.Services.Admin.Implementation
{

    public class AdminService : IAdminService
    {
        private readonly IUserRepository _userRepo;
        private readonly IEmailVerificationRepository _emailVerification;
        private readonly IEmailService _emailService;
        private readonly ILogger<AdminService> _logger;
        public AdminService(IUserRepository userRepo,
            IEmailVerificationRepository emailVerify,
            IEmailService emailService,
            ILogger<AdminService> logger
            )
        {
            _userRepo = userRepo;
            _emailVerification = emailVerify;
            _emailService = emailService;
            _logger = logger;


        }

        public async Task<List<AdminListViewModel>> GetAdminsAsync(
          string? search = null)
        {
            try
            {
                var admins =
                    await _userRepo.GetAdminsAsync(search);

                var adminList =
                    admins.Select(x => new AdminListViewModel
                    {
                        Id = x.Id,

                        UserId = x.UserId ?? string.Empty,

                        Name = x.Name ?? string.Empty,

                        Email = x.Email ?? string.Empty,

                        IsEmailVerified = x.IsEmailVerified,

                        IsActive = x.IsActive,

                        CreatedAt = x.CreatedAt

                    }).ToList();

                return adminList;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error while getting admin list.");

                return new List<AdminListViewModel>();
            }
        }
        public async Task<ServiceResult> ToggleAdminStatusAsync(Guid id)
        {
            try
            {
                var admin =
                    await _userRepo.GetByIdAsync(id);

                if (admin == null)
                {
                    return ServiceResult.Failue("Admin not found.");
                }

                if (admin.Role != Role.Admin)
                {
                    return ServiceResult.Failue("Invalid admin.");
                }

                admin.IsActive = !admin.IsActive;

                admin.UpdatedAt = DateTime.UtcNow;

                _userRepo.Update(admin);

                await _userRepo.SaveChangeAsync();

                return ServiceResult.Success(
                    admin.IsActive
                        ? "Admin enabled successfully."
                        : "Admin disabled successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error while changing admin status.");

                return ServiceResult.Failue(
                    "Something went wrong.");
            }
        }
    }
}
