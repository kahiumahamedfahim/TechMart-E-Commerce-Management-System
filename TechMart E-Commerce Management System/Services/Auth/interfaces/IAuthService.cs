using TechMart_E_Commerce_Management_System.Data.Entities.User;
using TechMart_E_Commerce_Management_System.Services.Common;
using TechMart_E_Commerce_Management_System.ViewModels;

namespace TechMart_E_Commerce_Management_System.Services.Auth.interfaces
{
    public interface IAuthService
    {
        Task<ServiceResult> RegisterAsync(RegisterVIewModel model);

        Task<ServiceResult> VerifyEmailAsync(string email,
    string verificationCode);
        Task<ServiceResult> ResendVerificationCodeAsync(ResendOtpViewModels model);
        Task<User?> ValidateUserAsync(LoginViewModel model);
    }
}
