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
            // Entity -> VM
            CreateMap<Booking, BookingViewModel>()
                .ForMember(dest => dest.NumberOfSeats, opt => opt.MapFrom(src => src.NumberOfTickets))
                .ForMember(dest => dest.NumberOfTickets, opt => opt.MapFrom(src => src.NumberOfTickets))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
                .ForMember(dest => dest.DiscountAmount, opt => opt.MapFrom(src => src.DiscountAmount))
                .ForMember(dest => dest.FinalAmount, opt => opt.MapFrom(src => src.FinalAmount))
                // showtime/user display fields
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Showtime != null && src.Showtime.Movie != null ? src.Showtime.Movie.Title : string.Empty))
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Showtime != null && src.Showtime.Hall != null && src.Showtime.Hall.Cinema != null ? src.Showtime.Hall.Cinema.Name : string.Empty))
                .ForMember(dest => dest.HallName, opt => opt.MapFrom(src => src.Showtime != null && src.Showtime.Hall != null ? src.Showtime.Hall.Name : string.Empty))
                .ForMember(dest => dest.ShowDateTime, opt => opt.MapFrom(src => src.Showtime != null ? src.Showtime.StartTime : default))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.Name : string.Empty))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User != null ? src.User.Email : string.Empty))
                // Seats list
                .ForMember(dest => dest.SeatNumbers, opt => opt.MapFrom(src => src.BookingSeats != null ? src.BookingSeats.Select(bs => bs.Seat != null ? bs.Seat.SeatNumber : string.Empty).ToList() : new List<string>()))
                .ForMember(dest => dest.CanBeCancelled, opt => opt.MapFrom(src => src.CanBeCancelled))
                .ForMember(dest => dest.SavingsAmount, opt => opt.MapFrom(src => src.SavingsAmount));

            // VM -> Entity (for create/edit)
            CreateMap<BookingViewModel, Booking>()
                .ForMember(dest => dest.NumberOfTickets, opt => opt.MapFrom(src => src.NumberOfTickets != 0 ? src.NumberOfTickets : src.NumberOfSeats))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
                .ForMember(dest => dest.DiscountAmount, opt => opt.MapFrom(src => src.DiscountAmount))
                .ForMember(dest => dest.FinalAmount, opt => opt.MapFrom(src => src.FinalAmount))
                // prevent AutoMapper from touching nav props or computed props
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Showtime, opt => opt.Ignore())
                .ForMember(dest => dest.BookingSeats, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Condition((src, dest, srcMember) => src.Id != 0));

            // Entity to ViewModel mappings
            CreateMap<Booking, BookingVM>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.SeatNumbers, opt => opt.MapFrom(src =>
                    src.BookingSeats.Select(bs => bs.Seat.SeatNumber).ToList()));

            CreateMap<Booking, BookingViewModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Showtime.Movie.Title))
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Showtime.Cinema.Name))
                .ForMember(dest => dest.HallName, opt => opt.MapFrom(src => src.Showtime.Hall.Name))
                .ForMember(dest => dest.ShowDateTime, opt => opt.MapFrom(src => src.Showtime.CreatedAt))
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
