using AutoMapper;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;

namespace VoxTics.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Entity to ViewModel mappings
            CreateMap<User, UserVM>()
                .ForMember(dest => dest.TotalBookings, opt => opt.MapFrom(src => src.Bookings.Count))
                .ForMember(dest => dest.TotalSpent, opt => opt.MapFrom(src =>
                    src.Bookings.Where(b => b.PaymentStatus == Models.Enums.PaymentStatus.Paid).Sum(b => b.TotalAmount)))
                .ForMember(dest => dest.RecentBookings, opt => opt.MapFrom(src =>
                    src.Bookings.OrderByDescending(b => b.BookingDate).Take(5)));

            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.TotalBookings, opt => opt.MapFrom(src => src.Bookings.Count))
                .ForMember(dest => dest.TotalSpent, opt => opt.MapFrom(src =>
                    src.Bookings.Where(b => b.PaymentStatus == Models.Enums.PaymentStatus.Paid).Sum(b => b.TotalAmount)))
                .ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(src => src.CreatedDate));

            // ViewModel to Entity mappings
            CreateMap<UserViewModel, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.Bookings, opt => opt.Ignore())
                .ForMember(dest => dest.EmailConfirmationToken, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordResetToken, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordResetExpires, opt => opt.Ignore());
        }
    }
}
