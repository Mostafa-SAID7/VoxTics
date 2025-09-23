
namespace VoxTics
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddVoxTicsServices(this IServiceCollection services, IConfiguration config)
        {
            // 🟢 Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // 🟢 Generic Repository Registration
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            // 🟢 General Repositories
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<ICinemasRepository, CinemasRepository>();
            services.AddScoped<IMoviesRepository, MoviesRepository>();
            services.AddScoped<IShowtimesRepository, ShowtimesRepository>();
            services.AddScoped<IHomeRepository, HomeRepository>();

            // 🟢 Identity Repositories
            services.AddScoped<IBaseRepository<UserOTP>, BaseRepository<UserOTP>>();

            // 🟢 Admin Repositories
            services.AddScoped<IAdminMoviesRepository, AdminMoviesRepository>();
            services.AddScoped<IAdminBookingsRepository, AdminBookingsRepository>();
            services.AddScoped<IAdminCategoriesRepository, AdminCategoriesRepository>();
            services.AddScoped<IAdminCinemasRepository, AdminCinemasRepository>();
            services.AddScoped<IAdminShowtimesRepository, AdminShowtimesRepository>();
            services.AddScoped<IDashboardRepository, DashboardRepository>();

            // 🟢 Admin Services
            services.AddScoped<IAdminBookingsService, AdminBookingsService>();
            services.AddScoped<IAdminCategoryService, AdminCategoryService>();
            services.AddScoped<IAdminCinemaService, AdminCinemaService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IAdminMovieService, AdminMovieService>();
            services.AddScoped<IAdminShowtimeService, AdminShowtimeService>();

            // 🟢 General Services
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICinemaService, CinemaService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IShowtimeService, ShowtimeService>();
            services.AddScoped<ICartService, CartService>();

            // 🟢 AutoMapper Mapping Profiles
            services.AddAutoMapper(cfg =>
            {
                // 🔹 General Profiles
                cfg.AddProfile<BookingProfile>();
                cfg.AddProfile<CategoryProfile>();
                cfg.AddProfile<CinemaProfile>();
                cfg.AddProfile<MovieProfile>();
                cfg.AddProfile<ShowtimeProfile>();

                // 🔹 Admin Profiles
                cfg.AddProfile<BookingAdminProfile>();
                cfg.AddProfile<CategoryAdminProfile>();
                cfg.AddProfile<CinemaAdminProfile>();
                cfg.AddProfile<AdminMovieProfile>();
                cfg.AddProfile<ShowtimeAdminProfile>();

                // 🔹 Identity Profiles
                cfg.AddProfile<AccountProfile>();
            });

            // 🟢 Helpers & Settings
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<ImageSettings>(config.GetSection("ImageSettings"));
            services.AddSingleton<ImageManager>();

            return services;
        }
    }
}
