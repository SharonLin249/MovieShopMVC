using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Data;
using MovieShop.Entities;
using MovieShop.Services;
using MovieShop.Sevices;
using MovieShop.Data.Repositories;
using System.Linq.Expressions;
using Moq;

namespace MovieShop.UnitTests
{
    [TestClass]
    public class MovieServiceUnitTest
    {
        // System Under Test
        private MovieService _sut;
        private List<Movie> _fakeMovies;
        private readonly Mock<IMovieRepository> _mockMovieRepository;

        public MovieServiceUnitTest()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
            _sut = new MovieService(_mockMovieRepository.Object);
        }

        [TestInitialize]
        //call(triggered) before every testcase
        public void TestInitialize()
        {
            _fakeMovies = new List<Movie>
            {
                new Movie
                          {
                              Id = 1,
                              Title = "TestMovie1",
                              Budget = 25000,
                          },
                          new Movie
                          {
                              Id = 2,
                              Title = "TestMovie2",
                              Budget = 25000,
                          },
                          new Movie
                          {
                              Id = 3,
                              Title = "TestMovie3",
                              Budget = 25000,
                          },
                          new Movie
                          {
                              Id = 4,
                              Title = "TestMovie4",
                              Budget = 25000,
                          },
                          new Movie
                          {
                               Id = 5,
                              Title = "TestMovie5",
                              Budget = 25000,
                          }
            };
            //using moq we are going to set up mock methods for IMovieRepository
            _mockMovieRepository.Setup(m => m.GetTopGrossingMovies()).Returns(_fakeMovies);
            _mockMovieRepository.Setup(m => m.GetById(It.IsAny<int>())).Returns((int id) => _fakeMovies.FirstOrDefault(x => x.Id == id));

        }
        
        [TestMethod]
        public void Test_For_TopGrossingMovies_From_FakeData()
        {
            //act
            var topMovies = _sut.GetTopGrossingMovies();

            //assert
            // you can do multiple asserts in one unit test method

            //checking topMovies is not null
            Assert.IsNotNull(topMovies);

            //check totalnumber of movies equal to 5
            Assert.AreEqual(5, topMovies.Count());


            //check the return type
            CollectionAssert.AllItemsAreInstancesOfType(topMovies.ToList(), typeof(Movie));
        }
        [TestMethod]
        public void Test_For_GetMovieDetails()
        {
            int id = 1;
            var movieDetails = _sut.GetMovieDetails(id);

            Assert.IsNotNull(movieDetails);

            Assert.AreEqual(movieDetails.Id, id);
            
            Assert.AreEqual(movieDetails.Title, "TestMovie1");

            Assert.IsInstanceOfType(movieDetails, typeof(Movie));





        }
        //new Unit test 
     }
    //public class FakeMovieRepository : IMovieRepository
    //{
    //    private List<Movie> _fakeMovies;
    //    public void Add(Movie entity)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public void Delete(Movie entity)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public void Delete(Expression<Func<Movie, bool>> where)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public Movie Get(Expression<Func<Movie, bool>> where)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public IEnumerable<Movie> GetAll()
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public Movie GetById(int id)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public IEnumerable<Movie> GetMany(Expression<Func<Movie, bool>> where)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public IEnumerable<Movie> GetMoviesByGenre(int genreId)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public IEnumerable<Movie> GetTopGrossingMovies()
    //    {
    //        // Instead of using Database we need to return fake movies from memory
    //        _fakeMovies = new List<Movie>
    //        {
    //            new Movie
    //                      {
    //                          Id = 1,
    //                          Title = "TestMovie1",
    //                          Budget = 25000,
    //                      },
    //                      new Movie
    //                      {
    //                          Id = 2,
    //                          Title = "TestMovie2",
    //                          Budget = 25000,
    //                      },
    //                      new Movie
    //                      {
    //                          Id = 3,
    //                          Title = "TestMovie3",
    //                          Budget = 25000,
    //                      },
    //                      new Movie
    //                      {
    //                          Id = 4,
    //                          Title = "TestMovie4",
    //                          Budget = 25000,
    //                      },
    //                      new Movie
    //                      {
    //                          Id = 5,
    //                          Title = "TestMovie5",
    //                          Budget = 25000,
    //                      }
    //        };
    //        return _fakeMovies;
    //    }
    //    public void Update(Movie entity)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}