using System.ComponentModel.DataAnnotations.Schema;

namespace VoxTics.Models.ViewModels
{
    public class CinemaVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public string Phone { get; set; }
        [NotMapped]
        public string? Website { get; set; }
    }
}
