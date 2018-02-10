using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommSec.Api.Movie.Controllers;
using Moq;
using CommSec.Api.Movie.Repository;
using MoviesLibrary;
using System.Collections.Generic;

namespace CommSec.Api.Movie.Tests
{
    [TestClass]
    public class SampleTest
    {
        Mock<IMovieRepo> mockMovieRepo;
        List<MovieData>  mockMovieList = new List<MovieData> {
            new MovieData() { Title = "The Simpsons Movie", Cast = new string[] { "Cast1_1", "Cast1_2", "Cast1_3", "Cast1_4" }, Classification = "R", MovieId = 1, Genre = "G1", Rating = 12, ReleaseDate = 2010 },
            new MovieData() { Title = "Warm Bodies", Cast = new string[] { "Cast2_1", "Cast2_2", "Cast2_3", "Cast2_4" }, Classification = "PG-12", MovieId = 2, Genre = "G3", Rating = 2, ReleaseDate = 2011 },
            new MovieData() { Title = "World War Z", Cast = new string[] { "Cast3_1", "Cast3_2", "Cast3_3", "Cast3_4" }, Classification = "A", MovieId = 3, Genre = "G2", Rating = 18, ReleaseDate = 2012 },
            new MovieData() { Title = "Dredd", Cast = new string[] { "Cast4_1", "Cast4_2", "Cast4_3", "Cast4_4" }, Classification = "MA", MovieId = 4, Genre = "G6", Rating = 20, ReleaseDate = 2013 },
        };

        [TestMethod]
        public void TestMethod_Get()
        {
            // Arrange
            mockMovieRepo = new Mock<IMovieRepo>(MockBehavior.Strict);
            mockMovieRepo.Setup(p => p.Get()).Returns(mockMovieList);
            var moviesController = new MoviesController(mockMovieRepo.Object);

            // Act
            var contentResult = moviesController.Get();

            // Assert
            Assert.AreEqual(contentResult.Count, 4);
            Assert.AreEqual(contentResult[0].Title, "The Simpsons Movie");
        }

        [TestMethod]
        public void TestMethod_Post()
        {
            // Arrange
            mockMovieRepo = new Mock<IMovieRepo>();
            mockMovieRepo.Setup(p => p.Post(mockMovieList[0]));
            var moviesController = new MoviesController(mockMovieRepo.Object);

            // Act
            moviesController.Post(mockMovieList[0]);

            // Assert
            mockMovieRepo.Verify(m => m.Post(mockMovieList[0]), Times.Once);
        }


        [TestMethod]
        public void TestMethod_Sort()
        {
            // Arrange
            mockMovieRepo = new Mock<IMovieRepo>();
            
            var moviesController = new MoviesController(mockMovieRepo.Object);
            moviesController.movieList = mockMovieList;


            // Act
            //order by title
            var result1 = moviesController.OrderMovies(moviesController.movieList,"Title");
            var result2 = moviesController.OrderMovies(moviesController.movieList, "Classification");
            var result3 = moviesController.OrderMovies(moviesController.movieList, "Genre");

            // Assert
            Assert.AreEqual("Dredd", result1[0].Title);
            Assert.AreEqual("A", result2[0].Classification);
            Assert.AreEqual("G1", result3[0].Genre);
        }

        [TestMethod]
        public void TestMethod_Insert()
        {
            // Arrange
            mockMovieRepo = new Mock<IMovieRepo>();
            mockMovieRepo.Setup(p => p.Post(mockMovieList[0]));
            var moviesController = new MoviesController(mockMovieRepo.Object);

            // Act
            moviesController.Post(mockMovieList[0]);

            // Assert
            mockMovieRepo.Verify(m => m.Post(mockMovieList[0]), Times.Once);
        }
    }
}
