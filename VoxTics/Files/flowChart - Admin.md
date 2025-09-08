                       ┌───────────────────────────────┐
                       │         Controller           │
                       │      MoviesController        │
                       │-----------------------------│
                       │ Actions: Index / Details      │
                       │          Create              │
                       │          Edit                │
                       │          Delete              │
                       └───────────────┬───────────────┘
                                       │
           ┌───────────────────────────┴───────────────────────────┐
           │                           Service                      │
           │---------------------------│---------------------------│
           │ MovieService                                       │
           │---------------------------│---------------------------│
           │ - Index/Details: Gets IQueryable<Movie>            │
           │   → Applies Helpers: Filter/Search/Sort/Pagination│
           │   → AutoMapper: Movie → MovieListVM/DetailsVM     │
           │ - Create: Validates MovieCreateVM                 │
           │   → Maps VM → Entity via AutoMapper               │
           │   → Calls Repository.AddAsync(entity)             │
           │ - Edit: Validates MovieEditVM                     │
           │   → Maps VM → Existing Entity                     │
           │   → Calls Repository.UpdateAsync(entity)          │
           │ - Delete: Calls Repository.DeleteAsync(id)        │
           └───────────────┬───────────────┘
                           │
           ┌───────────────▼───────────────┐
           │          Repository           │
           │      MovieRepository          │
           │-------------------------------│
           │ - GetAllWithIncludesAsync      │
           │ - GetByIdWithIncludesAsync     │
           │ - AddAsync                     │
           │ - UpdateAsync                  │
           │ - DeleteAsync                  │
           │ - CRUD operations              │
           └───────────────┬───────────────┘
                           │
           ┌───────────────▼───────────────┐
           │           DbContext           │
           │       MovieDbContext          │
           │-------------------------------│
           │ - DbSet<Movie>                 │
           │ - DbSet<Category>              │
           │ - DbSet<Actor>                 │
           │ - DbSet<Showtime>              │
           └───────────────┬───────────────┘
                           │
           ┌───────────────▼───────────────┐
           │          Database             │
           │ Movies, Categories, Actors…  │
           └──────────────────────────────┘
