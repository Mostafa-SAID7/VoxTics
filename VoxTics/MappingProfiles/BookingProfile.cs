using AutoMapper;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels.Booking;
using System;
using System.Collections.Generic;

namespace VoxTics.MappingProfiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            // Map Booking -> BookingDetailsVM
            CreateMap<Booking, BookingDetailsVM>()
                .ForMember(dest => dest.CinemaName, opt => opt.Ignore()) // set manually
                .ForMember(dest => dest.HallName, opt => opt.Ignore())   // set manually
                .ForMember(dest => dest.SeatNumbers, opt => opt.Ignore()) // set manually
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Showtime.Movie.Title))
                .ForMember(dest => dest.ShowTime, opt => opt.MapFrom(src => src.Showtime.StartTime))
                .ForMember(dest => dest.FinalAmount, opt => opt.MapFrom(src => src.TotalAmount));

            // Map Booking -> BookingSummaryVM
            CreateMap<Booking, BookingSummaryVM>()
                .ForMember(dest => dest.CinemaName, opt => opt.Ignore()) // set manually
                .ForMember(dest => dest.HallName, opt => opt.Ignore())   // set manually
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Showtime.Movie.Title))
                .ForMember(dest => dest.ShowTime, opt => opt.MapFrom(src => src.Showtime.StartTime))
                .ForMember(dest => dest.DiscountAmount, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.FinalAmount, opt => opt.MapFrom(src => src.TotalAmount))
                .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.CanBeCancelled, opt => opt.MapFrom(src => src.Showtime.StartTime > DateTime.UtcNow))
                .ForMember(dest => dest.SavingsAmount, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.SeatNumbers, opt => opt.Ignore()); // populate manually if needed
        }
    }
}
