using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using VoxTics.Models.Enums.Sorting;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShowtimesController : Controller
    {
        private readonly IShowtimeRepository _showtimeRepo;
        private readonly IMovieRepository _movieRepo;
        private readonly ICinemaRepository _cinemaRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<ShowtimesController> _logger;

        public ShowtimesController(
            IShowtimeRepository showtimeRepo,
            IMovieRepository movieRepo,
            ICinemaRepository cinemaRepo,
            IMapper mapper,
            ILogger<ShowtimesController> logger)
        {
            _showtimeRepo = showtimeRepo;
            _movieRepo = movieRepo;
            _cinemaRepo = cinemaRepo;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: Admin/Showtimes
        public async Task<IActionResult> Index(string? searchTerm = null, int page = 1, int pageSize = 10,
            string? sortBy = "starttime", SortOrder sortOrder = SortOrder.Asc)
        {
            try
            {
                var filter = new BasePaginatedFilterVM
                {
                    PageNumber = page,
                    PageSize = pageSize,
                    SearchTerm = searchTerm,
                    SortBy = sortBy,
                    SortOrder = sortOrder
                };

                var (showtimes, totalCount) = await _showtimeRepo.GetPagedShowtimesAsync(filter);

                var vmList = showtimes.Select(s => new ShowtimeViewModel
                {
                    Id = s.Id,
                    MovieId = s.MovieId,
                    MovieTitle = s.Movie?.Title ?? string.Empty,
                    CinemaName = s.Hall?.Cinema?.Name ?? string.Empty,
                    HallId = s.HallId,
                    HallName = s.Hall?.Name ?? string.Empty,
                    ShowDateTime = s.StartTime,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    Price = s.Price,
                    Status = s.Status,
                    IsActive = s.Status == ShowtimeStatus.Active,
                    CreatedAt = s.CreatedAt,
                    UpdatedAt = s.UpdatedAt,
                    BookingCount = s.Bookings?.Count ?? 0,
                    TotalSeats = s.Hall?.Seats?.Count ?? 0,
                    BookedSeats = s.Bookings?.Sum(b => b.NumberOfTickets) ?? 0
                }).ToList();

                ViewBag.TotalCount = totalCount;
                ViewBag.PageNumber = page;
                ViewBag.PageSize = pageSize;
                ViewBag.SearchTerm = searchTerm;
                ViewBag.SortBy = sortBy;
                ViewBag.SortOrder = sortOrder;

                return View(vmList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading showtimes index");
                TempData["Error"] = "Error loading showtimes";
                return View(new List<ShowtimeViewModel>());
            }
        }

        // GET: Admin/Showtimes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var showtime = await _showtimeRepo.GetShowtimeWithDetailsAsync(id);
                if (showtime == null)
                {
                    if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                        return Json(new { success = false, message = "Showtime not found" });

                    return NotFound();
                }

                var vm = new ShowtimeViewModel
                {
                    Id = showtime.Id,
                    MovieId = showtime.MovieId,
                    MovieTitle = showtime.Movie?.Title ?? string.Empty,
                    CinemaName = showtime.Hall?.Cinema?.Name ?? string.Empty,
                    HallId = showtime.HallId,
                    HallName = showtime.Hall?.Name ?? string.Empty,
                    ShowDateTime = showtime.StartTime,
                    StartTime = showtime.StartTime,
                    EndTime = showtime.EndTime,
                    Price = showtime.Price,
                    Status = showtime.Status,
                    TotalSeats = showtime.Hall?.Seats?.Count ?? 0,
                    BookedSeats = showtime.Bookings?.Sum(b => b.NumberOfTickets) ?? 0,
                    BookingCount = showtime.Bookings?.Count ?? 0,
                    CreatedAt = showtime.CreatedAt,
                    UpdatedAt = showtime.UpdatedAt
                };

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    return PartialView("_DetailsPartial", vm);

                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading showtime details for id {Id}", id);
                TempData["Error"] = "Error loading showtime details";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Admin/Showtimes/Create
        public async Task<IActionResult> Create()
        {
            var vm = new ShowtimeViewModel
            {
                ShowDateTime = DateTime.UtcNow.AddDays(1),
                StartTime = DateTime.UtcNow.AddDays(1),
                EndTime = DateTime.UtcNow.AddDays(1).AddHours(2),
                Price = 0m,
                Status = ShowtimeStatus.Active
            };

            await PopulateDropdownsAsync(vm);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("_Create", vm);

            return View(vm);
        }

        // POST: Admin/Showtimes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShowtimeViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await PopulateDropdownsAsync(vm);
                    return View(vm);
                }

                // Determine start and end times - prefer StartTime/EndTime if provided
                var start = vm.StartTime != default ? vm.StartTime : vm.ShowDateTime;
                var end = vm.EndTime != default ? vm.EndTime : start.AddHours(2);

                // Ensure end > start
                if (end <= start)
                {
                    ModelState.AddModelError("", "End time must be after start time.");
                    await PopulateDropdownsAsync(vm);
                    return View(vm);
                }

                // check time-slot availability
                var available = await _showtimeRepo.IsTimeSlotAvailableAsync(vm.HallId, start, end, null);
                if (!available)
                {
                    ModelState.AddModelError("", "Time slot conflicts with existing showtime.");
                    await PopulateDropdownsAsync(vm);
                    return View(vm);
                }

                var showtime = new Showtime
                {
                    MovieId = vm.MovieId,
                    HallId = vm.HallId,
                    StartTime = start,
                    Price = vm.Price,
                    Status = vm.Status,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                await _showtimeRepo.AddAsync(showtime);
                await _showtimeRepo.SaveChangesAsync();

                _logger.LogInformation("Showtime created (Id: {Id})", showtime.Id);

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    return Json(new { success = true, message = "Showtime created", showtimeId = showtime.Id });

                TempData["Success"] = "Showtime created";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating showtime");
                ModelState.AddModelError("", "Error creating showtime");
                await PopulateDropdownsAsync(vm);
                return View(vm);
            }
        }

        // GET: Admin/Showtimes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var showtime = await _showtimeRepo.GetByIdAsync(id);
                if (showtime == null) return NotFound();

                var vm = new ShowtimeViewModel
                {
                    Id = showtime.Id,
                    MovieId = showtime.MovieId,
                    HallId = showtime.HallId,
                    ShowDateTime = showtime.StartTime,
                    StartTime = showtime.StartTime,
                    EndTime = showtime.EndTime,
                    Price = showtime.Price,
                    Status = showtime.Status,
                    CreatedAt = showtime.CreatedAt,
                    UpdatedAt = showtime.UpdatedAt
                };

                await PopulateDropdownsAsync(vm);

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    return PartialView("_Edit", vm);

                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading edit form for showtime id {Id}", id);
                TempData["Error"] = "Error loading edit form";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Admin/Showtimes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ShowtimeViewModel vm)
        {
            if (id != vm.Id) return BadRequest();

            try
            {
                if (!ModelState.IsValid)
                {
                    await PopulateDropdownsAsync(vm);
                    return View(vm);
                }

                var existing = await _showtimeRepo.GetByIdAsync(id);
                if (existing == null) return NotFound();

                var start = vm.StartTime != default ? vm.StartTime : vm.ShowDateTime;
                var end = vm.EndTime != default ? vm.EndTime : start.AddHours(2);

                if (end <= start)
                {
                    ModelState.AddModelError("", "End time must be after start time.");
                    await PopulateDropdownsAsync(vm);
                    return View(vm);
                }

                var available = await _showtimeRepo.IsTimeSlotAvailableAsync(vm.HallId, start, end, id);
                if (!available)
                {
                    ModelState.AddModelError("", "Time slot conflicts with existing showtime.");
                    await PopulateDropdownsAsync(vm);
                    return View(vm);
                }

                // Map updated fields
                existing.MovieId = vm.MovieId;
                existing.HallId = vm.HallId;
                existing.StartTime = start;
                existing.Price = vm.Price;
                existing.Status = vm.Status;
                existing.UpdatedAt = DateTime.UtcNow;

                await _showtimeRepo.UpdateAsync(existing);
                await _showtimeRepo.SaveChangesAsync();

                _logger.LogInformation("Showtime updated (Id: {Id})", id);

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    return Json(new { success = true, message = "Showtime updated" });

                TempData["Success"] = "Showtime updated";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating showtime id {Id}", id);
                ModelState.AddModelError("", "Error updating showtime");
                await PopulateDropdownsAsync(vm);
                return View(vm);
            }
        }

        // GET: Admin/Showtimes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var showtime = await _showtimeRepo.GetByIdWithIncludesAsync(id, s => s.Movie, s => s.Hall);
            if (showtime == null) return NotFound();

            var vm = new ShowtimeViewModel
            {
                Id = showtime.Id,
                MovieId = showtime.MovieId,
                MovieTitle = showtime.Movie?.Title ?? string.Empty,
                HallId = showtime.HallId,
                HallName = showtime.Hall?.Name ?? string.Empty,
                CinemaName = showtime.Hall?.Cinema?.Name ?? string.Empty,
                ShowDateTime = showtime.StartTime,
                Price = showtime.Price,
                Status = showtime.Status
            };

            return View(vm);
        }

        // POST: Admin/Showtimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var existing = await _showtimeRepo.GetByIdAsync(id);
                if (existing == null) return NotFound();

                await _showtimeRepo.DeleteAsync(existing);
                await _showtimeRepo.SaveChangesAsync();

                _logger.LogInformation("Showtime deleted (Id: {Id})", id);

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    return Json(new { success = true, message = "Showtime deleted" });

                TempData["Success"] = "Showtime deleted";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting showtime id {Id}", id);
                TempData["Error"] = "Error deleting showtime";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Admin/Showtimes/ToggleStatus/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            try
            {
                var showtime = await _showtimeRepo.GetByIdAsync(id);
                if (showtime == null) return Json(new { success = false, message = "Showtime not found" });

                showtime.Status = showtime.Status == ShowtimeStatus.Active ? ShowtimeStatus.Cancelled : ShowtimeStatus.Active;
                showtime.UpdatedAt = DateTime.UtcNow;

                await _showtimeRepo.UpdateAsync(showtime);
                await _showtimeRepo.SaveChangesAsync();

                return Json(new { success = true, message = "Status updated", newStatus = showtime.Status.ToString() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error toggling showtime status for id {Id}", id);
                return Json(new { success = false, message = "Error updating status" });
            }
        }

        #region Helpers

        private async Task PopulateDropdownsAsync(ShowtimeViewModel vm)
        {
            var movies = await _movieRepo.GetAllAsync();
            vm.Movies = movies.Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.Title,
                Selected = vm.MovieId == m.Id
            }).ToList();

            var cinemas = await _cinemaRepo.GetAllAsync();
            vm.Cinemas = cinemas.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
                Selected = vm.CinemaId == c.Id
            }).ToList();

           
        }

        #endregion
    }
}
