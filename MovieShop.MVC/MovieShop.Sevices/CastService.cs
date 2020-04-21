using MovieShop.Data;
using MovieShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Sevices
{
    public class CastService :ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService()
        {
            _castRepository = new CastRepository(new MovieShopDbContext());
        }
       

        public Cast GetCastDetails(int castId)
        {
            var cast = _castRepository.GetCastWithMovies(castId);
            return cast;
        }

        public void AddCast(Cast cast)
        {
            _castRepository.Add(cast);
        }
    }
    public interface ICastService
    {
        Cast GetCastDetails(int castId);
        void AddCast(Cast cast);
    }

}
