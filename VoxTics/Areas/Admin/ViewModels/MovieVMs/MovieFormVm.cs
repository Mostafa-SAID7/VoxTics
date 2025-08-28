using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VoxTics.Areas.Admin.ViewModels.MovieVMs
{
    public class MovieFormVm
    {
        public int Id { get; set; } // 0 for create, >0 for edit

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = "";

        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Range(0, 10000)]
        public decimal Price { get; set; }

        [Display(Name = "Main Image URL")]
        public string? ImgUrl { get; set; }

        [Display(Name = "Upload Images")]
        public List<IFormFile>? UploadedImages { get; set; } = new List<IFormFile>();

        [Display(Name = "Trailer URL")]
        public string? TrailerUrl { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; } = DateTime.UtcNow.AddMonths(1);

        [Display(Name = "Status")]
        public string MovieStatus { get; set; } = "";

        [Display(Name = "Cinema")]
        [Required]
        public int CinemaId { get; set; }

        [Display(Name = "Category")]
        [Required]
        public int CategoryId { get; set; }

        // Dropdown lists (populate in controller)
        public IEnumerable<SelectListItem>? Cinemas { get; set; }
        public IEnumerable<SelectListItem>? Categories { get; set; }

        // Existing images (for edit view)
        public List<MovieImgVm> ExistingImages { get; set; } = new List<MovieImgVm>();
    }
}
