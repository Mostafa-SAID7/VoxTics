VoxTics/Areas/Admin/ViewModels/
 ├─ BaseAdminVM.cs                 # يحتوي أي خصائص مشتركة بين كل Admin VMs
 ├─ BasePaginatedFilterVM.cs       # PageNumber, PageSize, SearchTerm, SortBy إلخ
 ├─ AdminDashboardVM.cs
 ├─ BookingVM.cs
 ├─ CinemaVM.cs
 ├─ CategoryVM.cs
 ├─ MovieVM.cs
 ├─ ShowtimeVM.cs
 └─ UserVM.cs


Models/Entities/
     ├─ BaseEntity.cs                  # implements IAuditable
     ├─ IAuditable.cs
     ├─ Actor.cs
     ├─ Booking.cs
     ├─ BookingSeat.cs
     ├─ Category.cs
     ├─ Cinema.cs
     ├─ Hall.cs
     ├─ Movie.cs
     ├─ MovieActor.cs
     ├─ MovieCategory.cs
     ├─ MovieImg.cs
     ├─ Seat.cs
     ├─ Showtime.cs
     ├─ SocialMediaLink
     └─ User.cs
    ViewModels/
     ├─ BaseVM.cs                      # أي خصائص مشتركة (مثل Id, CreatedDate)
     ├─ BasePaginatedFilterVM.cs       # نفس اللي في Admin لكن للـ General
     ├─ BaseMovieVM.cs                 # fields مشتركة بين MovieVM, MovieDetailVM, MovieListVM
     ├─ ActorVM.cs
     ├─ BookingFormVM.cs
     ├─ BookingVM.cs
     ├─ CategoryVM.cs
     ├─ CinemaVM.cs
     ├─ HallVM.cs
     ├─ HomeVM.cs
     ├─ MovieVM.cs
     ├─ MovieDetailVM.cs
     ├─ MovieFilterVM.cs               # يرث من BasePaginatedFilterVM
     ├─ MovieImageVM.cs
     ├─ MovieListVM.cs                 # يرث من BaseMovieVM + BasePaginatedFilterVM
     ├─ SearchResultVM.cs              # Generic Search Result
     ├─ ShowtimeVM.cs
     └─ UserVM.cs
    Enums/
     ├─ MovieStatus.cs
     ├─ BookingStatus.cs
     ├─ NotificationType.cs
     ├─ PaymentStatus.cs
     ├─ SeatType.cs
     ├─ ShowtimeStatus.cs
     ├─ MovieSortBy.cs
     ├─ SortOrder.cs
     ├─ BookingSortBy.cs
     ├─ TimeRange.cs
     └─ UserRole.cs


MappingProfiles/
 ├─ BaseProfile.cs                 # Generic mappings / common mappings
 ├─ BookingProfile.cs
 ├─ CategoryProfile.cs
 ├─ CinemaProfile.cs
 ├─ MovieProfile.cs
 ├─ ShowtimeProfile.cs
 ├─ UserProfile.cs


Helpers/
 ├─ DateTimeExtensions.cs
 ├─ EmailService.cs
 ├─ EnumExtensions.cs
 ├─ FilterBase.cs
 ├─ ImageHelper.cs
 ├─ PaginatedList.cs
 ├─ PriceFormatter.cs
 ├─ SearchHelper.cs
 └─ ValidationHelpers.cs

Data/
 ├─ MovieDbContext.cs
 ├─ DbInitializer.cs           # Seed initial data
 ├─ UnitOfWork.cs              # Optional for repo pattern

