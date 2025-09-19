VoxTics/Areas/Admin/ViewModels/
 ├─ BaseAdminVM.cs                
 ├─ AdminDashboardVM.cs
 ├─ BookingVM.cs
 ├─ CinemaVM.cs
 ├─ CategoryVM.cs
 ├─ MovieVM.cs
 ├─ ShowtimeVM.cs
 └─ UserVM.cs


VoxTics/Models/Entities/
     ├─ Actor.cs
     ├─ BaseEntity.cs                 
     ├─ Booking.cs
     ├─ BookingSeat.cs
     ├─ Cart.cs
     ├─ CartItem.cs
     ├─ Category.cs
     ├─ Cinema.cs
     ├─ Hall.cs
     ├─ Movie.cs
     ├─ MovieActor.cs
     ├─ MovieCategory.cs
     ├─ MovieImg.cs
     ├─ Notification.cs
     ├─ Payment.cs
     ├─ Seat.cs
     ├─ Showtime.cs
     ├─ SocialMediaLink
     └─ UserMovieWatchlist
     └─ Watchlist.cs
        WatchlistItem.cs
    Enums/
        /Notifications
            NotificationType.cs
        /Sorting
            ActorSortBy.cs
            CategorySortBy.cs
            CinemaSortBy.cs
            HallSortBy.cs
            ShowtimeSortBy
            MovieSortBy.cs
            SortOrder.cs
            BookingSortBy.cs
        /TimeRange
            TimeOfDayRange.cs
            TimeRange.cs
     ├─ BookingStatus.cs
     ├─ MovieStatus.cs
     ├─ PaymentStatus.cs
     ├─ SeatType.cs
     ├─ ShowtimeStatus.cs

   ViewModels/
     ├─ BaseVM.cs                      
     ├─ BasePaginatedFilterVM.cs       
     ├─ BaseMovieVM.cs                 
     ├─ ActorVM.cs
     ├─ BookingFormVM.cs
     ├─ BookingVM.cs
     ├─ CategoryVM.cs
     ├─ CinemaVM.cs
     ├─ HallVM.cs
     ├─ HomeVM.cs
     ├─ MovieVM.cs
     ├─ MovieDetailVM.cs
     ├─ MovieFilterVM.cs               
     ├─ MovieImageVM.cs
     ├─ MovieListVM.cs                
     ├─ SearchResultVM.cs             
     ├─ ShowtimeVM.cs
     └─ UserVM.cs

MappingProfiles/
 ├─ BaseProfile.cs                 # Generic mappings / common mappings
 ├─ BookingProfile.cs
 ├─ CategoryProfile.cs
 ├─ CinemaProfile.cs
 ├─ MovieProfile.cs
 ├─ ShowtimeProfile.cs
 ├─ UserProfile.cs




Data/
 ├─ MovieDbContext.cs
 ├─ Seeds/         
 ├─ UoW/
 ├─     IUnitOfwork.cs
        UnitOfWork.cs


