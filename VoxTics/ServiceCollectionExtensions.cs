using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Data.UoW;
using VoxTics.MappingProfiles;
using VoxTics.MappingProfiles.AdminProfiles;
using VoxTics.Repositories;
using VoxTics.Repositories.IRepositories;
using VoxTics.Services.Implementations;
using VoxTics.Services.Interfaces;

namespace VoxTics
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<MovieDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Repositories and Services
            services.AddRepositories();
            services.AddBusinessServices();
            
            // Helpers 
            services.AddTransient<IEmailSender, EmailSender>();

            //AutoMapper and scan assembly for profiles
            services.AddAutoMapper(typeof(AccountProfile).Assembly);
            services.AddAutoMapper(typeof(BookingProfile));


            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Register UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositories
            services.AddScoped<IBookingsRepository, BookingsRepository>();
            services.AddScoped<IMoviesRepository, MoviesRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<ICinemasRepository, CinemasRepository>();
            services.AddScoped<IShowtimesRepository, ShowtimesRepository>();
            services.AddScoped<IApplicationUsersRepository, ApplicationUsersRepository>();
            services.AddScoped<IBaseRepository<UserOTP>, BaseRepository<UserOTP>>();
            services.AddScoped<IDashboardRepository, DashboardRepository>();
            services.AddScoped<IHomeRepository, HomeRepository>();

            services.AddHttpContextAccessor();
            return services;
        }

        private static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICinemaService, CinemaService>();
            services.AddScoped<IShowtimeService, ShowtimeService>();
            services.AddScoped<IApplicationUsersService, ApplicationUsersService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IDashboardService, DashboardService>();


            return services;
        }
    }

}
