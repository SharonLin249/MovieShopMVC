using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MovieShop.Entities;

namespace MovieShop.Data.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext context) : base(context)
        {
        }

        public IEnumerable<Movie> GetTopGrossingMovies()
        {
            var movies =  _context.Movies.OrderByDescending(m => m.Revenue).Take(20).ToList();
            return movies;
        }

        public IEnumerable<Movie> GetMoviesByGenre(int genreId)
        {
            return _context.Genres.Where(g => g.Id == genreId).SelectMany(m => m.Movies).ToList();
        }

        public override Movie GetById(int id)
        {
            var movie = _context.Movies.Include(m => m.MovieCasts.Select(c => c.Cast)).Include(m => m.Genres)
                                .FirstOrDefault(m => m.Id == id);
            if (movie == null) return null;
            var movieRating = _context.Reviews.Where(r => r.MovieId == id).Average(r => r.Rating);
            if (movieRating > 0) movie.Rating = Math.Ceiling(movieRating * 100) / 100;
            return movie;
        }
    }

    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Movie> GetTopGrossingMovies();
        IEnumerable<Movie> GetMoviesByGenre(int genreId);
    }
}

   
