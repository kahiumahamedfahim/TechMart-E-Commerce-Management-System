using System.ComponentModel.DataAnnotations;

namespace TechMart_E_Commerce_Management_System.ViewModels.UsersDTO
{
    public class ResendOtpViewModels
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
