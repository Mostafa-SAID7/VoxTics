using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoxTics.Data;
using VoxTics.Helpers; // for PaginatedList<T>
using VoxTics.Models.Enums;
using VoxTics.Models.ViewModels;
using VoxTics.Services.Interfaces;

namespace VoxTics.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _service;
        public MoviesController(IMovieService service) => _service = service;

        public async Task<IActionResult> Index()
        {
            var movies = await _service.GetWithCategoriesAsync();
            return View(movies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _service.GetByIdAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }
    }
}
