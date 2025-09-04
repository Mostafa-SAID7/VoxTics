using System.ComponentModel.DataAnnotations;

namespace VoxTics.Areas.Admin.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}
