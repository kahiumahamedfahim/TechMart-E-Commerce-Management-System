using System.ComponentModel.DataAnnotations;

namespace TechMart_E_Commerce_Management_System.ViewModels.CatagoriesDTO
{
    public class CreateCategoryViewModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }

        public IFormFile? Image { get; set; }

        public bool IsActive { get; set; }
    }
}
