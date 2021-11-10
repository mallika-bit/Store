using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Models;
using Store.ViewModels;


namespace Store.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Movie
        public ViewResult Index()
        {
            List<Movie> movies = _context.Movies.Include(m => m.Genres).ToList(); 

             return View(movies);

            
        }

        public ActionResult MovieDetails(int id)
        {
            var movieDetails = _context.Movies.SingleOrDefault(m=>m.Id == id);

            return  View(movieDetails);
        }
        public ActionResult NewMovie()
        {
            var genres = _context.Genres.ToList();
            var movieviewmodel = new NewMovieViewModel()
            {
                Movie = new Movie(),
                Genres = genres         //here Genres from viewmodel
            };


            return View("NewMovie", movieviewmodel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new NewMovieViewModel { 
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return View("NewMovie",viewmodel);

            }
            if(movie.Id == 0)
            {
                _context.Movies.Add(movie);

            }
            else
            {
                var movieInDb = _context.Movies.Single(m=>m.Id == movie.Id);

                movieInDb.Id = movie.Id;
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.GenresId = movie.GenresId;
                movieInDb.NumbersInStock = movie.NumbersInStock;

            }
           
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            var moviemodel = new NewMovieViewModel {

                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("NewMovie", moviemodel);
        }

    }
}