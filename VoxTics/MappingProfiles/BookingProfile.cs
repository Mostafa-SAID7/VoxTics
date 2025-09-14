using AutoMapper;
using VoxTics.Models.Entities;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.ViewModels.Booking;

namespace VoxTics.MappingProfiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            // Entity → BookingVM
            CreateMap<Booking, BookingVM>()
                .ForMember(dest => dest.BookingNumber, opt => opt.MapFrom(src => src.BookingNumber))
                .ForMember(dest => dest.SeatNumbers, opt => opt.MapFrom(src => src.BookingSeats.Select(s => s.SeatId)))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(dest => dest.DiscountAmount, opt => opt.MapFrom(src => src.DiscountAmount))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(src => src.PaymentStatus))
                .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod))
                .ForMember(dest => dest.BookingDate, opt => opt.MapFrom(src => src.BookingDate))
                .ForMember(dest => dest.PaymentDate, opt => opt.MapFrom(src => src.PaymentDate))
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Showtime.Movie.Title))
                .ForMember(dest => dest.MoviePoster, opt => opt.MapFrom(src => src.Showtime.Movie.ImageUrl))
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Showtime.Cinema.Name))
                .ForMember(dest => dest.HallName, opt => opt.MapFrom(src => src.Showtime.Hall.Name))
                .ForMember(dest => dest.ShowtimeStart, opt => opt.MapFrom(src => src.Showtime.StartTime))
                .ForMember(dest => dest.ShowtimeId, opt => opt.MapFrom(src => src.ShowtimeId))
                .ForMember(dest => dest.CanBeCancelled, opt => opt.MapFrom(src => src.CanBeCancelled));

            // BookingCreateVM → Booking (for creating a new booking)
            CreateMap<BookingCreateVM, Booking>()
       .ForMember(dest => dest.ShowtimeId, opt => opt.MapFrom(src => src.ShowtimeId))
       .ForMember(dest => dest.FinalAmount, opt => opt.MapFrom(src => src.NumberOfTickets))
       .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod))
       .ForMember(dest => dest.BookingDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
       .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => BookingStatus.Pending))
       .ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(_ => PaymentStatus.Pending))
       .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
       // Explicitly ignore properties that cannot be mapped
       .ForMember(dest => dest.Id, opt => opt.Ignore())
       .ForMember(dest => dest.BookingSeats, opt => opt.Ignore())
       .ForMember(dest => dest.UserId, opt => opt.Ignore());
        }

    }
}
