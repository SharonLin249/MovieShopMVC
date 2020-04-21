using System.Linq;
using System.Web.Mvc;
using MovieShop.Entities;
using MovieShop.Sevices;
// using X.PagedList;

namespace MovieShopMVC.Controllers
{
    //DI with Contructor Injection
    [RoutePrefix("movies")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        //MVC 5 requires Parameterless Constructor
        // For IMovieService movieService, we need to inject an implementation
        //we can pass any object/instance that implements IMovieService interface
        //In our project Movie Service class is implemetning IMovieService Interface
        //IOC should inject instance of  MovieService fro Constructor
        //.Net  Framework there are no buildt-in IOC, we need to download 3rd party IOC'S
        //Popular 3rd party IOC's like Ninject, Autofac, Unity etc
        //in .NET Core or ASP.NET Core Dependency Injection in builtin, no need 3rd party
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        [HttpGet]
     
        public ActionResult Index()
            
        {
            // call service layer to get top 20 recenue movies
            //routing 
            //all url's always map to vies
            //ActionResult method needs to return View
            //every http request always go to controlelr first, then action methods needs to return to view
            var movies = _movieService.GetTopGrossingMovies(); //movie is a object model, is a list, but base type in the c#

            return View(movies);
        }



        //[Route("details/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _movieService.GetMovieDetails(id);
            return View(movie);
        }

        [Route("genre/{genreId}")]
        public ActionResult Genre(int genreId)
        {
            var movies = _movieService.GetMoviesByGenre(genreId).OrderBy(m => m.Title).ToList();
            return View("MoviesByGenre", movies);
        }


        [HttpPost]
        [Route("create")]
        public ActionResult Create(Movie movie)
        {

            return View("Index");
        }

        //take genre id from url aand then call movie service to get the list of movies belong to the genre
        //return movies to the view and display as Imagetags insode the bootstrap card with image urls as 
        //posterUrl form Movie table column
        //create getMoviesByGenre(int genreId) inside IMovieService call Movies Repo to get movies of that gene
    }
}
