                       ┌─────────────────────┐
                       │     BaseEntity      │
                       │  + Id : int         │
                       │  + CreatedAt : Date │
                       │  + UpdatedAt : Date │
                       └─────────▲───────────┘
                                 │
                       ┌─────────────────────┐
                       │       Movie         │
                       │ - Title : string    │
                       │ - Description : str │
                       │ - Director : string │
                       │ - ReleaseDate : Date│
                       │ - Duration : int    │
                       │ - Price : decimal   │
                       │ - Rating : decimal  │
                       │ - Language : string │
                       │ - Country : string? │
                       │ - AgeRating : string│
                       │ - ImageUrl : string?│
                       │ - IsFeatured : bool │
                       │ - Status : Enum     │
                       │ - ShortDescription  │
                       └─────────┬───────────┘
                                 │
         ┌───────────────────────┼─────────────────────────┐
         │                       │                         │
 ┌───────▼────────┐       ┌──────▼─────────┐       ┌───────▼────────┐
 │ MovieCategory   │       │ MovieActor     │       │   MovieImg     │
 └─────────────────┘       └────────────────┘       └────────────────┘


━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
         Repository Layer (Data Access)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

 ┌───────────────────────────────┐
 │     IBaseRepository<T>        │   (Generic CRUD)
 │ + GetByIdAsync(id)            │
 │ + GetAllAsync(term)           │
 │ + AddAsync(entity)            │
 │ + UpdateAsync(entity)         │
 │ + DeleteAsync(id/entity)      │
 └───────────────▲───────────────┘
                 │
 ┌────────────────────────────────────────────┐
 │         IMovieRepository : IBaseRepo<Movie> │
 │ + GetMovieCountByStatusAsync(status)        │
 │ + GetMoviesForAdminAsync(includeDeleted)    │
 │ + GetFeaturedMoviesAsync(take)              │
 │ + GetAllWithIncludesAsync(includeDeleted)   │
 │ + GetPagedMoviesAsync(search,sort,...)      │
 │ + GetAllCategories()                        │
 └─────────────────▲───────────────────────────┘
                   │
 ┌─────────────────┴───────────────────────────┐
 │           MovieRepository                    │
 │ (implements IMovieRepository, BaseRepo)      │
 └──────────────────────────────────────────────┘


━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
         Service Layer (Business Logic)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

 ┌─────────────────────────┐
 │      MovieService       │
 │ - _repo : IMovieRepo    │
 │ + CreateMovie(vm)       │
 │ + UpdateMovie(vm)       │
 │ + GetMovieDetails(id)   │
 │ + GetFeaturedMovies()   │
 │ + SearchMovies(...)     │
 └─────────────────────────┘


━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
         ViewModels (Presentation Layer)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

 ┌────────────────────────────────────┐
 │ MovieCreateEditViewModel           │
 │ - Title, Description, Director...  │
 └────────────────────────────────────┘

 ┌────────────────────────────────────┐
 │ MovieListItemViewModel             │
 │ - Id, Title, ReleaseDate, Status   │
 └────────────────────────────────────┘

 ┌────────────────────────────────────┐
 │ MovieCategoryViewModel             │
 └────────────────────────────────────┘

 ┌────────────────────────────────────┐
 │ MovieActorViewModel                │
 └────────────────────────────────────┘

 ┌────────────────────────────────────┐
 │ MovieImgViewModel                  │
 └────────────────────────────────────┘
   ┌─────────────────────┐                  ┌────────────────────────────────────┐
   │       Movie         │                  │ MovieCreateEditViewModel           │
   │  (Entity)           │   AutoMapper     │  (ViewModel)                       │
   └─────────┬───────────┘ <------------->  └────────────────────────────────────┘
             │                                  │
             │                                  │
             ▼                                  ▼
   ┌─────────────────────┐                  ┌────────────────────────────────────┐
   │   MovieProfile      │  (Mapping Layer) │ MovieListItemViewModel             │
   │ - CreateMap<Movie,MovieCreateEditVM>   │ - Id, Title, ReleaseDate, Status   │
   │ - CreateMap<Movie,MovieListItemVM>     └────────────────────────────────────┘
   └─────────────────────┘


 sequenceDiagram
    actor Admin as Admin (User)
    participant Controller as MovieController
    participant Service as MovieService
    participant Repo as MovieRepository
    participant DB as Database

    Admin ->> Controller: POST /Admin/Movies/Create (MovieCreateEditViewModel)
    Controller ->> Service: CreateMovie(vm)
    Service ->> Repo: AddAsync(Movie entity)
    Repo ->> DB: INSERT INTO Movies (...)
    DB -->> Repo: New Movie Id
    Repo -->> Service: Movie entity (with Id)
    Service -->> Controller: Success (Movie created)
    Controller -->> Admin: Redirect to Movies List

    sequenceDiagram
    actor Admin as Admin (User)
    participant Controller as MovieController
    participant Service as MovieService
    participant Repo as MovieRepository
    participant DB as Database
    participant Helper as SearchHelper + PaginatedList

    Admin ->> Controller: GET /Admin/Movies?search="Action"&page=2
    Controller ->> Service: GetPagedMoviesAsync(search, sort, filters, page)
    Service ->> Repo: GetPagedMoviesAsync(search, sort, filters, page)

    Note over Repo,DB: Build EF Query with Includes + Filters
    Repo ->> DB: SELECT * FROM Movies WHERE Title LIKE '%Action%' ORDER BY ReleaseDate OFFSET 10 ROWS FETCH NEXT 10 ROWS ONLY
    DB -->> Repo: List<Movie> (paged data)

    Repo -->> Service: Paged Movies
    Service ->> Helper: Map Movies -> MovieListItemViewModel
    Helper -->> Service: PaginatedList<MovieListItemViewModel>

    Service -->> Controller: PagedResult (ViewModels + Metadata)
    Controller -->> Admin: Render Movies List (page 2 with results)
