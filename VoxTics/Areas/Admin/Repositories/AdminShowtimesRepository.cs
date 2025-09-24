using VoxTics.Areas.Admin.ViewModels.Showtime;

public class AdminShowtimesRepository : IAdminShowtimesRepository
{
    private readonly MovieDbContext _context;
    private readonly IMapper _mapper;

    public AdminShowtimesRepository(MovieDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IQueryable<Showtime> Query()
    {
        return _context.Showtimes.AsQueryable();
    }

    public async Task<Showtime?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Showtimes
            .Include(s => s.Movie)
            .Include(s => s.Cinema)
            .Include(s => s.Hall)
            .Include(s => s.Bookings)
                .ThenInclude(b => b.User)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }

    public async Task AddShowtimeAsync(Showtime showtime, CancellationToken cancellationToken = default)
    {
        _context.Showtimes.Add(showtime);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateShowtimeAsync(Showtime showtime, CancellationToken cancellationToken = default)
    {
        _context.Showtimes.Update(showtime);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveShowtimeAsync(int id, CancellationToken cancellationToken = default)
    {
        var showtime = await GetByIdAsync(id, cancellationToken);
        if (showtime == null) return;
        _context.Showtimes.Remove(showtime);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<ShowtimeViewModel>> GetPagedShowtimesAsync(string? searchTerm = null,
        int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var query = _context.Showtimes
            .Include(s => s.Movie)
            .Include(s => s.Cinema)
            .Include(s => s.Hall)
            .Include(s => s.Bookings)
                .ThenInclude(b => b.User)
            .AsQueryable();

        if (!string.IsNullOrEmpty(searchTerm))
        {
            query = query.Where(s =>
                s.Movie.Title.Contains(searchTerm) ||
                s.Cinema.Name.Contains(searchTerm) ||
                s.Hall.Name.Contains(searchTerm));
        }

        query = query.OrderBy(s => s.StartTime)
                     .Skip((pageNumber - 1) * pageSize)
                     .Take(pageSize);

        var showtimes = await query.ToListAsync(cancellationToken);
        return _mapper.Map<IEnumerable<ShowtimeViewModel>>(showtimes);
    }

    public async Task<int> CountShowtimesAsync(string? searchTerm = null, CancellationToken cancellationToken = default)
    {
        var query = _context.Showtimes.AsQueryable();
        if (!string.IsNullOrEmpty(searchTerm))
        {
            query = query.Where(s =>
                s.Movie.Title.Contains(searchTerm) ||
                s.Cinema.Name.Contains(searchTerm) ||
                s.Hall.Name.Contains(searchTerm));
        }
        return await query.CountAsync(cancellationToken);
    }

    public async Task<ShowtimeDetailsViewModel?> GetShowtimeDetailsAsync(int id, CancellationToken cancellationToken = default)
    {
        var showtime = await _context.Showtimes
            .Include(s => s.Movie)
            .Include(s => s.Cinema)
            .Include(s => s.Hall)
            .Include(s => s.Bookings)
                .ThenInclude(b => b.User)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

        if (showtime == null) return null;
        return _mapper.Map<ShowtimeDetailsViewModel>(showtime);
    }

    public async Task<bool> ShowtimeExistsAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Showtimes.AnyAsync(s => s.Id == id, cancellationToken);
    }
}
