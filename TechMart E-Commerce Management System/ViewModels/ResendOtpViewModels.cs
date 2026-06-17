using System.ComponentModel.DataAnnotations;

namespace TechMart_E_Commerce_Management_System.ViewModels
{
    public class ResendOtpViewModels
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
