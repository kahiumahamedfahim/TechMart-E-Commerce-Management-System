using System.ComponentModel.DataAnnotations;

namespace TechMart_E_Commerce_Management_System.ViewModels.CatagoriesDTO
{
    public class UpdateCategoryViewModel
    {
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [StringLength(20)]

        public string? Description { get; set; }

        public IFormFile? Image { get; set; }

        public string? ExistingImagePath { get; set; }
        public bool IsActive { get; set; }

    }
}
