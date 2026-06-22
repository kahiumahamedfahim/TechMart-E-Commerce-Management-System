using TechMart_E_Commerce_Management_System.Services.Common;
using TechMart_E_Commerce_Management_System.ViewModels;

namespace TechMart_E_Commerce_Management_System.Services.Profile.interfaces
{
    public interface IProfileService
    {
        Task<ProfileViewModel> GetProfileAsync(Guid userId);
        Task<EditProfileViewModel> GetEditProfileAsync(Guid userId);
        Task<ServiceResult> UpdateProfileAsync(Guid userId,
            EditProfileViewModel model);
        Task<string?> GetCurrentProfileImageAsync(Guid userId);
    }
}
