---
name: VoxTics booking flow
description: How the booking system works end-to-end, key decisions, and gotchas.
---

## Entry point
`moviedetails.js` → BookingFlowModule → redirects to `/Bookings/Create?showtimeId=X` (NOT movieId).
`BookingsController.Create(int showtimeId)` is the GET action — must accept showtimeId, not movieId.

## Data flow
1. Controller calls `IShowtimeService.GetShowtimeByIdAsync(showtimeId)` — this now includes Movie, Cinema, Hall.ThenInclude(Seats).
2. Controller builds `BookingCreateVM` with display fields + `List<SeatOptionVM>` (seats from Hall).
3. View renders a visual seat grid grouped by Row; clicking seats appends hidden `<input name="SeatIds">` via JS.
4. `booking-create.js` updates hidden inputs `TotalAmount` and `FinalAmount` on change (they are posted back as hidden inputs, NOT displayed spans).
5. POST → `BookingService.CreateBookingAsync` → sets Status = Confirmed immediately + calls `ReserveSeatAsync` to decrement AvailableSeats.
6. Redirects to `Bookings/Details/{id}`.

## Repository includes required
- `GetUserBookingsAsync`: `.Include(Showtime).ThenInclude(Movie)` + `.ThenInclude(Cinema)`
- `GetBookingDetailsAsync`: same + `.Include(BookingSeats).ThenInclude(Seat)`

## AutoMapper — BookingProfile fixes
- `Booking → BookingListVM`: must map MovieTitle from `Showtime.Movie.Title`, CinemaName from `Showtime.Cinema.Name`, PaymentStatus from `Payments` collection (null-safe).
- `Booking → BookingDetailsVM`: same as above, plus HallName, ShowtimeDuration, PaymentMethod, MovieMainImage.

## PaymentMethod enum values
`Undefined=0, CreditCard=1, Paypal=2, Stripe=3, Cash=4` — radio inputs must use integer values `(int)PaymentMethod.X`.

## Seat entity
`Seat.SeatNumber`, `Seat.Row`, `Seat.NumberInRow`, `Seat.Type` (SeatType enum), `Seat.IsAvailable`, `Seat.IsActive`.
Seats come from `showtime.Hall.Seats` — filter by `IsActive`, group by `Row`, order by `NumberInRow`.

**Why:** Original code looped `for (int i = 1; i <= Model.SeatPrice; i++)` — used price value as loop count.
