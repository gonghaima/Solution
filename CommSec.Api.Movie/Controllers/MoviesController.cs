using System.Collections.Generic;
using System.Web.Http;
using MoviesLibrary;
using System.Web.Http.Cors;
using CommSec.Api.Movie.Repository;
using System.Web.UI;
using System.Web.Mvc;

namespace CommSec.Api.Movie.Controllers
{

    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    //[EnableCors(origins: "http://localhost:4200",headers: "accept,content-type,origin,x-my-header", methods: "get,post,put,delete")]
    public class MoviesController : ApiController
    {
        // Below is just the sample code from the Visual Studio Web Api Template. 
        // Feel free to replace this with whatever implementation you feel is suitable and production ready for a web api.

        // Calling the 3rd party api is expensive and its data only gets updated every 24 hours. Caching can help with this.

        // MoviesLibrary is referenced in this project from ../packages/MoviesLibrary.1.0.0/MoviesLibrary.dll. You can restructure this solution as you like.

        IMovieRepo movieRepo;
        public MoviesController()
        {
            movieRepo = new MovieRepo();
        }

        public MoviesController(IMovieRepo movieRepository)
        {
            movieRepo = movieRepository;
        }

        // GET api/values
        [System.Web.Http.HttpGet]
        [OutputCache(Duration = 86400, VaryByParam = "none", Location = OutputCacheLocation.ServerAndClient)]
        public List<MovieData> Get()
        {
            var movieList = movieRepo.Get();
            return movieList;
        }

        [System.Web.Http.HttpPost]
        public void Post([FromBody]MovieData value)
        {
            movieRepo.Post(value);
        }


        //[System.Web.Http.HttpPut]
        //public void Put(int id, [FromBody]MovieData value)
        //{
        //    movieRepo.Put(id, value);
        //}

        [System.Web.Http.HttpDelete]
        public bool Delete(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
