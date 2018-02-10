using System.Collections.Generic;
using MoviesLibrary;

namespace CommSec.Api.Movie.Services
{
    public interface IMovieHelper
    {
        List<MovieData> OrderMovies(List<MovieData> movieList, string keyword);
        List<MovieData> Search(List<MovieData> movieList, string k);
    }
}