using AutoMapper;
using VoxTics.Areas.Admin.ViewModels.Movie;
using VoxTics.Models.Entities;
using System.Linq;

namespace VoxTics.Areas.Admin.MappingProfiles
{
    public class MovieAdminProfile : Profile
    {
        public MovieAdminProfile()
        {
            // =============================
            // Movie → MovieListItemViewModel
            // =============================
            CreateMap<Movie, MovieListItemViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.MainImageUrl, opt => opt.MapFrom(src => src.MainImage))
                .ForMember(dest => dest.ShowtimeCount, opt => opt.MapFrom(src => src.Showtimes.Count));

            // ============================
            // Movie → MovieDetailViewModel
            // ============================
            CreateMap<Movie, MovieDetailViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.MainImageUrl, opt => opt.MapFrom(src => src.MainImage));

            // =====================================
            // MovieCreateEditViewModel → Movie
            // (Used for Create or Update operations)
            // =====================================
            CreateMap<MovieCreateEditViewModel, Movie>()
                .ForMember(dest => dest.MainImage, opt => opt.Ignore())         // handled manually after upload
                .ForMember(dest => dest.MovieImages, opt => opt.Ignore())      // handled manually for multiple images
                .ForMember(dest => dest.Category, opt => opt.Ignore())         // only CategoryId provided
                .ForMember(dest => dest.Bookings, opt => opt.Ignore())         // not needed here
                .ForMember(dest => dest.Showtimes, opt => opt.Ignore())        // handled separately
                .ForMember(dest => dest.MovieActors, opt => opt.Ignore())      // handled separately
                .ForMember(dest => dest.WatchlistItems, opt => opt.Ignore())   // handled separately
                .ForMember(dest => dest.CartItems, opt => opt.Ignore());       // handled separately

            // =====================================
            // Movie → MovieCreateEditViewModel
            // (Used to pre-fill Edit forms)
            // =====================================
            CreateMap<Movie, MovieCreateEditViewModel>()
                .ForMember(dest => dest.MainImage, opt => opt.Ignore()) // can't map URL to IFormFile
                .ForMember(dest => dest.ExistingPosterUrl, opt => opt.MapFrom(src => src.MainImage))
                .ForMember(dest => dest.AdditionalImages, opt => opt.Ignore()) // new uploads only
                .ForMember(dest => dest.ExistingImageUrls,
                    opt => opt.MapFrom(src => src.MovieImages.Select(mi => mi.VariantImages)));
        }
    }
}
