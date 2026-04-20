using MovieApp.Data;
using MovieApp.Data.Models;

namespace MovieApp.Business
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _context;
        public MovieService(AppDbContext context)
        {
            _context = context;
        }
        public void AddMovie(Movie movie)
        {
            _context.movies.Add(movie);
            _context.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var movie = _context.movies.Find(id);
            if(movie != null)
            {
                _context.movies.Remove(movie);
                _context.SaveChanges();
            }
        }

        public Movie GetMovieById(int id)
        {
            return _context.movies.Find(id);
        }

        public List<Movie> GetMovies()
        {
            return _context.movies.ToList();
        }

        public void UpdateMovie(Movie movie)
        {
            _context.movies.Update(movie);
            _context.SaveChanges();
        }
    }
}
