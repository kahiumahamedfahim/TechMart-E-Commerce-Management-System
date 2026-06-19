using Microsoft.AspNetCore.Identity;
using TechMart_E_Commerce_Management_System.Data.Entities.Enums;
using TechMart_E_Commerce_Management_System.Data.Entities.User;
using TechMart_E_Commerce_Management_System.Repositories.Interfaces;
using TechMart_E_Commerce_Management_System.Services.Auth.interfaces;
using TechMart_E_Commerce_Management_System.Services.Common;
using TechMart_E_Commerce_Management_System.Services.File.Interfaces;
using TechMart_E_Commerce_Management_System.ViewModels;

namespace TechMart_E_Commerce_Management_System.Services.Auth.implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IEmailVerificationRepository _emailVerificationRepo;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly ILogger<AuthService> _logger;
        private readonly IEmailService _emailService;
        private readonly IFileService _fileservice;
        private readonly IPasswordResetRepository _passwordRepo;
        public AuthService(IUserRepository userRepo,
            IPasswordHasher<User> passwordHasher,
            ILogger<AuthService> logger,
            IEmailVerificationRepository emailVerificationRepository,
            IEmailService emailService,
            IFileService fileservice,
            IPasswordResetRepository passwordRepository

            )
        {
            _userRepo = userRepo;
            _passwordHasher = passwordHasher;
            _logger = logger;
            _emailVerificationRepo = emailVerificationRepository;
            _emailService = emailService;
            _fileservice = fileservice;
            _passwordRepo = passwordRepository;

        }


        public async Task<ServiceResult> RegisterAsync(
    RegisterVIewModel model)
        {
            try
            {
                var originalEmail = model.Email.Trim();

                var email = originalEmail.ToLower();

                var existingUser =
                    await _userRepo.GetByEmailAsync(email);

                if (existingUser != null)
                {
                    if (existingUser.IsEmailVerified)
                    {
                        return ServiceResult.Failue(
                            "Email already exists!");
                    }

                    var otp = GenerateOtp();

                    var verificationCode =
                        new EmailVerification
                        {
                            Id = Guid.NewGuid(),
                            UserId = existingUser.Id,
                            VerificationCode = otp,
                            ExpiryTime = DateTime.UtcNow.AddMinutes(10),
                            IsUsed = false
                        };

                    await _emailVerificationRepo.AddAsync(
                        verificationCode);

                    await _emailVerificationRepo.SaveChangeAsync();

                    await SendOtpMessageAsync(
                        originalEmail,
                        otp);

                    return ServiceResult.Success(
                        "Account exists but email is not verified. A new OTP has been generated.");
                }

                var role =
                    await _userRepo.AnySuperAdminExistsAsync()
                    ? Role.Customer
                    : Role.SuperAdmin;

                var userId =
                    await GenerateUserIdAsync(role);
                var uploadResult =
                    await _fileservice.UploadImageAsync(model.ProfileImage,
                    "users", FileConstants.ImageExtensions,
                    FileConstants.ProductImageMaxSize);
                if (!uploadResult.IsSuccess &&
                        model.ProfileImage != null)
                {
                    return ServiceResult.Failue(
                        uploadResult.ErrorMessage ??
                        "Image upload failed.");
                }

                var user = new User
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Name = model.Name.Trim(),
                    Email = email,
                    Role = role,
                    IsEmailVerified = false,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ProfileImage = uploadResult.FilePath

                };

                user.PasswordHash =
                    _passwordHasher.HashPassword(
                        user,
                        model.Password);

                await _userRepo.AddAsync(user);

                await _userRepo.SaveChangeAsync();

                var otpCode = GenerateOtp();

                var emailVerification =
                    new EmailVerification
                    {
                        Id = Guid.NewGuid(),
                        UserId = user.Id,
                        VerificationCode = otpCode,
                        ExpiryTime = DateTime.UtcNow.AddMinutes(10),
                        IsUsed = false
                    };

                await _emailVerificationRepo.AddAsync(
                    emailVerification);

                await _emailVerificationRepo.SaveChangeAsync();

                await SendOtpMessageAsync(
                    originalEmail,
                    otpCode);

                _logger.LogInformation(
                    "User registered successfully: {Email}",
                    email);

                return ServiceResult.Success(
                    "Registration successful. Please verify your email.");
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Registration Error");

                return ServiceResult.Failue(
                    "An unexpected error occurred.");
            }
        }

        public async Task<ServiceResult> ResendVerificationCodeAsync(ResendOtpViewModels model)
        {
            try
            {
                var orginalEmail = model.Email;
                var email = model.Email
                                        .Trim()
                                        .ToLower();
                var user =
                    await _userRepo.GetByEmailAsync(email);
                if (user == null)
                {
                    return ServiceResult.Failue("User not found!");
                }
                if (user.IsEmailVerified)
                {
                    return ServiceResult.Failue("Email already verified");
                }
                var otp = GenerateOtp();
                await SendOtpMessageAsync(orginalEmail, otp);

                var verification =
                    new EmailVerification
                    {
                        Id = Guid.NewGuid(),
                        UserId = user.Id,
                        VerificationCode = otp,
                        ExpiryTime = DateTime.UtcNow.AddMinutes(10),
                        IsUsed = false
                    };
                await _emailVerificationRepo.AddAsync(verification);
                await _emailVerificationRepo.SaveChangeAsync();
                return ServiceResult.Success("Verification code resent");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "OTP resend error");
                return ServiceResult.Failue("AN unexpected error occured");
            }
        }

        public async Task<ServiceResult> VerifyEmailAsync(
            string email,
            string verificationCode)
        {
            try
            {
                email = email
                    .Trim()
                    .ToLower();

                var user =
                    await _userRepo.GetByEmailAsync(email);

                if (user == null)
                {
                    return ServiceResult.Failue(
                        "User not found!");
                }

                var verification =
                    await _emailVerificationRepo
                        .GetValidCodeAsync(
                            user.Id,
                            verificationCode);

                if (verification == null)
                {
                    return ServiceResult.Failue(
                        "Invalid or Expired OTP");
                }

                verification.IsUsed = true;

                user.IsEmailVerified = true;

                user.UpdatedAt =
                    DateTime.UtcNow;

                _emailVerificationRepo.Update(
                    verification);

                _userRepo.Update(user);

                await _emailVerificationRepo
                    .SaveChangeAsync();

                return ServiceResult.Success(
                    "Email verified successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Email Verification Error");

                return ServiceResult.Failue(
                    "An unexpected error occurred.");
            }
        }

        private async Task<string> GenerateUserIdAsync(Role role)
        {
            var count = await _userRepo.GetRoleCountAsync(role);
            count++;
            switch (role)
            {
                case Role.SuperAdmin:
                    return $"SA-{count:D4}";

                case Role.Admin:
                    return $"AD-{count:D4}";

                case Role.Customer:
                    return $"CU-{count:D4}";

                default:
                    throw new ArgumentException("Invalid role");
            }
        }
        private string GenerateOtp()
        {
            return Random.Shared
                .Next(100000, 999999)
                .ToString();
        }

        public async Task<User?> ValidateUserAsync(LoginViewModel model)
        {
            try
            {
                var email = model.Email
                                        .Trim()
                                        .ToLower();
                var user =
                    await _userRepo.GetByEmailAsync(email);
                if (user == null)
                {
                    return null;
                }
                if (!user.IsEmailVerified)
                {
                    return null;
                }
                if (!user.IsActive)
                {
                    return null;
                }

                var passwordResult =
                    _passwordHasher.VerifyHashedPassword(user,
                    user.PasswordHash
                    , model.Password);
                if (passwordResult == PasswordVerificationResult.Failed)
                {
                    return null;
                }
                return user;


            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Login Validation failed fo{Email}",
                    model.Email);
                return null;
            }
        }
        private async Task SendOtpMessageAsync(
     string email,
     string otp)
        {
            await _emailService.SendEmailAsync(
                email,
                "TechMart Email Verification",
                $@"
        <h2>Welcome to TechMart</h2>

        <p>Your verification code is:</p>

        <h1>{otp}</h1>

        <p>This code will expire in 10 minutes.</p>
        ");
        }



        public async Task<ServiceResult> VerifyResetCodeAsync(string email, string resetCode)
        {
            try
            {
                email = email.Trim().ToLower();
                var user =
                    await _userRepo.GetByEmailAsync(email);
                if (user == null)
                {
                    return ServiceResult.Failue(
                        "User not found!");
                }
                var verification =
                    await _passwordRepo.GetValidCodeAsync(
                        user.Id,
                        resetCode);
                if (verification == null)
                {
                    return ServiceResult.Failue
                        ("Invalid or expired reset code.");
                }
                return ServiceResult.Success
                    ("Reset code verified successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Reset code verification error");
                return ServiceResult.Failue("An unexpected error occured");
            }
        }



        public async Task<ServiceResult> ForgetPasswordAsync(string email)
        {
            try
            {
                email = email.Trim().ToLower();
                var user =
                    await _userRepo.GetByEmailAsync(email);
                if (user == null)
                {
                    return ServiceResult.Failue(
                        "User not found");
                }
                if (!user.IsEmailVerified)
                {
                    return ServiceResult.Failue
                        ("Email is not Verified.");

                }
                var otp =
                     GenerateOtp();
                await SendOtpMessageAsync(user.Email, otp);
                var resetCode =
                    new PasswordResetCode
                    {
                        Id = Guid.NewGuid(),
                        UserId = user.Id,
                        ResetCode = otp,
                        ExpiryTime = DateTime.UtcNow.
                        AddMinutes(10),
                        IsUsed = false
                    };
                await _passwordRepo.AddAsync(resetCode);
                await _passwordRepo.SaveChangeAsync();
                return ServiceResult.Success(
                    "Password reset code sent Succeefully.");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Forget Password error.");
                return ServiceResult.Failue(
                    "An unexpected error occurred.");
            }
        }
        private async Task SendResetPasswordOtpAsync(
            string email,
            string otp)
        {
            await _emailService.SendEmailAsync(email,
                "TechMart Password Reset",
        $@"
        <h2>Password Reset Request</h2>

        <p>Your password reset code is:</p>

        <h1>{otp}</h1>

        <p>This code will expire in 10 minutes.</p>
        ");

        }


        public async Task<ServiceResult> ResetPasswordAsync(string email,
            string resetCode,
            string newPassword)
        {
            try
            {
                email = email.Trim().ToLower();
                var user =
                    await _userRepo.GetByEmailAsync(email);
                if (user == null)
                {
                    return ServiceResult.Failue
                        ("User not found.");
                }
                var verification =
                    await _passwordRepo.GetValidCodeAsync
                    (user.Id, resetCode);
                if (verification == null)
                {
                    return ServiceResult.Failue(
                        "Invalid or Expired reset code.");
                }
                user.PasswordHash =
                    _passwordHasher.HashPassword(
                        user, newPassword);
                user.UpdatedAt = DateTime.UtcNow;
                verification.IsUsed = true;
                _userRepo.Update(user);
                _passwordRepo.Update(verification);
                await _passwordRepo.SaveChangeAsync();
                return ServiceResult.Success
                    ("Password reset sucessfully done ");

            }
            catch (Exception ex)
            {

                _logger.LogError(ex,
                    "Password Reset error.");
                return ServiceResult.Failue(
                    "An umexpecrted error occured.");
            }
        }
    }
}
