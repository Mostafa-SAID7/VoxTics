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
            // Map Booking -> BookingViewModel (for listing)
            CreateMap<Booking, BookingViewModel>()
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Movie.Cinema.Name))
                .ForMember(dest => dest.SeatCount, opt => opt.MapFrom(src => src.BookingSeats.Count))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            // Map Booking -> BookingDetailsViewModel (for details page)
            CreateMap<Booking, BookingDetailsViewModel>()
         .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.Name))
         .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
         .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Movie.Title))
         .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Movie.Cinema.Name))
         .ForMember(dest => dest.SeatNumbers, opt => opt.MapFrom(src => src.BookingSeats.Select(s => s.SeatNumber)))
         .ForMember(dest => dest.SeatPrice, opt => opt.MapFrom(src => src.Movie.Price)) 
         .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
         .ForMember(dest => dest.DiscountAmount, opt => opt.MapFrom(src => src.DiscountAmount))
         .ForMember(dest => dest.FinalAmount, opt => opt.MapFrom(src => src.FinalAmount))
         .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
         .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod.ToString()));
        }
    }
}
