using System;
using VoxTics.Models.Enums;
using VoxTics.Models.Enums.TimeRange;

namespace VoxTics.Models.ViewModels
{
    public class ShowtimeFilterVM : BasePaginatedFilterVM
    {
        public int? MovieId { get; set; }
        public int? CinemaId { get; set; }
        public int? HallId { get; set; }
        public ShowtimeStatus? Status { get; set; } 
        public TimeOfDayRange? TimeOfDayRange { get; set; }   

        public bool? HasAvailableSeats { get; set; }
    }
}
