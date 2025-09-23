using AutoMapper;
using VoxTics.Areas.Admin.ViewModels.Category;
using VoxTics.Models.Entities;



namespace VoxTics.Areas.Admin.MappingProfiles
    {
        public class CategoryAdminProfile : Profile
        {
            public CategoryAdminProfile()
            {
                // 1. Category <-> CategoryCreateEditViewModel
                CreateMap<Category, CategoryCreateEditViewModel>()
                    .ForMember(dest => dest.MovieCount, opt => opt.MapFrom(src => src.MovieCount))
                    .ReverseMap();

                // 2. Category -> CategoryDetailsViewModel
                CreateMap<Category, CategoryDetailsViewModel>()
                    .ForMember(dest => dest.MovieCount, opt => opt.MapFrom(src => src.MovieCount))
                    .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                    .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));

                // 3. Category -> CategoryViewModel
                CreateMap<Category, CategoryViewModel>()
                    .ForMember(dest => dest.MovieCount, opt => opt.MapFrom(src => src.MovieCount))
                    .ForMember(dest => dest.StatusBadge,
                               opt => opt.MapFrom(src => src.IsActive ? "badge bg-success" : "badge bg-secondary"))
                    .ForMember(dest => dest.Movies, opt => opt.Ignore()); // populate manually if needed

            }
        }
    } 
