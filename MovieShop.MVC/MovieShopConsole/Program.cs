using MovieShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Data.Repositories;
using MovieShop.Sevices;

namespace MovieShopConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var db = new MovieShopDbContext())
            //{
            //    //var genres = db.Genres.ToList();
            //    // var movies = db.Movies.ToList().Where(m => m.Title.StartsWith("a")).ToList();
            //}
            var movieService = new MovieService();
            //var genreService = new GenreSevice();


            var movie = movieService.GetMovieDetails(1);
            Console.WriteLine(movie.Id + movie.Title);
            Console.ReadLine();
        }
    }
}
