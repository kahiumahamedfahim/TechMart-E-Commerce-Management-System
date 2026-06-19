using System.ComponentModel.DataAnnotations;

namespace TechMart_E_Commerce_Management_System.ViewModels
{
    public class VerifyResetCodeViewModel
    {
        [Required]
        public string? ResetCode { get; set; }
    }
}
