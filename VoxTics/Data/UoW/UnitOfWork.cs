using VoxTics.Repositories.IRepositories;

namespace VoxTics.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieDbContext _context;

        public IBookingsRepository Bookings { get; }
        public ICategoriesRepository Categories { get; }
        public ICinemasRepository Cinemas { get; }
        public IMoviesRepository Movies { get; }
        public IShowtimesRepository Showtimes { get; }
        public IDashboardRepository AdminDashboard { get; }
        public IApplicationUsersRepository ApplicationUsers { get; }
        public IHomeRepository Home { get; }

        public UnitOfWork(
            MovieDbContext context,
            IBookingsRepository bookings,
            ICategoriesRepository categories,
            ICinemasRepository cinemas,
            IMoviesRepository movies,
            IShowtimesRepository showtimes,
             IApplicationUsersRepository applicationUsers,
            IDashboardRepository adminDashboard,
            IHomeRepository home)
        {
            _context = context;
            Bookings = bookings;
            Categories = categories;
            Cinemas = cinemas;
            Movies = movies;
            Showtimes = showtimes;
            AdminDashboard = adminDashboard;
            Home = home;
            ApplicationUsers = applicationUsers;
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }


}
