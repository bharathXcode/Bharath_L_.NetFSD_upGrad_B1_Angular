using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.Models;

namespace MovieApp.Business
{
    public interface IMovieService
    {
        List<Movie> GetMovies();
        Movie GetMovieById(int id);
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int id);
    }
}
