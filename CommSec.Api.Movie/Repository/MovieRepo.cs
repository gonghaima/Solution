using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoviesLibrary;

namespace CommSec.Api.Movie.Repository
{
    public class MovieRepo : IMovieRepo
    {
        MoviesLibrary.MovieDataSource moviesLibraryDS;
        public MovieRepo(){
            moviesLibraryDS = new MovieDataSource();
        }
        bool IMovieRepo.Delete(string id)
        {
            this.moviesLibraryDS.GetAllData();
            return true;
        }

        List<MovieData> IMovieRepo.Get()
        {
            var ml = this.moviesLibraryDS.GetAllData();
            return ml;
        }

        void IMovieRepo.Post(MovieData movieData)
        {
            this.moviesLibraryDS.Update(movieData);
        }

        void IMovieRepo.Put(int id, MovieData movieData)
        {
            this.moviesLibraryDS.Update(movieData);
        }
    }
}