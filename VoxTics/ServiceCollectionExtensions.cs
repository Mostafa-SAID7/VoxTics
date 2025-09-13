using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VoxTics.Data.UoW;
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

            services.AddRepositories();
            services.AddBusinessServices();
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBookingsRepository, BookingsRepository>();
            services.AddScoped<IMoviesRepository, MoviesRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<ICinemasRepository, CinemasRepository>();
            services.AddScoped<IShowtimesRepository, ShowtimesRepository>();


            return services;
        }

        private static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICinemaService, CinemaService>();
            services.AddScoped<IShowtimeService, ShowtimeService>();


            return services;
        }
    }

}
