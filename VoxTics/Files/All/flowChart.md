                       ┌───────────────────────┐
                       │      Controller       │
                       │  MoviesController     │
                       │                       │
                       │ Action: Index/Details │
                       └──────────┬────────────┘
                                  │
                                  ▼
                       ┌───────────────────────┐
                       │       Service         │
                       │    MovieService       │
                       │                       │
                       │ - يحصل على IQueryable<Movie> من Repo
                       │ - يطبق Helpers:       │
                       │   • FilterBase        │
                       │   • SearchHelper      │
                       │   • Pagination        │
                       │ - يستخدم AutoMapper   │
                       │   لتحويل Movie → VM   │
                       └──────────┬────────────┘
                                  │
                                  ▼
                       ┌───────────────────────┐
                       │      Repository       │
                       │   MovieRepository     │
                       │                       │
                       │ - GetAllWithIncludes  │
                       │ - GetByIdWithIncludes │
                       │ - CRUD operations     │
                       └──────────┬────────────┘
                                  │
                                  ▼
                       ┌───────────────────────┐
                       │       DbContext       │
                       │    MovieDbContext     │
                       │                       │
                       │ - DbSet<Movie>        │
                       │ - DbSet<Category>     │
                       │ - DbSet<Actor>        │
                       │ - DbSet<Showtime>     │
                       └──────────┬────────────┘
                                  │
                                  ▼
                       ┌───────────────────────┐
                       │      Database         │
                       │ Movies, Categories,   │
                       │ Actors, Showtimes...  │
                       └───────────────────────┘
