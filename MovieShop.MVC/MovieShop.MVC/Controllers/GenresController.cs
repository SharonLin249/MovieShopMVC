using MovieShop.Services;
using MovieShop.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class GenresController : Controller
    {
        IGenreService _genreService;
        // GET: Genres
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        public PartialViewResult Index()
        {
            return PartialView("GenresView", _genreService.GetAllGenres().OrderBy(g => g.Name).ToList());
        }
    }
}