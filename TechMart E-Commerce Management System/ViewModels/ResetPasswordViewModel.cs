using System.ComponentModel.DataAnnotations;

namespace TechMart_E_Commerce_Management_System.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }
    }
}
