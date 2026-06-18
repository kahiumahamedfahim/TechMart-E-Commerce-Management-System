using System.ComponentModel.DataAnnotations;

namespace TechMart_E_Commerce_Management_System.ViewModels
{
    public class VerifyEmailViewModel
    {

        [Required]
        public string? VerificationCode { get; set; }
    }
}
