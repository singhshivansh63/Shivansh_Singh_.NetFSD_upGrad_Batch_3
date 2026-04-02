using MovieApp.Data;
using MovieApp.Models;
using MovieApp.Repository.Interfaces;

namespace MovieApp.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAll() => _context.Movies.ToList();
        public Movie GetById(int id) => _context.Movies.FirstOrDefault(m => m.Id == id);

        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
        }

        public void Update(Movie movie)
        {
            _context.Movies.Update(movie);
        }

        public void Delete(int id)
        {
            var movie = GetById(id);
            if (movie != null) _context.Movies.Remove(movie);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}