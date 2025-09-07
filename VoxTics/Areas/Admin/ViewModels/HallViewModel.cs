using System.ComponentModel.DataAnnotations.Schema;

namespace VoxTics.Areas.Admin.ViewModels
{
    public class HallViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CinemaName { get; set; } = string.Empty;
        public ICollection<Seat> Seats { get; set; } = new List<Seat>();

        // Optional helper property (not mapped to DB if you use EF [NotMapped])
        [NotMapped]
        public int SeatCount => Seats?.Count ?? 0;
    }
}
