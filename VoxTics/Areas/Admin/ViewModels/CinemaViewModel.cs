using System.ComponentModel.DataAnnotations;

namespace VoxTics.Areas.Admin.ViewModels
{
    public class CinemaViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Cinema Name")]
        public string Name { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Url]
        public string Website { get; set; }

        public string ImageUrl { get; set; }

        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
