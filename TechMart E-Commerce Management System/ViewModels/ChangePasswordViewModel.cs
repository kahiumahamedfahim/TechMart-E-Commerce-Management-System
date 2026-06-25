using System.ComponentModel.DataAnnotations;

namespace TechMart_E_Commerce_Management_System.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string? CurrrentPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string? NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword))]
        public string? ConfirmPassword { get; set; }
    }
}
