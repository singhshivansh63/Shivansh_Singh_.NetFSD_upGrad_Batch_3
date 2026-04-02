using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Services.Interfaces;

namespace MovieApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetAll());
        }

        public IActionResult Details(int id)
        {
            var movie = _service.GetById(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _service.Create(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        public IActionResult Edit(int id)
        {
            var movie = _service.GetById(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _service.Edit(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        public IActionResult Delete(int id)
        {
            var movie = _service.GetById(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}