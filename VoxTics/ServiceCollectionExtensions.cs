using AutoMapper;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using VoxTics.Areas.Admin.AdminProfiles;
using VoxTics.Areas.Admin.MappingProfiles;
using VoxTics.Areas.Admin.Profiles;
using VoxTics.Areas.Admin.Repositories;
using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Areas.Admin.Services.Implementations;
using VoxTics.Areas.Admin.Services.Interfaces;
using VoxTics.Areas.Identity.IdentityProfiles;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Services;
using VoxTics.Data.UoW;
using VoxTics.Helpers.ImgsHelper;
using VoxTics.MappingProfiles;
using VoxTics.Repositories;
using VoxTics.Repositories.IRepositories;
using VoxTics.Services;
using VoxTics.Services.Implementations;
using VoxTics.Services.Interfaces;
using VoxTics.Services.IServices;

namespace VoxTics.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // General Repositories
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<ICinemasRepository, CinemasRepository>();
            services.AddScoped<IMoviesRepository, MoviesRepository>();
            services.AddScoped<IShowtimesRepository, ShowtimesRepository>();
            services.AddScoped<IHomeRepository, HomeRepository>();

            // Identity Repositories
            services.AddScoped<IBaseRepository<UserOTP>, BaseRepository<UserOTP>>();

            // Admin Repositories
            services.AddScoped<IAdminBookingsRepository, AdminBookingsRepository>();
            services.AddScoped<IAdminCategoriesRepository, AdminCategoriesRepository>();
            services.AddScoped<IAdminCinemasRepository, AdminCinemasRepository>();
            services.AddScoped<IAdminMoviesRepository, AdminMoviesRepository>();
            services.AddScoped<IAdminShowtimesRepository, AdminShowtimesRepository>();
            services.AddScoped<IDashboardRepository, DashboardRepository>();

            // General Services
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICinemaService, CinemaService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IShowtimeService, ShowtimeService>();
            services.AddScoped<ICartService, CartService>();

            //Helpers
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddSingleton<ImageManager>();
            // Identity Services
            services.Configure<ImageSettings>(config.GetSection("ImageSettings"));


            // Admin Services
            services.AddScoped<IAdminBookingsService, AdminBookingsService>();
            services.AddScoped<IAdminCategoryService, AdminCategoryService>();
            services.AddScoped<IAdminCinemaService, AdminCinemaService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IAdminMovieService, AdminMovieService>();
            services.AddScoped<IAdminShowtimeService, AdminShowtimeService>();


            // AutoMapper Mapping Profiles
            services.AddAutoMapper(cfg =>
            {
                // General
                cfg.AddProfile<BookingProfile>();
                cfg.AddProfile<CategoryProfile>();
                cfg.AddProfile<CinemaProfile>();
                cfg.AddProfile<MovieProfile>();
                cfg.AddProfile<ShowtimeProfile>();

                // Admin
                cfg.AddProfile<BookingAdminProfile>();
                cfg.AddProfile<CategoryAdminProfile>();
                cfg.AddProfile<CinemaAdminProfile>();
                cfg.AddProfile<AdminMovieProfile>();
                cfg.AddProfile<ShowtimeAdminProfile>();

                // Identity
                cfg.AddProfile<AccountProfile>();
            });

            // Helpers or utilities can also be added here if they need DI
            // services.AddTransient<ImageHelper>();

            return services;
        }
    }
}
