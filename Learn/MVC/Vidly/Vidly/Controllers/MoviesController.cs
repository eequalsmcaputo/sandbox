using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Persistence;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private VidlyContext _context;

        public MoviesController()
        {
            _context = new VidlyContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if(movie == null)
            {
                return Content("No movie with ID " + id.ToString() + " exists.");
            }

            return View(movie);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            // Check that the model data contains validation errors
            if(!ModelState.IsValid)
            {
                // Initialize a new ViewModel for the form
                var viewModel = new ViewModels.MovieFormViewModel
                {
                    // Set the Movie to the object passed in
                    Movie = movie,

                    // Initialize the Genres list from the database
                    Genres = _context.Genres.ToList()
                };

                // Return the MovieForm view with the ViewModel just created
                return View("MovieForm", viewModel);
            }

            if(movie.Id == 0)
            {
                _context.Movies.Add(movie);
            } else
            {
                var movieInDB = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDB.Name = movie.Name;
                movieInDB.GenreId = movie.GenreId;
                movieInDB.ReleaseDate = movie.ReleaseDate;
                movieInDB.DateAdded = movie.DateAdded;
                movieInDB.NumberInStock = movie.NumberInStock;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if(movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ViewModels.MovieFormViewModel
            {
                Genres = _context.Genres.ToList(),
                Movie = movie
            };

            return View("MovieForm", viewModel);
        }

        /*public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

        }*/

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            //return Content("Hello world!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }


        [Route("movies/releated/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year.ToString() + "/" + month.ToString());
        }
    }
}