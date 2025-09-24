﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VoxTics.Services.Interfaces;

namespace VoxTics.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaService _cinemaService;

        public CinemasController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService ?? throw new ArgumentNullException(nameof(cinemaService));
        }

        // ---------------------------
        // GET: /Cinemas
        // ---------------------------
        public async Task<IActionResult> Index()
        {
            try
            {
                var cinemas = await _cinemaService.GetActiveCinemasAsync();
                return View(cinemas);
            }
            catch (Exception ex)
            {
                // Log error if needed
                Console.WriteLine($"[CinemasController.Index] Error: {ex.Message}");
                return StatusCode(500, "An error occurred while loading cinemas.");
            }
        }

        // ---------------------------
        // GET: /Cinemas/Details/5
        // ---------------------------
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var cinema = await _cinemaService.GetCinemaDetailsAsync(id);
                if (cinema == null)
                    return NotFound();

                // Get gallery images
                var images = await _cinemaService.GetCinemaImagesAsync(id);
                ViewBag.Images = images;

                return View(cinema);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CinemasController.Details] Error: {ex.Message}");
                return StatusCode(500, "An error occurred while loading cinema details.");
            }
        }
    }
}
