using AutoMapper;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;
using VoxTics.Areas.Admin.ViewModels;

namespace VoxTics.MappingProfiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            // Entity to ViewModel mappings
            CreateMap<Booking, BookingVM>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.SeatNumbers, opt => opt.MapFrom(src =>
                    src.BookingSeats.Select(bs => bs.Seat.SeatNumber).ToList()));

            CreateMap<Booking, BookingViewModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Showtime.Movie.Title))
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Showtime.Cinema.Name))
                .ForMember(dest => dest.HallName, opt => opt.MapFrom(src => src.Showtime.Hall.Name))
                .ForMember(dest => dest.ShowDateTime, opt => opt.MapFrom(src => src.Showtime.ShowDateTime))
                .ForMember(dest => dest.SeatNumbers, opt => opt.MapFrom(src =>
                    src.BookingSeats.Select(bs => bs.Seat.SeatNumber).ToList()));

            // ViewModel to Entity mappings
            CreateMap<BookingViewModel, Booking>()
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Showtime, opt => opt.Ignore())
                .ForMember(dest => dest.BookingSeats, opt => opt.Ignore());
        }
    }
}
