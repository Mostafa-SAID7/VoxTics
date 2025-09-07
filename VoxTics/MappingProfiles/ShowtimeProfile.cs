using AutoMapper;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;
using VoxTics.Areas.Admin.ViewModels;

namespace VoxTics.MappingProfiles
{
    public class ShowtimeProfile : Profile
    {
        public ShowtimeProfile()
        {
            // Entity to ViewModel mappings
            CreateMap<Showtime, ShowtimeVM>()
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.MoviePosterImage, opt => opt.MapFrom(src => src.Movie.ImageUrl))
                .ForMember(dest => dest.MovieDuration, opt => opt.MapFrom(src => src.Movie.Duration))
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Cinema.Name))
                .ForMember(dest => dest.CinemaAddress, opt => opt.MapFrom(src => src.Cinema.Address))
                .ForMember(dest => dest.HallName, opt => opt.MapFrom(src => src.Hall.Name))
                .ForMember(dest => dest.TotalSeats, opt => opt.MapFrom(src => src.Hall.SeatCount))
                .ForMember(dest => dest.AvailableSeats, opt => opt.MapFrom(src =>
                    src.Hall.SeatCount - src.Bookings.Where(b => b.Status != Models.Enums.BookingStatus.Cancelled)
                        .SelectMany(b => b.BookingSeats).Count()));

            CreateMap<Showtime, ShowtimeViewModel>()
                .ForMember(dest => dest.ShowDate, opt => opt.MapFrom(src => src.ShowDateTime.Date))
                .ForMember(dest => dest.ShowTime, opt => opt.MapFrom(src => src.ShowDateTime.TimeOfDay))
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Cinema.Name))
                .ForMember(dest => dest.HallName, opt => opt.MapFrom(src => src.Hall.Name))
                .ForMember(dest => dest.TotalSeats, opt => opt.MapFrom(src => src.Hall.SeatCount))
                .ForMember(dest => dest.BookedSeats, opt => opt.MapFrom(src =>
                    src.Bookings.Where(b => b.Status != Models.Enums.BookingStatus.Cancelled)
                        .SelectMany(b => b.BookingSeats).Count()))
                .ForMember(dest => dest.AvailableSeats, opt => opt.MapFrom(src =>
                    src.Hall.SeatCount - src.Bookings.Where(b => b.Status != Models.Enums.BookingStatus.Cancelled)
                        .SelectMany(b => b.BookingSeats).Count()));

            // ViewModel to Entity mappings
            CreateMap<ShowtimeViewModel, Showtime>()
                .ForMember(dest => dest.ShowDateTime, opt => opt.MapFrom(src => src.ShowDate.Add(src.ShowTime)))
                .ForMember(dest => dest.Movie, opt => opt.Ignore())
                .ForMember(dest => dest.Cinema, opt => opt.Ignore())
                .ForMember(dest => dest.Hall, opt => opt.Ignore())
                .ForMember(dest => dest.Bookings, opt => opt.Ignore());
        }
    }
}
