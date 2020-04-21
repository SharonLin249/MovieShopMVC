using MovieShop.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Data
{
    public class CastRepository : Repository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext context) : base(context)
        {
        }

        public Cast GetCastWithMovies(int castId)
        {
            var cast = _context.Casts.Where(c => c.Id == castId)
                .Include(c => c.MovieCasts.Select(m => m.Movie)).FirstOrDefault();
            return cast;
        }
        public override void Add(Cast cast)
        {
            _context.Casts.Add(cast);
            _context.SaveChanges();
        }
    }


    public interface ICastRepository : IRepository<Cast>
    {
        Cast GetCastWithMovies(int castId);
    }
}
