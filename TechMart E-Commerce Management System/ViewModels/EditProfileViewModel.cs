using System.ComponentModel.DataAnnotations;

namespace TechMart_E_Commerce_Management_System.ViewModels
{
    public class EditProfileViewModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string? CurrentProfileImage { get; set; }

        public IFormFile? ProfileImage { get; set; }

    }
}
