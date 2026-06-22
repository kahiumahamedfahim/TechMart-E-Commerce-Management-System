using TechMart_E_Commerce_Management_System.Repositories.Interfaces;
using TechMart_E_Commerce_Management_System.Services.Common;
using TechMart_E_Commerce_Management_System.Services.File.Interfaces;
using TechMart_E_Commerce_Management_System.Services.Profile.interfaces;
using TechMart_E_Commerce_Management_System.ViewModels;

namespace TechMart_E_Commerce_Management_System.Services.Profile.implementations
{
    public class ProfileService : IProfileService
    {
        private readonly IUserRepository _userRepo;
        private readonly ILogger<ProfileService> _logger;
        private readonly IFileService _fileService;
        public ProfileService(IUserRepository userRepository,
            ILogger<ProfileService> logger
            , IFileService fileService)
        {
            _userRepo = userRepository;
            _logger = logger;
            _fileService = fileService;
        }

        public async Task<string?> GetCurrentProfileImageAsync(Guid userId)
        {
            var user =
                await _userRepo.GetByIdAsync(userId);
            return user?.ProfileImage;
        }

        public async Task<EditProfileViewModel> GetEditProfileAsync(Guid userId)
        {
            var user =
                await _userRepo.GetByIdAsync(userId);
            if (user == null)
            {
                return null;
            }
            var profile =
                new EditProfileViewModel
                {
                    Name = user.Name ?? string.Empty,
                    CurrentProfileImage = user.ProfileImage
                };
            return profile;

        }

        public async Task<ProfileViewModel> GetProfileAsync(Guid userId)
        {
            var user =
                await _userRepo.GetByIdAsync(userId);
            if (user == null)
            {
                return null;
            }
            var profileViewModel =
                new ProfileViewModel
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    Email = user.Email,
                    ProfileImage = user.ProfileImage,
                    Role = user.Role.ToString(),
                    CreatedAt = user.CreatedAt,
                };
            return profileViewModel;
        }

        public async Task<ServiceResult> UpdateProfileAsync(Guid userId,
            EditProfileViewModel model)
        {
            try
            {
                var user =
                    await _userRepo.GetByIdAsync(userId);
                if (user == null)
                {
                    return ServiceResult
                        .Failue("User not found!");
                }
                user.Name = model.Name.Trim();
                user.UpdatedAt = DateTime.UtcNow;
                if (model.ProfileImage != null)
                {
                    var uploadResult =
                        await _fileService.UploadImageAsync(
                            model.ProfileImage, "users",
                            FileConstants.ImageExtensions,
                            FileConstants.ProductImageMaxSize);
                    if (!uploadResult.IsSuccess)
                    {
                        return ServiceResult.Failue
                            (uploadResult.ErrorMessage);

                    }
                    user.ProfileImage = uploadResult.FilePath;
                }
                _userRepo.Update(user);
                await _userRepo.SaveChangeAsync();
                return ServiceResult.Success(
                    "Profile updated Sucessfully!");


            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Profile updated Failed!");
                return ServiceResult.Failue("An unexpected error " +
                    "occurred!");
            }
        }
    }
}
