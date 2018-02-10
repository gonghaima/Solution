using System.Collections.Generic;
using MoviesLibrary;

namespace CommSec.Api.Movie.Repository
{
    public interface IMovieRepo
    {
        bool Delete(string id);
        List<MovieData> Get();
        void Post(MovieData movieData);
        void Create(MovieData movieData);
    }
}