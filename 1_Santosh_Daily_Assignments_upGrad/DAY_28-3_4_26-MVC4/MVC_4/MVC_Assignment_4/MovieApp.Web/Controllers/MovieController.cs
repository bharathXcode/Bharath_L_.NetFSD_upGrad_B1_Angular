using Microsoft.AspNetCore.Mvc;
using MovieApp.Business;
using MovieApp.Data.Models;

namespace MovieApp.Web.Controllers
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
            var movies= _service.GetMovies();
            return View(movies);
        }
        public IActionResult Details(int Id)
        {
            var movie=_service.GetMovieById(Id);
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
                _service.AddMovie(movie);
                return RedirectToAction("Index");

            }

            return View(movie);
            
        }
        public IActionResult Edit(int Id)
        {
            var movie = _service.GetMovieById(Id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateMovie(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        public IActionResult Delete(int Id)
        {
            var movie= _service.GetMovieById(Id);
            return View(movie);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConform(int Id)
        {
            _service.DeleteMovie(Id);
            return RedirectToAction("Index");
        }
    }
}
