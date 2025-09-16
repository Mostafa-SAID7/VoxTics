using AutoMapper;
using VoxTics.Areas.Admin.ViewModels.Booking;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using System.Linq;

namespace VoxTics.Areas.Admin.AdminProfiles
{
    public class BookingAdminProfile : Profile
    {
        public BookingAdminProfile()
        {
            // Booking -> BookingViewModel
            CreateMap<Booking, BookingViewModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Showtime.Movie.Title))
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Showtime.Cinema.Name))
                .ForMember(dest => dest.ShowtimeDisplay, opt => opt.MapFrom(src => src.Showtime.StartTime.ToString("yyyy-MM-dd HH:mm")))
                .ForMember(dest => dest.Seats, opt => opt.MapFrom(src => src.BookingSeats.Select(bs => bs.Seat.SeatNumber)))
                .ForMember(dest => dest.FinalAmount, opt => opt.MapFrom(src => src.TotalAmount - src.DiscountAmount));

            // Booking -> BookingTableViewModel
            CreateMap<Booking, BookingTableViewModel>()
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.CanBeCancelled, opt => opt.MapFrom(src => src.Status == BookingStatus.Pending));

            // Booking -> BookingDetailsViewModel
            CreateMap<Booking, BookingDetailsViewModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Showtime.Movie.Title))
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Showtime.Cinema.Name))
                .ForMember(dest => dest.HallName, opt => opt.MapFrom(src => src.Showtime.Hall.Name))
                .ForMember(dest => dest.ShowDateTime, opt => opt.MapFrom(src => src.Showtime.StartTime))
                .ForMember(dest => dest.SeatNumbers, opt => opt.MapFrom(src => src.BookingSeats.Select(bs => bs.Seat.SeatNumber)))
                .ForMember(dest => dest.NumberOfTickets, opt => opt.MapFrom(src => src.BookingSeats.Count))
                .ForMember(dest => dest.SavingsAmount, opt => opt.MapFrom(src => src.TotalAmount - src.FinalAmount))
                .ForMember(dest => dest.CanBeCancelled, opt => opt.MapFrom(src => src.Status == BookingStatus.Pending));

            // BookingCreateEditViewModel -> Booking
            CreateMap<BookingCreateEditViewModel, Booking>()
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
                .ForMember(dest => dest.DiscountAmount, opt => opt.MapFrom(src => src.DiscountAmount))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(src => src.PaymentStatus))
                .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod))
                .ForMember(dest => dest.TransactionId, opt => opt.MapFrom(src => src.TransactionId))
                .ForMember(dest => dest.PaymentDate, opt => opt.MapFrom(src => src.PaymentDate))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
                .ForMember(dest => dest.CancellationDate, opt => opt.MapFrom(src => src.CancellationDate))
                .ForMember(dest => dest.CancellationReason, opt => opt.MapFrom(src => src.CancellationReason));
        }
    }
}
