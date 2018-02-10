using System.Collections.Generic;
using System.Web.Http;
using MoviesLibrary;
using System.Web.Http.Cors;
using CommSec.Api.Movie.Repository;
using System.Web.UI;
using System.Web.Mvc;
using System.Linq;
using System;
using System.Reflection;

namespace CommSec.Api.Movie.Controllers
{

    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class MoviesController : ApiController
    {
        // Below is just the sample code from the Visual Studio Web Api Template. 
        // Feel free to replace this with whatever implementation you feel is suitable and production ready for a web api.

        // Calling the 3rd party api is expensive and its data only gets updated every 24 hours. Caching can help with this.

        // MoviesLibrary is referenced in this project from ../packages/MoviesLibrary.1.0.0/MoviesLibrary.dll. You can restructure this solution as you like.

        //IMovieRepo movieRepo;
        private readonly IMovieRepo movieRepo;
        public List<MovieData> movieList;

        public MoviesController(IMovieRepo movieRepository)
        {
            this.movieRepo = movieRepository;
        }

        // GET api/values
        [System.Web.Http.HttpGet]
        [OutputCache(Duration = 86400, VaryByParam = "none", Location = OutputCacheLocation.ServerAndClient)]
        public List<MovieData> Get(string orderBy = "")
        {
            movieList = movieRepo.Get();
            if (orderBy != string.Empty)
            {
                movieList = OrderMovies(movieList, orderBy);
            }
            return movieList;
        }

        public List<MovieData> OrderMovies(List<MovieData> movieList, string keyword)
        {
            var propertyInfo = movieList.First().GetType().GetProperty(keyword, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            return movieList.OrderBy(e => propertyInfo.GetValue(e, null)).ToList();
        }

        [System.Web.Http.HttpGet]
        [OutputCache(Duration = 86400, VaryByParam = "none", Location = OutputCacheLocation.ServerAndClient)]
        public List<MovieData> Search(string k)
        {
            var searchResult = this.movieList.Where(record => record.Cast.Contains(k) ||
            record.Classification.Contains(k) ||
            record.Genre.Contains(k) ||
            record.Rating.ToString().Contains(k) ||
            record.ReleaseDate.ToString().Contains(k) ||
            record.Title.Contains(k)).ToList();
            return searchResult;
        }

        [System.Web.Http.HttpPost]
        public void Post([FromBody]MovieData value)
        {
            movieRepo.Post(value);
        }

        [System.Web.Http.HttpDelete]
        public bool Delete(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
