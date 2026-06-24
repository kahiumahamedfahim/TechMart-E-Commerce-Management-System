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

        public Task<ServiceResult> CreateAdminAsyn(CreateAdminViewModel model)
        {
            throw new NotImplementedException();
        }
        //public async Task<ServiceResult> CreateAdminAsyn(CreateAdminViewModel model)
        //{
        //    try
        //    {
        //        var email =
        //            model.Email.Trim().ToLower();
        //        var existingUser =
        //            await _userRepo.GetByEmailAsync(email);
        //        if (existingUser != null)
        //        {
        //            return ServiceResult.Failue(
        //                "Email is already exists");
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
    }
}
