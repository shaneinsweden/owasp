using Owasp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoShop.Models;

namespace VideoShop.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }

        //GET: Movies/Random
        public ActionResult Random(Movie movie)
        {
            movie.Name = "Braveheart";
            if (movie == null)
            {
                movie = new Movie() { Id = 1, Name = "Braveheart" };
            }
            else if (!string.IsNullOrEmpty(movie.SelectedLanguage))
            {
                movie.Summary = FileUtils.FetchMovieSummary(movie.SelectedLanguage + ".txt", System.Web.HttpContext.Current);
            }

            return View(movie);
        }
    }
}