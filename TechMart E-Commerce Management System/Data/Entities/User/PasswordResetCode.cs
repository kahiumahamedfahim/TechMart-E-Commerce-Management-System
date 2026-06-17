namespace TechMart_E_Commerce_Management_System.Data.Entities.User
{
    public class PasswordResetCode
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? ResetCode { get; set; }
        public DateTime ExpiryTime { get; set; }
        public bool IsUsed { get; set; }
        public User? User { get; set; }
    }
}
