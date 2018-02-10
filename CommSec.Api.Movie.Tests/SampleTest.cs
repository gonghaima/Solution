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
        [TestMethod]
        public void TestMethod_Get()
        {
            // Arrange
            mockMovieRepo = new Mock<IMovieRepo>(MockBehavior.Strict);
            mockMovieRepo.Setup(p => p.Get()).Returns(new List<MovieData> { new MovieData { Title = "test" } });
            var moviesController = new MoviesController(mockMovieRepo.Object);

            // Act
            var contentResult = moviesController.Get();

            // Assert
            Assert.AreEqual(contentResult.Count, 1);
            Assert.AreEqual(contentResult[0].Title, "test");
        }

        [TestMethod]
        public void TestMethod_Post()
        {
            // Arrange
            mockMovieRepo = new Mock<IMovieRepo>();
            MovieData mockMovieData = new MovieData { Title = "test" };
            mockMovieRepo.Setup(p => p.Post(new MovieData { Title = "test" }));
            var moviesController = new MoviesController(mockMovieRepo.Object);

            // Act
            moviesController.Post(mockMovieData);

            // Assert
            mockMovieRepo.Verify(m => m.Post(mockMovieData), Times.Once);
        }
    }
}
