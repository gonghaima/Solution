using System.Collections.Generic;
using System.Web.Http;
using MoviesLibrary;
using System.Web.Http.Cors;
using CommSec.Api.Movie.Repository;
using System.Web.UI;
using System.Web.Mvc;
using System.Linq;
using System.Reflection;
using CommSec.Api.Movie.Services;

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
        private readonly IMovieHelper movieHelper;
        public List<MovieData> movieList;

        public MoviesController(IMovieRepo movieRepository, IMovieHelper movieHelper)
        {
            this.movieRepo = movieRepository;
            this.movieHelper = movieHelper;
        }

        // GET api/values
        [System.Web.Http.HttpGet]
        [OutputCache(Duration = 86400, VaryByParam = "none", Location = OutputCacheLocation.ServerAndClient)]
        public List<MovieData> Get(string orderBy = "")
        {
            movieList = movieRepo.Get();
            if (orderBy != string.Empty)
            {
                movieList = this.movieHelper.OrderMovies(movieList, orderBy);
            }
            return movieList;
        }

        [System.Web.Http.HttpGet]
        [OutputCache(Duration = 86400, VaryByParam = "none", Location = OutputCacheLocation.ServerAndClient)]
        public List<MovieData> Search(string k)
        {
            return this.movieHelper.Search(this.movieList,k);
        }


        [System.Web.Http.HttpPost]
        public void Post([FromBody]MovieData value)
        {
            movieRepo.Post(value);
        }

        [System.Web.Http.HttpPost]
        public void Create([FromBody]MovieData value)
        {
            movieRepo.Create(value);
        }

        [System.Web.Http.HttpDelete]
        public bool Delete(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
