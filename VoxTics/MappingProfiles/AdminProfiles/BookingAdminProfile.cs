using AutoMapper;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;
using VoxTics.Areas.Admin.ViewModels;

namespace VoxTics.MappingProfiles.AdminProfiles
{
    public class BookingAdminProfile : Profile
    {
        public BookingAdminProfile()
        {
            // Booking entity → BookingViewModel
            CreateMap<Booking, BookingViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.ShowtimeId, opt => opt.MapFrom(src => src.ShowtimeId))
                .ForMember(dest => dest.NumberOfSeats, opt => opt.MapFrom(src => src.FinalAmount))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(src => src.PaymentStatus))
                .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod))
                .ForMember(dest => dest.TransactionId, opt => opt.MapFrom(src => src.TransactionId))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
                .ForMember(dest => dest.CancellationReason, opt => opt.MapFrom(src => src.CancellationReason))
                .ForMember(dest => dest.CancellationDate, opt => opt.MapFrom(src => src.CancellationDate))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.BookingDate))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt))
                .ForMember(dest => dest.ShowtimeStart, opt => opt.MapFrom(src => src.Showtime.StartTime))
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Showtime.Movie.Title))
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Showtime.Cinema.Name))
                .ForMember(dest => dest.HallName, opt => opt.MapFrom(src => src.Showtime.Hall.Name))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.SeatNumbers, opt => opt.MapFrom(src => src.BookingSeats.Select(bs => bs.Seat.SeatNumber)))
                .ForMember(dest => dest.FinalAmount, opt => opt.MapFrom(src => src.TotalPrice - src.DiscountAmount))
                .ForMember(dest => dest.SavingsAmount, opt => opt.MapFrom(src => src.DiscountAmount));

            // BookingViewModel → Booking entity (for updates)
            CreateMap<BookingViewModel, Booking>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(src => src.PaymentStatus))
                .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
                .ForMember(dest => dest.TransactionId, opt => opt.MapFrom(src => src.TransactionId))
                .ForMember(dest => dest.CancellationReason, opt => opt.MapFrom(src => src.CancellationReason))
                .ForMember(dest => dest.CancellationDate, opt => opt.MapFrom(src => src.CancellationDate))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));
                // Ignore complex navigation properties
               
        }
    }
}
