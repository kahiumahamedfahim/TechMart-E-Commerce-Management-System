using TechMart_E_Commerce_Management_System.Data.Enums;

namespace TechMart_E_Commerce_Management_System.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string? UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? ProfileImage { get; set; }
        public Role Role { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //navigation propert 
        public ICollection<EmailVerification>? EmailVerficationsCodes { get; set; }
        public ICollection<PasswordResetCode>? PasswordResetCodes { get; set; }

    }
}
