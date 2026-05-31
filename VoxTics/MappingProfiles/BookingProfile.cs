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
            // ✅ Booking → BookingListVM (for user booking history)
            CreateMap<Booking, BookingListVM>()
                .ForMember(dest => dest.BookingId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.BookingReference, opt => opt.MapFrom(src => src.BookingReference))
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Showtime != null && src.Showtime.Movie != null ? src.Showtime.Movie.Title : string.Empty))
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Showtime != null && src.Showtime.Cinema != null ? src.Showtime.Cinema.Name : string.Empty))
                .ForMember(dest => dest.ShowtimeStart, opt => opt.MapFrom(src => src.Showtime.StartTime))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(src =>
                    src.Payments != null && src.Payments.Any()
                        ? src.Payments.OrderByDescending(p => p.Id).First().Status
                        : VoxTics.Models.Enums.PaymentStatus.Pending))
                .ForMember(dest => dest.FinalAmount, opt => opt.MapFrom(src => src.FinalAmount));

            // ✅ BookingSeat → BookingSeatVM (for each seat)
            CreateMap<BookingSeat, BookingSeatVM>()
                .ForMember(dest => dest.SeatId, opt => opt.MapFrom(src => src.SeatId))
                .ForMember(dest => dest.SeatNumber, opt => opt.MapFrom(src => src.Seat.SeatNumber))
                .ForMember(dest => dest.SeatPrice, opt => opt.MapFrom(src => src.SeatPrice));

            // ✅ Booking → BookingDetailsVM (for detailed booking view)
            CreateMap<Booking, BookingDetailsVM>()
                .ForMember(dest => dest.BookingId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.BookingReference, opt => opt.MapFrom(src => src.BookingReference))
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Showtime != null && src.Showtime.Movie != null ? src.Showtime.Movie.Title : string.Empty))
                .ForMember(dest => dest.MovieMainImage, opt => opt.MapFrom(src => src.Showtime != null && src.Showtime.Movie != null ? src.Showtime.Movie.MainImage ?? string.Empty : string.Empty))
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Showtime != null && src.Showtime.Cinema != null ? src.Showtime.Cinema.Name : string.Empty))
                .ForMember(dest => dest.HallName, opt => opt.MapFrom(src => src.Showtime != null && src.Showtime.Hall != null ? src.Showtime.Hall.Name : string.Empty))
                .ForMember(dest => dest.ShowtimeStart, opt => opt.MapFrom(src => src.Showtime.StartTime))
                .ForMember(dest => dest.ShowtimeDuration, opt => opt.MapFrom(src => src.Showtime != null ? src.Showtime.Duration : 0))
                .ForMember(dest => dest.NumberOfTickets, opt => opt.MapFrom(src => src.NumberOfTickets))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
                .ForMember(dest => dest.DiscountAmount, opt => opt.MapFrom(src => src.DiscountAmount))
                .ForMember(dest => dest.FinalAmount, opt => opt.MapFrom(src => src.FinalAmount))
                .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src =>
                    src.Payments != null && src.Payments.Any()
                        ? src.Payments.OrderByDescending(p => p.Id).First().Method
                        : VoxTics.Models.Enums.PaymentMethod.Undefined))
                .ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(src =>
                    src.Payments != null && src.Payments.Any()
                        ? src.Payments.OrderByDescending(p => p.Id).First().Status
                        : VoxTics.Models.Enums.PaymentStatus.Pending))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.BookingDate, opt => opt.MapFrom(src => src.BookingDate))
                .ForMember(dest => dest.Seats, opt => opt.MapFrom(src => src.BookingSeats));

            // ✅ BookingCreateVM → Booking (for creating a booking)
            CreateMap<BookingCreateVM, Booking>()
                .ForMember(dest => dest.ShowtimeId, opt => opt.MapFrom(src => src.ShowtimeId))
                .ForMember(dest => dest.NumberOfTickets, opt => opt.MapFrom(src => src.SeatIds.Count))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
                .ForMember(dest => dest.DiscountAmount, opt => opt.MapFrom(src => src.DiscountAmount))
                .ForMember(dest => dest.FinalAmount, opt => opt.MapFrom(src => src.FinalAmount))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => VoxTics.Models.Enums.BookingStatus.Pending))
                .ForMember(dest => dest.BookingSeats, opt => opt.MapFrom(src =>
                    src.SeatIds.Select(id => new BookingSeat
                    {
                        SeatId = id,
                        SeatPrice = src.SeatPrice,
                    }).ToList()
                ));
        }
    }
}
