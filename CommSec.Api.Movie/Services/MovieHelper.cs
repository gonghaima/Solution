using MoviesLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CommSec.Api.Movie.Services
{
    public class MovieHelper : IMovieHelper
    {
        public List<MovieData> Search(List<MovieData> movieList, string k)
        {
            var searchResult = movieList.Where(record => record.Cast.Contains(k) ||
            record.Classification.Contains(k) ||
            record.Genre.Contains(k) ||
            record.Rating.ToString().Contains(k) ||
            record.ReleaseDate.ToString().Contains(k) ||
            record.Title.Contains(k)).ToList();
            return searchResult;
        }

        public List<MovieData> OrderMovies(List<MovieData> movieList, string keyword)
        {
            var propertyInfo = movieList.First().GetType().GetProperty(keyword, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            return movieList.OrderBy(e => propertyInfo.GetValue(e, null)).ToList();
        }
    }
}